using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AmortizationOSBusinessLogic.ViewModels
{
    public class SubdivisionViewModel
    {
        public int Id { get; set; }
        [DisplayName("Наименование")]
        public string SubdivisionName { get; set; }
        [DisplayName("Счет затрат")]
        public string ExpenceAccount { get; set; }
    }
}
