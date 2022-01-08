using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using AmortizationOSDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmortizationOSDatabase.Implements
{
    public class MOLStorage : IMOLStorage
    {
        public List<MOLViewModel> GetFullList()
        {
            using (var context = new AmortizationOSDatabase())
            {
                return context.MOL
                .Select(rec => new MOLViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO
                })
                .ToList();
            }
        }
        public List<MOLViewModel> GetFilteredList(MOLBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                return context.MOL
                .Where(rec => rec.FIO.Contains(model.FIO))
               .Select(rec => new MOLViewModel
               {
                   Id = rec.Id,
                   FIO = rec.FIO
               })
                .ToList();
            }
        }
        public MOLViewModel GetElement(MOLBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var mol = context.MOL
                .FirstOrDefault(rec => rec.FIO == model.FIO || rec.Id == model.Id);
                return mol != null ?
                new MOLViewModel
                {
                    Id = mol.Id,
                    FIO = mol.FIO
                } : null;
            }
        }
        public void Insert(MOLBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                context.MOL.Add(CreateModel(model, new MOL()));
                context.SaveChanges();
            }
        }
        public void Update(MOLBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                var element = context.MOL.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(MOLBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                MOL element = context.MOL.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.MOL.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private MOL CreateModel(MOLBindingModel model, MOL component)
        {
            component.FIO = model.FIO;
            return component;
        }
    }
}
