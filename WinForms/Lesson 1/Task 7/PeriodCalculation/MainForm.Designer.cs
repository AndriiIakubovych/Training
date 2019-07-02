namespace PeriodCalculation
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
            this.periodText = new System.Windows.Forms.Label();
            this.period = new System.Windows.Forms.TextBox();
            this.calculate = new System.Windows.Forms.Button();
            this.variants = new System.Windows.Forms.GroupBox();
            this.seconds = new System.Windows.Forms.RadioButton();
            this.minutes = new System.Windows.Forms.RadioButton();
            this.hours = new System.Windows.Forms.RadioButton();
            this.days = new System.Windows.Forms.RadioButton();
            this.months = new System.Windows.Forms.RadioButton();
            this.years = new System.Windows.Forms.RadioButton();
            this.variants.SuspendLayout();
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
            // periodText
            // 
            resources.ApplyResources(this.periodText, "periodText");
            this.periodText.Name = "periodText";
            // 
            // period
            // 
            this.period.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.period, "period");
            this.period.Name = "period";
            this.period.ReadOnly = true;
            // 
            // calculate
            // 
            resources.ApplyResources(this.calculate, "calculate");
            this.calculate.Name = "calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // variants
            // 
            this.variants.Controls.Add(this.seconds);
            this.variants.Controls.Add(this.minutes);
            this.variants.Controls.Add(this.hours);
            this.variants.Controls.Add(this.days);
            this.variants.Controls.Add(this.months);
            this.variants.Controls.Add(this.years);
            resources.ApplyResources(this.variants, "variants");
            this.variants.Name = "variants";
            this.variants.TabStop = false;
            // 
            // seconds
            // 
            resources.ApplyResources(this.seconds, "seconds");
            this.seconds.Name = "seconds";
            this.seconds.TabStop = true;
            this.seconds.UseVisualStyleBackColor = true;
            // 
            // minutes
            // 
            resources.ApplyResources(this.minutes, "minutes");
            this.minutes.Name = "minutes";
            this.minutes.TabStop = true;
            this.minutes.UseVisualStyleBackColor = true;
            // 
            // hours
            // 
            resources.ApplyResources(this.hours, "hours");
            this.hours.Name = "hours";
            this.hours.TabStop = true;
            this.hours.UseVisualStyleBackColor = true;
            // 
            // days
            // 
            resources.ApplyResources(this.days, "days");
            this.days.Name = "days";
            this.days.TabStop = true;
            this.days.UseVisualStyleBackColor = true;
            // 
            // months
            // 
            resources.ApplyResources(this.months, "months");
            this.months.Name = "months";
            this.months.TabStop = true;
            this.months.UseVisualStyleBackColor = true;
            // 
            // years
            // 
            resources.ApplyResources(this.years, "years");
            this.years.Name = "years";
            this.years.TabStop = true;
            this.years.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.variants);
            this.Controls.Add(this.period);
            this.Controls.Add(this.periodText);
            this.Controls.Add(this.date);
            this.Controls.Add(this.dateText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.variants.ResumeLayout(false);
            this.variants.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label dateText;
        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Label periodText;
        private System.Windows.Forms.TextBox period;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.GroupBox variants;
        private System.Windows.Forms.RadioButton seconds;
        private System.Windows.Forms.RadioButton minutes;
        private System.Windows.Forms.RadioButton hours;
        private System.Windows.Forms.RadioButton days;
        private System.Windows.Forms.RadioButton months;
        private System.Windows.Forms.RadioButton years;
    }
}