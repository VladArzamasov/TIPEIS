using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using AmortizationOSBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AmortizationOS
{
    public partial class AmortizationForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly AmortizationBusinessLogic _amortizationBusinesslogic;
        private readonly OSBusinessLogic _osBusinesslogic;
        private readonly TransactionsJournalBusinessLogic _transactionsJournalBusinesslogic;
        private readonly SubdivisionBusinessLogic _subdivisionBusinesslogic;
        private readonly ChartOfAccountBusinessLogic _chartOfAccountBusinesslogic;
        private int? id;
        private Dictionary<int, (string, decimal)> amortizationOs;
        public int Id { set { id = value; } }
        public AmortizationForm(AmortizationBusinessLogic amortizationBusinesslogic, OSBusinessLogic osBusinesslogic, TransactionsJournalBusinessLogic transactionsJournalBusinesslogic, 
            SubdivisionBusinessLogic subdivisionBusinesslogic, ChartOfAccountBusinessLogic chartOfAccountBusinesslogic)
        {
            InitializeComponent();
            _amortizationBusinesslogic = amortizationBusinesslogic;
            _osBusinesslogic = osBusinesslogic;
            _transactionsJournalBusinesslogic = transactionsJournalBusinesslogic;
            _subdivisionBusinesslogic = subdivisionBusinesslogic;
            _chartOfAccountBusinesslogic = chartOfAccountBusinesslogic;
        }

        private void AmortizationForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    AmortizationViewModel view = _amortizationBusinesslogic.Read(new AmortizationBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        amortizationOs = view.AmortizationOs;
                        dateTimePicker.Value = view.AmortizationDate;
                        textBoxSum.Text = view.Sum.ToString();
                        LoadData();
                    }
                    buttonSave.Visible = false;
                    buttonStart.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                amortizationOs = new Dictionary<int, (string, decimal)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (amortizationOs != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in amortizationOs)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
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
            CheckDateOperation();
            try
            {
                _amortizationBusinesslogic.Create(new AmortizationBindingModel
                {
                    Id = id,
                    AmortizationDate = dateTimePicker.Value,
                    Sum = Math.Round(Convert.ToDecimal(textBoxSum.Text), 2),
                    Comment = "Амортизация ОС",
                    AmortizationOs = amortizationOs
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
                TransactionsJournalCreate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void Amortization()
        {
            try
            {
                var os = _osBusinesslogic.Read(null);
                decimal result = 0;
                decimal sum = 0;
                foreach (var element in os)
                {
                    if (element.Status == "Эксплуатируется" && element.DateAdd <= dateTimePicker.Value)
                    {
                        sum = CalcSum(element);
                        amortizationOs.Add(element.Id, (element.OsName, sum));
                        result += sum;
                    }
                }
                textBoxSum.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private decimal CalcSum(OSViewModel oS)
        {
            decimal result;
            result = Math.Round((oS?.BalansSum / oS?.SPI ?? 0), 2);
            return result;
        }
        private void CheckDateOperation()
        {
            List<AmortizationViewModel> listAm = _amortizationBusinesslogic.Read(null);
            for (int i = 0; i < listAm.Count; i++)
            {
                if (dateTimePicker.Value.DayOfYear == listAm[i].AmortizationDate.DayOfYear && listAm[i].Comment == "Амортизация ОС")
                {
                    _amortizationBusinesslogic.Delete(new AmortizationBindingModel { Id = listAm[i].Id });
                    break;
                }
            }
        }
        private void TransactionsJournalCreate() 
        {
            ChartOfAccountViewModel chartOfAccount = _chartOfAccountBusinesslogic.TakeChartOfAccount(new ChartOfAccountBindingModel
            {
                AccountNumber = "02"
            })?[0];
            AmortizationViewModel amortization = SearchOperation();
            foreach (var element in amortization.AmortizationOs)
            {
                OSBindingModel os = _osBusinesslogic.TakeOS(new OSBindingModel
                {
                    Id = element.Key
                })?[0];
                SubdivisionBindingModel subdivision = _subdivisionBusinesslogic.TakeSubdivision(new SubdivisionBindingModel
                {
                    Id = os.SubdivisionId
                })?[0];
                _transactionsJournalBusinesslogic.CreateOrUpdate(new TransactionsJournalBindingModel
                {
                    Date = amortization.AmortizationDate,
                    AccountDebet = subdivision.ExpenceAccount,
                    SubcontoDt1 = subdivision.SubdivisionName,
                    AccountKredit = chartOfAccount.Id,
                    SubcontoCt1 = os.OsName,
                    Sum = element.Value.Item2,
                    AmortizationId = amortization.Id,
                    Comment = amortization.Comment
                }); ;
            }
        }
        private AmortizationViewModel SearchOperation()
        {
            List<AmortizationViewModel> listOp = _amortizationBusinesslogic.Read(null);
            AmortizationViewModel amortization = null;
            for (int i = 0; i < listOp.Count; i++)
            {
                if (dateTimePicker.Value == listOp[i].AmortizationDate && listOp[i].Comment == "Амортизация ОС")
                {
                    amortization = listOp[i];
                }
            }
            return amortization;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (amortizationOs != null)
            {
                amortizationOs.Clear();
            }
            Amortization();
            LoadData();
        }
    }
}
