using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AmortizationOS
{
    public partial class TransactionsAddForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly AmortizationBusinessLogic _amortizationBusinesslogic;
        private readonly OSBusinessLogic _osBusinesslogic;
        private readonly TransactionsJournalBusinessLogic _transactionsJournalBusinesslogic;
        private readonly ChartOfAccountBusinessLogic _chartOfAccountBusinesslogic;
        private Dictionary<int, (string, decimal)> operationOs;
        public TransactionsAddForm(AmortizationBusinessLogic amortizationBusinesslogic, OSBusinessLogic osBusinesslogic, TransactionsJournalBusinessLogic transactionsJournalBusinesslogic,
            ChartOfAccountBusinessLogic chartOfAccountBusinesslogic)
        {
            InitializeComponent();
            _amortizationBusinesslogic = amortizationBusinesslogic;
            _osBusinesslogic = osBusinesslogic;
            _transactionsJournalBusinesslogic = transactionsJournalBusinesslogic;
            _chartOfAccountBusinesslogic = chartOfAccountBusinesslogic;
        }

        private void TransactionsAddForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<OSViewModel> list = _osBusinesslogic.Read(new OSBindingModel
                {
                    Status = "Не эксплуатируется"
                });
                if (list != null)
                {
                    comboBoxOs.DisplayMember = "OsName";
                    comboBoxOs.ValueMember = "Id";
                    comboBoxOs.DataSource = list;
                    comboBoxOs.SelectedItem = null;
                }
                operationOs = new Dictionary<int, (string, decimal)>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateTimePicker.Text))
            {
                MessageBox.Show("Заполните дату", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(comboBoxOs.Text))
            {
                MessageBox.Show("Необходимо выбрать основное средство", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            Operation();
            try
            {
                _amortizationBusinesslogic.Create(new AmortizationBindingModel
                {
                    AmortizationDate = dateTimePicker.Value,
                    Sum = Math.Round(Convert.ToDecimal(textBoxSum.Text), 2),
                    Comment = "Ввод в эксплуатацию",
                    AmortizationOs = operationOs
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
                TransactionsJournalCreate();
                UpdateOs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void Operation()
        {
            try
            {
                decimal sum = Math.Round(Convert.ToDecimal(textBoxSum.Text), 2);
                operationOs.Add(Convert.ToInt32(comboBoxOs.SelectedValue), (comboBoxOs.Text, sum));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void TransactionsJournalCreate()
        {
            ChartOfAccountViewModel chartOfAccountDt = _chartOfAccountBusinesslogic.TakeChartOfAccount(new ChartOfAccountBindingModel
            {
                AccountNumber = "01"
            })?[0];
            ChartOfAccountViewModel chartOfAccountKt = _chartOfAccountBusinesslogic.TakeChartOfAccount(new ChartOfAccountBindingModel
            {
                AccountNumber = "000"
            })?[0];
            AmortizationViewModel operation = SearchOperation();
            foreach (var element in operation.AmortizationOs)
            {
                OSViewModel os = _osBusinesslogic.Read(new OSBindingModel
                {
                    Id = element.Key
                })?[0];

                _transactionsJournalBusinesslogic.CreateOrUpdate(new TransactionsJournalBindingModel
                {
                    Date = operation.AmortizationDate,
                    AccountDebet = chartOfAccountDt.Id,
                    SubcontoDt1 = os.OsName,
                    SubcontoDt2 = os.SubdivisionName,
                    SubcontoDt3 = os.MolFIO,
                    AccountKredit = chartOfAccountKt.Id,
                    Sum = element.Value.Item2,
                    AmortizationId = operation.Id,
                    Comment = operation.Comment
                }); ;
            }
        }
        private void UpdateOs()
        {
            AmortizationViewModel operation = SearchOperation();
            foreach (var element in operation.AmortizationOs)
            {
                OSBindingModel os = _osBusinesslogic.TakeOS(new OSBindingModel
                {
                    Id = element.Key
                })?[0];

                OSBindingModel osBM = new OSBindingModel
                {
                    Id = os.Id,
                    OsName = os.OsName,
                    BalansSum = os.BalansSum,
                    SPI = os.SPI,
                    Status = "Эксплуатируется",
                    DateAdd = dateTimePicker.Value,
                    SubdivisionId = os.SubdivisionId,
                    MolId = os.MolId
                };

                _osBusinesslogic.Update(osBM);
            }
        }
        private AmortizationViewModel SearchOperation()
        {
            List<AmortizationViewModel> listOp = _amortizationBusinesslogic.Read(null);
            AmortizationViewModel operation = null;
            for (int i = 0; i < listOp.Count; i++)
            {
                if (dateTimePicker.Value == listOp[i].AmortizationDate && listOp[i].Comment == "Ввод в эксплуатацию")
                {
                    operation = listOp[i];
                }
            }
            return operation;
        }
        private void comboBoxOs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void CalcSum()
        {
            if (comboBoxOs.SelectedValue != null)
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxOs.SelectedValue);
                    OSViewModel os = _osBusinesslogic.Read(new OSBindingModel
                    {
                        Id = id
                    })?[0];
                    textBoxSum.Text = (os?.BalansSum ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
