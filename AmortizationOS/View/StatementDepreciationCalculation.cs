using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using AmortizationOSBusinessLogic.Enums;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace AmortizationOS
{
    public partial class StatementDepreciationCalculation : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly MailLogic mailLogic;
        public StatementDepreciationCalculation(ReportLogic logic, MailLogic mailLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.mailLogic = mailLogic;
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (comboBoxMonth.SelectedValue == null)
            {
                MessageBox.Show("Выберите месяц", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxYear.Text == "")
            {
                MessageBox.Show("Выберите год", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                labelZagolovok.Visible = true;
                labelZagolovok.Text = "Ведомость расчета износа за " + comboBoxMonth.Text + " месяц " + comboBoxYear.Text + " года";
                decimal itog = 0;
                var dict = logic.GetIznos(new ReportBindingModel
                {
                    Month = (Month)Enum.Parse(typeof(Month), comboBoxMonth.SelectedValue.ToString()),
                    Year = comboBoxYear.Text
                });
                if (dict != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        itog += elem.Sum;
                        dataGridView1.Rows.Add(new object[] { elem.Id, elem.OsName, elem.Sum, elem.OstSumStart, elem.OstSumEnd, elem.SumIznosa });
                    }
                    dataGridView1.Rows.Add(new object[] { "Итого", "", itog, "", "", "" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void StatementDepreciationCalculation_Load(object sender, EventArgs e)
        {
            comboBoxMonth.DataSource = Enum.GetValues(typeof(Month)).Cast<Month>().Select(p => new { Name = Enum.GetName(typeof(Month), p), Value = (int)p }).ToList();
            comboBoxMonth.DisplayMember = "Name";
            comboBoxMonth.ValueMember = "Name";
            comboBoxMonth.SelectedItem = null;
            labelZagolovok.Visible = false;
        }

        private void buttonSaveToExel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveToExcelFileReportCalculation(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            Month = (Month)Enum.Parse(typeof(Month), comboBoxMonth.SelectedValue.ToString()),
                            Year = comboBoxYear.Text
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

        private void buttonSaveToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveToPdfFileReportCalculation(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            Month = (Month)Enum.Parse(typeof(Month), comboBoxMonth.SelectedValue.ToString()),
                            Year = comboBoxYear.Text
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
            if (comboBoxMonth.SelectedValue == null)
            {
                MessageBox.Show("Выберите месяц", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxYear.Text == "")
            {
                MessageBox.Show("Выберите год", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.SaveToPdfFileReportCalculation(new ReportBindingModel
                {
                    FileName = "D:\\Отчеты\\Ведомость расчета износа.pdf",
                    Month = (Month)Enum.Parse(typeof(Month), comboBoxMonth.SelectedValue.ToString()),
                    Year = comboBoxYear.Text
                });
                mailLogic.sendMailStatementDepreciationCalculation();
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
                        logic.SaveToWordFileReportCalculation(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            Month = (Month)Enum.Parse(typeof(Month), comboBoxMonth.SelectedValue.ToString()),
                            Year = comboBoxYear.Text
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
