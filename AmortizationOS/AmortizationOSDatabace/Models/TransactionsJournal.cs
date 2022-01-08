using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmortizationOSDatabase.Models
{
    public class TransactionsJournal
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey(nameof(AccountsDebet))]
        public int? AccountDebet { get; set; }
        [ForeignKey(nameof(AccountsKredit))]
        public int? AccountKredit { get; set; }
        public string SubcontoDt1 { get; set; }
        public string SubcontoDt2 { get; set; }
        public string SubcontoDt3 { get; set; }
        public string SubcontoCt1 { get; set; }
        public string SubcontoCt2 { get; set; }
        public string SubcontoCt3 { get; set; }
        [Required]
        public decimal Sum { get; set; }
        public int AmortizationId { get; set; }
        public string Comment { get; set; }
        public virtual ChartOfAccounts AccountsKredit { get; set; }
        public virtual ChartOfAccounts AccountsDebet { get; set; }
        public virtual Amortization Amortization { get; set; }
    }
}
