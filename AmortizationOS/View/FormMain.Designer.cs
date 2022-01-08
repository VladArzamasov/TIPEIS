namespace AmortizationOS
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основныеСредстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подразделенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мОЛToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналПроводокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ведомостьРасчетаИзносаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ведомостьРаспределенияИзносаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьАрхивToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.оборотносальдоваяВедомостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.операцииToolStripMenuItem,
            this.журналПроводокToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.создатьАрхивToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1028, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.основныеСредстваToolStripMenuItem,
            this.подразделенияToolStripMenuItem,
            this.мОЛToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(139, 29);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // основныеСредстваToolStripMenuItem
            // 
            this.основныеСредстваToolStripMenuItem.Name = "основныеСредстваToolStripMenuItem";
            this.основныеСредстваToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.основныеСредстваToolStripMenuItem.Text = "Основные средства";
            this.основныеСредстваToolStripMenuItem.Click += new System.EventHandler(this.основныеСредстваToolStripMenuItem_Click);
            // 
            // подразделенияToolStripMenuItem
            // 
            this.подразделенияToolStripMenuItem.Name = "подразделенияToolStripMenuItem";
            this.подразделенияToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.подразделенияToolStripMenuItem.Text = "Подразделения";
            this.подразделенияToolStripMenuItem.Click += new System.EventHandler(this.подразделенияToolStripMenuItem_Click);
            // 
            // мОЛToolStripMenuItem
            // 
            this.мОЛToolStripMenuItem.Name = "мОЛToolStripMenuItem";
            this.мОЛToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.мОЛToolStripMenuItem.Text = "МОЛ";
            this.мОЛToolStripMenuItem.Click += new System.EventHandler(this.мОЛToolStripMenuItem_Click);
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.операцииToolStripMenuItem.Text = "Операции";
            this.операцииToolStripMenuItem.Click += new System.EventHandler(this.операцииToolStripMenuItem_Click);
            // 
            // журналПроводокToolStripMenuItem
            // 
            this.журналПроводокToolStripMenuItem.Name = "журналПроводокToolStripMenuItem";
            this.журналПроводокToolStripMenuItem.Size = new System.Drawing.Size(180, 29);
            this.журналПроводокToolStripMenuItem.Text = "Журнал проводок";
            this.журналПроводокToolStripMenuItem.Click += new System.EventHandler(this.журналПроводокToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ведомостьРасчетаИзносаToolStripMenuItem,
            this.ведомостьРаспределенияИзносаToolStripMenuItem,
            this.оборотносальдоваяВедомостьToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // ведомостьРасчетаИзносаToolStripMenuItem
            // 
            this.ведомостьРасчетаИзносаToolStripMenuItem.Name = "ведомостьРасчетаИзносаToolStripMenuItem";
            this.ведомостьРасчетаИзносаToolStripMenuItem.Size = new System.Drawing.Size(392, 34);
            this.ведомостьРасчетаИзносаToolStripMenuItem.Text = "Ведомость расчета износа";
            this.ведомостьРасчетаИзносаToolStripMenuItem.Click += new System.EventHandler(this.ведомостьРасчетаИзносаToolStripMenuItem_Click);
            // 
            // ведомостьРаспределенияИзносаToolStripMenuItem
            // 
            this.ведомостьРаспределенияИзносаToolStripMenuItem.Name = "ведомостьРаспределенияИзносаToolStripMenuItem";
            this.ведомостьРаспределенияИзносаToolStripMenuItem.Size = new System.Drawing.Size(392, 34);
            this.ведомостьРаспределенияИзносаToolStripMenuItem.Text = "Ведомость распределения износа";
            this.ведомостьРаспределенияИзносаToolStripMenuItem.Click += new System.EventHandler(this.ведомостьРаспределенияИзносаToolStripMenuItem_Click);
            // 
            // создатьАрхивToolStripMenuItem
            // 
            this.создатьАрхивToolStripMenuItem.Name = "создатьАрхивToolStripMenuItem";
            this.создатьАрхивToolStripMenuItem.Size = new System.Drawing.Size(146, 29);
            this.создатьАрхивToolStripMenuItem.Text = "Создать архив";
            this.создатьАрхивToolStripMenuItem.Click += new System.EventHandler(this.создатьАрхивToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 48);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(1003, 484);
            this.dataGridView.TabIndex = 1;
            // 
            // оборотносальдоваяВедомостьToolStripMenuItem
            // 
            this.оборотносальдоваяВедомостьToolStripMenuItem.Name = "оборотносальдоваяВедомостьToolStripMenuItem";
            this.оборотносальдоваяВедомостьToolStripMenuItem.Size = new System.Drawing.Size(392, 34);
            this.оборотносальдоваяВедомостьToolStripMenuItem.Text = "Оборотно-сальдовая ведомость";
            this.оборотносальдоваяВедомостьToolStripMenuItem.Click += new System.EventHandler(this.оборотносальдоваяВедомостьToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 544);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Амортизация ОС";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основныеСредстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подразделенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мОЛToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналПроводокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ведомостьРасчетаИзносаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ведомостьРаспределенияИзносаToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem создатьАрхивToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оборотносальдоваяВедомостьToolStripMenuItem;
    }
}

