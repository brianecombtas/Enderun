using Interop.QBFC16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enderun
{
    public class JournalEntry
    {
        public void DoAccountAdd()
        {
            bool sessionBegun = false;
            bool connectionOpen = false;
            QBSessionManager sessionManager = null;

            try
            {
                //Create the session Manager object
                sessionManager = new QBSessionManager();

                //Create the message set request object to hold our request
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest("US", 16, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                BuildAccountAddRq(requestMsgSet);

                //Connect to QuickBooks and begin a session
                sessionManager.OpenConnection("", "Sample Code from OSR");
                connectionOpen = true;
                sessionManager.BeginSession("", ENOpenMode.omDontCare);
                sessionBegun = true;

                //Send the request and get the response from QuickBooks
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);

                //End the session and close the connection to QuickBooks
                sessionManager.EndSession();
                sessionBegun = false;
                sessionManager.CloseConnection();
                connectionOpen = false;

                WalkAccountAddRs(responseMsgSet);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                if (sessionBegun)
                {
                    sessionManager.EndSession();
                }
                if (connectionOpen)
                {
                    sessionManager.CloseConnection();
                }
            }
        }
        void BuildAccountAddRq(IMsgSetRequest requestMsgSet)
        {
            IAccountAdd AccountAddRq = requestMsgSet.AppendAccountAddRq();
            //Set field value for Name
            AccountAddRq.Name.SetValue("ab");
            //Set field value for IsActive
            AccountAddRq.IsActive.SetValue(true);
            //Set field value for ListID
            AccountAddRq.ParentRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            AccountAddRq.ParentRef.FullName.SetValue("ab");
            //Set field value for AccountType
            AccountAddRq.AccountType.SetValue(ENAccountType.atAccountsPayable);
            //Set field value for AccountNumber
            AccountAddRq.AccountNumber.SetValue("ab");
            //Set field value for BankNumber
            AccountAddRq.BankNumber.SetValue("ab");
            //Set field value for Desc
            AccountAddRq.Desc.SetValue("ab");
            //Set field value for OpenBalance
            AccountAddRq.OpenBalance.SetValue(10.01);
            //Set field value for OpenBalanceDate
            AccountAddRq.OpenBalanceDate.SetValue(DateTime.Parse("15/12/2007"));
            //Set field value for ListID
            AccountAddRq.SalesTaxCodeRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            AccountAddRq.SalesTaxCodeRef.FullName.SetValue("ab");
            //Set field value for TaxLineID
            AccountAddRq.TaxLineID.SetValue(6);
            //Set field value for ListID
            AccountAddRq.CurrencyRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            AccountAddRq.CurrencyRef.FullName.SetValue("ab");
            //Set field value for IncludeRetElementList
            //May create more than one of these if needed
            AccountAddRq.IncludeRetElementList.Add("ab");
        }




        void WalkAccountAddRs(IMsgSetResponse responseMsgSet)
        {
            if (responseMsgSet == null) return;
            IResponseList responseList = responseMsgSet.ResponseList;
            if (responseList == null) return;
            //if we sent only one request, there is only one response, we'll walk the list for this sample
            for (int i = 0; i < responseList.Count; i++)
            {
                IResponse response = responseList.GetAt(i);
                //check the status code of the response, 0=ok, >0 is warning
                if (response.StatusCode >= 0)
                {
                    //the request-specific response is in the details, make sure we have some
                    if (response.Detail != null)
                    {
                        //make sure the response is the type we're expecting
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtAccountAddRs)
                        {
                            //upcast to more specific type here, this is safe because we checked with response.Type check above
                            IAccountRet AccountRet = (IAccountRet)response.Detail;
                            WalkAccountRet(AccountRet);
                        }
                    }
                }
            }
        }




        void WalkAccountRet(IAccountRet AccountRet)
        {
            if (AccountRet == null) return;
            //Go through all the elements of IAccountRet
            //Get value of ListID
            string ListID313 = (string)AccountRet.ListID.GetValue();
            //Get value of TimeCreated
            DateTime TimeCreated314 = (DateTime)AccountRet.TimeCreated.GetValue();
            //Get value of TimeModified
            DateTime TimeModified315 = (DateTime)AccountRet.TimeModified.GetValue();
            //Get value of EditSequence
            string EditSequence316 = (string)AccountRet.EditSequence.GetValue();
            //Get value of Name
            string Name317 = (string)AccountRet.Name.GetValue();
            //Get value of FullName
            string FullName318 = (string)AccountRet.FullName.GetValue();
            //Get value of IsActive
            if (AccountRet.IsActive != null)
            {
                bool IsActive319 = (bool)AccountRet.IsActive.GetValue();
            }
            if (AccountRet.ParentRef != null)
            {
                //Get value of ListID
                if (AccountRet.ParentRef.ListID != null)
                {
                    string ListID320 = (string)AccountRet.ParentRef.ListID.GetValue();
                }
                //Get value of FullName
                if (AccountRet.ParentRef.FullName != null)
                {
                    string FullName321 = (string)AccountRet.ParentRef.FullName.GetValue();
                }
            }
            //Get value of Sublevel
            int Sublevel322 = (int)AccountRet.Sublevel.GetValue();
            //Get value of AccountType
            ENAccountType AccountType323 = (ENAccountType)AccountRet.AccountType.GetValue();
            //Get value of SpecialAccountType
            if (AccountRet.SpecialAccountType != null)
            {
                ENSpecialAccountType SpecialAccountType324 = (ENSpecialAccountType)AccountRet.SpecialAccountType.GetValue();
            }
            //Get value of IsTaxAccount
            if (AccountRet.IsTaxAccount != null)
            {
                bool IsTaxAccount325 = (bool)AccountRet.IsTaxAccount.GetValue();
            }
            //Get value of AccountNumber
            if (AccountRet.AccountNumber != null)
            {
                string AccountNumber326 = (string)AccountRet.AccountNumber.GetValue();
            }
            //Get value of BankNumber
            if (AccountRet.BankNumber != null)
            {
                string BankNumber327 = (string)AccountRet.BankNumber.GetValue();
            }
            //Get value of Desc
            if (AccountRet.Desc != null)
            {
                string Desc328 = (string)AccountRet.Desc.GetValue();
            }
            //Get value of Balance
            if (AccountRet.Balance != null)
            {
                double Balance329 = (double)AccountRet.Balance.GetValue();
            }
            //Get value of TotalBalance
            if (AccountRet.TotalBalance != null)
            {
                double TotalBalance330 = (double)AccountRet.TotalBalance.GetValue();
            }
            if (AccountRet.SalesTaxCodeRef != null)
            {
                //Get value of ListID
                if (AccountRet.SalesTaxCodeRef.ListID != null)
                {
                    string ListID331 = (string)AccountRet.SalesTaxCodeRef.ListID.GetValue();
                }
                //Get value of FullName
                if (AccountRet.SalesTaxCodeRef.FullName != null)
                {
                    string FullName332 = (string)AccountRet.SalesTaxCodeRef.FullName.GetValue();
                }
            }
            if (AccountRet.TaxLineInfoRet != null)
            {
                //Get value of TaxLineID
                int TaxLineID333 = (int)AccountRet.TaxLineInfoRet.TaxLineID.GetValue();
                //Get value of TaxLineName
                if (AccountRet.TaxLineInfoRet.TaxLineName != null)
                {
                    string TaxLineName334 = (string)AccountRet.TaxLineInfoRet.TaxLineName.GetValue();
                }
            }
            //Get value of CashFlowClassification
            if (AccountRet.CashFlowClassification != null)
            {
                ENCashFlowClassification CashFlowClassification335 = (ENCashFlowClassification)AccountRet.CashFlowClassification.GetValue();
            }
            if (AccountRet.CurrencyRef != null)
            {
                //Get value of ListID
                if (AccountRet.CurrencyRef.ListID != null)
                {
                    string ListID336 = (string)AccountRet.CurrencyRef.ListID.GetValue();
                }
                //Get value of FullName
                if (AccountRet.CurrencyRef.FullName != null)
                {
                    string FullName337 = (string)AccountRet.CurrencyRef.FullName.GetValue();
                }
            }
            if (AccountRet.DataExtRetList != null)
            {
                for (int i338 = 0; i338 < AccountRet.DataExtRetList.Count; i338++)
                {
                    IDataExtRet DataExtRet = AccountRet.DataExtRetList.GetAt(i338);
                    //Get value of OwnerID
                    if (DataExtRet.OwnerID != null)
                    {
                        string OwnerID339 = (string)DataExtRet.OwnerID.GetValue();
                    }
                    //Get value of DataExtName
                    string DataExtName340 = (string)DataExtRet.DataExtName.GetValue();
                    //Get value of DataExtType
                    ENDataExtType DataExtType341 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                    //Get value of DataExtValue
                    string DataExtValue342 = (string)DataExtRet.DataExtValue.GetValue();
                }
            }
        }
    }
}
