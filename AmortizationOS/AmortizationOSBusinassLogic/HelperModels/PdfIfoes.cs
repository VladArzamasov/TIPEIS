using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.HelperModels
{
    class PdfIfoes
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportCalculationViewModel> ReportCalculation { get; set; }
    }
}
