namespace HumanResourcesDepartment
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
            this.employeeChoiceText = new System.Windows.Forms.Label();
            this.employeeChoice = new System.Windows.Forms.ComboBox();
            this.employeeInformation = new System.Windows.Forms.GroupBox();
            this.deleteEmployee = new System.Windows.Forms.Button();
            this.editEmployee = new System.Windows.Forms.Button();
            this.addEmployee = new System.Windows.Forms.Button();
            this.employeeNameText = new System.Windows.Forms.Label();
            this.photo = new System.Windows.Forms.PictureBox();
            this.employeeName = new System.Windows.Forms.TextBox();
            this.firingOrderNumber = new System.Windows.Forms.TextBox();
            this.birthdateText = new System.Windows.Forms.Label();
            this.firingOrderNumberText = new System.Windows.Forms.Label();
            this.birthdate = new System.Windows.Forms.TextBox();
            this.hiringOrderNumber = new System.Windows.Forms.TextBox();
            this.positionText = new System.Windows.Forms.Label();
            this.hiringOrderNumberText = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.TextBox();
            this.employeeInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeChoiceText
            // 
            resources.ApplyResources(this.employeeChoiceText, "employeeChoiceText");
            this.employeeChoiceText.Name = "employeeChoiceText";
            // 
            // employeeChoice
            // 
            resources.ApplyResources(this.employeeChoice, "employeeChoice");
            this.employeeChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeChoice.FormattingEnabled = true;
            this.employeeChoice.Name = "employeeChoice";
            this.employeeChoice.SelectedIndexChanged += new System.EventHandler(this.employeeChoice_SelectedIndexChanged);
            // 
            // employeeInformation
            // 
            resources.ApplyResources(this.employeeInformation, "employeeInformation");
            this.employeeInformation.Controls.Add(this.deleteEmployee);
            this.employeeInformation.Controls.Add(this.editEmployee);
            this.employeeInformation.Controls.Add(this.addEmployee);
            this.employeeInformation.Controls.Add(this.employeeNameText);
            this.employeeInformation.Controls.Add(this.photo);
            this.employeeInformation.Controls.Add(this.employeeName);
            this.employeeInformation.Controls.Add(this.firingOrderNumber);
            this.employeeInformation.Controls.Add(this.birthdateText);
            this.employeeInformation.Controls.Add(this.firingOrderNumberText);
            this.employeeInformation.Controls.Add(this.birthdate);
            this.employeeInformation.Controls.Add(this.hiringOrderNumber);
            this.employeeInformation.Controls.Add(this.positionText);
            this.employeeInformation.Controls.Add(this.hiringOrderNumberText);
            this.employeeInformation.Controls.Add(this.position);
            this.employeeInformation.Name = "employeeInformation";
            this.employeeInformation.TabStop = false;
            // 
            // deleteEmployee
            // 
            resources.ApplyResources(this.deleteEmployee, "deleteEmployee");
            this.deleteEmployee.Name = "deleteEmployee";
            this.deleteEmployee.UseVisualStyleBackColor = true;
            this.deleteEmployee.Click += new System.EventHandler(this.deleteEmployee_Click);
            // 
            // editEmployee
            // 
            resources.ApplyResources(this.editEmployee, "editEmployee");
            this.editEmployee.Name = "editEmployee";
            this.editEmployee.UseVisualStyleBackColor = true;
            this.editEmployee.Click += new System.EventHandler(this.editEmployee_Click);
            // 
            // addEmployee
            // 
            resources.ApplyResources(this.addEmployee, "addEmployee");
            this.addEmployee.Name = "addEmployee";
            this.addEmployee.UseVisualStyleBackColor = true;
            this.addEmployee.Click += new System.EventHandler(this.addEmployee_Click);
            // 
            // employeeNameText
            // 
            resources.ApplyResources(this.employeeNameText, "employeeNameText");
            this.employeeNameText.Name = "employeeNameText";
            // 
            // photo
            // 
            resources.ApplyResources(this.photo, "photo");
            this.photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photo.Name = "photo";
            this.photo.TabStop = false;
            // 
            // employeeName
            // 
            resources.ApplyResources(this.employeeName, "employeeName");
            this.employeeName.BackColor = System.Drawing.SystemColors.Window;
            this.employeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.employeeName.Name = "employeeName";
            this.employeeName.ReadOnly = true;
            // 
            // firingOrderNumber
            // 
            resources.ApplyResources(this.firingOrderNumber, "firingOrderNumber");
            this.firingOrderNumber.BackColor = System.Drawing.SystemColors.Window;
            this.firingOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firingOrderNumber.Name = "firingOrderNumber";
            this.firingOrderNumber.ReadOnly = true;
            // 
            // birthdateText
            // 
            resources.ApplyResources(this.birthdateText, "birthdateText");
            this.birthdateText.Name = "birthdateText";
            // 
            // firingOrderNumberText
            // 
            resources.ApplyResources(this.firingOrderNumberText, "firingOrderNumberText");
            this.firingOrderNumberText.Name = "firingOrderNumberText";
            // 
            // birthdate
            // 
            resources.ApplyResources(this.birthdate, "birthdate");
            this.birthdate.BackColor = System.Drawing.SystemColors.Window;
            this.birthdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.birthdate.Name = "birthdate";
            this.birthdate.ReadOnly = true;
            // 
            // hiringOrderNumber
            // 
            resources.ApplyResources(this.hiringOrderNumber, "hiringOrderNumber");
            this.hiringOrderNumber.BackColor = System.Drawing.SystemColors.Window;
            this.hiringOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hiringOrderNumber.Name = "hiringOrderNumber";
            this.hiringOrderNumber.ReadOnly = true;
            // 
            // positionText
            // 
            resources.ApplyResources(this.positionText, "positionText");
            this.positionText.Name = "positionText";
            // 
            // hiringOrderNumberText
            // 
            resources.ApplyResources(this.hiringOrderNumberText, "hiringOrderNumberText");
            this.hiringOrderNumberText.Name = "hiringOrderNumberText";
            // 
            // position
            // 
            resources.ApplyResources(this.position, "position");
            this.position.BackColor = System.Drawing.SystemColors.Window;
            this.position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.position.Name = "position";
            this.position.ReadOnly = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.employeeInformation);
            this.Controls.Add(this.employeeChoice);
            this.Controls.Add(this.employeeChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.employeeInformation.ResumeLayout(false);
            this.employeeInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label employeeChoiceText;
        private System.Windows.Forms.ComboBox employeeChoice;
        private System.Windows.Forms.GroupBox employeeInformation;
        private System.Windows.Forms.Label employeeNameText;
        private System.Windows.Forms.TextBox employeeName;
        private System.Windows.Forms.Label birthdateText;
        private System.Windows.Forms.TextBox birthdate;
        private System.Windows.Forms.Label positionText;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.Label hiringOrderNumberText;
        private System.Windows.Forms.TextBox hiringOrderNumber;
        private System.Windows.Forms.Label firingOrderNumberText;
        private System.Windows.Forms.TextBox firingOrderNumber;
        private System.Windows.Forms.PictureBox photo;
        private System.Windows.Forms.Button addEmployee;
        private System.Windows.Forms.Button editEmployee;
        private System.Windows.Forms.Button deleteEmployee;
    }
}