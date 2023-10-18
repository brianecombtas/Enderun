using Interop.QBFC16;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enderun
{
    public class JournalEntry
    {
        private IConfigurationSection? systemMessages = Program.Configuration.GetSection("SystemMessages");
        private IConfigurationSection? chartOfAccounts = Program.Configuration.GetSection("ChartOfAccounts");
        public void DoAccountAdd()
        {
            try
            {
                //Create the session Manager object
                QBSessionManager sessionManager = new QBSessionManager();

                //Create the message set request object to hold our request
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest("US", 16, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                MapJournalAddRq(requestMsgSet);

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

        void MapJournalAddRq(IMsgSetRequest requestMsgSet)
        {
            Random rand = new Random();
            var randomAmount = Math.Round(Convert.ToDouble(rand.Next(100) * Math.PI), 2);

            //// HEADER
            IJournalEntryAdd journal = requestMsgSet.AppendJournalEntryAddRq();
            journal.TxnDate.SetValue(DateTime.Today.AddMonths(-4)); // -------------------- TRANSACTION DATE
            journal.RefNumber.SetValue($"{rand.Next(100)}"); // --------------------------- REFERENCE NUMBER
            journal.IsAdjustment.SetValue(true); // --------------------------------------- IS ADJUSTMENT (TRUE/FALSE)
            journal.ExternalGUID.SetValue(System.Guid.NewGuid().ToString("B")); // -------- ID (WE THINK THIS IS ONLY A UNIQUE ID FOR THE REQUEST)

            //// DEBIT LINE
            ///
            var asdasd = chartOfAccounts?.GetSection($"{rand.Next(40)}").Value;
            IORJournalLine journalLineDebit = journal.ORJournalLineList.Append(); 
            journalLineDebit.JournalDebitLine.Amount.SetValue(randomAmount);  // ----------------------------------------------------- AMOUNT
            journalLineDebit.JournalDebitLine.AccountRef.FullName.SetValue(chartOfAccounts?.GetSection($"{rand.Next(40)}").Value); //- CHART OF ACCOUNTS (SETUP IN QUICKBOOKS)
            journalLineDebit.JournalDebitLine.EntityRef.FullName.SetValue(vendor[rand.Next(5)]);
            journalLineDebit.JournalDebitLine.ClassRef.FullName.SetValue("TestClass1");
            journalLineDebit.JournalDebitLine.Memo.SetValue($"TESTING_NO_{rand.Next(100)}");  

            //// CREDIT LINE
            IORJournalLine journalLineCredit = journal.ORJournalLineList.Append();
            journalLineCredit.JournalCreditLine.Amount.SetValue(randomAmount); // ----------------------------------------------------- AMOUNT
            journalLineCredit.JournalCreditLine.AccountRef.FullName.SetValue(chartOfAccounts?.GetSection("6").Value);//- ACCOUNTS PAYABLE
            journalLineCredit.JournalCreditLine.EntityRef.FullName.SetValue(vendor[rand.Next(5)]);
            journalLineCredit.JournalCreditLine.ClassRef.FullName.SetValue("TestClass1");
            journalLineCredit.JournalCreditLine.Memo.SetValue($"TESTING_NO_{rand.Next(100)}");

            journal.IncludeRetElementList.Add("ab");
        }
    }
}
