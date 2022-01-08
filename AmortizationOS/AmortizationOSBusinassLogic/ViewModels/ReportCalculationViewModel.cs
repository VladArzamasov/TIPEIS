using System;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.ViewModels
{
    public class ReportCalculationViewModel
    {
        public int Id { get; set; }
        public string OsName { get; set; }
        public decimal Sum { get; set; }
        public decimal OstSumStart { get; set; }
        public decimal OstSumEnd { get; set; }
        public decimal SumIznosa { get; set; }
    }
}
