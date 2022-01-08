using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmortizationOSDatabase.Models
{
    public class MOL
    {
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [ForeignKey("MolId")]
        public virtual List<OS> OS { get; set; }
    }
}
