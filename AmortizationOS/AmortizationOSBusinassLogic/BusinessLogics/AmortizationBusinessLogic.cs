using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    public class AmortizationBusinessLogic
    {
        private readonly IAmortizationStorage _amortizationStorage;
        public AmortizationBusinessLogic(IAmortizationStorage amortizationStorage)
        {
            _amortizationStorage = amortizationStorage;
        }
        public List<AmortizationViewModel> Read(AmortizationBindingModel model)
        {
            if (model == null)
            {
                return _amortizationStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<AmortizationViewModel> { _amortizationStorage.GetElement(model)
};
            }
            return _amortizationStorage.GetFilteredList(model);
        }
        public void Create(AmortizationBindingModel model)
        {
            var element = _amortizationStorage.GetElement(new AmortizationBindingModel
            {
                Id = model.Id
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая операция");
            }
            _amortizationStorage.Insert(model);

        }
        public void Delete(AmortizationBindingModel model)
        {
            var element = _amortizationStorage.GetElement(new AmortizationBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _amortizationStorage.Delete(model);
        }
    }
}
