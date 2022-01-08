using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.Interfaces
{
    public interface ISubdivisionStorage
    {
        List<SubdivisionViewModel> GetFullList();
        List<SubdivisionViewModel> GetFilteredList(SubdivisionBindingModel model);
        SubdivisionViewModel GetElement(SubdivisionBindingModel model);
        SubdivisionBindingModel GetSubdivision(SubdivisionBindingModel model);
        void Insert(SubdivisionBindingModel model);
        void Update(SubdivisionBindingModel model);
        void Delete(SubdivisionBindingModel model);
    }
}
