namespace UsersAccounting
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
            this.displayType = new System.Windows.Forms.GroupBox();
            this.adminsUsers = new System.Windows.Forms.RadioButton();
            this.allUsers = new System.Windows.Forms.RadioButton();
            this.usersListText = new System.Windows.Forms.Label();
            this.usersList = new System.Windows.Forms.ListBox();
            this.userInformation = new System.Windows.Forms.GroupBox();
            this.userType = new System.Windows.Forms.TextBox();
            this.userTypeText = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.TextBox();
            this.telephoneText = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.userPasswordText = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.displayType.SuspendLayout();
            this.userInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayType
            // 
            this.displayType.Controls.Add(this.adminsUsers);
            this.displayType.Controls.Add(this.allUsers);
            resources.ApplyResources(this.displayType, "displayType");
            this.displayType.Name = "displayType";
            this.displayType.TabStop = false;
            // 
            // adminsUsers
            // 
            resources.ApplyResources(this.adminsUsers, "adminsUsers");
            this.adminsUsers.Name = "adminsUsers";
            this.adminsUsers.TabStop = true;
            this.adminsUsers.UseVisualStyleBackColor = true;
            // 
            // allUsers
            // 
            resources.ApplyResources(this.allUsers, "allUsers");
            this.allUsers.Name = "allUsers";
            this.allUsers.TabStop = true;
            this.allUsers.UseVisualStyleBackColor = true;
            this.allUsers.CheckedChanged += new System.EventHandler(this.allUsers_CheckedChanged);
            // 
            // usersListText
            // 
            resources.ApplyResources(this.usersListText, "usersListText");
            this.usersListText.Name = "usersListText";
            // 
            // usersList
            // 
            this.usersList.FormattingEnabled = true;
            resources.ApplyResources(this.usersList, "usersList");
            this.usersList.Name = "usersList";
            this.usersList.SelectedIndexChanged += new System.EventHandler(this.usersList_SelectedIndexChanged);
            this.usersList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.usersList_DoubleClick);
            // 
            // userInformation
            // 
            this.userInformation.Controls.Add(this.userType);
            this.userInformation.Controls.Add(this.userTypeText);
            this.userInformation.Controls.Add(this.telephone);
            this.userInformation.Controls.Add(this.telephoneText);
            this.userInformation.Controls.Add(this.address);
            this.userInformation.Controls.Add(this.addressText);
            this.userInformation.Controls.Add(this.userPassword);
            this.userInformation.Controls.Add(this.userPasswordText);
            resources.ApplyResources(this.userInformation, "userInformation");
            this.userInformation.Name = "userInformation";
            this.userInformation.TabStop = false;
            // 
            // userType
            // 
            this.userType.BackColor = System.Drawing.SystemColors.Window;
            this.userType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.userType, "userType");
            this.userType.Name = "userType";
            this.userType.ReadOnly = true;
            // 
            // userTypeText
            // 
            resources.ApplyResources(this.userTypeText, "userTypeText");
            this.userTypeText.Name = "userTypeText";
            // 
            // telephone
            // 
            this.telephone.BackColor = System.Drawing.SystemColors.Window;
            this.telephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.telephone, "telephone");
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            // 
            // telephoneText
            // 
            resources.ApplyResources(this.telephoneText, "telephoneText");
            this.telephoneText.Name = "telephoneText";
            // 
            // address
            // 
            this.address.BackColor = System.Drawing.SystemColors.Window;
            this.address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.address, "address");
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // addressText
            // 
            resources.ApplyResources(this.addressText, "addressText");
            this.addressText.Name = "addressText";
            // 
            // userPassword
            // 
            this.userPassword.BackColor = System.Drawing.SystemColors.Window;
            this.userPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.userPassword, "userPassword");
            this.userPassword.Name = "userPassword";
            this.userPassword.ReadOnly = true;
            // 
            // userPasswordText
            // 
            resources.ApplyResources(this.userPasswordText, "userPasswordText");
            this.userPasswordText.Name = "userPasswordText";
            // 
            // add
            // 
            resources.ApplyResources(this.add, "add");
            this.add.Name = "add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            resources.ApplyResources(this.delete, "delete");
            this.delete.Name = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.userInformation);
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.usersListText);
            this.Controls.Add(this.displayType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.displayType.ResumeLayout(false);
            this.displayType.PerformLayout();
            this.userInformation.ResumeLayout(false);
            this.userInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox displayType;
        private System.Windows.Forms.RadioButton adminsUsers;
        private System.Windows.Forms.RadioButton allUsers;
        private System.Windows.Forms.Label usersListText;
        private System.Windows.Forms.ListBox usersList;
        private System.Windows.Forms.GroupBox userInformation;
        private System.Windows.Forms.Label userPasswordText;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Label addressText;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label telephoneText;
        private System.Windows.Forms.TextBox telephone;
        private System.Windows.Forms.Label userTypeText;
        private System.Windows.Forms.TextBox userType;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
    }
}