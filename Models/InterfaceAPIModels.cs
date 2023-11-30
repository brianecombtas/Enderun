using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enderun.Models
{
    public class InterfaceAPIModels
    {
        public class APParams
        {
            public int? InvoiceAPNo { get; set; }
            public int? CompUnitType { get; set; }
            public int? CompUnitID { get; set; }
            public int? Account { get; set; }
            public int? CompanyID { get; set; }
            public string SupplierCode { get; set; }
            public string InvoiceSubType { get; set; }
            public string InvoiceNumber { get; set; }
            public string WorkerCode { get; set; }
            public DateTime? InvoiceFromDate { get; set; }
            public DateTime? InvoiceToDate { get; set; }
            public DateTime? DocDate { get; set; }

            public APParams() { }
        }


        public class AcctHeader
        {
            public DateTime? Timestamp { get; set; }
            public string? ProcessId { get; set; }
            public int TotalSuccess { get; set; }
            public int TotalFailed { get; set; }

            [JsonProperty("AcctInterfaces")]
            public List<AcctInterfaces>? AcctInterfaces { get; set; }


            public AcctHeader()
            {
                AcctInterfaces = new List<AcctInterfaces>(); 
            }

        }
        public class AcctInterfaces
        {
            public string ID { get; set; }
            public string TRID { get; set; }
            public string InvoiceID { get; set; }
            public string FinalID { get; set; }
            public string CashAdvanceID { get; set; }
            public string InvoiceAPNo { get; set; }
            public string InvoiceCount { get; set; }
            public string Percentage { get; set; }
            public string ExpenseTypeAssignID { get; set; }
            public string CompanyID { get; set; }
            public string Type { get; set; }
            public string TRProjectID { get; set; }
            public string ProjectID { get; set; }
            public string ExpenseAccountID { get; set; }
            public string LineCount { get; set; }
            public decimal? AmountOrg { get; set; }
            public decimal? TaxOrg { get; set; }
            public decimal? ReductionOrg { get; set; }
            public decimal? TotalOrg { get; set; }
            public decimal? ExchangeRate { get; set; }
            public decimal? AmountUSD { get; set; }
            public decimal? TaxUSD { get; set; }
            public decimal? ReductionUSD { get; set; }
            public decimal? TotalUSD { get; set; }
            public decimal? AmountMng { get; set; }
            public decimal? TaxMng { get; set; }
            public decimal? ReductionMng { get; set; }
            public decimal? TotalMng { get; set; }
            public decimal? AmountReim { get; set; }
            public string ProcessID { get; set; }
            public string WorkerCode { get; set; }
            public string LineType { get; set; }
            public string TasNo { get; set; }
            public string SupplierCode { get; set; }
            public string SupplierName { get; set; }
            public string SupplierInterfaceCode { get; set; }
            public string InvoiceSupplierNo { get; set; }
            public string FormOfPaymentInterfaceCode { get; set; }
            public string CurrOrg { get; set; }
            public string CurrMng { get; set; }
            public string CurrReim { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmployeeIndex { get; set; }
            public string EmployeeAccountingCode { get; set; }
            public string EmployeeAccountingCode2 { get; set; }
            public string EmployeeAccountingCode3 { get; set; }
            public string ToAirport { get; set; }
            public string ToCity { get; set; }
            public string ExpenseName { get; set; }
            public string AccountingCode { get; set; }
            public string VatCode { get; set; }
            public string ExpenseCategory { get; set; }
            public string CompanyName { get; set; }
            public string CompanyCode { get; set; }
            public string CompanyNumber { get; set; }
            public string SiteCode { get; set; }
            public string SiteName { get; set; }
            public string UnitCode { get; set; }
            public string UnitName { get; set; }
            public string UnitIndex { get; set; }
            public string ProjectCode { get; set; }
            public string ProjectName { get; set; }
            public string ProjectIndex { get; set; }
            public string CustomItemCode { get; set; }
            public string CustomItemName { get; set; }
            public string ExpenseAccountAccountCode1 { get; set; }
            public string ExpenseAccountAccountCode2 { get; set; }
            public string ExpenseAccountVatCode { get; set; }
            public string ToCountry { get; set; }
            public string ProjectType { get; set; }
            public string Remark { get; set; }
            public DateTime? DepartureDate { get; set; }
            public DateTime? EndDate { get; set; }
            public DateTime? InvoiceDate { get; set; }
            public DateTime? DueDate { get; set; }
            public DateTime? ExpenseApprovedDate { get; set; }
            public bool? PaidByEmployee { get; set; }


            public AcctInterfaces() { }
        }
    }
}
