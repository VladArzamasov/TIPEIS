using System;
using System.Collections.Generic;
using System.Text;

namespace AmortizationOSBusinessLogic.ViewModels
{
    public class TurnoverBalanceViewModel
    {
        public string Account { get; set; }
        public decimal DebetStart { get; set; }
        public decimal KreditStart { get; set; }
        public decimal DebetObr { get; set; }
        public decimal KreditObr { get; set; }
        public decimal DebetOst { get; set; }
        public decimal KreditOst { get; set; }
    }
}
