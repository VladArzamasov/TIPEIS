using System.ComponentModel.DataAnnotations;

namespace AmortizationOSDatabase.Models
{
    public class AmortizationOS
    {
        public int Id { get; set; }
        public int AmortizationId { get; set; }
        public int OsId { get; set; }
        [Required]
        public decimal Sum { get; set; }
        public virtual OS OS { get; set; }
        public virtual Amortization Amortization { get; set; }
    }
}
