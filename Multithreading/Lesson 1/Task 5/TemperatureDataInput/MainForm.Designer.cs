namespace TemperatureDataInput
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.monthChoiceText = new System.Windows.Forms.Label();
            this.monthChoice = new System.Windows.Forms.ComboBox();
            this.yearChoiceText = new System.Windows.Forms.Label();
            this.yearChoice = new System.Windows.Forms.ComboBox();
            this.panel = new System.Windows.Forms.Panel();
            this.nightTemperatureText = new System.Windows.Forms.Label();
            this.dayTemperatureText = new System.Windows.Forms.Label();
            this.createGraph = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthChoiceText
            // 
            this.monthChoiceText.AutoSize = true;
            this.monthChoiceText.Location = new System.Drawing.Point(9, 9);
            this.monthChoiceText.Name = "monthChoiceText";
            this.monthChoiceText.Size = new System.Drawing.Size(95, 13);
            this.monthChoiceText.TabIndex = 0;
            this.monthChoiceText.Text = "Выберите месяц:";
            // 
            // monthChoice
            // 
            this.monthChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthChoice.FormattingEnabled = true;
            this.monthChoice.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.monthChoice.Location = new System.Drawing.Point(12, 25);
            this.monthChoice.Name = "monthChoice";
            this.monthChoice.Size = new System.Drawing.Size(188, 21);
            this.monthChoice.TabIndex = 1;
            this.monthChoice.SelectedIndexChanged += new System.EventHandler(this.monthChoice_SelectedIndexChanged);
            // 
            // yearChoiceText
            // 
            this.yearChoiceText.AutoSize = true;
            this.yearChoiceText.Location = new System.Drawing.Point(211, 9);
            this.yearChoiceText.Name = "yearChoiceText";
            this.yearChoiceText.Size = new System.Drawing.Size(80, 13);
            this.yearChoiceText.TabIndex = 2;
            this.yearChoiceText.Text = "Выберите год:";
            // 
            // yearChoice
            // 
            this.yearChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearChoice.FormattingEnabled = true;
            this.yearChoice.Location = new System.Drawing.Point(214, 25);
            this.yearChoice.Name = "yearChoice";
            this.yearChoice.Size = new System.Drawing.Size(188, 21);
            this.yearChoice.TabIndex = 3;
            this.yearChoice.SelectedIndexChanged += new System.EventHandler(this.yearChoice_SelectedIndexChanged);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.nightTemperatureText);
            this.panel.Controls.Add(this.dayTemperatureText);
            this.panel.Location = new System.Drawing.Point(12, 61);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(390, 268);
            this.panel.TabIndex = 4;
            // 
            // nightTemperatureText
            // 
            this.nightTemperatureText.Location = new System.Drawing.Point(220, 9);
            this.nightTemperatureText.Name = "nightTemperatureText";
            this.nightTemperatureText.Size = new System.Drawing.Size(150, 13);
            this.nightTemperatureText.TabIndex = 1;
            this.nightTemperatureText.Text = "Ночная температура (°C):";
            // 
            // dayTemperatureText
            // 
            this.dayTemperatureText.Location = new System.Drawing.Point(71, 9);
            this.dayTemperatureText.Name = "dayTemperatureText";
            this.dayTemperatureText.Size = new System.Drawing.Size(150, 13);
            this.dayTemperatureText.TabIndex = 0;
            this.dayTemperatureText.Text = "Дневная температура (°C):";
            // 
            // createGraph
            // 
            this.createGraph.Image = ((System.Drawing.Image)(resources.GetObject("createGraph.Image")));
            this.createGraph.Location = new System.Drawing.Point(136, 341);
            this.createGraph.Name = "createGraph";
            this.createGraph.Size = new System.Drawing.Size(142, 23);
            this.createGraph.TabIndex = 5;
            this.createGraph.Text = "Построить график";
            this.createGraph.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.createGraph.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.createGraph.UseVisualStyleBackColor = true;
            this.createGraph.Click += new System.EventHandler(this.createGraph_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 376);
            this.Controls.Add(this.createGraph);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.yearChoice);
            this.Controls.Add(this.yearChoiceText);
            this.Controls.Add(this.monthChoice);
            this.Controls.Add(this.monthChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод данных";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label monthChoiceText;
        private System.Windows.Forms.ComboBox monthChoice;
        private System.Windows.Forms.Label yearChoiceText;
        private System.Windows.Forms.ComboBox yearChoice;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label dayTemperatureText;
        private System.Windows.Forms.Label nightTemperatureText;
        private System.Windows.Forms.Button createGraph;
    }
}