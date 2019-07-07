namespace Phonebook
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
            this.sortType = new System.Windows.Forms.GroupBox();
            this.sort = new System.Windows.Forms.Button();
            this.telephoneSort = new System.Windows.Forms.RadioButton();
            this.nameSort = new System.Windows.Forms.RadioButton();
            this.noSort = new System.Windows.Forms.RadioButton();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.directoryView = new System.Windows.Forms.DataGridView();
            this.sortType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.directoryView)).BeginInit();
            this.SuspendLayout();
            // 
            // sortType
            // 
            this.sortType.Controls.Add(this.sort);
            this.sortType.Controls.Add(this.telephoneSort);
            this.sortType.Controls.Add(this.nameSort);
            this.sortType.Controls.Add(this.noSort);
            resources.ApplyResources(this.sortType, "sortType");
            this.sortType.Name = "sortType";
            this.sortType.TabStop = false;
            // 
            // sort
            // 
            resources.ApplyResources(this.sort, "sort");
            this.sort.Name = "sort";
            this.sort.UseVisualStyleBackColor = true;
            this.sort.Click += new System.EventHandler(this.sort_Click);
            // 
            // telephoneSort
            // 
            resources.ApplyResources(this.telephoneSort, "telephoneSort");
            this.telephoneSort.Name = "telephoneSort";
            this.telephoneSort.TabStop = true;
            this.telephoneSort.UseVisualStyleBackColor = true;
            // 
            // nameSort
            // 
            resources.ApplyResources(this.nameSort, "nameSort");
            this.nameSort.Name = "nameSort";
            this.nameSort.TabStop = true;
            this.nameSort.UseVisualStyleBackColor = true;
            // 
            // noSort
            // 
            resources.ApplyResources(this.noSort, "noSort");
            this.noSort.Name = "noSort";
            this.noSort.TabStop = true;
            this.noSort.UseVisualStyleBackColor = true;
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
            // directoryView
            // 
            this.directoryView.AllowUserToAddRows = false;
            this.directoryView.AllowUserToDeleteRows = false;
            this.directoryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.directoryView, "directoryView");
            this.directoryView.MultiSelect = false;
            this.directoryView.Name = "directoryView";
            this.directoryView.ReadOnly = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.directoryView);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.sortType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sortType.ResumeLayout(false);
            this.sortType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.directoryView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox sortType;
        private System.Windows.Forms.RadioButton noSort;
        private System.Windows.Forms.RadioButton nameSort;
        private System.Windows.Forms.RadioButton telephoneSort;
        private System.Windows.Forms.Button sort;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.DataGridView directoryView;
    }
}