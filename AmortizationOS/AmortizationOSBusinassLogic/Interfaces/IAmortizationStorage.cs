using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.Interfaces
{
    public interface IAmortizationStorage
    {
        List<AmortizationViewModel> GetFullList();
        List<AmortizationViewModel> GetFilteredList(AmortizationBindingModel model);
        AmortizationViewModel GetElement(AmortizationBindingModel model);
        void Insert(AmortizationBindingModel model);
        void Delete(AmortizationBindingModel model);
    }
}
