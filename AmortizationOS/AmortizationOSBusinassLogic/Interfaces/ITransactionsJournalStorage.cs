using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.Interfaces
{
    public interface ITransactionsJournalStorage
    {
        List<TransactionsJournalViewModel> GetFullList();
        List<TransactionsJournalViewModel> GetFilteredList(TransactionsJournalBindingModel model);
        TransactionsJournalViewModel GetElement(TransactionsJournalBindingModel model);
        void Insert(TransactionsJournalBindingModel model);
        void Update(TransactionsJournalBindingModel model);
        void Delete(TransactionsJournalBindingModel model);
        List<TransactionsJournalViewModel> SearchTransactionsJournal(DateTime date1, DateTime date2);
    }
}
