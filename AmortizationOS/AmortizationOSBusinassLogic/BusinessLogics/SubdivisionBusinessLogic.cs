using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    public class SubdivisionBusinessLogic
    {
        private readonly ISubdivisionStorage _subdivisionStorage;

        public SubdivisionBusinessLogic(ISubdivisionStorage subdivisionStorage)
        {
            _subdivisionStorage = subdivisionStorage;
        }

        public List<SubdivisionViewModel> Read(SubdivisionBindingModel model)
        {
            if (model == null)
            {
                return _subdivisionStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SubdivisionViewModel> { _subdivisionStorage.GetElement(model) };
            }
            return _subdivisionStorage.GetFilteredList(model);
        }
        public List<SubdivisionBindingModel> TakeSubdivision(SubdivisionBindingModel model)
        {
            return new List<SubdivisionBindingModel> { _subdivisionStorage.GetSubdivision(model) };
        }
        public void CreateOrUpdate(SubdivisionBindingModel model)
        {
            var element = _subdivisionStorage.GetElement(new SubdivisionBindingModel
            {
                SubdivisionName = model.SubdivisionName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть подразделение с таким названием");
            }
            if (model.Id.HasValue)
            {
                _subdivisionStorage.Update(model);
            }
            else
            {
                _subdivisionStorage.Insert(model);
            }
        }
        public void Delete(SubdivisionBindingModel model)
        {
            var element = _subdivisionStorage.GetElement(new SubdivisionBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _subdivisionStorage.Delete(model);
        }
    }
}
