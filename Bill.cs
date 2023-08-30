using Interop.QBFC16;

namespace Enderun
{
    public class Bill
    {

        //The following sample code is generated as an illustration of
        //Creating requests and parsing responses ONLY
        //This code is NOT intended to show best practices or ideal code
        //Use at your most careful discretion
        public void DoBillAdd()
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

                BuildBillAddRq(requestMsgSet);

                //Send the request and get the response from QuickBooks
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);

                //End the session and close the connection to QuickBooks
                sessionManager.EndSession();
                sessionBegun = false;
                sessionManager.CloseConnection();
                connectionOpen = false;

                WalkBillAddRs(responseMsgSet);
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
        void BuildBillAddRq(IMsgSetRequest requestMsgSet)
        {
            IBillAdd BillAddRq = requestMsgSet.AppendBillAddRq();
            //Set attributes
            //Set field value for defMacro
            BillAddRq.defMacro.SetValue("IQBStringType");
            //Set field value for ListID
            BillAddRq.VendorRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            BillAddRq.VendorRef.FullName.SetValue("ab");
            //Set field value for Addr1
            BillAddRq.VendorAddress.Addr1.SetValue("ab");
            //Set field value for Addr2
            BillAddRq.VendorAddress.Addr2.SetValue("ab");
            //Set field value for Addr3
            BillAddRq.VendorAddress.Addr3.SetValue("ab");
            //Set field value for Addr4
            BillAddRq.VendorAddress.Addr4.SetValue("ab");
            //Set field value for Addr5
            BillAddRq.VendorAddress.Addr5.SetValue("ab");
            //Set field value for City
            BillAddRq.VendorAddress.City.SetValue("ab");
            //Set field value for State
            BillAddRq.VendorAddress.State.SetValue("ab");
            //Set field value for PostalCode
            BillAddRq.VendorAddress.PostalCode.SetValue("ab");
            //Set field value for Country
            BillAddRq.VendorAddress.Country.SetValue("ab");
            //Set field value for Note
            BillAddRq.VendorAddress.Note.SetValue("ab");
            //Set field value for ListID
            BillAddRq.APAccountRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            BillAddRq.APAccountRef.FullName.SetValue("ab");
            //Set field value for TxnDate
            BillAddRq.TxnDate.SetValue(DateTime.Parse("15/12/2007"));
            //Set field value for DueDate
            BillAddRq.DueDate.SetValue(DateTime.Parse("15/12/2007"));
            //Set field value for RefNumber
            BillAddRq.RefNumber.SetValue("ab");
            //Set field value for ListID
            BillAddRq.TermsRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            BillAddRq.TermsRef.FullName.SetValue("ab");
            //Set field value for Memo
            BillAddRq.Memo.SetValue("ab");
            //Set field value for IsTaxIncluded
            BillAddRq.IsTaxIncluded.SetValue(true);
            //Set field value for ListID
            BillAddRq.SalesTaxCodeRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            BillAddRq.SalesTaxCodeRef.FullName.SetValue("ab");
            //Set field value for ExchangeRate
            BillAddRq.ExchangeRate.SetValue(5);
            //Set field value for ExternalGUID
            BillAddRq.ExternalGUID.SetValue(Guid.NewGuid().ToString());
            //Set field value for LinkToTxnIDList
            //May create more than one of these if needed
            BillAddRq.LinkToTxnIDList.Add("200000-1011023419");
            IExpenseLineAdd ExpenseLineAdd549 = BillAddRq.ExpenseLineAddList.Append();
            //Set attributes
            //Set field value for defMacro
            ExpenseLineAdd549.defMacro.SetValue("IQBStringType");
            //Set field value for ListID
            ExpenseLineAdd549.AccountRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            ExpenseLineAdd549.AccountRef.FullName.SetValue("ab");
            //Set field value for Amount
            ExpenseLineAdd549.Amount.SetValue(10.01);
            //Set field value for Memo
            ExpenseLineAdd549.Memo.SetValue("ab");
            //Set field value for ListID
            ExpenseLineAdd549.CustomerRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            ExpenseLineAdd549.CustomerRef.FullName.SetValue("ab");
            //Set field value for ListID
            ExpenseLineAdd549.ClassRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            ExpenseLineAdd549.ClassRef.FullName.SetValue("ab");
            //Set field value for ListID
            ExpenseLineAdd549.SalesTaxCodeRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            ExpenseLineAdd549.SalesTaxCodeRef.FullName.SetValue("ab");
            //Set field value for BillableStatus
            ExpenseLineAdd549.BillableStatus.SetValue(ENBillableStatus.bsBillable);
            //Set field value for ListID
            ExpenseLineAdd549.SalesRepRef.ListID.SetValue("200000-1011023419");
            //Set field value for FullName
            ExpenseLineAdd549.SalesRepRef.FullName.SetValue("ab");
            IDataExt DataExt550 = ExpenseLineAdd549.DataExtList.Append();
            //Set field value for OwnerID
            DataExt550.OwnerID.SetValue(Guid.NewGuid().ToString());
            //Set field value for DataExtName
            DataExt550.DataExtName.SetValue("ab");
            //Set field value for DataExtValue
            DataExt550.DataExtValue.SetValue("ab");
            IORItemLineAdd ORItemLineAddListElement551 = BillAddRq.ORItemLineAddList.Append();
            string ORItemLineAddListElementType552 = "ItemLineAdd";
            if (ORItemLineAddListElementType552 == "ItemLineAdd")
            {
                //Set field value for ListID
                ORItemLineAddListElement551.ItemLineAdd.ItemRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemLineAdd.ItemRef.FullName.SetValue("ab");
                //Set field value for ListID
                ORItemLineAddListElement551.ItemLineAdd.InventorySiteRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemLineAdd.InventorySiteRef.FullName.SetValue("ab");
                //Set field value for ListID
                ORItemLineAddListElement551.ItemLineAdd.InventorySiteLocationRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemLineAdd.InventorySiteLocationRef.FullName.SetValue("ab");
                string ORSerialLotNumberElementType553 = "SerialNumber";
                if (ORSerialLotNumberElementType553 == "SerialNumber")
                {
                    //Set field value for SerialNumber
                    ORItemLineAddListElement551.ItemLineAdd.ORSerialLotNumber.SerialNumber.SetValue("ab");
                }
                if (ORSerialLotNumberElementType553 == "LotNumber")
                {
                    //Set field value for LotNumber
                    ORItemLineAddListElement551.ItemLineAdd.ORSerialLotNumber.LotNumber.SetValue("ab");
                }
                //Get value of Expiration Date
                ORItemLineAddListElement551.ItemLineAdd.ExpirationDateForSerialLotNumber.SetValue("2022-09-22");
                //Set field value for Desc
                ORItemLineAddListElement551.ItemLineAdd.Desc.SetValue("ab");
                //Set field value for Quantity
                ORItemLineAddListElement551.ItemLineAdd.Quantity.SetValue(2);
                //Set field value for UnitOfMeasure
                ORItemLineAddListElement551.ItemLineAdd.UnitOfMeasure.SetValue("ab");
                //Set field value for Cost
                ORItemLineAddListElement551.ItemLineAdd.Cost.SetValue(15.65);
                //Set field value for Amount
                ORItemLineAddListElement551.ItemLineAdd.Amount.SetValue(10.01);
                //Set field value for ListID
                ORItemLineAddListElement551.ItemLineAdd.CustomerRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemLineAdd.CustomerRef.FullName.SetValue("ab");
                //Set field value for ListID
                ORItemLineAddListElement551.ItemLineAdd.ClassRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemLineAdd.ClassRef.FullName.SetValue("ab");
                //Set field value for ListID
                ORItemLineAddListElement551.ItemLineAdd.SalesTaxCodeRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemLineAdd.SalesTaxCodeRef.FullName.SetValue("ab");
                //Set field value for BillableStatus
                ORItemLineAddListElement551.ItemLineAdd.BillableStatus.SetValue(ENBillableStatus.bsBillable);
                //Set field value for ListID
                ORItemLineAddListElement551.ItemLineAdd.OverrideItemAccountRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemLineAdd.OverrideItemAccountRef.FullName.SetValue("ab");
                //Set field value for TxnID
                ORItemLineAddListElement551.ItemLineAdd.LinkToTxn.TxnID.SetValue("200000-1011023419");
                //Set field value for TxnLineID
                ORItemLineAddListElement551.ItemLineAdd.LinkToTxn.TxnLineID.SetValue("200000-1011023419");
                //Set field value for ListID
                ORItemLineAddListElement551.ItemLineAdd.SalesRepRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemLineAdd.SalesRepRef.FullName.SetValue("ab");
                IDataExt DataExt554 = ORItemLineAddListElement551.ItemLineAdd.DataExtList.Append();
                //Set field value for OwnerID
                DataExt554.OwnerID.SetValue(Guid.NewGuid().ToString());
                //Set field value for DataExtName
                DataExt554.DataExtName.SetValue("ab");
                //Set field value for DataExtValue
                DataExt554.DataExtValue.SetValue("ab");
            }
            if (ORItemLineAddListElementType552 == "ItemGroupLineAdd")
            {
                //Set field value for ListID
                ORItemLineAddListElement551.ItemGroupLineAdd.ItemGroupRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemGroupLineAdd.ItemGroupRef.FullName.SetValue("ab");
                //Set field value for Quantity
                ORItemLineAddListElement551.ItemGroupLineAdd.Quantity.SetValue(2);
                //Set field value for UnitOfMeasure
                ORItemLineAddListElement551.ItemGroupLineAdd.UnitOfMeasure.SetValue("ab");
                //Set field value for ListID
                ORItemLineAddListElement551.ItemGroupLineAdd.InventorySiteRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemGroupLineAdd.InventorySiteRef.FullName.SetValue("ab");
                //Set field value for ListID
                ORItemLineAddListElement551.ItemGroupLineAdd.InventorySiteLocationRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                ORItemLineAddListElement551.ItemGroupLineAdd.InventorySiteLocationRef.FullName.SetValue("ab");
                IDataExt DataExt555 = ORItemLineAddListElement551.ItemGroupLineAdd.DataExtList.Append();
                //Set field value for OwnerID
                DataExt555.OwnerID.SetValue(Guid.NewGuid().ToString());
                //Set field value for DataExtName
                DataExt555.DataExtName.SetValue("ab");
                //Set field value for DataExtValue
                DataExt555.DataExtValue.SetValue("ab");
            }
            //Set field value for IncludeRetElementList
            //May create more than one of these if needed
            BillAddRq.IncludeRetElementList.Add("ab");
        }




