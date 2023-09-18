using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enderun.Models
{
    public class Header
    {
        public string? CompanyCode { get; set; }
        public string? InvoiceType { get; set; }
        public int InvoiceNo { get; set; }
        public string? VCECode { get; set; }
        public string? VCEName { get; set; }
        public string? Remarks { get; set; }
        public DateTime? TransDate { get; set; }
        public string? Status { get; set; }
        public string? CreditAccount { get; set; }
        public List<Body> Details { get; set; }
    }

    public class Body
    {
        public string? AccountCode { get; set; }
        public string? CostCenter { get; set; }
        public decimal Amount { get; set; }
        public int VATAmount { get; set; }
        public string? Particulars { get; set; }
    }

}
