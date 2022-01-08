using AmortizationOSBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.HelperModels
{
    class ExcelInfoes
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDistributionViewModel> ReportDistribution { get; set; }
    }
}
