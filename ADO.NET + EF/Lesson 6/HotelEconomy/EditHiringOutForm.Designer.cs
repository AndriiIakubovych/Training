namespace HotelEconomy
{
    partial class EditHiringOutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditHiringOutForm));
            this.roomChoiceText = new System.Windows.Forms.Label();
            this.roomChoice = new System.Windows.Forms.ComboBox();
            this.clientChoiceText = new System.Windows.Forms.Label();
            this.clientChoice = new System.Windows.Forms.ComboBox();
            this.beginningDateText = new System.Windows.Forms.Label();
            this.beginningDate = new System.Windows.Forms.DateTimePicker();
            this.daysCountText = new System.Windows.Forms.Label();
            this.daysCount = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roomChoiceText
            // 
            resources.ApplyResources(this.roomChoiceText, "roomChoiceText");
            this.roomChoiceText.Name = "roomChoiceText";
            // 
            // roomChoice
            // 
            this.roomChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomChoice.FormattingEnabled = true;
            resources.ApplyResources(this.roomChoice, "roomChoice");
            this.roomChoice.Name = "roomChoice";
            // 
            // clientChoiceText
            // 
            resources.ApplyResources(this.clientChoiceText, "clientChoiceText");
            this.clientChoiceText.Name = "clientChoiceText";
            // 
            // clientChoice
            // 
            this.clientChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientChoice.FormattingEnabled = true;
            resources.ApplyResources(this.clientChoice, "clientChoice");
            this.clientChoice.Name = "clientChoice";
            // 
            // beginningDateText
            // 
            resources.ApplyResources(this.beginningDateText, "beginningDateText");
            this.beginningDateText.Name = "beginningDateText";
            // 
            // beginningDate
            // 
            this.beginningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.beginningDate, "beginningDate");
            this.beginningDate.Name = "beginningDate";
            // 
            // daysCountText
            // 
            resources.ApplyResources(this.daysCountText, "daysCountText");
            this.daysCountText.Name = "daysCountText";
            // 
            // daysCount
            // 
            resources.ApplyResources(this.daysCount, "daysCount");
            this.daysCount.Name = "daysCount";
            this.daysCount.TextChanged += new System.EventHandler(this.daysCount_TextChanged);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.ok, "ok");
            this.ok.Name = "ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ok_MouseDown);
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditHiringOutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.daysCount);
            this.Controls.Add(this.daysCountText);
            this.Controls.Add(this.beginningDate);
            this.Controls.Add(this.beginningDateText);
            this.Controls.Add(this.clientChoice);
            this.Controls.Add(this.clientChoiceText);
            this.Controls.Add(this.roomChoice);
            this.Controls.Add(this.roomChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditHiringOutForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EditHiringOutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label roomChoiceText;
        private System.Windows.Forms.ComboBox roomChoice;
        private System.Windows.Forms.Label clientChoiceText;
        private System.Windows.Forms.ComboBox clientChoice;
        private System.Windows.Forms.Label beginningDateText;
        private System.Windows.Forms.DateTimePicker beginningDate;
        private System.Windows.Forms.Label daysCountText;
        private System.Windows.Forms.TextBox daysCount;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}