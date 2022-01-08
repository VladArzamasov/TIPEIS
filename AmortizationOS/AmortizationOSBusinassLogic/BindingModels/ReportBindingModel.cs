using System;
using System.Collections.Generic;
using System.Text;
using AmortizationOSBusinessLogic.Enums;

namespace AmortizationOSBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public Month Month { get; set; }
        public string Year { get; set; }
    }
}
