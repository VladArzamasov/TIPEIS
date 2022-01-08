using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace AmortizationOS
{
    public partial class TurnoverBalanceForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly MailLogic mailLogic;
        public TurnoverBalanceForm(ReportLogic logic, MailLogic mailLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.mailLogic = mailLogic;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetTurnoverBalance(new TurnoverBalanceBindingModel
                {
                    dateFrom = dateTimePickerFrom.Value,
                    dateTo = dateTimePickerTo.Value
                });
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.Account, elem.DebetStart, elem.KreditStart, elem.DebetObr, elem.KreditObr, elem.DebetOst, elem.KreditOst });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveToPdfFile(new TurnoverBalanceBindingModel
                        {
                            FileName = dialog.FileName,
                            dateFrom = dateTimePickerFrom.Value,
                            dateTo = dateTimePickerTo.Value
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveToExcelFile(new TurnoverBalanceBindingModel
                        {
                            FileName = dialog.FileName,
                            dateFrom = dateTimePickerFrom.Value,
                            dateTo = dateTimePickerTo.Value
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonMail_Click(object sender, EventArgs e)
        {
            try
            {
                logic.SaveToPdfFile(new TurnoverBalanceBindingModel
                {
                    FileName = "D:\\Отчеты\\Оборотно-сальдовая ведомость.pdf",
                    dateFrom = dateTimePickerFrom.Value,
                    dateTo = dateTimePickerTo.Value
                });
                mailLogic.sendMailTurnoverBalance();
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToWord_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveToWordFile(new TurnoverBalanceBindingModel
                        {
                            FileName = dialog.FileName,
                            dateFrom = dateTimePickerFrom.Value,
                            dateTo = dateTimePickerTo.Value
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
