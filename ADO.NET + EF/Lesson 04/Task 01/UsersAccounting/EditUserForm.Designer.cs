namespace UsersAccounting
{
    partial class EditUserForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUserForm));
            this.userLoginText = new System.Windows.Forms.Label();
            this.userLogin = new System.Windows.Forms.TextBox();
            this.checkUser = new System.Windows.Forms.Button();
            this.userPasswordText = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.telephoneText = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.MaskedTextBox();
            this.hasAdminRights = new System.Windows.Forms.CheckBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userLoginText
            // 
            resources.ApplyResources(this.userLoginText, "userLoginText");
            this.userLoginText.Name = "userLoginText";
            // 
            // userLogin
            // 
            resources.ApplyResources(this.userLogin, "userLogin");
            this.userLogin.Name = "userLogin";
            this.userLogin.TextChanged += new System.EventHandler(this.userLogin_TextChanged);
            // 
            // checkUser
            // 
            resources.ApplyResources(this.checkUser, "checkUser");
            this.checkUser.Name = "checkUser";
            this.checkUser.UseVisualStyleBackColor = true;
            this.checkUser.Click += new System.EventHandler(this.checkUser_Click);
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
            // hasAdminRights
            // 
            resources.ApplyResources(this.hasAdminRights, "hasAdminRights");
            this.hasAdminRights.Name = "hasAdminRights";
            this.hasAdminRights.UseVisualStyleBackColor = true;
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
            // EditUserForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userLoginText);
            this.Controls.Add(this.userLogin);
            this.Controls.Add(this.checkUser);
            this.Controls.Add(this.userPasswordText);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.address);
            this.Controls.Add(this.telephoneText);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.hasAdminRights);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditUserForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label userLoginText;
        private System.Windows.Forms.TextBox userLogin;
        private System.Windows.Forms.Button checkUser;
        private System.Windows.Forms.Label userPasswordText;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Label addressText;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label telephoneText;
        private System.Windows.Forms.MaskedTextBox telephone;
        private System.Windows.Forms.CheckBox hasAdminRights;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}