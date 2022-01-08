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
    public partial class TransactionsJournal : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly TransactionsJournalBusinessLogic _transactionsJournallogic;
        public TransactionsJournal(TransactionsJournalBusinessLogic transactionsJournallogic)
        {
            InitializeComponent();
            _transactionsJournallogic = transactionsJournallogic;
        }
        private void TransactionsJournal_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _transactionsJournallogic.Read(null);
                if (list != null)
                {
                    dataGridViewTransactionsJournal.DataSource = list;
                    dataGridViewTransactionsJournal.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridViewTransactionsJournal.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridViewTransactionsJournal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridViewTransactionsJournal.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridViewTransactionsJournal.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridViewTransactionsJournal.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date1 = dateTimePickerFrom.Value;
                DateTime date2 = dateTimePickerTo.Value;
                var list = _transactionsJournallogic.Search(date1, date2);
                if (list != null)
                {
                    dataGridViewTransactionsJournal.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<TransactionsAddForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
