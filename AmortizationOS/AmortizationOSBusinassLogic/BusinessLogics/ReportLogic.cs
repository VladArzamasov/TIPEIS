using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.HelperModels;
using AmortizationOSBusinessLogic.Interfaces;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IOSStorage _osStorage;
        private readonly ITransactionsJournalStorage _transactionsJournalStorage;
        private readonly IChartOfAccountStorage _chartOfAccountStorage;
        public ReportLogic(IOSStorage osStorage, ITransactionsJournalStorage transactionsJournalStorage, IChartOfAccountStorage chartOfAccountStorage)
        {
            _osStorage = osStorage;
            _transactionsJournalStorage = transactionsJournalStorage;
            _chartOfAccountStorage = chartOfAccountStorage;
        }
        public List<ReportCalculationViewModel> GetIznos(ReportBindingModel model)
        {
            var transactions = _transactionsJournalStorage.GetFullList();
            var list = new List<ReportCalculationViewModel>();
            foreach (var transaction in transactions)
            {
                if (transaction.Date.Month == (int) model.Month && transaction.Date.Year.ToString() == model.Year && transaction.Comment == "Амортизация ОС")
                {
                    DateTime date = transaction.Date;
                    var os = _osStorage.GetElement(new OSBindingModel
                        {
                            OsName = transaction.SubcontoCt1
                        });
                    var record = new ReportCalculationViewModel
                    {
                        Id = os.Id,
                        OsName = os.OsName,
                        Sum = transaction.Sum,
                        OstSumStart = os.BalansSum,
                        OstSumEnd = 0,
                        SumIznosa = transaction.Sum
                    };
                    foreach (var trans in transactions)
                    {
                        if(trans.Date.Month < date.Month && trans.Date.Year <= date.Year && trans.Comment == "Амортизация ОС" && trans.SubcontoCt1 == os.OsName)
                        {
                            record.OstSumStart -= trans.Sum;
                            if (trans.Date.Year == date.Year)
                            {
                                record.SumIznosa += trans.Sum;
                            }
                        }
                    }
                    record.OstSumEnd = record.OstSumStart - transaction.Sum;
                    list.Add(record);
                }
            }
            return list;
        }
        public List<ReportDistributionViewModel> GetDistributionIznos(ReportBindingModel model)
        {
            var transactions = _transactionsJournalStorage.GetFullList();
            var list = new List<ReportDistributionViewModel>();
            var trans = new List<TransactionsJournalViewModel>();
            foreach (var transaction in transactions)
            {
                if (transaction.Date.Month <= (int)model.Month && transaction.Date.Year.ToString() == model.Year && transaction.Comment == "Амортизация ОС")
                {
                    trans.Add(transaction);
                }
            }
            for (int i = 1; i <= (int)model.Month; i++)
            {
                var record = new ReportDistributionViewModel
                {
                    Month = ((Enums.Month)Enum.GetValues(typeof(Enums.Month)).GetValue(i-1)).ToString(),
                    SumAccount1 = 0,
                    SumAccount2 = 0,
                    SumAccount3 = 0,
                    SumAccount4 = 0,
                    SumItog = 0,
                    SumStartYear = 0
                };
                foreach (var transaction in trans)
                {
                    if (transaction.Date.Month == i)
                    {
                        record.SumItog += transaction.Sum;
                        if (transaction.AccountDebet == "20")
                        {
                            record.SumAccount1 = transaction.Sum;
                        }
                        else if (transaction.AccountDebet == "23")
                        {
                            record.SumAccount2 = transaction.Sum;
                        }
                        else if (transaction.AccountDebet == "25")
                        {
                            record.SumAccount3 = transaction.Sum;
                        }
                        else
                        {
                            record.SumAccount4 = transaction.Sum;
                        }
                    }
                }
                if (i > 1) { record.SumStartYear = list[i - 2].SumStartYear + record.SumItog; }
                else { record.SumStartYear = record.SumItog; }
                list.Add(record);
            }
            return list;
        }
        public List<TurnoverBalanceViewModel> GetTurnoverBalance(TurnoverBalanceBindingModel model)
        {
            var list = new List<TurnoverBalanceViewModel>();
            var chartOfAccaonts = _chartOfAccountStorage.GetFullList();
            foreach (var chartOfAccaont in chartOfAccaonts)
            {
                decimal debetStart = 0;
                decimal kreditStart = 0;
                if (chartOfAccaont.AccountNumber != "000")
                {
                    var transactionsDebet = _transactionsJournalStorage.GetFilteredList(new TransactionsJournalBindingModel
                    {
                        AccountDebet = chartOfAccaont.Id
                    });
                    var transactionsKredit = _transactionsJournalStorage.GetFilteredList(new TransactionsJournalBindingModel
                    {
                        AccountKredit = chartOfAccaont.Id
                    });
                    var record = new TurnoverBalanceViewModel
                    {
                        Account = chartOfAccaont.AccountNumber,
                        DebetStart = 0,
                        KreditStart = 0,
                        DebetObr = 0,
                        KreditObr = 0,
                        DebetOst = 0,
                        KreditOst = 0
                    };
                    foreach (var transactionDebet in transactionsDebet)
                    {
                        if (transactionDebet.Date < model.dateFrom)
                        {
                            debetStart += transactionDebet.Sum;
                        }
                        if (transactionDebet.Date >= model.dateFrom && transactionDebet.Date <= model.dateTo)
                        {
                            record.DebetObr += transactionDebet.Sum;
                        }
                    }
                    foreach (var transactionKredit in transactionsKredit)
                    {
                        if (transactionKredit.Date < model.dateFrom)
                        {
                            kreditStart += transactionKredit.Sum;
                        }
                        if (transactionKredit.Date >= model.dateFrom && transactionKredit.Date <= model.dateTo)
                        {
                            record.KreditObr += transactionKredit.Sum;
                        }
                    }
                    if (record.Account != "02")
                    {
                        record.DebetStart = debetStart - kreditStart;
                        record.DebetOst = record.DebetStart + record.DebetObr - record.KreditObr;
                    }
                    else
                    {
                        record.KreditStart = kreditStart - debetStart;
                        record.KreditOst = record.KreditStart + record.KreditObr - record.DebetObr;
                    }
                    list.Add(record);
                }
            }
            return list;
        }
        public void SaveToExcelFileReportCalculation(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Ведомость расчета износа за " + model.Month + " " + model.Year + " года",
                ReportCalculation = GetIznos(model)
            });
        }
        public void SaveToPdfFileReportCalculation(ReportBindingModel model)
        {
            SaveToPdf.CreateDocument(new PdfIfoes
            {
                FileName = model.FileName,
                Title = "Ведомость расчета износа за " + model.Month + " " + model.Year + " года",
                ReportCalculation = GetIznos(model)
            });
        }
        public void SaveToWordFileReportCalculation(ReportBindingModel model)
        {
            SaveToWord.CreateDocument(new WordInfoes
            {
                FileName = model.FileName,
                Title = "Ведомость расчета износа за " + model.Month + " " + model.Year + " года",
                ReportCalculation = GetIznos(model)
            });
        }
        public void SaveToPdfFileReportDistribution(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Ведомость распределения износа по счетам затрат с начала года по " + model.Month + " " + model.Year + " года",
                ReportDistribution = GetDistributionIznos(model)
            });
        }
        public void SaveToExcelFileReportDistribution(ReportBindingModel model)
        {
            SaveToExcel.CreateDocument(new ExcelInfoes
            {
                FileName = model.FileName,
                Title = "Ведомость распределения износа по счетам затрат с начала года по " + model.Month + " " + model.Year + " года",
                ReportDistribution = GetDistributionIznos(model)
            });
        }
        public void SaveToWordFileReportDistribution(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Ведомость распределения износа по счетам затрат с начала года по " + model.Month + " " + model.Year + " года",
                ReportDistribution = GetDistributionIznos(model)
            });
        }
        public void SaveToPdfFile(TurnoverBalanceBindingModel model)
        {
            SaveToPdf.CreateDocumention(new PdfInformation
            {
                FileName = model.FileName,
                Title = "Оборотно-сальдовая ведомость с " + model.dateFrom + " по " + model.dateFrom + ".",
                TurnoverBalance = GetTurnoverBalance(model)
            });
        }
        public void SaveToExcelFile(TurnoverBalanceBindingModel model)
        {
            SaveToExcel.CreateDocumention(new ExcelInformation
            {
                FileName = model.FileName,
                Title = "Оборотно-сальдовая ведомость с " + model.dateFrom + " по " + model.dateFrom + ".",
                TurnoverBalance = GetTurnoverBalance(model)
            });
        }
        public void SaveToWordFile(TurnoverBalanceBindingModel model)
        {
            SaveToWord.CreateDocumention(new WordInformation
            {
                FileName = model.FileName,
                Title = "Оборотно-сальдовая ведомость с " + model.dateFrom + " по " + model.dateFrom + ".",
                TurnoverBalance = GetTurnoverBalance(model)
            });
        }
    }
}
