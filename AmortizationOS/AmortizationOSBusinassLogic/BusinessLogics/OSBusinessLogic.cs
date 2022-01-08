using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    public class OSBusinessLogic
    {
        private readonly IOSStorage _ocStorage;

        public OSBusinessLogic(IOSStorage ocStorage)
        {
            _ocStorage = ocStorage;
        }

        public List<OSViewModel> Read(OSBindingModel model)
        {
            if (model == null)
            {
                return _ocStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OSViewModel> { _ocStorage.GetElement(model) };
            }
            return _ocStorage.GetFilteredList(model);
        }
        public List<OSBindingModel> TakeOS(OSBindingModel model)
        {
            return new List<OSBindingModel> { _ocStorage.GetOS(model) };
        }
        public void CreateOrUpdate(OSBindingModel model)
        {
            var element = _ocStorage.GetElement(new OSBindingModel
            {
                OsName = model.OsName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть основное средство с таким названием");
            }
            if (model.Id.HasValue)
            {
                _ocStorage.Update(model);
            }
            else
            {
                _ocStorage.Insert(model);
            }
        }
        public void Update(OSBindingModel model)
        {
            _ocStorage.UpdateOs(model);
        }
        public void Delete(OSBindingModel model)
        {
            var element = _ocStorage.GetElement(new OSBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _ocStorage.Delete(model);
        }
    }
}
