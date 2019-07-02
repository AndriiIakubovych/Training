namespace Phonebook
{
    partial class AddRowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRowForm));
            this.nameText = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.telephoneText = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.MaskedTextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameText
            // 
            resources.ApplyResources(this.nameText, "nameText");
            this.nameText.Name = "nameText";
            // 
            // name
            // 
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
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
            // AddRowForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.telephoneText);
            this.Controls.Add(this.address);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.name);
            this.Controls.Add(this.nameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRowForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label nameText;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label addressText;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label telephoneText;
        private System.Windows.Forms.MaskedTextBox telephone;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}