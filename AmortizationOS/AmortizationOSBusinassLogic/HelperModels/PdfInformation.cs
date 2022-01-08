using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.HelperModels
{
    class PdfInformation
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<TurnoverBalanceViewModel> TurnoverBalance { get; set; }
    }
}
