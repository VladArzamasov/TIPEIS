using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDistributionViewModel> ReportDistribution { get; set; }
    }
}
