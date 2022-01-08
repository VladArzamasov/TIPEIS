using AmortizationOSBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.ViewModels
{
    public class ReportDistributionViewModel
    {
        public string Month { get; set; }
        public decimal SumAccount1 { get; set; }
        public decimal SumAccount2 { get; set; }
        public decimal SumAccount3 { get; set; }
        public decimal SumAccount4 { get; set; }
        public decimal SumItog { get; set; }
        public decimal SumStartYear { get; set; }
    }
}
