namespace AmortizationOS
{
    partial class OSForm
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
            this.labelBalSum = new System.Windows.Forms.Label();
            this.labelSPI = new System.Windows.Forms.Label();
            this.labelSubdivision = new System.Windows.Forms.Label();
            this.labelMOL = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxBalSum = new System.Windows.Forms.TextBox();
            this.textBoxSPI = new System.Windows.Forms.TextBox();
            this.comboBoxSubdivision = new System.Windows.Forms.ComboBox();
            this.comboBoxMOL = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
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
            // labelBalSum
            // 
            this.labelBalSum.AutoSize = true;
            this.labelBalSum.Location = new System.Drawing.Point(13, 45);
            this.labelBalSum.Name = "labelBalSum";
            this.labelBalSum.Size = new System.Drawing.Size(190, 20);
            this.labelBalSum.TabIndex = 1;
            this.labelBalSum.Text = "Балансовая стоимость:";
            // 
            // labelSPI
            // 
            this.labelSPI.AutoSize = true;
            this.labelSPI.Location = new System.Drawing.Point(13, 80);
            this.labelSPI.Name = "labelSPI";
            this.labelSPI.Size = new System.Drawing.Size(174, 20);
            this.labelSPI.TabIndex = 2;
            this.labelSPI.Text = "СПИ (число месяцев):";
            // 
            // labelSubdivision
            // 
            this.labelSubdivision.AutoSize = true;
            this.labelSubdivision.Location = new System.Drawing.Point(13, 117);
            this.labelSubdivision.Name = "labelSubdivision";
            this.labelSubdivision.Size = new System.Drawing.Size(137, 20);
            this.labelSubdivision.TabIndex = 3;
            this.labelSubdivision.Text = "Подразделение:";
            // 
            // labelMOL
            // 
            this.labelMOL.AutoSize = true;
            this.labelMOL.Location = new System.Drawing.Point(13, 153);
            this.labelMOL.Name = "labelMOL";
            this.labelMOL.Size = new System.Drawing.Size(50, 20);
            this.labelMOL.TabIndex = 4;
            this.labelMOL.Text = "МОЛ:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(209, 10);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(328, 26);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxBalSum
            // 
            this.textBoxBalSum.Location = new System.Drawing.Point(209, 42);
            this.textBoxBalSum.Name = "textBoxBalSum";
            this.textBoxBalSum.Size = new System.Drawing.Size(328, 26);
            this.textBoxBalSum.TabIndex = 6;
            // 
            // textBoxSPI
            // 
            this.textBoxSPI.Location = new System.Drawing.Point(209, 77);
            this.textBoxSPI.Name = "textBoxSPI";
            this.textBoxSPI.Size = new System.Drawing.Size(328, 26);
            this.textBoxSPI.TabIndex = 7;
            // 
            // comboBoxSubdivision
            // 
            this.comboBoxSubdivision.FormattingEnabled = true;
            this.comboBoxSubdivision.Location = new System.Drawing.Point(209, 114);
            this.comboBoxSubdivision.Name = "comboBoxSubdivision";
            this.comboBoxSubdivision.Size = new System.Drawing.Size(328, 28);
            this.comboBoxSubdivision.TabIndex = 8;
            // 
            // comboBoxMOL
            // 
            this.comboBoxMOL.FormattingEnabled = true;
            this.comboBoxMOL.Location = new System.Drawing.Point(209, 150);
            this.comboBoxMOL.Name = "comboBoxMOL";
            this.comboBoxMOL.Size = new System.Drawing.Size(328, 28);
            this.comboBoxMOL.TabIndex = 9;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(17, 196);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(520, 33);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(17, 235);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(520, 33);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // OSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 278);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxMOL);
            this.Controls.Add(this.comboBoxSubdivision);
            this.Controls.Add(this.textBoxSPI);
            this.Controls.Add(this.textBoxBalSum);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelMOL);
            this.Controls.Add(this.labelSubdivision);
            this.Controls.Add(this.labelSPI);
            this.Controls.Add(this.labelBalSum);
            this.Controls.Add(this.labelName);
            this.Name = "OSForm";
            this.Text = "Основное средство";
            this.Load += new System.EventHandler(this.OSForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelBalSum;
        private System.Windows.Forms.Label labelSPI;
        private System.Windows.Forms.Label labelSubdivision;
        private System.Windows.Forms.Label labelMOL;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxBalSum;
        private System.Windows.Forms.TextBox textBoxSPI;
        private System.Windows.Forms.ComboBox comboBoxSubdivision;
        private System.Windows.Forms.ComboBox comboBoxMOL;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}