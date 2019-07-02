namespace HotelEconomy
{
    partial class AddUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.userNameText = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.userPasswordText = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.adminRights = new System.Windows.Forms.CheckBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userNameText
            // 
            resources.ApplyResources(this.userNameText, "userNameText");
            this.userNameText.Name = "userNameText";
            // 
            // userName
            // 
            resources.ApplyResources(this.userName, "userName");
            this.userName.Name = "userName";
            this.userName.TextChanged += new System.EventHandler(this.userName_TextChanged);
            // 
            // userPasswordText
            // 
            resources.ApplyResources(this.userPasswordText, "userPasswordText");
            this.userPasswordText.Name = "userPasswordText";
            // 
            // userPassword
            // 
            resources.ApplyResources(this.userPassword, "userPassword");
            this.userPassword.Name = "userPassword";
            this.userPassword.TextChanged += new System.EventHandler(this.userPassword_TextChanged);
            // 
            // adminRights
            // 
            resources.ApplyResources(this.adminRights, "adminRights");
            this.adminRights.Name = "adminRights";
            this.adminRights.UseVisualStyleBackColor = true;
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
            // AddUserForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.adminRights);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.userPasswordText);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label userNameText;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label userPasswordText;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.CheckBox adminRights;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}