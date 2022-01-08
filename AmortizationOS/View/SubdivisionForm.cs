using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AmortizationOS
{
    public partial class SubdivisionForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly SubdivisionBusinessLogic Slogic;
        private readonly ChartOfAccountBusinessLogic Clogic;
        private int? id;
        public SubdivisionForm(SubdivisionBusinessLogic Slogic, ChartOfAccountBusinessLogic Clogic)
        {
            InitializeComponent();
            this.Slogic = Slogic;
            this.Clogic = Clogic;
        }

        private void SubdivisionForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<ChartOfAccountViewModel> list = Clogic.Read(null);
                if (list != null)
                {
                    comboBoxExpenceAccount.DisplayMember = "AccountNumber";
                    comboBoxExpenceAccount.ValueMember = "Id";
                    comboBoxExpenceAccount.DataSource = list;
                    comboBoxExpenceAccount.SelectedItem = null;
                }
                if (id.HasValue)
                {
                    var view = Slogic.Read(new SubdivisionBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.SubdivisionName;
                        ChartOfAccountViewModel account = Clogic.Read(new ChartOfAccountBindingModel { AccountNumber = view.ExpenceAccount })?[0];
                        foreach (var current in list)
                        {
                            if (current.AccountNumber == account.AccountNumber)
                            {
                                comboBoxExpenceAccount.SelectedItem = current;
                            }
                        }
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите наименование подразделения", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxExpenceAccount.SelectedValue == null)
            {
                MessageBox.Show("Выберите счет затрат", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }
            try
            {
                SubdivisionBindingModel subdivision = new SubdivisionBindingModel
                {
                    Id = id,
                    SubdivisionName = textBoxName.Text,
                    ExpenceAccount = Convert.ToInt32(comboBoxExpenceAccount.SelectedValue)
                };

                Slogic.CreateOrUpdate(subdivision);
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
