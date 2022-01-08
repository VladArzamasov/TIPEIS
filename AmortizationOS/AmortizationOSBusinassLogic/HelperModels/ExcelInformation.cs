using AmortizationOSBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.HelperModels
{
    class ExcelInformation
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<TurnoverBalanceViewModel> TurnoverBalance { get; set; }
    }
}
