using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmortizationOSDatabase.Models
{
    public class ChartOfAccounts
    {
        public int Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string AccountName { get; set; }
        public string Subconto1 { get; set; }
        public string Subconto2 { get; set; }
        public string Subconto3 { get; set; }
        [ForeignKey("ExpenseAccount")]
        public virtual List<Subdivision> Subdivision { get; set; }
        [InverseProperty(nameof(TransactionsJournal.AccountsKredit))]
        public virtual List<TransactionsJournal> TransactionsJournalAccountKredit { get; set; }
        [InverseProperty(nameof(TransactionsJournal.AccountsDebet))]
        public virtual List<TransactionsJournal> TransactionsJournalAccountDebet { get; set; }
    }
}
