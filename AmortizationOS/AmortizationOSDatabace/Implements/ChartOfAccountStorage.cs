using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmortizationOSDatabase.Implements
{
    public class ChartOfAccountStorage : IChartOfAccountStorage
    {
        public List<ChartOfAccountViewModel> GetFullList()
        {
            using (var context = new AmortizationOSDatabase())
            {
                return context.ChartOfAccounts.Select(rec => new ChartOfAccountViewModel
                {
                    Id = rec.Id,
                    AccountName = rec.AccountName,
                    AccountNumber = rec.AccountNumber,
                    Subconto1 = rec.Subconto1,
                    Subconto2 = rec.Subconto2,
                    Subconto3 = rec.Subconto3
                })
                .ToList();
            }
        }

        public List<ChartOfAccountViewModel> GetFilteredList(ChartOfAccountBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                return context.ChartOfAccounts
                    .Where(rec => rec.AccountNumber == model.AccountNumber).Select(rec => new ChartOfAccountViewModel
                    {
                        Id = rec.Id,
                        AccountName = rec.AccountName,
                        AccountNumber = rec.AccountNumber,
                        Subconto1 = rec.Subconto1,
                        Subconto2 = rec.Subconto2,
                        Subconto3 = rec.Subconto3
                    })
                .ToList();
            }
        }

        public ChartOfAccountViewModel GetElement(ChartOfAccountBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var chartOfAccount = context.ChartOfAccounts.FirstOrDefault(rec => rec.Id == model.Id);
                return chartOfAccount != null ?
                new ChartOfAccountViewModel
                {
                    Id = chartOfAccount.Id,
                    AccountName = chartOfAccount.AccountName,
                    AccountNumber = chartOfAccount.AccountNumber,
                    Subconto1 = chartOfAccount.Subconto1,
                    Subconto2 = chartOfAccount.Subconto2,
                    Subconto3 = chartOfAccount.Subconto3
                } :
                null;
            }
        }
        public ChartOfAccountViewModel GetChartOfAccount(ChartOfAccountBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AmortizationOSDatabase())
            {
                var chartOfAccount = context.ChartOfAccounts.FirstOrDefault(rec => rec.AccountNumber == model.AccountNumber);
                return chartOfAccount != null ?
                new ChartOfAccountViewModel
                {
                    Id = chartOfAccount.Id,
                    AccountName = chartOfAccount.AccountName,
                    AccountNumber = chartOfAccount.AccountNumber,
                    Subconto1 = chartOfAccount.Subconto1,
                    Subconto2 = chartOfAccount.Subconto2,
                    Subconto3 = chartOfAccount.Subconto3
                } :
                null;
            }
        }
    }
}
