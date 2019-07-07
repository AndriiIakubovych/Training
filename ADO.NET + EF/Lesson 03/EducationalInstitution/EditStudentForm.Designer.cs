namespace EducationalInstitution
{
    partial class EditStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditStudentForm));
            this.studentNameText = new System.Windows.Forms.Label();
            this.studentName = new System.Windows.Forms.TextBox();
            this.birthdateText = new System.Windows.Forms.Label();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.addressText = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.telephoneText = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.MaskedTextBox();
            this.groupChoiceText = new System.Windows.Forms.Label();
            this.groupChoice = new System.Windows.Forms.ComboBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentNameText
            // 
            resources.ApplyResources(this.studentNameText, "studentNameText");
            this.studentNameText.Name = "studentNameText";
            // 
            // studentName
            // 
            resources.ApplyResources(this.studentName, "studentName");
            this.studentName.Name = "studentName";
            this.studentName.TextChanged += new System.EventHandler(this.studentName_TextChanged);
            // 
            // birthdateText
            // 
            resources.ApplyResources(this.birthdateText, "birthdateText");
            this.birthdateText.Name = "birthdateText";
            // 
            // birthdate
            // 
            resources.ApplyResources(this.birthdate, "birthdate");
            this.birthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdate.Name = "birthdate";
            // 
            // addressText
            // 
            resources.ApplyResources(this.addressText, "addressText");
            this.addressText.Name = "addressText";
            // 
            // address
            // 
            resources.ApplyResources(this.address, "address");
            this.address.Name = "address";
            // 
            // telephoneText
            // 
            resources.ApplyResources(this.telephoneText, "telephoneText");
            this.telephoneText.Name = "telephoneText";
            // 
            // telephone
            // 
            resources.ApplyResources(this.telephone, "telephone");
            this.telephone.Name = "telephone";
            // 
            // groupChoiceText
            // 
            resources.ApplyResources(this.groupChoiceText, "groupChoiceText");
            this.groupChoiceText.Name = "groupChoiceText";
            // 
            // groupChoice
            // 
            resources.ApplyResources(this.groupChoice, "groupChoice");
            this.groupChoice.BackColor = System.Drawing.SystemColors.Window;
            this.groupChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupChoice.FormattingEnabled = true;
            this.groupChoice.Name = "groupChoice";
            // 
            // ok
            // 
            resources.ApplyResources(this.ok, "ok");
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Name = "ok";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditStudentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.groupChoice);
            this.Controls.Add(this.groupChoiceText);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.telephoneText);
            this.Controls.Add(this.address);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.birthdateText);
            this.Controls.Add(this.studentName);
            this.Controls.Add(this.studentNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditStudentForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EditStudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label studentNameText;
        private System.Windows.Forms.TextBox studentName;
        private System.Windows.Forms.Label birthdateText;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Label addressText;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label telephoneText;
        private System.Windows.Forms.MaskedTextBox telephone;
        private System.Windows.Forms.Label groupChoiceText;
        private System.Windows.Forms.ComboBox groupChoice;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}