namespace AmortizationOS
{
    partial class TurnoverBalanceForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebetStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KreditStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebetObr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KreditObr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebetOst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KreditOst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            this.buttonSaveToPdf = new System.Windows.Forms.Button();
            this.buttonMail = new System.Windows.Forms.Button();
            this.buttonSaveToWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите период:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "с";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "по";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(226, 15);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerFrom.TabIndex = 5;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(487, 15);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerTo.TabIndex = 6;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Account,
            this.DebetStart,
            this.KreditStart,
            this.DebetObr,
            this.KreditObr,
            this.DebetOst,
            this.KreditOst});
            this.dataGridView.Location = new System.Drawing.Point(32, 69);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(1120, 507);
            this.dataGridView.TabIndex = 7;
            // 
            // Account
            // 
            this.Account.HeaderText = "Счет";
            this.Account.MinimumWidth = 8;
            this.Account.Name = "Account";
            this.Account.Width = 80;
            // 
            // DebetStart
            // 
            this.DebetStart.HeaderText = "Начальный дебет";
            this.DebetStart.MinimumWidth = 8;
            this.DebetStart.Name = "DebetStart";
            this.DebetStart.Width = 150;
            // 
            // KreditStart
            // 
            this.KreditStart.HeaderText = "Начальный кредит";
            this.KreditStart.MinimumWidth = 8;
            this.KreditStart.Name = "KreditStart";
            this.KreditStart.Width = 150;
            // 
            // DebetObr
            // 
            this.DebetObr.HeaderText = "Дебетовый оборот";
            this.DebetObr.MinimumWidth = 8;
            this.DebetObr.Name = "DebetObr";
            this.DebetObr.Width = 150;
            // 
            // KreditObr
            // 
            this.KreditObr.HeaderText = "Кредитовый оборот";
            this.KreditObr.MinimumWidth = 8;
            this.KreditObr.Name = "KreditObr";
            this.KreditObr.Width = 150;
            // 
            // DebetOst
            // 
            this.DebetOst.HeaderText = "Остаток дебет";
            this.DebetOst.MinimumWidth = 8;
            this.DebetOst.Name = "DebetOst";
            this.DebetOst.Width = 150;
            // 
            // KreditOst
            // 
            this.KreditOst.HeaderText = "Остаток кредит";
            this.KreditOst.MinimumWidth = 8;
            this.KreditOst.Name = "KreditOst";
            this.KreditOst.Width = 150;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(709, 14);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(139, 33);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Location = new System.Drawing.Point(854, 15);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(162, 33);
            this.buttonSaveToExcel.TabIndex = 9;
            this.buttonSaveToExcel.Text = "Сохранить в Excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // buttonSaveToPdf
            // 
            this.buttonSaveToPdf.Location = new System.Drawing.Point(1022, 14);
            this.buttonSaveToPdf.Name = "buttonSaveToPdf";
            this.buttonSaveToPdf.Size = new System.Drawing.Size(149, 33);
            this.buttonSaveToPdf.TabIndex = 10;
            this.buttonSaveToPdf.Text = "Сохранить в Pdf";
            this.buttonSaveToPdf.UseVisualStyleBackColor = true;
            this.buttonSaveToPdf.Click += new System.EventHandler(this.buttonSaveToPdf_Click);
            // 
            // buttonMail
            // 
            this.buttonMail.Location = new System.Drawing.Point(993, 587);
            this.buttonMail.Name = "buttonMail";
            this.buttonMail.Size = new System.Drawing.Size(178, 33);
            this.buttonMail.TabIndex = 11;
            this.buttonMail.Text = "Отправить на почту";
            this.buttonMail.UseVisualStyleBackColor = true;
            this.buttonMail.Click += new System.EventHandler(this.buttonMail_Click);
            // 
            // buttonSaveToWord
            // 
            this.buttonSaveToWord.Location = new System.Drawing.Point(825, 587);
            this.buttonSaveToWord.Name = "buttonSaveToWord";
            this.buttonSaveToWord.Size = new System.Drawing.Size(162, 33);
            this.buttonSaveToWord.TabIndex = 12;
            this.buttonSaveToWord.Text = "Сохранить в Word";
            this.buttonSaveToWord.UseVisualStyleBackColor = true;
            this.buttonSaveToWord.Click += new System.EventHandler(this.buttonSaveToWord_Click);
            // 
            // TurnoverBalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 632);
            this.Controls.Add(this.buttonSaveToWord);
            this.Controls.Add(this.buttonMail);
            this.Controls.Add(this.buttonSaveToPdf);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "TurnoverBalanceForm";
            this.Text = "Оборотно-сальдовая ведомость";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebetStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn KreditStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebetObr;
        private System.Windows.Forms.DataGridViewTextBoxColumn KreditObr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebetOst;
        private System.Windows.Forms.DataGridViewTextBoxColumn KreditOst;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.Button buttonSaveToPdf;
        private System.Windows.Forms.Button buttonMail;
        private System.Windows.Forms.Button buttonSaveToWord;
    }
}