using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    public class ChartOfAccountBusinessLogic
    {
        private readonly IChartOfAccountStorage _chartOfAccountStorage;

        public ChartOfAccountBusinessLogic(IChartOfAccountStorage chartOfAccountStorage)
        {
            _chartOfAccountStorage = chartOfAccountStorage;
        }

        public List<ChartOfAccountViewModel> Read(ChartOfAccountBindingModel model)
        {
            if (model == null)
            {
                return _chartOfAccountStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ChartOfAccountViewModel> { _chartOfAccountStorage.GetElement(model) };
            }
            return _chartOfAccountStorage.GetFilteredList(model);
        }
        public List<ChartOfAccountViewModel> TakeChartOfAccount(ChartOfAccountBindingModel model)
        {
            return new List<ChartOfAccountViewModel> { _chartOfAccountStorage.GetChartOfAccount(model) };
        }
    }
}
