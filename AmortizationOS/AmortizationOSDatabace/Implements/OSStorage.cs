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
    public class OSStorage : IOSStorage
    {
        public List<OSViewModel> GetFullList()
        {
            using (var context = new AmortizationOSDatabase())
            {
                return context.OS
                    .Include(rec => rec.Subdivision)
                    .Include(rec => rec.MOL)
                .Select(CreateModel).ToList();
            }
        }

        public List<OSViewModel> GetFilteredList(OSBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                return context.OS
                    .Include(rec => rec.Subdivision)
                    .Include(rec => rec.MOL)
                    .Where(rec => rec.Status == model.Status)
                    .Select(CreateModel).ToList();
            }
        }

        public OSViewModel GetElement(OSBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var os = context.OS
                    .Include(rec => rec.Subdivision)
                    .Include(rec => rec.MOL)
                .FirstOrDefault(rec => rec.Id == model.Id || rec.OsName == model.OsName);
                return os != null ?
                CreateModel(os) : null;
            }
        }
        public OSBindingModel GetOS(OSBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var os = context.OS
                    .Include(rec => rec.Subdivision)
                    .Include(rec => rec.MOL)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return os != null ?
                CreateModele(os) : null;
            }
        }
        public void Insert(OSBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                context.OS.Add(CreateModel(model, new OS()));
                context.SaveChanges();
            }
        }

        public void Update(OSBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                OS element = context.OS.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void UpdateOs(OSBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                OS element = context.OS.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OSBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                OS element = context.OS.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.OS.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private OS CreateModel(OSBindingModel model, OS os)
        {
            os.OsName = model.OsName;
            os.BalansSum = model.BalansSum;
            os.SPI = model.SPI;
            os.Status = model.Status;
            os.DateAdd = model.DateAdd;
            os.SubdivisionId = model.SubdivisionId;
            os.MolId = model.MolId;
            return os;
        }

        private OSViewModel CreateModel(OS os)
        {
            return new OSViewModel
            {
                Id = os.Id,
                OsName = os.OsName,
                BalansSum = os.BalansSum,
                SPI = os.SPI,
                Status = os.Status,
                DateAdd = os.DateAdd,
                SubdivisionName = os.Subdivision.SubdivisionName,
                MolFIO = os.MOL.FIO
            };
        }
        private OSBindingModel CreateModele(OS os)
        {
            return new OSBindingModel
            {
                Id = os.Id,
                OsName = os.OsName,
                BalansSum = os.BalansSum,
                SPI = os.SPI,
                Status = os.Status,
                DateAdd = os.DateAdd,
                SubdivisionId = os.Subdivision.Id,
                MolId = os.MOL.Id
            };
        }
    }
}
