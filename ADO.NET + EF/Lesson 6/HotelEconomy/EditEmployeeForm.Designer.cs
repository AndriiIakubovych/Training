namespace HotelEconomy
{
    partial class EditEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEmployeeForm));
            this.employeeNameText = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.TextBox();
            this.birthdateText = new System.Windows.Forms.Label();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.positionText = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.telephoneText = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.MaskedTextBox();
            this.salaryText = new System.Windows.Forms.Label();
            this.salary = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // employeeNameText
            // 
            resources.ApplyResources(this.employeeNameText, "employeeNameText");
            this.employeeNameText.Name = "employeeNameText";
            // 
            // employeeName
            // 
            resources.ApplyResources(this.employeeName, "employeeName");
            this.employeeName.Name = "employeeName";
            this.employeeName.TextChanged += new System.EventHandler(this.employeeName_TextChanged);
            // 
            // birthdateText
            // 
            resources.ApplyResources(this.birthdateText, "birthdateText");
            this.birthdateText.Name = "birthdateText";
            // 
            // birthdate
            // 
            this.birthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.birthdate, "birthdate");
            this.birthdate.Name = "birthdate";
            // 
            // positionText
            // 
            resources.ApplyResources(this.positionText, "positionText");
            this.positionText.Name = "positionText";
            // 
            // position
            // 
            resources.ApplyResources(this.position, "position");
            this.position.Name = "position";
            this.position.TextChanged += new System.EventHandler(this.position_TextChanged);
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
            this.address.TextChanged += new System.EventHandler(this.address_TextChanged);
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
            this.telephone.TextChanged += new System.EventHandler(this.telephone_TextChanged);
            // 
            // salaryText
            // 
            resources.ApplyResources(this.salaryText, "salaryText");
            this.salaryText.Name = "salaryText";
            // 
            // salary
            // 
            resources.ApplyResources(this.salary, "salary");
            this.salary.Name = "salary";
            this.salary.TextChanged += new System.EventHandler(this.salary_TextChanged);
            // 
            // ok
            // 
            resources.ApplyResources(this.ok, "ok");
            this.ok.Name = "ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ok_MouseDown);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditEmployeeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.salary);
            this.Controls.Add(this.salaryText);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.telephoneText);
            this.Controls.Add(this.address);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.position);
            this.Controls.Add(this.positionText);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.birthdateText);
            this.Controls.Add(this.employeeName);
            this.Controls.Add(this.employeeNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditEmployeeForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label employeeNameText;
        private System.Windows.Forms.TextBox employeeName;
        private System.Windows.Forms.Label birthdateText;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Label positionText;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.Label addressText;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label telephoneText;
        private System.Windows.Forms.MaskedTextBox telephone;
        private System.Windows.Forms.Label salaryText;
        private System.Windows.Forms.TextBox salary;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}