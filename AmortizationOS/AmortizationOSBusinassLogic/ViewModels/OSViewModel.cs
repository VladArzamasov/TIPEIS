using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AmortizationOSBusinessLogic.ViewModels
{
    public class OSViewModel
    {
        public int Id { get; set; }
        [DisplayName("Наименование")]
        public string OsName { get; set; }
        [DisplayName("Балансовая стоимость")]
        public decimal BalansSum { get; set; }
        [DisplayName("Срок полезного использования")]
        public int SPI { get; set; }
        [DisplayName("Cтатус")]
        public string Status { get; set; }
        [DisplayName("Дата ввода в эксплуатацию")]
        public DateTime DateAdd { get; set; }
        [DisplayName("Подразделение")]
        public string SubdivisionName { get; set; }
        [DisplayName("МОЛ")]
        public string MolFIO { get; set; }
    }
}
