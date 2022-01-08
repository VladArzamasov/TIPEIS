using System;
using System.Collections.Generic;
using System.Text;
using AmortizationOSBusinessLogic.ViewModels;

namespace AmortizationOSBusinessLogic.HelperModels
{
    class WordInformation
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<TurnoverBalanceViewModel> TurnoverBalance { get; set; }
    }
}
