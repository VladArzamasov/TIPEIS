using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AmortizationOSBusinessLogic.ViewModels
{
    public class MOLViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО")]
        public string FIO { get; set; }
    }
}
