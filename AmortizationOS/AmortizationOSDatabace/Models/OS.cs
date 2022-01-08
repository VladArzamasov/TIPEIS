using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmortizationOSDatabase.Models
{
    public class OS
    {
        public int Id { get; set; }
        [Required]
        public string OsName { get; set; }
        [Required]
        public decimal BalansSum { get; set; }
        [Required]
        public int SPI { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime DateAdd { get; set; }
        public int SubdivisionId { get; set; }
        public int MolId { get; set; }
        public virtual Subdivision Subdivision { get; set; }
        public virtual MOL MOL { get; set; }

        [ForeignKey("OsId")]
        public virtual List<AmortizationOS> AmortizationOs { get; set; }
    }
}