        void WalkBillAddRs(IMsgSetResponse responseMsgSet)
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
                        if (responseType == ENResponseType.rtBillAddRs)
                        {
                            //upcast to more specific type here, this is safe because we checked with response.Type check above
                            IBillRet BillRet = (IBillRet)response.Detail;
                            WalkBillRet(BillRet);
                        }
                    }
                }
            }
        }




        void WalkBillRet(IBillRet BillRet)
        {
            if (BillRet == null) return;
            //Go through all the elements of IBillRet
            //Get value of TxnID
            string TxnID556 = (string)BillRet.TxnID.GetValue();
            //Get value of TimeCreated
            DateTime TimeCreated557 = (DateTime)BillRet.TimeCreated.GetValue();
            //Get value of TimeModified
            DateTime TimeModified558 = (DateTime)BillRet.TimeModified.GetValue();
            //Get value of EditSequence
            string EditSequence559 = (string)BillRet.EditSequence.GetValue();
            //Get value of TxnNumber
            if (BillRet.TxnNumber != null)
            {
                int TxnNumber560 = (int)BillRet.TxnNumber.GetValue();
            }
            //Get value of ListID
            if (BillRet.VendorRef.ListID != null)
            {
                string ListID561 = (string)BillRet.VendorRef.ListID.GetValue();
            }
            //Get value of FullName
            if (BillRet.VendorRef.FullName != null)
            {
                string FullName562 = (string)BillRet.VendorRef.FullName.GetValue();
            }
            if (BillRet.VendorAddress != null)
            {
                //Get value of Addr1
                if (BillRet.VendorAddress.Addr1 != null)
                {
                    string Addr1563 = (string)BillRet.VendorAddress.Addr1.GetValue();
                }
                //Get value of Addr2
                if (BillRet.VendorAddress.Addr2 != null)
                {
                    string Addr2564 = (string)BillRet.VendorAddress.Addr2.GetValue();
                }
                //Get value of Addr3
                if (BillRet.VendorAddress.Addr3 != null)
                {
                    string Addr3565 = (string)BillRet.VendorAddress.Addr3.GetValue();
                }
                //Get value of Addr4
                if (BillRet.VendorAddress.Addr4 != null)
                {
                    string Addr4566 = (string)BillRet.VendorAddress.Addr4.GetValue();
                }
                //Get value of Addr5
                if (BillRet.VendorAddress.Addr5 != null)
                {
                    string Addr5567 = (string)BillRet.VendorAddress.Addr5.GetValue();
                }
                //Get value of City
                if (BillRet.VendorAddress.City != null)
                {
                    string City568 = (string)BillRet.VendorAddress.City.GetValue();
                }
                //Get value of State
                if (BillRet.VendorAddress.State != null)
                {
                    string State569 = (string)BillRet.VendorAddress.State.GetValue();
                }
                //Get value of PostalCode
                if (BillRet.VendorAddress.PostalCode != null)
                {
                    string PostalCode570 = (string)BillRet.VendorAddress.PostalCode.GetValue();
                }
                //Get value of Country
                if (BillRet.VendorAddress.Country != null)
                {
                    string Country571 = (string)BillRet.VendorAddress.Country.GetValue();
                }
                //Get value of Note
                if (BillRet.VendorAddress.Note != null)
                {
                    string Note572 = (string)BillRet.VendorAddress.Note.GetValue();
                }
            }
            if (BillRet.APAccountRef != null)
            {
                //Get value of ListID
                if (BillRet.APAccountRef.ListID != null)
                {
                    string ListID573 = (string)BillRet.APAccountRef.ListID.GetValue();
                }
                //Get value of FullName
                if (BillRet.APAccountRef.FullName != null)
                {
                    string FullName574 = (string)BillRet.APAccountRef.FullName.GetValue();
                }
            }
            //Get value of TxnDate
            DateTime TxnDate575 = (DateTime)BillRet.TxnDate.GetValue();
            //Get value of DueDate
            if (BillRet.DueDate != null)
            {
                DateTime DueDate576 = (DateTime)BillRet.DueDate.GetValue();
            }
            //Get value of AmountDue
            double AmountDue577 = (double)BillRet.AmountDue.GetValue();
            if (BillRet.CurrencyRef != null)
            {
                //Get value of ListID
                if (BillRet.CurrencyRef.ListID != null)
                {
                    string ListID578 = (string)BillRet.CurrencyRef.ListID.GetValue();
                }
                //Get value of FullName
                if (BillRet.CurrencyRef.FullName != null)
                {
                    string FullName579 = (string)BillRet.CurrencyRef.FullName.GetValue();
                }
            }
            //Get value of ExchangeRate
            //if (BillRet.ExchangeRate != null)
            //{
            //    IQBFloatType ExchangeRate580 = (IQBFloatType)BillRet.ExchangeRate.GetValue();
            //}
            //Get value of AmountDueInHomeCurrency
            if (BillRet.AmountDueInHomeCurrency != null)
            {
                double AmountDueInHomeCurrency581 = (double)BillRet.AmountDueInHomeCurrency.GetValue();
            }
            //Get value of RefNumber
            if (BillRet.RefNumber != null)
            {
                string RefNumber582 = (string)BillRet.RefNumber.GetValue();
            }
            //Get value of IsPending
            //if (BillRet.IsPending != null)
            //{
            //    bool isPending = (string)BillRet.IsPending.GetValue();
            //}
            if (BillRet.TermsRef != null)
            {
                //Get value of ListID
                if (BillRet.TermsRef.ListID != null)
                {
                    string ListID583 = (string)BillRet.TermsRef.ListID.GetValue();
                }
                //Get value of FullName
                if (BillRet.TermsRef.FullName != null)
                {
                    string FullName584 = (string)BillRet.TermsRef.FullName.GetValue();
                }
            }
            //Get value of Memo
            if (BillRet.Memo != null)
            {
                string Memo585 = (string)BillRet.Memo.GetValue();
            }
            //Get value of IsTaxIncluded
            if (BillRet.IsTaxIncluded != null)
            {
                bool IsTaxIncluded586 = (bool)BillRet.IsTaxIncluded.GetValue();
            }
            if (BillRet.SalesTaxCodeRef != null)
            {
                //Get value of ListID
                if (BillRet.SalesTaxCodeRef.ListID != null)
                {
                    string ListID587 = (string)BillRet.SalesTaxCodeRef.ListID.GetValue();
                }
                //Get value of FullName
                if (BillRet.SalesTaxCodeRef.FullName != null)
                {
                    string FullName588 = (string)BillRet.SalesTaxCodeRef.FullName.GetValue();
                }
            }
            //Get value of IsPaid
            if (BillRet.IsPaid != null)
            {
                bool IsPaid589 = (bool)BillRet.IsPaid.GetValue();
            }
            //Get value of ExternalGUID
            if (BillRet.ExternalGUID != null)
            {
                string ExternalGUID590 = (string)BillRet.ExternalGUID.GetValue();
            }
            if (BillRet.LinkedTxnList != null)
            {
                for (int i591 = 0; i591 < BillRet.LinkedTxnList.Count; i591++)
                {
                    ILinkedTxn LinkedTxn = BillRet.LinkedTxnList.GetAt(i591);
                    //Get value of TxnID
                    string TxnID592 = (string)LinkedTxn.TxnID.GetValue();
                    //Get value of TxnType
                    ENTxnType TxnType593 = (ENTxnType)LinkedTxn.TxnType.GetValue();
                    //Get value of TxnDate
                    DateTime TxnDate594 = (DateTime)LinkedTxn.TxnDate.GetValue();
                    //Get value of RefNumber
                    if (LinkedTxn.RefNumber != null)
                    {
                        string RefNumber595 = (string)LinkedTxn.RefNumber.GetValue();
                    }
                    //Get value of LinkType
                    if (LinkedTxn.LinkType != null)
                    {
                        ENLinkType LinkType596 = (ENLinkType)LinkedTxn.LinkType.GetValue();
                    }
                    //Get value of Amount
                    double Amount597 = (double)LinkedTxn.Amount.GetValue();
                }
            }
            if (BillRet.ExpenseLineRetList != null)
            {
                for (int i598 = 0; i598 < BillRet.ExpenseLineRetList.Count; i598++)
                {
                    IExpenseLineRet ExpenseLineRet = BillRet.ExpenseLineRetList.GetAt(i598);
                    //Get value of TxnLineID
                    string TxnLineID599 = (string)ExpenseLineRet.TxnLineID.GetValue();
                    if (ExpenseLineRet.AccountRef != null)
                    {
                        //Get value of ListID
                        if (ExpenseLineRet.AccountRef.ListID != null)
                        {
                            string ListID600 = (string)ExpenseLineRet.AccountRef.ListID.GetValue();
                        }
                        //Get value of FullName
                        if (ExpenseLineRet.AccountRef.FullName != null)
                        {
                            string FullName601 = (string)ExpenseLineRet.AccountRef.FullName.GetValue();
                        }
                    }
                    //Get value of Amount
                    if (ExpenseLineRet.Amount != null)
                    {
                        double Amount602 = (double)ExpenseLineRet.Amount.GetValue();
                    }
                    //Get value of Memo
                    if (ExpenseLineRet.Memo != null)
                    {
                        string Memo603 = (string)ExpenseLineRet.Memo.GetValue();
                    }
                    if (ExpenseLineRet.CustomerRef != null)
                    {
                        //Get value of ListID
                        if (ExpenseLineRet.CustomerRef.ListID != null)
                        {
                            string ListID604 = (string)ExpenseLineRet.CustomerRef.ListID.GetValue();
                        }
                        //Get value of FullName
                        if (ExpenseLineRet.CustomerRef.FullName != null)
                        {
                            string FullName605 = (string)ExpenseLineRet.CustomerRef.FullName.GetValue();
                        }
                    }
                    if (ExpenseLineRet.ClassRef != null)
                    {
                        //Get value of ListID
                        if (ExpenseLineRet.ClassRef.ListID != null)
                        {
                            string ListID606 = (string)ExpenseLineRet.ClassRef.ListID.GetValue();
                        }
                        //Get value of FullName
                        if (ExpenseLineRet.ClassRef.FullName != null)
                        {
                            string FullName607 = (string)ExpenseLineRet.ClassRef.FullName.GetValue();
                        }
                    }
                    if (ExpenseLineRet.SalesTaxCodeRef != null)
                    {
                        //Get value of ListID
                        if (ExpenseLineRet.SalesTaxCodeRef.ListID != null)
                        {
                            string ListID608 = (string)ExpenseLineRet.SalesTaxCodeRef.ListID.GetValue();
                        }
                        //Get value of FullName
                        if (ExpenseLineRet.SalesTaxCodeRef.FullName != null)
                        {
                            string FullName609 = (string)ExpenseLineRet.SalesTaxCodeRef.FullName.GetValue();
                        }
                    }
                    //Get value of BillableStatus
                    if (ExpenseLineRet.BillableStatus != null)
                    {
                        ENBillableStatus BillableStatus610 = (ENBillableStatus)ExpenseLineRet.BillableStatus.GetValue();
                    }
                    if (ExpenseLineRet.SalesRepRef != null)
                    {
                        //Get value of ListID
                        if (ExpenseLineRet.SalesRepRef.ListID != null)
                        {
                            string ListID611 = (string)ExpenseLineRet.SalesRepRef.ListID.GetValue();
                        }
                        //Get value of FullName
                        if (ExpenseLineRet.SalesRepRef.FullName != null)
                        {
                            string FullName612 = (string)ExpenseLineRet.SalesRepRef.FullName.GetValue();
                        }
                    }
                    if (ExpenseLineRet.DataExtRetList != null)
                    {
                        for (int i613 = 0; i613 < ExpenseLineRet.DataExtRetList.Count; i613++)
                        {
                            IDataExtRet DataExtRet = ExpenseLineRet.DataExtRetList.GetAt(i613);
                            //Get value of OwnerID
                            if (DataExtRet.OwnerID != null)
                            {
                                string OwnerID614 = (string)DataExtRet.OwnerID.GetValue();
                            }
                            //Get value of DataExtName
                            string DataExtName615 = (string)DataExtRet.DataExtName.GetValue();
                            //Get value of DataExtType
                            ENDataExtType DataExtType616 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                            //Get value of DataExtValue
                            string DataExtValue617 = (string)DataExtRet.DataExtValue.GetValue();
                        }
                    }
                }
            }
            if (BillRet.ORItemLineRetList != null)
            {
                for (int i618 = 0; i618 < BillRet.ORItemLineRetList.Count; i618++)
                {
                    IORItemLineRet ORItemLineRet619 = BillRet.ORItemLineRetList.GetAt(i618);
                    if (ORItemLineRet619.ItemLineRet != null)
                    {
                        if (ORItemLineRet619.ItemLineRet != null)
                        {
                            //Get value of TxnLineID
                            string TxnLineID620 = (string)ORItemLineRet619.ItemLineRet.TxnLineID.GetValue();
                            if (ORItemLineRet619.ItemLineRet.ItemRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemLineRet.ItemRef.ListID != null)
                                {
                                    string ListID621 = (string)ORItemLineRet619.ItemLineRet.ItemRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemLineRet.ItemRef.FullName != null)
                                {
                                    string FullName622 = (string)ORItemLineRet619.ItemLineRet.ItemRef.FullName.GetValue();
                                }
                            }
                            if (ORItemLineRet619.ItemLineRet.InventorySiteRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemLineRet.InventorySiteRef.ListID != null)
                                {
                                    string ListID623 = (string)ORItemLineRet619.ItemLineRet.InventorySiteRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemLineRet.InventorySiteRef.FullName != null)
                                {
                                    string FullName624 = (string)ORItemLineRet619.ItemLineRet.InventorySiteRef.FullName.GetValue();
                                }
                            }
                            if (ORItemLineRet619.ItemLineRet.InventorySiteLocationRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemLineRet.InventorySiteLocationRef.ListID != null)
                                {
                                    string ListID625 = (string)ORItemLineRet619.ItemLineRet.InventorySiteLocationRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemLineRet.InventorySiteLocationRef.FullName != null)
                                {
                                    string FullName626 = (string)ORItemLineRet619.ItemLineRet.InventorySiteLocationRef.FullName.GetValue();
                                }
                            }
                            if (ORItemLineRet619.ItemLineRet.ORSerialLotNumber != null)
                            {
                                if (ORItemLineRet619.ItemLineRet.ORSerialLotNumber.SerialNumber != null)
                                {
                                    //Get value of SerialNumber
                                    if (ORItemLineRet619.ItemLineRet.ORSerialLotNumber.SerialNumber != null)
                                    {
                                        string SerialNumber628 = (string)ORItemLineRet619.ItemLineRet.ORSerialLotNumber.SerialNumber.GetValue();
                                    }
                                }
                                if (ORItemLineRet619.ItemLineRet.ORSerialLotNumber.LotNumber != null)
                                {
                                    //Get value of LotNumber
                                    if (ORItemLineRet619.ItemLineRet.ORSerialLotNumber.LotNumber != null)
                                    {
                                        string LotNumber629 = (string)ORItemLineRet619.ItemLineRet.ORSerialLotNumber.LotNumber.GetValue();
                                    }
                                }
                            }
                            //Get value of Expiration Date
                            if (ORItemLineRet619.ItemLineRet.ExpirationDateForSerialLotNumber != null)
                            {
                                string ExpDate630 = (string)ORItemLineRet619.ItemLineRet.ExpirationDateForSerialLotNumber.GetValue();
                            }
                            //Get value of Desc
                            if (ORItemLineRet619.ItemLineRet.Desc != null)
                            {
                                string Desc630 = (string)ORItemLineRet619.ItemLineRet.Desc.GetValue();
                            }
                            //Get value of Quantity
                            if (ORItemLineRet619.ItemLineRet.Quantity != null)
                            {
                                int Quantity631 = (int)ORItemLineRet619.ItemLineRet.Quantity.GetValue();
                            }
                            //Get value of UnitOfMeasure
                            if (ORItemLineRet619.ItemLineRet.UnitOfMeasure != null)
                            {
                                string UnitOfMeasure632 = (string)ORItemLineRet619.ItemLineRet.UnitOfMeasure.GetValue();
                            }
                            if (ORItemLineRet619.ItemLineRet.OverrideUOMSetRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemLineRet.OverrideUOMSetRef.ListID != null)
                                {
                                    string ListID633 = (string)ORItemLineRet619.ItemLineRet.OverrideUOMSetRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemLineRet.OverrideUOMSetRef.FullName != null)
                                {
                                    string FullName634 = (string)ORItemLineRet619.ItemLineRet.OverrideUOMSetRef.FullName.GetValue();
                                }
                            }
                            //Get value of Cost
                            if (ORItemLineRet619.ItemLineRet.Cost != null)
                            {
                                double Cost635 = (double)ORItemLineRet619.ItemLineRet.Cost.GetValue();
                            }
                            //Get value of Amount
                            if (ORItemLineRet619.ItemLineRet.Amount != null)
                            {
                                double Amount636 = (double)ORItemLineRet619.ItemLineRet.Amount.GetValue();
                            }
                            if (ORItemLineRet619.ItemLineRet.CustomerRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemLineRet.CustomerRef.ListID != null)
                                {
                                    string ListID637 = (string)ORItemLineRet619.ItemLineRet.CustomerRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemLineRet.CustomerRef.FullName != null)
                                {
                                    string FullName638 = (string)ORItemLineRet619.ItemLineRet.CustomerRef.FullName.GetValue();
                                }
                            }
                            if (ORItemLineRet619.ItemLineRet.ClassRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemLineRet.ClassRef.ListID != null)
                                {
                                    string ListID639 = (string)ORItemLineRet619.ItemLineRet.ClassRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemLineRet.ClassRef.FullName != null)
                                {
                                    string FullName640 = (string)ORItemLineRet619.ItemLineRet.ClassRef.FullName.GetValue();
                                }
                            }
                            if (ORItemLineRet619.ItemLineRet.SalesTaxCodeRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemLineRet.SalesTaxCodeRef.ListID != null)
                                {
                                    string ListID641 = (string)ORItemLineRet619.ItemLineRet.SalesTaxCodeRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemLineRet.SalesTaxCodeRef.FullName != null)
                                {
                                    string FullName642 = (string)ORItemLineRet619.ItemLineRet.SalesTaxCodeRef.FullName.GetValue();
                                }
                            }
                            //Get value of BillableStatus
                            if (ORItemLineRet619.ItemLineRet.BillableStatus != null)
                            {
                                ENBillableStatus BillableStatus643 = (ENBillableStatus)ORItemLineRet619.ItemLineRet.BillableStatus.GetValue();
                            }
                            if (ORItemLineRet619.ItemLineRet.SalesRepRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemLineRet.SalesRepRef.ListID != null)
                                {
                                    string ListID644 = (string)ORItemLineRet619.ItemLineRet.SalesRepRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemLineRet.SalesRepRef.FullName != null)
                                {
                                    string FullName645 = (string)ORItemLineRet619.ItemLineRet.SalesRepRef.FullName.GetValue();
                                }
                            }
                            if (ORItemLineRet619.ItemLineRet.DataExtRetList != null)
                            {
                                for (int i646 = 0; i646 < ORItemLineRet619.ItemLineRet.DataExtRetList.Count; i646++)
                                {
                                    IDataExtRet DataExtRet = ORItemLineRet619.ItemLineRet.DataExtRetList.GetAt(i646);
                                    //Get value of OwnerID
                                    if (DataExtRet.OwnerID != null)
                                    {
                                        string OwnerID647 = (string)DataExtRet.OwnerID.GetValue();
                                    }
                                    //Get value of DataExtName
                                    string DataExtName648 = (string)DataExtRet.DataExtName.GetValue();
                                    //Get value of DataExtType
                                    ENDataExtType DataExtType649 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                    //Get value of DataExtValue
                                    string DataExtValue650 = (string)DataExtRet.DataExtValue.GetValue();
                                }
                            }
                        }
                    }
                    if (ORItemLineRet619.ItemGroupLineRet != null)
                    {
                        if (ORItemLineRet619.ItemGroupLineRet != null)
                        {
                            //Get value of TxnLineID
                            string TxnLineID651 = (string)ORItemLineRet619.ItemGroupLineRet.TxnLineID.GetValue();
                            //Get value of ListID
                            if (ORItemLineRet619.ItemGroupLineRet.ItemGroupRef.ListID != null)
                            {
                                string ListID652 = (string)ORItemLineRet619.ItemGroupLineRet.ItemGroupRef.ListID.GetValue();
                            }
                            //Get value of FullName
                            if (ORItemLineRet619.ItemGroupLineRet.ItemGroupRef.FullName != null)
                            {
                                string FullName653 = (string)ORItemLineRet619.ItemGroupLineRet.ItemGroupRef.FullName.GetValue();
                            }
                            //Get value of Desc
                            if (ORItemLineRet619.ItemGroupLineRet.Desc != null)
                            {
                                string Desc654 = (string)ORItemLineRet619.ItemGroupLineRet.Desc.GetValue();
                            }
                            //Get value of Quantity
                            if (ORItemLineRet619.ItemGroupLineRet.Quantity != null)
                            {
                                int Quantity655 = (int)ORItemLineRet619.ItemGroupLineRet.Quantity.GetValue();
                            }
                            //Get value of UnitOfMeasure
                            if (ORItemLineRet619.ItemGroupLineRet.UnitOfMeasure != null)
                            {
                                string UnitOfMeasure656 = (string)ORItemLineRet619.ItemGroupLineRet.UnitOfMeasure.GetValue();
                            }
                            if (ORItemLineRet619.ItemGroupLineRet.OverrideUOMSetRef != null)
                            {
                                //Get value of ListID
                                if (ORItemLineRet619.ItemGroupLineRet.OverrideUOMSetRef.ListID != null)
                                {
                                    string ListID657 = (string)ORItemLineRet619.ItemGroupLineRet.OverrideUOMSetRef.ListID.GetValue();
                                }
                                //Get value of FullName
                                if (ORItemLineRet619.ItemGroupLineRet.OverrideUOMSetRef.FullName != null)
                                {
                                    string FullName658 = (string)ORItemLineRet619.ItemGroupLineRet.OverrideUOMSetRef.FullName.GetValue();
                                }
                            }
                            //Get value of TotalAmount
                            double TotalAmount659 = (double)ORItemLineRet619.ItemGroupLineRet.TotalAmount.GetValue();
                            if (ORItemLineRet619.ItemGroupLineRet.ItemLineRetList != null)
                            {
                                for (int i660 = 0; i660 < ORItemLineRet619.ItemGroupLineRet.ItemLineRetList.Count; i660++)
                                {
                                    IItemLineRet ItemLineRet = ORItemLineRet619.ItemGroupLineRet.ItemLineRetList.GetAt(i660);
                                    //Get value of TxnLineID
                                    string TxnLineID661 = (string)ItemLineRet.TxnLineID.GetValue();
                                    if (ItemLineRet.ItemRef != null)
                                    {
                                        //Get value of ListID
                                        if (ItemLineRet.ItemRef.ListID != null)
                                        {
                                            string ListID662 = (string)ItemLineRet.ItemRef.ListID.GetValue();
                                        }
                                        //Get value of FullName
                                        if (ItemLineRet.ItemRef.FullName != null)
                                        {
                                            string FullName663 = (string)ItemLineRet.ItemRef.FullName.GetValue();
                                        }
                                    }
                                    if (ItemLineRet.InventorySiteRef != null)
                                    {
                                        //Get value of ListID
                                        if (ItemLineRet.InventorySiteRef.ListID != null)
                                        {
                                            string ListID664 = (string)ItemLineRet.InventorySiteRef.ListID.GetValue();
                                        }
                                        //Get value of FullName
                                        if (ItemLineRet.InventorySiteRef.FullName != null)
                                        {
                                            string FullName665 = (string)ItemLineRet.InventorySiteRef.FullName.GetValue();
                                        }
                                    }
                                    if (ItemLineRet.InventorySiteLocationRef != null)
                                    {
                                        //Get value of ListID
                                        if (ItemLineRet.InventorySiteLocationRef.ListID != null)
                                        {
                                            string ListID666 = (string)ItemLineRet.InventorySiteLocationRef.ListID.GetValue();
                                        }
                                        //Get value of FullName
                                        if (ItemLineRet.InventorySiteLocationRef.FullName != null)
                                        {
                                            string FullName667 = (string)ItemLineRet.InventorySiteLocationRef.FullName.GetValue();
                                        }
                                    }
                                    if (ItemLineRet.ORSerialLotNumber != null)
                                    {
                                        if (ItemLineRet.ORSerialLotNumber.SerialNumber != null)
                                        {
                                            //Get value of SerialNumber
                                            if (ItemLineRet.ORSerialLotNumber.SerialNumber != null)
                                            {
                                                string SerialNumber669 = (string)ItemLineRet.ORSerialLotNumber.SerialNumber.GetValue();
                                            }
                                        }
                                        if (ItemLineRet.ORSerialLotNumber.LotNumber != null)
                                        {
                                            //Get value of LotNumber
                                            if (ItemLineRet.ORSerialLotNumber.LotNumber != null)
                                            {
                                                string LotNumber670 = (string)ItemLineRet.ORSerialLotNumber.LotNumber.GetValue();
                                            }
                                        }
                                    }
                                    //Get value of Expiration Date
                                    if (ItemLineRet.ExpirationDateForSerialLotNumber != null)
                                    {
                                        string ExpDate = (string)ItemLineRet.ExpirationDateForSerialLotNumber.GetValue();
                                    }
                                    //Get value of Desc
                                    if (ItemLineRet.Desc != null)
                                    {
                                        string Desc671 = (string)ItemLineRet.Desc.GetValue();
                                    }
                                    //Get value of Quantity
                                    if (ItemLineRet.Quantity != null)
                                    {
                                        int Quantity672 = (int)ItemLineRet.Quantity.GetValue();
                                    }
                                    //Get value of UnitOfMeasure
                                    if (ItemLineRet.UnitOfMeasure != null)
                                    {
                                        string UnitOfMeasure673 = (string)ItemLineRet.UnitOfMeasure.GetValue();
                                    }
                                    if (ItemLineRet.OverrideUOMSetRef != null)
                                    {
                                        //Get value of ListID
                                        if (ItemLineRet.OverrideUOMSetRef.ListID != null)
                                        {
                                            string ListID674 = (string)ItemLineRet.OverrideUOMSetRef.ListID.GetValue();
                                        }
                                        //Get value of FullName
                                        if (ItemLineRet.OverrideUOMSetRef.FullName != null)
                                        {
                                            string FullName675 = (string)ItemLineRet.OverrideUOMSetRef.FullName.GetValue();
                                        }
                                    }
                                    //Get value of Cost
                                    if (ItemLineRet.Cost != null)
                                    {
                                        double Cost676 = (double)ItemLineRet.Cost.GetValue();
                                    }
                                    //Get value of Amount
                                    if (ItemLineRet.Amount != null)
                                    {
                                        double Amount677 = (double)ItemLineRet.Amount.GetValue();
                                    }
                                    if (ItemLineRet.CustomerRef != null)
                                    {
                                        //Get value of ListID
                                        if (ItemLineRet.CustomerRef.ListID != null)
                                        {
                                            string ListID678 = (string)ItemLineRet.CustomerRef.ListID.GetValue();
                                        }
                                        //Get value of FullName
                                        if (ItemLineRet.CustomerRef.FullName != null)
                                        {
                                            string FullName679 = (string)ItemLineRet.CustomerRef.FullName.GetValue();
                                        }
                                    }
                                    if (ItemLineRet.ClassRef != null)
                                    {
                                        //Get value of ListID
                                        if (ItemLineRet.ClassRef.ListID != null)
                                        {
                                            string ListID680 = (string)ItemLineRet.ClassRef.ListID.GetValue();
                                        }
                                        //Get value of FullName
                                        if (ItemLineRet.ClassRef.FullName != null)
                                        {
                                            string FullName681 = (string)ItemLineRet.ClassRef.FullName.GetValue();
                                        }
                                    }
                                    if (ItemLineRet.SalesTaxCodeRef != null)
                                    {
                                        //Get value of ListID
                                        if (ItemLineRet.SalesTaxCodeRef.ListID != null)
                                        {
                                            string ListID682 = (string)ItemLineRet.SalesTaxCodeRef.ListID.GetValue();
                                        }
                                        //Get value of FullName
                                        if (ItemLineRet.SalesTaxCodeRef.FullName != null)
                                        {
                                            string FullName683 = (string)ItemLineRet.SalesTaxCodeRef.FullName.GetValue();
                                        }
                                    }
                                    //Get value of BillableStatus
                                    if (ItemLineRet.BillableStatus != null)
                                    {
                                        ENBillableStatus BillableStatus684 = (ENBillableStatus)ItemLineRet.BillableStatus.GetValue();
                                    }
                                    if (ItemLineRet.SalesRepRef != null)
                                    {
                                        //Get value of ListID
                                        if (ItemLineRet.SalesRepRef.ListID != null)
                                        {
                                            string ListID685 = (string)ItemLineRet.SalesRepRef.ListID.GetValue();
                                        }
                                        //Get value of FullName
                                        if (ItemLineRet.SalesRepRef.FullName != null)
                                        {
                                            string FullName686 = (string)ItemLineRet.SalesRepRef.FullName.GetValue();
                                        }
                                    }
                                    if (ItemLineRet.DataExtRetList != null)
                                    {
                                        for (int i687 = 0; i687 < ItemLineRet.DataExtRetList.Count; i687++)
                                        {
                                            IDataExtRet DataExtRet = ItemLineRet.DataExtRetList.GetAt(i687);
                                            //Get value of OwnerID
                                            if (DataExtRet.OwnerID != null)
                                            {
                                                string OwnerID688 = (string)DataExtRet.OwnerID.GetValue();
                                            }
                                            //Get value of DataExtName
                                            string DataExtName689 = (string)DataExtRet.DataExtName.GetValue();
                                            //Get value of DataExtType
                                            ENDataExtType DataExtType690 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                                            //Get value of DataExtValue
                                            string DataExtValue691 = (string)DataExtRet.DataExtValue.GetValue();
                                        }
                                    }
                                }
                            }
                            if (ORItemLineRet619.ItemGroupLineRet.DataExtList != null)
                            {
                                for (int i692 = 0; i692 < ORItemLineRet619.ItemGroupLineRet.DataExtList.Count; i692++)
                                {
                                    IDataExt DataExt = ORItemLineRet619.ItemGroupLineRet.DataExtList.GetAt(i692);
                                    //Get value of OwnerID
                                    string OwnerID693 = (string)DataExt.OwnerID.GetValue();
                                    //Get value of DataExtName
                                    string DataExtName694 = (string)DataExt.DataExtName.GetValue();
                                    //Get value of DataExtValue
                                    string DataExtValue695 = (string)DataExt.DataExtValue.GetValue();
                                }
                            }
                        }
                    }
                }
            }
            //Get value of OpenAmount
            if (BillRet.OpenAmount != null)
            {
                double OpenAmount696 = (double)BillRet.OpenAmount.GetValue();
            }
            if (BillRet.DataExtRetList != null)
            {
                for (int i697 = 0; i697 < BillRet.DataExtRetList.Count; i697++)
                {
                    IDataExtRet DataExtRet = BillRet.DataExtRetList.GetAt(i697);
                    //Get value of OwnerID
                    if (DataExtRet.OwnerID != null)
                    {
                        string OwnerID698 = (string)DataExtRet.OwnerID.GetValue();
                    }
                    //Get value of DataExtName
                    string DataExtName699 = (string)DataExtRet.DataExtName.GetValue();
                    //Get value of DataExtType
                    ENDataExtType DataExtType700 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                    //Get value of DataExtValue
                    string DataExtValue701 = (string)DataExtRet.DataExtValue.GetValue();
                }
            }
        }
    }
}
