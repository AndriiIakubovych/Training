﻿namespace RefrigeratorsShop
{
    partial class AddSellerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSellerForm));
            this.sellerNameText = new System.Windows.Forms.Label();
            this.sellerName = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.telephoneText = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.MaskedTextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sellerNameText
            // 
            resources.ApplyResources(this.sellerNameText, "sellerNameText");
            this.sellerNameText.Name = "sellerNameText";
            // 
            // sellerName
            // 
            resources.ApplyResources(this.sellerName, "sellerName");
            this.sellerName.Name = "sellerName";
            this.sellerName.TextChanged += new System.EventHandler(this.sellerName_TextChanged);
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
            // AddSellerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.telephoneText);
            this.Controls.Add(this.address);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.sellerName);
            this.Controls.Add(this.sellerNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSellerForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label sellerNameText;
        private System.Windows.Forms.TextBox sellerName;
        private System.Windows.Forms.Label addressText;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label telephoneText;
        private System.Windows.Forms.MaskedTextBox telephone;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}