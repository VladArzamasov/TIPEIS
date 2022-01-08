using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmortizationOSDatabase.Models
{
    public class Subdivision
    {
        public int Id { get; set; }
        [Required]
        public string SubdivisionName { get; set; }
        public int ExpenseAccount { get; set; }
        public virtual ChartOfAccounts ChartOfAccounts { get; set; }
        [ForeignKey("SubdivisionId")]
        public virtual ICollection<OS> OS { get; set; }
    }
}
