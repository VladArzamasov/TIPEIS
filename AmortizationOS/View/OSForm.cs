using AmortizationOSBusinessLogic.BindingModels;
using AmortizationOSBusinessLogic.ViewModels;
using AmortizationOSBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using System.Text.RegularExpressions;

namespace AmortizationOS
{
    public partial class OSForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly OSBusinessLogic Vlogic;
        private readonly SubdivisionBusinessLogic Flogic;
        private readonly MOLBusinessLogic Plogic;
        private int? id;
        public OSForm(OSBusinessLogic Vlogic, SubdivisionBusinessLogic Flogic, MOLBusinessLogic Plogic)
        {
            InitializeComponent();
            this.Vlogic = Vlogic;
            this.Flogic = Flogic;
            this.Plogic = Plogic;
        }

        private void OSForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<SubdivisionViewModel> list = Flogic.Read(null);
                if (list != null)
                {
                    comboBoxSubdivision.DisplayMember = "SubdivisionName";
                    comboBoxSubdivision.ValueMember = "Id";
                    comboBoxSubdivision.DataSource = list;
                    comboBoxSubdivision.SelectedItem = null;
                }
                List<MOLViewModel> listMOL = Plogic.Read(null);
                if (listMOL != null)
                {
                    comboBoxMOL.DisplayMember = "FIO";
                    comboBoxMOL.ValueMember = "Id";
                    comboBoxMOL.DataSource = listMOL;
                    comboBoxMOL.SelectedItem = null;
                }
                if (id.HasValue)
                {
                    var view = Vlogic.Read(new OSBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.OsName;
                        textBoxBalSum.Text = view.BalansSum.ToString();
                        textBoxSPI.Text = view.SPI.ToString();
                        SubdivisionViewModel subdivision = Flogic.Read(new SubdivisionBindingModel { SubdivisionName = view.SubdivisionName })?[0];
                        foreach (var current in list)
                        {
                            if (current.SubdivisionName == subdivision.SubdivisionName)
                            {
                                comboBoxSubdivision.SelectedItem = current;
                            }
                        }
                        MOLViewModel mol = Plogic.Read(new MOLBindingModel { FIO = view.MolFIO })?[0];
                        foreach (var currentMol in listMOL)
                        {
                            if (currentMol.FIO == mol.FIO)
                            {
                                comboBoxMOL.SelectedItem = currentMol;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите наименование", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxBalSum.Text))
            {
                MessageBox.Show("Введите балансовую стоимость", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(textBoxBalSum.Text, @"[0-9]{1,3}[,][0-9]{2}\z"))
            {
                MessageBox.Show("Балансовая стоимость - необходимо ввести число с двумя знаками после запятой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDouble(textBoxBalSum.Text) < 0)
            {
                MessageBox.Show("Балансовая стоимость - необходимо ввести неотрицательное число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSPI.Text))
            {
                MessageBox.Show("Введите СПИ", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if ((!Regex.IsMatch(textBoxSPI.Text, @"[0-9]\z")) || (Convert.ToInt32(textBoxSPI.Text) < 0))
            {
                MessageBox.Show("СПИ - необходимо ввести неотрицательное число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSubdivision.SelectedValue == null)
            {
                MessageBox.Show("Выберите подразделение", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxMOL.SelectedValue == null)
            {
                MessageBox.Show("Выберите МОЛ", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }


            try
            {
                OSBindingModel os = new OSBindingModel
                {
                    Id = id,
                    OsName = textBoxName.Text,
                    BalansSum = Math.Round(decimal.Parse(textBoxBalSum.Text), 2),
                    SPI = Convert.ToInt32(textBoxSPI.Text),
                    Status = "Не эксплуатируется",
                    SubdivisionId = Convert.ToInt32(comboBoxSubdivision.SelectedValue),
                    MolId = Convert.ToInt32(comboBoxMOL.SelectedValue)
                };

                Vlogic.CreateOrUpdate(os);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
