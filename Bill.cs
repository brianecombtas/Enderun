using Interop.QBFC16;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Enderun
{
    public class Bill
    {

        //The following sample code is generated as an illustration of
        //Creating requests and parsing responses ONLY
        //This code is NOT intended to show best practices or ideal code
        //Use at your most careful discretion
        private IConfigurationSection? systemMessages = Program.Configuration.GetSection("SystemMessages");

        public void DoBillAdd()
        {
            try
            {
                //Create the session Manager object
                QBSessionManager? sessionManager = new QBSessionManager();

                //Create the message set request object to hold our request
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest("US", 16, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                MapBillAddRq(requestMsgSet);

                //Connect to QuickBooks and begin a session
                sessionManager.OpenConnection("", systemMessages?.GetSection("EB-002").Value);
                sessionManager.BeginSession("", ENOpenMode.omDontCare);

                //Send the request and get the response from QuickBooks
                IResponse response = sessionManager.DoRequests(requestMsgSet).ResponseList.GetAt(0);
                if (response.StatusCode != 0)
                {
                    MessageBox.Show(systemMessages?.GetSection("E3").Value, "Error");
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
                Log.Information($"{systemMessages?.GetSection("EB-001").Value}{e.Message}");
                MessageBox.Show(systemMessages?.GetSection("E3").Value, "Error");
            }
        }


        void MapBillAddRq(IMsgSetRequest requestMsgSet)
        {
            Random rand = new Random();
            var randomAmount = Math.Round(Convert.ToDouble(rand.Next(100) * Math.PI), 2);

            IBillAdd add = requestMsgSet.AppendBillAddRq();
            add.ExternalGUID.SetValue(System.Guid.NewGuid().ToString("B"));
            add.VendorRef.FullName.SetValue("BABY FIRST");
            add.TxnDate.SetValue(DateTime.Today);
            add.DueDate.SetValue(DateTime.Today.AddMonths(4));
            add.Memo.SetValue("TESTING");

            ////       EXPENSE LINE
            IExpenseLineAdd line = add.ExpenseLineAddList.Append();
            line.AccountRef.FullName.SetValue("Sales - Software");
            line.Amount.SetValue(randomAmount);
            line.ClassRef.FullName.SetValue("TestClass1");

            ////       ITEM LINE
            IORItemLineAdd item = add.ORItemLineAddList.Append();
            item.ItemLineAdd.ItemRef.FullName.SetValue("0002");
            item.ItemLineAdd.TaxAmount.SetValue(rand.Next(10));
            item.ItemLineAdd.Cost.SetValue(randomAmount);
        }


    }
}
