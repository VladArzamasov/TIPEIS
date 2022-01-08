using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    public class TransactionsJournalBusinessLogic
    {
        private readonly ITransactionsJournalStorage _transactionsJournalStorage;

        public TransactionsJournalBusinessLogic(ITransactionsJournalStorage transactionsJournalStorage)
        {
            _transactionsJournalStorage = transactionsJournalStorage;
        }

        public List<TransactionsJournalViewModel> Read(TransactionsJournalBindingModel model)
        {
            if (model == null)
            {
                return _transactionsJournalStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TransactionsJournalViewModel> { _transactionsJournalStorage.GetElement(model) };
            }
            return _transactionsJournalStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(TransactionsJournalBindingModel model)
        {
            var element = _transactionsJournalStorage.GetElement(new TransactionsJournalBindingModel
            {
                AmortizationId = model.AmortizationId
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая проводка");
            }
            if (model.Id.HasValue)
            {
                _transactionsJournalStorage.Update(model);
            }
            else
            {
                _transactionsJournalStorage.Insert(model);
            }
        }
        public void Delete(TransactionsJournalBindingModel model)
        {
            var element = _transactionsJournalStorage.GetElement(new TransactionsJournalBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _transactionsJournalStorage.Delete(model);
        }
        public List<TransactionsJournalViewModel> Search(DateTime date1, DateTime date2)
        {
            return _transactionsJournalStorage.SearchTransactionsJournal(date1, date2);
        }
    }
}
