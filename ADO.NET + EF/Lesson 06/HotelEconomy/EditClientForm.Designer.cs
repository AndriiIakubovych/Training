namespace HotelEconomy
{
    partial class EditClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditClientForm));
            this.clientNameText = new System.Windows.Forms.Label();
            this.clientName = new System.Windows.Forms.TextBox();
            this.sexChoiceText = new System.Windows.Forms.Label();
            this.sexChoice = new System.Windows.Forms.ComboBox();
            this.birthdateText = new System.Windows.Forms.Label();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.passportDataText = new System.Windows.Forms.Label();
            this.passportData = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.telephoneText = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.MaskedTextBox();
            this.nationalityText = new System.Windows.Forms.Label();
            this.nationality = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientNameText
            // 
            resources.ApplyResources(this.clientNameText, "clientNameText");
            this.clientNameText.Name = "clientNameText";
            // 
            // clientName
            // 
            resources.ApplyResources(this.clientName, "clientName");
            this.clientName.Name = "clientName";
            this.clientName.TextChanged += new System.EventHandler(this.clientName_TextChanged);
            // 
            // sexChoiceText
            // 
            resources.ApplyResources(this.sexChoiceText, "sexChoiceText");
            this.sexChoiceText.Name = "sexChoiceText";
            // 
            // sexChoice
            // 
            this.sexChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexChoice.FormattingEnabled = true;
            this.sexChoice.Items.AddRange(new object[] {
            resources.GetString("sexChoice.Items"),
            resources.GetString("sexChoice.Items1")});
            resources.ApplyResources(this.sexChoice, "sexChoice");
            this.sexChoice.Name = "sexChoice";
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
            // passportDataText
            // 
            resources.ApplyResources(this.passportDataText, "passportDataText");
            this.passportDataText.Name = "passportDataText";
            // 
            // passportData
            // 
            resources.ApplyResources(this.passportData, "passportData");
            this.passportData.Name = "passportData";
            this.passportData.TextChanged += new System.EventHandler(this.passportData_TextChanged);
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
            // nationalityText
            // 
            resources.ApplyResources(this.nationalityText, "nationalityText");
            this.nationalityText.Name = "nationalityText";
            // 
            // nationality
            // 
            resources.ApplyResources(this.nationality, "nationality");
            this.nationality.Name = "nationality";
            this.nationality.TextChanged += new System.EventHandler(this.nationality_TextChanged);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.ok, "ok");
            this.ok.Name = "ok";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditClientForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.nationality);
            this.Controls.Add(this.nationalityText);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.telephoneText);
            this.Controls.Add(this.address);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.passportData);
            this.Controls.Add(this.passportDataText);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.birthdateText);
            this.Controls.Add(this.sexChoice);
            this.Controls.Add(this.sexChoiceText);
            this.Controls.Add(this.clientName);
            this.Controls.Add(this.clientNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditClientForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EditClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label clientNameText;
        private System.Windows.Forms.TextBox clientName;
        private System.Windows.Forms.Label sexChoiceText;
        private System.Windows.Forms.ComboBox sexChoice;
        private System.Windows.Forms.Label birthdateText;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Label passportDataText;
        private System.Windows.Forms.TextBox passportData;
        private System.Windows.Forms.Label addressText;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label telephoneText;
        private System.Windows.Forms.MaskedTextBox telephone;
        private System.Windows.Forms.Label nationalityText;
        private System.Windows.Forms.TextBox nationality;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}