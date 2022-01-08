using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.BindingModels
{
    public class TurnoverBalanceBindingModel
    {
        public string FileName { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
    }
}
