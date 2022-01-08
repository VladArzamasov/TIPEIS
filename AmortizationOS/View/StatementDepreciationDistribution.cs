using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using AmortizationOSBusinessLogic.Enums;
using Microsoft.Reporting.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace AmortizationOS
{
    public partial class StatementDepreciationDistribution : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly MailLogic mailLogic;
        public StatementDepreciationDistribution(ReportLogic logic, MailLogic mailLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.mailLogic = mailLogic;
        }

        private void StatementDepreciationDistribution_Load(object sender, EventArgs e)
        {
            comboBoxMonth.DataSource = Enum.GetValues(typeof(Month)).Cast<Month>().Select(p => new { Name = Enum.GetName(typeof(Month), p), Value = (int)p }).ToList();
            comboBoxMonth.DisplayMember = "Name";
            comboBoxMonth.ValueMember = "Name";
            comboBoxMonth.SelectedItem = null;
            this.reportViewer1.RefreshReport();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
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
                ReportParameter parameter = new ReportParameter("ReportParameter", "Ведомость распределения износа по счетам затрат с начала года по " +
               comboBoxMonth.Text + " " + comboBoxYear.Text + " года");
                reportViewer1.LocalReport.SetParameters(parameter);
                var dataSource = logic.GetDistributionIznos(new ReportBindingModel
                {
                    Month = (Month)Enum.Parse(typeof(Month), comboBoxMonth.SelectedValue.ToString()),
                    Year = comboBoxYear.Text
                });
                ReportDataSource source = new ReportDataSource("DataSetReport", dataSource);
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToPdf_Click(object sender, EventArgs e)
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
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveToPdfFileReportDistribution(new ReportBindingModel
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

        private void buttonSaveToExel_Click(object sender, EventArgs e)
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
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveToExcelFileReportDistribution(new ReportBindingModel
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
                logic.SaveToPdfFileReportDistribution(new ReportBindingModel
                {
                    FileName = "D:\\Отчеты\\Ведомость распределения износа по счетам затрат.pdf",
                    Month = (Month)Enum.Parse(typeof(Month), comboBoxMonth.SelectedValue.ToString()),
                    Year = comboBoxYear.Text
                });
                mailLogic.sendMailStatementDepreciationDistribution();
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
                        logic.SaveToWordFileReportDistribution(new ReportBindingModel
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
