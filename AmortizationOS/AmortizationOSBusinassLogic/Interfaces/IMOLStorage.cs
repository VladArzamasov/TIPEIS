using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.Interfaces
{
    public interface IMOLStorage
    {
        List<MOLViewModel> GetFullList();
        List<MOLViewModel> GetFilteredList(MOLBindingModel model);
        MOLViewModel GetElement(MOLBindingModel model);
        void Insert(MOLBindingModel model);

        void Update(MOLBindingModel model);

        void Delete(MOLBindingModel model);
    }
}
