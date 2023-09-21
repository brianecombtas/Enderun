using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enderun.Models
{
    public class AccountDetails
    {

        public class AcctInterface
        {
            public virtual bool PaidByEmployee { get; set; }

            public virtual int ID { get; set; }
            public virtual int TRID { get; set; }
            public virtual int InvoiceID { get; set; }
            public virtual int FinalID { get; set; }
            public virtual int CashAdvanceID { get; set; }
            public virtual int InvoiceAPNo { get; set; }
            public virtual int InvoiceCount { get; set; }
            public virtual int Percentage { get; set; }
            public virtual int ExpenseTypeAssignID { get; set; }
            public virtual int CompanyID { get; set; }
            public virtual int Type { get; set; }
            public virtual int TRProjectID { get; set; }
            public virtual int ProjectID { get; set; }
            public virtual int ExpenseAccountID { get; set; }
            public virtual int LineCount { get; set; }
            public virtual decimal AmountOrg { get; set; }
            public virtual decimal TaxOrg { get; set; }
            public virtual decimal ReductionOrg { get; set; }
            public virtual decimal TotalOrg { get; set; }
            public virtual decimal ExchangeRate { get; set; }
            public virtual decimal AmountUSD { get; set; }
            public virtual decimal TaxUSD { get; set; }
            public virtual decimal ReductionUSD { get; set; }
            public virtual decimal TotalUSD { get; set; }
            public virtual decimal AmountMng { get; set; }
            public virtual decimal TaxMng { get; set; }
            public virtual decimal ReductionMng { get; set; }
            public virtual decimal TotalMng { get; set; }
            public virtual decimal AmountReim { get; set; }
            public virtual string ProcessID { get; set; }
            public virtual string WorkerCode { get; set; }
            public virtual string LineType { get; set; }
            public virtual string TasNo { get; set; }
            public virtual string SupplierCode { get; set; }
            public virtual string SupplierName { get; set; }
            public virtual string SupplierInterfaceCode { get; set; }
            public virtual string InvoiceSupplierNo { get; set; }
            public virtual string FormOfPaymentInterfaceCode { get; set; }
            public virtual string CurrOrg { get; set; }
            public virtual string CurrMng { get; set; }
            public virtual string CurrReim { get; set; }
            public virtual string FirstName { get; set; }
            public virtual string LastName { get; set; }
            public virtual string EmployeeIndex { get; set; }
            public virtual string EmployeeAccountingCode { get; set; }
            public virtual string EmployeeAccountingCode2 { get; set; }
            public virtual string EmployeeAccountingCode3 { get; set; }
            public virtual string ToAirport { get; set; }
            public virtual string ToCity { get; set; }
            public virtual string ExpenseName { get; set; }
            public virtual string AccountingCode { get; set; }
            public virtual string VatCode { get; set; }
            public virtual string ExpenseCategory { get; set; }
            public virtual string CompanyName { get; set; }
            public virtual string CompanyCode { get; set; }
            public virtual string CompanyNumber { get; set; }
            public virtual string SiteCode { get; set; }
            public virtual string SiteName { get; set; }
            public virtual string UnitCode { get; set; }
            public virtual string UnitName { get; set; }
            public virtual string UnitIndex { get; set; }
            public virtual string ProjectCode { get; set; }
            public virtual string ProjectName { get; set; }
            public virtual string ProjectIndex { get; set; }
            public virtual string CustomItemCode { get; set; }
            public virtual string CustomItemName { get; set; }
            public virtual string ExpenseAccountAccountCode1 { get; set; }
            public virtual string ExpenseAccountAccountCode2 { get; set; }
            public virtual string ExpenseAccountVatCode { get; set; }
            public virtual string ToCountry { get; set; }
            public virtual string ProjectType { get; set; }
            public virtual string Remark { get; set; }
            public virtual DateTime DepartureDate { get; set; }
            public virtual DateTime EndDate { get; set; }
            public virtual DateTime InvoiceDate { get; set; }
            public virtual DateTime DueDate { get; set; }
            public virtual DateTime ExpenseApprovedDate { get; set; }


            public AcctInterface() { }
        }
    }
}
