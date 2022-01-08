using System;
using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using System.Windows.Forms;
using Unity;

namespace AmortizationOS
{
    public partial class MOL : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MOLBusinessLogic logic;
        public MOL(MOLBusinessLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void MOL_Load(object sender, EventArgs e)
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
                    dataGridViewMOL.DataSource = list;
                    dataGridViewMOL.Columns[0].Visible = false;
                    dataGridViewMOL.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMOL>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewMOL.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormMOL>();
                form.Id = Convert.ToInt32(dataGridViewMOL.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewMOL.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewMOL.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new MOLBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
