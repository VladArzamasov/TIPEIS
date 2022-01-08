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
    public class AmortizationStorage : IAmortizationStorage
    {
        public List<AmortizationViewModel> GetFullList()
        {
            using (var context = new AmortizationOSDatabase())
            {
                return context.Amortization
                    .Include(rec => rec.AmortizationOs)
                    .ThenInclude(rec => rec.OS)
                    .ToList().Select(rec => new AmortizationViewModel
                {
                    Id = rec.Id,
                    AmortizationDate = rec.AmortizationDate,
                    Sum = rec.Sum,
                    Comment = rec.Comment,
                    AmortizationOs = rec.AmortizationOs
                    .ToDictionary(recD => recD.OsId,
                    recD => (recD.OS?.OsName, recD.Sum))
                })
                .ToList();
            }
        }
        public List<AmortizationViewModel> GetFilteredList(AmortizationBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                return context.Amortization
                    .Include(rec => rec.AmortizationOs)
                    .ThenInclude(rec => rec.OS)
                    .Where(rec => rec.Comment == model.Comment)
                    .ToList()
                    .Select(rec => new AmortizationViewModel
                    {
                        Id = rec.Id,
                        AmortizationDate = rec.AmortizationDate,
                        Sum = rec.Sum,
                        Comment = rec.Comment,
                        AmortizationOs = rec.AmortizationOs.ToDictionary(recED => recED.OsId, recED => (recED.OS?.OsName, recED.Sum))
                    })
                .ToList();
            }
        }

        public AmortizationViewModel GetElement(AmortizationBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var amortization = context.Amortization
                    .Include(rec => rec.AmortizationOs)
                    .ThenInclude(rec => rec.OS)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return amortization != null ?
                new AmortizationViewModel
                {
                    Id = amortization.Id,
                    AmortizationDate = amortization.AmortizationDate,
                    Sum = amortization.Sum,
                    Comment = amortization.Comment,
                    AmortizationOs = amortization.AmortizationOs.ToDictionary(recED => recED.OsId, recED => (recED.OS?.OsName, recED.Sum))
                } :
                null;
            }
        }

        public void Insert(AmortizationBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Amortization(), context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
        }
        public void Delete(AmortizationBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                Amortization element = context.Amortization.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Amortization.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Amortization CreateModel(AmortizationBindingModel model, Amortization Amortization, AmortizationOSDatabase context)
        {
            Amortization.AmortizationDate = model.AmortizationDate;
            Amortization.Sum = model.Sum;
            Amortization.Comment = model.Comment;
            
            if (Amortization.Id == 0)
            {
                context.Amortization.Add(Amortization);
                context.SaveChanges();
            }

            foreach (var ed in model.AmortizationOs)
            {
                context.AmortizationOs.Add(new AmortizationOS
                {
                    AmortizationId = Amortization.Id,
                    OsId = ed.Key,
                    Sum = ed.Value.Item2
                });

                context.SaveChanges();
            }

            return Amortization;
        }
    }
}
