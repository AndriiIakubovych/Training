﻿namespace RefrigeratorsShop
{
    partial class SellersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellersForm));
            this.sellersView = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sellersView)).BeginInit();
            this.SuspendLayout();
            // 
            // sellersView
            // 
            this.sellersView.AllowUserToAddRows = false;
            this.sellersView.AllowUserToDeleteRows = false;
            this.sellersView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.sellersView, "sellersView");
            this.sellersView.MultiSelect = false;
            this.sellersView.Name = "sellersView";
            this.sellersView.ReadOnly = true;
            // 
            // add
            // 
            resources.ApplyResources(this.add, "add");
            this.add.Name = "add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // edit
            // 
            resources.ApplyResources(this.edit, "edit");
            this.edit.Name = "edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // delete
            // 
            resources.ApplyResources(this.delete, "delete");
            this.delete.Name = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // SellersForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.sellersView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SellersForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SellersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sellersView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView sellersView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
    }
}