using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.Interfaces
{
    public interface IOSStorage
    {
        List<OSViewModel> GetFullList();
        List<OSViewModel> GetFilteredList(OSBindingModel model);
        OSViewModel GetElement(OSBindingModel model);
        OSBindingModel GetOS(OSBindingModel model);
        void Insert(OSBindingModel model);
        void Update(OSBindingModel model);
        void UpdateOs(OSBindingModel model);
        void Delete(OSBindingModel model);
    }
}
