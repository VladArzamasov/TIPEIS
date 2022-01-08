using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AmortizationOSBusinessLogic.ViewModels
{
    public class AmortizationViewModel
    {
        [DisplayName("Номер")]
        public int Id { get; set; }
        [DisplayName("Дата")]
        public DateTime AmortizationDate { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Комментарий")]
        public string Comment { get; set; }
        [DataMember]
        public Dictionary<int, (string, decimal)> AmortizationOs { get; set; }
    }
}
