namespace AmortizationOS
{
    partial class SubdivisionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelExpenceAccount = new System.Windows.Forms.Label();
            this.comboBoxExpenceAccount = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(126, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Наименование:";
            // 
            // labelExpenceAccount
            // 
            this.labelExpenceAccount.AutoSize = true;
            this.labelExpenceAccount.Location = new System.Drawing.Point(13, 50);
            this.labelExpenceAccount.Name = "labelExpenceAccount";
            this.labelExpenceAccount.Size = new System.Drawing.Size(108, 20);
            this.labelExpenceAccount.TabIndex = 1;
            this.labelExpenceAccount.Text = "Счет затрат:";
            // 
            // comboBoxExpenceAccount
            // 
            this.comboBoxExpenceAccount.FormattingEnabled = true;
            this.comboBoxExpenceAccount.Location = new System.Drawing.Point(140, 47);
            this.comboBoxExpenceAccount.Name = "comboBoxExpenceAccount";
            this.comboBoxExpenceAccount.Size = new System.Drawing.Size(278, 28);
            this.comboBoxExpenceAccount.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(140, 10);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(278, 26);
            this.textBoxName.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 100);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(405, 36);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(12, 142);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(405, 36);
            this.buttonCansel.TabIndex = 5;
            this.buttonCansel.Text = "Отменить";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // SubdivisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 189);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboBoxExpenceAccount);
            this.Controls.Add(this.labelExpenceAccount);
            this.Controls.Add(this.labelName);
            this.Name = "SubdivisionForm";
            this.Text = "Подразделение";
            this.Load += new System.EventHandler(this.SubdivisionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelExpenceAccount;
        private System.Windows.Forms.ComboBox comboBoxExpenceAccount;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCansel;
    }
}