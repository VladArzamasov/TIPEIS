using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace AmortizationOS
{
    public partial class AmortizationTransactionsForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly TransactionsJournalBusinessLogic _transactionsJournallogic;
        private int? id;
        public int Id { set { id = value; } }
        public AmortizationTransactionsForm(TransactionsJournalBusinessLogic transactionsJournallogic)
        {
            InitializeComponent();
            _transactionsJournallogic = transactionsJournallogic;
        }

        private void AmortizationTransactionsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var listTransactons = _transactionsJournallogic.Read(new TransactionsJournalBindingModel { AmortizationId = id.Value });
                if (listTransactons != null)
                {
                    dataGridView.DataSource = listTransactons;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[4].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[8].Visible = false;
                    dataGridView.Columns[9].Visible = false;
                    dataGridView.Columns[11].Visible = false;
                    dataGridView.Columns[12].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
