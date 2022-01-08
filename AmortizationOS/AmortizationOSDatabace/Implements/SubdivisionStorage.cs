using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using AmortizationOSDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmortizationOSDatabase.Implements
{
    public class SubdivisionStorage : ISubdivisionStorage
    {
        public List<SubdivisionViewModel> GetFullList()
        {
            using (var context = new AmortizationOSDatabase())
            {
                return context.Subdivision
                    .Include(rec => rec.ChartOfAccounts)
                .Select(CreateModel).ToList();
            }
        }

        public List<SubdivisionViewModel> GetFilteredList(SubdivisionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                return context.Subdivision
                    .Include(rec => rec.ChartOfAccounts)
                    .Where(rec => rec.SubdivisionName == model.SubdivisionName)
                    .Select(CreateModel).ToList();
            }
        }

        public SubdivisionViewModel GetElement(SubdivisionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var subdivision = context.Subdivision
                    .Include(rec => rec.ChartOfAccounts)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return subdivision != null ?
                CreateModel(subdivision) : null;
            }
        }
        public SubdivisionBindingModel GetSubdivision(SubdivisionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var subdivision = context.Subdivision
                    .Include(rec => rec.ChartOfAccounts)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return subdivision != null ?
                CreateModele(subdivision) : null;
            }
        }
        public void Insert(SubdivisionBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                context.Subdivision.Add(CreateModel(model, new Subdivision()));
                context.SaveChanges();
            }
        }

        public void Update(SubdivisionBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                Subdivision element = context.Subdivision.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Подразделение не найдено");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(SubdivisionBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                Subdivision element = context.Subdivision.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Subdivision.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Подразделение не найдено");
                }
            }
        }

        private Subdivision CreateModel(SubdivisionBindingModel model, Subdivision subdivision)
        {
            subdivision.SubdivisionName = model.SubdivisionName;
            subdivision.ExpenseAccount = model.ExpenceAccount;
            return subdivision;
        }

        private SubdivisionViewModel CreateModel(Subdivision subdivision)
        {
            return new SubdivisionViewModel
            {
                Id = subdivision.Id,
                SubdivisionName = subdivision.SubdivisionName,
                ExpenceAccount = subdivision.ChartOfAccounts.AccountNumber
            };
        }
        private SubdivisionBindingModel CreateModele(Subdivision subdivision)
        {
            return new SubdivisionBindingModel
            {
                Id = subdivision.Id,
                SubdivisionName = subdivision.SubdivisionName,
                ExpenceAccount = subdivision.ChartOfAccounts.Id
            };
        }
    }
}
