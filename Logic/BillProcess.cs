﻿using Interop.QBFC16;
using Microsoft.Extensions.Configuration;
using Serilog;
using static Enderun.Models.InterfaceAPIModels;

namespace Enderun.Logic
{
    public class BillProcess
    {

        //The following sample code is generated as an illustration of
        //Creating requests and parsing responses ONLY
        //This code is NOT intended to show best practices or ideal code
        //Use at your most careful discretion
        private IConfigurationSection? systemMessages = Program.Configuration.GetSection("SystemMessages");
        private IConfigurationSection? chartOfAccounts = Program.Configuration.GetSection("ChartOfAccounts");

        public void DoBillAdd(List<AcctInterfaces> bills, string region)
        {
            try
            {
                //Create the session Manager object
                QBSessionManager? sessionManager = new QBSessionManager();

                //Create the message set request object to hold our request
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest(region, 16, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                MapBillAddRq(requestMsgSet, bills, region);

                //Connect to QuickBooks and begin a session
                sessionManager.OpenConnection("", systemMessages?.GetSection("EB-002").Value);
                sessionManager.BeginSession("", ENOpenMode.omDontCare);

                //Send the request and get the response from QuickBooks
                IResponse response = sessionManager.DoRequests(requestMsgSet).ResponseList.GetAt(0);
                if (response.StatusCode != 0)
                {
                    var asdasd = systemMessages?.GetSection("E3").Value;
                    MessageBox.Show(systemMessages?.GetSection("E3").Value);
                    Log.Error($"{systemMessages?.GetSection("EB-001").Value}{response.StatusMessage}");
                    return;
                }

                MessageBox.Show(systemMessages?.GetSection("EB-003").Value);
                Log.Information($"{systemMessages?.GetSection("EB-003").Value}");

                //End the session and close the connection to QuickBooks
                sessionManager.EndSession();
                sessionManager.CloseConnection();
            }
            catch (Exception e)
            {
                Log.Information($"{systemMessages?.GetSection("EB-001").Value}{e.Message}{e.StackTrace}");
                MessageBox.Show(systemMessages?.GetSection("E3").Value);
            }
        }

        public string[] vendor = { "BABY FIRST", "FLOWER BOY", "MARCAYDA BAKERY", "ALFAMART BUCAL", "MARVINS ROOM" };
        void MapBillAddRq(IMsgSetRequest requestMsgSet, List<AcctInterfaces> billsList, string region)
        {
            foreach (var bills in billsList)
            {
                try
                {
                    Random rand = new Random();
                    var randomAmount = Math.Round(Convert.ToDouble(rand.Next(100) * Math.PI), 2);

                    #region Header
                    //// HEADER
                    IBillAdd add = requestMsgSet.AppendBillAddRq();
                    add.ExternalGUID.SetValue(Guid.NewGuid().ToString("B"));
                    add.VendorRef.FullName.SetValue(bills.WorkerCode);  /// -------------- ACCOUNT CODE?
                    add.TxnDate.SetValue(bills.ExpenseApprovedDate ?? DateTime.Now);  /// ------------------------------- TRANSACTION DATE
                    add.DueDate.SetValue(DateTime.Today.AddMonths(4)); // -------------------- DUE DATE
                    add.Memo.SetValue($"{bills.TasNo.ToUpper()}{bills.CustomItemName.ToUpper()}"); // -------------------- MEMO (WE THINK THESE ARE REMARKS)
                    #endregion

                    #region Expenses
                    ////       EXPENSE LINE
                    IExpenseLineAdd line = add.ExpenseLineAddList.Append();
                    line.AccountRef.FullName.SetValue(chartOfAccounts?.GetSection($"{rand.Next(40)}").Value); // ------------ CHART OF ACCOUNTS
                    line.Amount.SetValue(string.IsNullOrEmpty(bills.AmountOrg.ToString()) ? 0 : (double)bills.AmountOrg); // --------------------- AMOUNT

                    if (region.Equals("US"))
                        line.ClassRef.FullName.SetValue("TestClass1"); // ------------------------------------------------------- CLASS TYPE (SETUP IN QUICKBOOKS)
                    #endregion

                    #region Item
                    ////       ITEM LINE
                    IORItemLineAdd item = add.ORItemLineAddList.Append();
                    item.ItemLineAdd.ItemRef.FullName.SetValue("0002"); // ------------------------------------------ ITEM TYPE (SETUP IN QUICKBOOKS)
                    item.ItemLineAdd.TaxAmount.SetValue(rand.Next(10)); // ------------------------------------------ TAX AMOUNT
                    item.ItemLineAdd.Cost.SetValue(string.IsNullOrEmpty(bills.TotalMng.ToString()) ? 0 : (double)bills.TotalMng); // --- AMOUNT/COST
                    #endregion

                }
                catch (Exception err)
                {
                    Log.Error($"{systemMessages?.GetSection("EB-001").Value}{err.Message} - ({bills.WorkerCode}-{bills.TasNo})");
                    continue;
                }
            }
        }
    }
}
