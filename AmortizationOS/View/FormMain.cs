using AmortizationOSBusinessLogic.BusinessLogics;
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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ChartOfAccountBusinessLogic logic;
        private BackUpAbstractLogic _backUpAbstractLogic;
        public FormMain(ChartOfAccountBusinessLogic logic, BackUpAbstractLogic backUpAbstractLogic)
        {
            InitializeComponent();
            this.logic = logic;
            _backUpAbstractLogic = backUpAbstractLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void подразделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<Subdivision>();
            form.ShowDialog();
        }

        private void мОЛToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<MOL>();
            form.ShowDialog();
        }

        private void основныеСредстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<OS>();
            form.ShowDialog();
        }

        private void операцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<Amortization>();
            form.ShowDialog();
        }

        private void журналПроводокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<TransactionsJournal>();
            form.ShowDialog();
        }

        private void ведомостьРасчетаИзносаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<StatementDepreciationCalculation>();
            form.ShowDialog();
        }

        private void ведомостьРаспределенияИзносаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<StatementDepreciationDistribution>();
            form.ShowDialog();
        }

        private void создатьАрхивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void оборотносальдоваяВедомостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<TurnoverBalanceForm>();
            form.ShowDialog();
        }
    }
}
