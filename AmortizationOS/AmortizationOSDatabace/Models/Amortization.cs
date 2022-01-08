using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmortizationOSDatabase.Models
{
    public class Amortization
    {
        public int Id { get; set; }
        [Required]
        public DateTime AmortizationDate { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public string Comment { get; set; }
        [ForeignKey("AmortizationId")]
        public virtual List<TransactionsJournal> TransactionsJournal { get; set; }
        [ForeignKey("AmortizationId")]
        public virtual List<AmortizationOS> AmortizationOs { get; set; }
    }
}
