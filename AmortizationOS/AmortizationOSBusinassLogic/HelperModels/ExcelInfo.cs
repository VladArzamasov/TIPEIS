using AmortizationOSBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportCalculationViewModel> ReportCalculation { get; set; }
    }
}
