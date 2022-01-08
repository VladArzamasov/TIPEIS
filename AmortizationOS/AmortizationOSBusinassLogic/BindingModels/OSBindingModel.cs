using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.BindingModels
{
    public class OSBindingModel
    {
        public int? Id { get; set; }
        public string OsName { get; set; }
        public decimal BalansSum { get; set; }
        public int SPI { get; set; }
        public string Status { get; set; }
        public DateTime DateAdd { get; set; }
        public int SubdivisionId { get; set; }
        public int MolId { get; set; }
    }
}
