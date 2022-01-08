using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.Interfaces
{
    public interface IChartOfAccountStorage
    {
        List<ChartOfAccountViewModel> GetFullList();
        List<ChartOfAccountViewModel> GetFilteredList(ChartOfAccountBindingModel model);
        ChartOfAccountViewModel GetElement(ChartOfAccountBindingModel model);
        ChartOfAccountViewModel GetChartOfAccount(ChartOfAccountBindingModel model);
    }
}
