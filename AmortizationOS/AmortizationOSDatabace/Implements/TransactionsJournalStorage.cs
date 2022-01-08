using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using AmortizationOSDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AmortizationOSDatabase.Implements
{
    public class TransactionsJournalStorage : ITransactionsJournalStorage
    {
        public List<TransactionsJournalViewModel> GetFullList()
        {
            using (var context = new AmortizationOSDatabase())
            {
                return context.TransactionsJournal
                    .Include(rec => rec.AccountsDebet)
                    .Include(rec => rec.AccountsKredit)
                    .Include(rec => rec.Amortization)
                .Select(CreateModel).ToList();
            }
        }

        public List<TransactionsJournalViewModel> GetFilteredList(TransactionsJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                return context.TransactionsJournal
                    .Include(rec => rec.AccountsDebet)
                    .Include(rec => rec.AccountsKredit)
                    .Include(rec => rec.Amortization)
                    .Where(rec => (rec.AmortizationId == model.AmortizationId) || (rec.AccountDebet == model.AccountDebet) || (rec.AccountKredit == model.AccountKredit))
                    .Select(CreateModel).ToList();
            }
        }

        public TransactionsJournalViewModel GetElement(TransactionsJournalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var transactionsJournal = context.TransactionsJournal
                    .Include(rec => rec.AccountsDebet)
                    .Include(rec => rec.AccountsKredit)
                    .Include(rec => rec.Amortization)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return transactionsJournal != null ?
                CreateModel(transactionsJournal) : null;
            }
        }
        public List<TransactionsJournalViewModel> SearchTransactionsJournal(DateTime date1, DateTime date2)
        {
            using (var context = new AmortizationOSDatabase())
            {
                return context.TransactionsJournal
                    .Include(rec => rec.AccountsDebet)
                    .Include(rec => rec.AccountsKredit)
                    .Include(rec => rec.Amortization)
                    .Where(rec => rec.Date >= date1 && rec.Date <= date2)
                    .Select(CreateModel).ToList();
            }
        }
        public void Insert(TransactionsJournalBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                context.TransactionsJournal.Add(CreateModel(model, new TransactionsJournal()));
                context.SaveChanges();
            }
        }

        public void Update(TransactionsJournalBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                TransactionsJournal element = context.TransactionsJournal.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(TransactionsJournalBindingModel model)
        {
            using (var context = new AmortizationOSDatabase())
            {
                TransactionsJournal element = context.TransactionsJournal.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.TransactionsJournal.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private TransactionsJournal CreateModel(TransactionsJournalBindingModel model, TransactionsJournal transactionsJournal)
        {
            transactionsJournal.Date = model.Date;
            transactionsJournal.AccountDebet = model.AccountDebet;
            transactionsJournal.AccountKredit = model.AccountKredit;
            transactionsJournal.SubcontoDt1 = model.SubcontoDt1;
            transactionsJournal.SubcontoDt2 = model.SubcontoDt2;
            transactionsJournal.SubcontoDt3 = model.SubcontoDt3;
            transactionsJournal.SubcontoCt1 = model.SubcontoCt1;
            transactionsJournal.SubcontoCt2 = model.SubcontoCt2;
            transactionsJournal.SubcontoCt3 = model.SubcontoCt3;
            transactionsJournal.Sum = model.Sum;
            transactionsJournal.AmortizationId = model.AmortizationId;
            transactionsJournal.Comment = model.Comment;
            return transactionsJournal;
        }

        private TransactionsJournalViewModel CreateModel(TransactionsJournal transactionsJournal)
        {
            return new TransactionsJournalViewModel
            {
                Id = transactionsJournal.Id,
                Date = transactionsJournal.Date,
                AccountDebet = transactionsJournal.AccountsDebet.AccountNumber,
                AccountKredit = transactionsJournal.AccountsKredit.AccountNumber,
                SubcontoDt1 = transactionsJournal.SubcontoDt1,
                SubcontoDt2 = transactionsJournal.SubcontoDt2,
                SubcontoDt3 = transactionsJournal.SubcontoDt3,
                SubcontoCt1 = transactionsJournal.SubcontoCt1,
                SubcontoCt2 = transactionsJournal.SubcontoCt2,
                SubcontoCt3 = transactionsJournal.SubcontoCt3,
                Sum = transactionsJournal.Sum,
                AmortizationId = transactionsJournal.Amortization.Id,
                Comment = transactionsJournal.Comment
            };
        }
    }
}
