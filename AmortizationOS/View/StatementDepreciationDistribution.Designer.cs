namespace AmortizationOS
{
    partial class StatementDepreciationDistribution
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
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.buttonMake = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonSaveToPdf = new System.Windows.Forms.Button();
            this.buttonSaveToExel = new System.Windows.Forms.Button();
            this.buttonMail = new System.Windows.Forms.Button();
            this.buttonSaveToWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.comboBoxYear.Location = new System.Drawing.Point(501, 20);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(191, 28);
            this.comboBoxYear.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Выберите год:";
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(157, 20);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(191, 28);
            this.comboBoxMonth.TabIndex = 12;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 23);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(139, 20);
            this.label.TabIndex = 11;
            this.label.Text = "Выберите месяц:";
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(711, 16);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(144, 35);
            this.buttonMake.TabIndex = 10;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AmortizationOS.ReportViewer.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 79);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1217, 593);
            this.reportViewer1.TabIndex = 15;
            // 
            // buttonSaveToPdf
            // 
            this.buttonSaveToPdf.Location = new System.Drawing.Point(1026, 16);
            this.buttonSaveToPdf.Name = "buttonSaveToPdf";
            this.buttonSaveToPdf.Size = new System.Drawing.Size(154, 35);
            this.buttonSaveToPdf.TabIndex = 16;
            this.buttonSaveToPdf.Text = "Сохранить в Pdf";
            this.buttonSaveToPdf.UseVisualStyleBackColor = true;
            this.buttonSaveToPdf.Click += new System.EventHandler(this.buttonSaveToPdf_Click);
            // 
            // buttonSaveToExel
            // 
            this.buttonSaveToExel.Location = new System.Drawing.Point(861, 16);
            this.buttonSaveToExel.Name = "buttonSaveToExel";
            this.buttonSaveToExel.Size = new System.Drawing.Size(159, 35);
            this.buttonSaveToExel.TabIndex = 17;
            this.buttonSaveToExel.Text = "Сохранить в Excel";
            this.buttonSaveToExel.UseVisualStyleBackColor = true;
            this.buttonSaveToExel.Click += new System.EventHandler(this.buttonSaveToExel_Click);
            // 
            // buttonMail
            // 
            this.buttonMail.Location = new System.Drawing.Point(1026, 678);
            this.buttonMail.Name = "buttonMail";
            this.buttonMail.Size = new System.Drawing.Size(179, 35);
            this.buttonMail.TabIndex = 18;
            this.buttonMail.Text = "Отправить на почту";
            this.buttonMail.UseVisualStyleBackColor = true;
            this.buttonMail.Click += new System.EventHandler(this.buttonMail_Click);
            // 
            // buttonSaveToWord
            // 
            this.buttonSaveToWord.Location = new System.Drawing.Point(861, 678);
            this.buttonSaveToWord.Name = "buttonSaveToWord";
            this.buttonSaveToWord.Size = new System.Drawing.Size(159, 35);
            this.buttonSaveToWord.TabIndex = 19;
            this.buttonSaveToWord.Text = "Сохранить в Word";
            this.buttonSaveToWord.UseVisualStyleBackColor = true;
            this.buttonSaveToWord.Click += new System.EventHandler(this.buttonSaveToWord_Click);
            // 
            // StatementDepreciationDistribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 725);
            this.Controls.Add(this.buttonSaveToWord);
            this.Controls.Add(this.buttonMail);
            this.Controls.Add(this.buttonSaveToExel);
            this.Controls.Add(this.buttonSaveToPdf);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonMake);
            this.Name = "StatementDepreciationDistribution";
            this.Text = "Ведомость распределения износа по счетам затрат";
            this.Load += new System.EventHandler(this.StatementDepreciationDistribution_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonMake;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button buttonSaveToPdf;
        private System.Windows.Forms.Button buttonSaveToExel;
        private System.Windows.Forms.Button buttonMail;
        private System.Windows.Forms.Button buttonSaveToWord;
    }
}