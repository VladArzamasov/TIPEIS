using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AmortizationOSBusinessLogic.ViewModels
{
    public class TransactionsJournalViewModel
    {
        [DisplayName("Номер")]
        public int Id { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Счет Дт")]
        public string AccountDebet { get; set; }
        [DisplayName("Субконто1 Дт")]
        public string SubcontoDt1 { get; set; }
        [DisplayName("Субконто2 Дт")]
        public string SubcontoDt2 { get; set; }
        [DisplayName("Субконто3 Дт")]
        public string SubcontoDt3 { get; set; }
        [DisplayName("Счет Кт")]
        public string AccountKredit { get; set; }
        [DisplayName("Субконто1 Кт")]
        public string SubcontoCt1 { get; set; }
        [DisplayName("Субконто2 Кт")]
        public string SubcontoCt2 { get; set; }
        [DisplayName("Субконто3 Кт")]
        public string SubcontoCt3 { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Операция")]
        public int AmortizationId { get; set; }
        [DisplayName("Комментарий")]
        public string Comment { get; set; }
    }
}
