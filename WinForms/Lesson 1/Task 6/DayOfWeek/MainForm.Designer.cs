namespace DayOfWeek
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
            this.dateText = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.TextBox();
            this.dayText = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.TextBox();
            this.calculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateText
            // 
            resources.ApplyResources(this.dateText, "dateText");
            this.dateText.Name = "dateText";
            // 
            // date
            // 
            resources.ApplyResources(this.date, "date");
            this.date.Name = "date";
            // 
            // dayText
            // 
            resources.ApplyResources(this.dayText, "dayText");
            this.dayText.Name = "dayText";
            // 
            // day
            // 
            resources.ApplyResources(this.day, "day");
            this.day.BackColor = System.Drawing.SystemColors.Window;
            this.day.Name = "day";
            this.day.ReadOnly = true;
            // 
            // calculate
            // 
            resources.ApplyResources(this.calculate, "calculate");
            this.calculate.Name = "calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.day);
            this.Controls.Add(this.dayText);
            this.Controls.Add(this.date);
            this.Controls.Add(this.dateText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label dateText;
        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Label dayText;
        private System.Windows.Forms.TextBox day;
        private System.Windows.Forms.Button calculate;
    }
}