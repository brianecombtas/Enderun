using Enderun.Logic;
using Interop.QBFC16;
using Microsoft.Extensions.Configuration;
using Serilog;
using static Enderun.Models.InterfaceAPIModels;

namespace Enderun
{
    public class JournalEntryProcess
    {
        private IConfigurationSection? systemMessages = Program.Configuration.GetSection("SystemMessages");
        private IConfigurationSection? chartOfAccounts = Program.Configuration.GetSection("ChartOfAccounts");
        public void DoAccountAdd(List<AcctInterfaces> entries, string region)
        {
            try
            {
                //Create the session Manager object
                QBSessionManager sessionManager = new QBSessionManager();

                //Create the message set request object to hold our request
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(region, 16, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                MapJournalAddRq(requestMsgSet, entries, region);

                //Connect to QuickBooks and begin a session
                sessionManager.OpenConnection("", systemMessages?.GetSection("EJ-002").Value);
                sessionManager.BeginSession("", ENOpenMode.omDontCare);

                //Send the request and get the response from QuickBooks
                IResponse response = sessionManager.DoRequests(requestMsgSet).ResponseList.GetAt(0);
                if (response.StatusCode != 0)
                {
                    var asdasd = systemMessages?.GetSection("E3").Value;
                    MessageBox.Show(systemMessages?.GetSection("E3").Value);
                    Log.Error($"{systemMessages?.GetSection("EJ-001").Value}{response.StatusMessage}");
                    return;
                }

                MessageBox.Show(systemMessages?.GetSection("EJ-003").Value);
                Log.Information($"{systemMessages?.GetSection("EJ-003").Value}");


                //End the session and close the connection to QuickBooks
                sessionManager.EndSession();
                sessionManager.CloseConnection();
            }
            catch (Exception e)
            {
                Log.Error($"{systemMessages?.GetSection("EJ-001").Value}{e.Message}{e.StackTrace}");
                MessageBox.Show(systemMessages?.GetSection("E3").Value);
            }
        }

        public string[] vendor = { "BABY FIRST", "FLOWER BOY", "MARCAYDA BAKERY", "ALFAMART BUCAL", "MARVINS ROOM" };

        void MapJournalAddRq(IMsgSetRequest requestMsgSet, List<AcctInterfaces> entries, string region)
        {
            foreach (var entry in entries)
            {
                try
                {
                    Random rand = new Random();
                    var randomAmount = Math.Round(Convert.ToDouble(rand.Next(100) * Math.PI), 2);

                    #region Header
                    //// HEADER
                    IJournalEntryAdd journal = requestMsgSet.AppendJournalEntryAddRq();
                    journal.TxnDate.SetValue(entry.ExpenseApprovedDate ?? DateTime.Now); // -------------------- TRANSACTION DATE
                    journal.RefNumber.SetValue(entry.TasNo); // --------------------------- REFERENCE NUMBER
                    journal.IsAdjustment.SetValue(true); // --------------------------------------- IS ADJUSTMENT (TRUE/FALSE)
                    journal.ExternalGUID.SetValue(System.Guid.NewGuid().ToString("B")); // -------- ID (WE THINK THIS IS ONLY A UNIQUE ID FOR THE REQUEST)
                    #endregion

                    #region Debit
                    //// DEBIT LINE
                    IORJournalLine journalLineDebit = journal.ORJournalLineList.Append();
                    journalLineDebit.JournalDebitLine.Amount.SetValue(string.IsNullOrEmpty(entry.AmountOrg.ToString()) ? 0 : (double)entry.AmountOrg);  // ----------------------------------------------------- AMOUNT
                    journalLineDebit.JournalDebitLine.AccountRef.FullName.SetValue(chartOfAccounts?.GetSection($"{rand.Next(40)}").Value); //- CHART OF ACCOUNTS (SETUP IN QUICKBOOKS)
                    journalLineDebit.JournalDebitLine.EntityRef.FullName.SetValue(entry.WorkerCode);
                    journalLineDebit.JournalDebitLine.Memo.SetValue($"{entry.TasNo.ToUpper()}{entry.CustomItemName.ToUpper()}");

                    if (region.Equals("US"))
                        journalLineDebit.JournalDebitLine.ClassRef.FullName.SetValue("TestClass1");
                    #endregion

                    #region Credit
                    //// CREDIT LINE
                    IORJournalLine journalLineCredit = journal.ORJournalLineList.Append();
                    journalLineCredit.JournalCreditLine.Amount.SetValue(string.IsNullOrEmpty(entry.AmountOrg.ToString()) ? 0 : (double)entry.AmountOrg); // ----------------------------------------------------- AMOUNT
                    journalLineCredit.JournalCreditLine.AccountRef.FullName.SetValue(chartOfAccounts?.GetSection("6").Value);//- ACCOUNTS PAYABLE
                    journalLineCredit.JournalCreditLine.EntityRef.FullName.SetValue(entry.WorkerCode);
                    journalLineCredit.JournalCreditLine.Memo.SetValue($"{entry.TasNo.ToUpper()}{entry.CustomItemName.ToUpper()}");

                    if (region.Equals("US"))
                        journalLineCredit.JournalCreditLine.ClassRef.FullName.SetValue("TestClass1");
                    #endregion

                    journal.IncludeRetElementList.Add("ab");
                }
                catch (Exception err)
                {
                    Log.Error($"{systemMessages?.GetSection("EJ-001").Value}{err.Message} - ({entry.WorkerCode}-{entry.TasNo})");
                    continue;
                }
            }
        }
    }
}
