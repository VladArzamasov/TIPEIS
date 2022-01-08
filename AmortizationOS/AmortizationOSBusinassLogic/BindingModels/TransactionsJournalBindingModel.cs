using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.BindingModels
{
    public class TransactionsJournalBindingModel
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public int AccountDebet { get; set; }
        public string SubcontoDt1 { get; set; }
        public string SubcontoDt2 { get; set; }
        public string SubcontoDt3 { get; set; }
        public int AccountKredit { get; set; }
        public string SubcontoCt1 { get; set; }
        public string SubcontoCt2 { get; set; }
        public string SubcontoCt3 { get; set; }
        public decimal Sum { get; set; }
        public int AmortizationId { get; set; }
        public string Comment { get; set; }
    }
}
