using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    public class MOLBusinessLogic
    {
        private readonly IMOLStorage _molStorage;

        public MOLBusinessLogic(IMOLStorage molStorage)
        {
            _molStorage = molStorage;
        }

        public List<MOLViewModel> Read(MOLBindingModel model)
        {
            if (model == null)
            {
                return _molStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<MOLViewModel> { _molStorage.GetElement(model) };
            }
            return _molStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(MOLBindingModel model)
        {
            var element = _molStorage.GetElement(new MOLBindingModel
            {
                FIO = model.FIO
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть MOL с таким названием");
            }
            if (model.Id.HasValue)
            {
                _molStorage.Update(model);
            }
            else
            {
                _molStorage.Insert(model);
            }
        }
        public void Delete(MOLBindingModel model)
        {
            var element = _molStorage.GetElement(new MOLBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _molStorage.Delete(model);
        }
    }
}
