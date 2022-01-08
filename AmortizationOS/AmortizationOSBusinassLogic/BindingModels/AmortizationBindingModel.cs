using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.BindingModels
{
    public class AmortizationBindingModel
    {
        public int? Id { get; set; }
        public DateTime AmortizationDate { get; set; }
        public decimal Sum { get; set; }
        public string Comment { get; set; }
        public Dictionary<int, (string, decimal)> AmortizationOs { get; set; }
    }
}
