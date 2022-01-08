namespace AmortizationOS
{
    partial class StatementDepreciationCalculation
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OstSumStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OstSumEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumIznosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonMake = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.labelZagolovok = new System.Windows.Forms.Label();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            this.buttonSaveToPdf = new System.Windows.Forms.Button();
            this.buttonMail = new System.Windows.Forms.Button();
            this.buttonSaveToWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NameOs,
            this.Sum,
            this.OstSumStart,
            this.OstSumEnd,
            this.SumIznosa});
            this.dataGridView1.Location = new System.Drawing.Point(24, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1129, 531);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Инв. ном.";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.Width = 48;
            // 
            // NameOs
            // 
            this.NameOs.HeaderText = "Наименование ОС";
            this.NameOs.MinimumWidth = 8;
            this.NameOs.Name = "NameOs";
            this.NameOs.Width = 99;
            // 
            // Sum
            // 
            this.Sum.HeaderText = "Сумма износа";
            this.Sum.MinimumWidth = 8;
            this.Sum.Name = "Sum";
            this.Sum.Width = 99;
            // 
            // OstSumStart
            // 
            this.OstSumStart.HeaderText = "Остаточная стоимость на начало месяца";
            this.OstSumStart.MinimumWidth = 8;
            this.OstSumStart.Name = "OstSumStart";
            this.OstSumStart.Width = 147;
            // 
            // OstSumEnd
            // 
            this.OstSumEnd.HeaderText = "Остаточная стоимость на конец месяца";
            this.OstSumEnd.MinimumWidth = 8;
            this.OstSumEnd.Name = "OstSumEnd";
            this.OstSumEnd.Width = 148;
            // 
            // SumIznosa
            // 
            this.SumIznosa.HeaderText = "Сумма износа с начала года";
            this.SumIznosa.MinimumWidth = 8;
            this.SumIznosa.Name = "SumIznosa";
            this.SumIznosa.Width = 148;
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(706, 14);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(136, 35);
            this.buttonMake.TabIndex = 5;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 21);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(139, 20);
            this.label.TabIndex = 6;
            this.label.Text = "Выберите месяц:";
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(157, 18);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(191, 28);
            this.comboBoxMonth.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите год:";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.comboBoxYear.Location = new System.Drawing.Point(480, 18);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(191, 28);
            this.comboBoxYear.TabIndex = 9;
            // 
            // labelZagolovok
            // 
            this.labelZagolovok.AutoSize = true;
            this.labelZagolovok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZagolovok.Location = new System.Drawing.Point(334, 65);
            this.labelZagolovok.Name = "labelZagolovok";
            this.labelZagolovok.Size = new System.Drawing.Size(58, 22);
            this.labelZagolovok.TabIndex = 10;
            this.labelZagolovok.Text = "label2";
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Location = new System.Drawing.Point(1000, 14);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(167, 35);
            this.buttonSaveToExcel.TabIndex = 11;
            this.buttonSaveToExcel.Text = "Сохранить в Excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToExel_Click);
            // 
            // buttonSaveToPdf
            // 
            this.buttonSaveToPdf.Location = new System.Drawing.Point(848, 14);
            this.buttonSaveToPdf.Name = "buttonSaveToPdf";
            this.buttonSaveToPdf.Size = new System.Drawing.Size(146, 35);
            this.buttonSaveToPdf.TabIndex = 12;
            this.buttonSaveToPdf.Text = "Сохранить в Pdf";
            this.buttonSaveToPdf.UseVisualStyleBackColor = true;
            this.buttonSaveToPdf.Click += new System.EventHandler(this.buttonSaveToPdf_Click);
            // 
            // buttonMail
            // 
            this.buttonMail.Location = new System.Drawing.Point(986, 627);
            this.buttonMail.Name = "buttonMail";
            this.buttonMail.Size = new System.Drawing.Size(181, 35);
            this.buttonMail.TabIndex = 13;
            this.buttonMail.Text = "Отправить на почту";
            this.buttonMail.UseVisualStyleBackColor = true;
            this.buttonMail.Click += new System.EventHandler(this.buttonMail_Click);
            // 
            // buttonSaveToWord
            // 
            this.buttonSaveToWord.Location = new System.Drawing.Point(813, 627);
            this.buttonSaveToWord.Name = "buttonSaveToWord";
            this.buttonSaveToWord.Size = new System.Drawing.Size(167, 35);
            this.buttonSaveToWord.TabIndex = 14;
            this.buttonSaveToWord.Text = "Сохранить в Word";
            this.buttonSaveToWord.UseVisualStyleBackColor = true;
            this.buttonSaveToWord.Click += new System.EventHandler(this.buttonSaveToWord_Click);
            // 
            // StatementDepreciationCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 669);
            this.Controls.Add(this.buttonSaveToWord);
            this.Controls.Add(this.buttonMail);
            this.Controls.Add(this.buttonSaveToPdf);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.labelZagolovok);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StatementDepreciationCalculation";
            this.Text = "Ведомость расчета износа";
            this.Load += new System.EventHandler(this.StatementDepreciationCalculation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label labelZagolovok;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.Button buttonSaveToPdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn OstSumStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn OstSumEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumIznosa;
        private System.Windows.Forms.Button buttonMail;
        private System.Windows.Forms.Button buttonSaveToWord;
    }
}