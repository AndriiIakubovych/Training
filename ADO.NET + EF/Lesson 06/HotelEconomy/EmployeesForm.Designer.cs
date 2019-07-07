namespace HotelEconomy
{
    partial class EmployeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesForm));
            this.employeesView = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.searchParameters = new System.Windows.Forms.GroupBox();
            this.search = new System.Windows.Forms.Button();
            this.positionChoice = new System.Windows.Forms.ComboBox();
            this.positionChoiceText = new System.Windows.Forms.Label();
            this.positionSearch = new System.Windows.Forms.CheckBox();
            this.employeeName = new System.Windows.Forms.TextBox();
            this.employeeNameText = new System.Windows.Forms.Label();
            this.employeeNameSearch = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.employeesView)).BeginInit();
            this.searchParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // employeesView
            // 
            this.employeesView.AllowUserToAddRows = false;
            this.employeesView.AllowUserToDeleteRows = false;
            this.employeesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.employeesView, "employeesView");
            this.employeesView.MultiSelect = false;
            this.employeesView.Name = "employeesView";
            this.employeesView.ReadOnly = true;
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
            // searchParameters
            // 
            this.searchParameters.Controls.Add(this.search);
            this.searchParameters.Controls.Add(this.positionChoice);
            this.searchParameters.Controls.Add(this.positionChoiceText);
            this.searchParameters.Controls.Add(this.positionSearch);
            this.searchParameters.Controls.Add(this.employeeName);
            this.searchParameters.Controls.Add(this.employeeNameText);
            this.searchParameters.Controls.Add(this.employeeNameSearch);
            resources.ApplyResources(this.searchParameters, "searchParameters");
            this.searchParameters.Name = "searchParameters";
            this.searchParameters.TabStop = false;
            // 
            // search
            // 
            resources.ApplyResources(this.search, "search");
            this.search.Name = "search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // positionChoice
            // 
            this.positionChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.positionChoice, "positionChoice");
            this.positionChoice.FormattingEnabled = true;
            this.positionChoice.Name = "positionChoice";
            // 
            // positionChoiceText
            // 
            resources.ApplyResources(this.positionChoiceText, "positionChoiceText");
            this.positionChoiceText.Name = "positionChoiceText";
            // 
            // positionSearch
            // 
            resources.ApplyResources(this.positionSearch, "positionSearch");
            this.positionSearch.Name = "positionSearch";
            this.positionSearch.UseVisualStyleBackColor = true;
            this.positionSearch.CheckedChanged += new System.EventHandler(this.positionSearch_CheckedChanged);
            // 
            // employeeName
            // 
            resources.ApplyResources(this.employeeName, "employeeName");
            this.employeeName.Name = "employeeName";
            // 
            // employeeNameText
            // 
            resources.ApplyResources(this.employeeNameText, "employeeNameText");
            this.employeeNameText.Name = "employeeNameText";
            // 
            // employeeNameSearch
            // 
            resources.ApplyResources(this.employeeNameSearch, "employeeNameSearch");
            this.employeeNameSearch.Name = "employeeNameSearch";
            this.employeeNameSearch.UseVisualStyleBackColor = true;
            this.employeeNameSearch.CheckedChanged += new System.EventHandler(this.employeeNameSearch_CheckedChanged);
            // 
            // EmployeesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchParameters);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.employeesView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeesForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EmployeesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeesView)).EndInit();
            this.searchParameters.ResumeLayout(false);
            this.searchParameters.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView employeesView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox searchParameters;
        private System.Windows.Forms.CheckBox positionSearch;
        private System.Windows.Forms.Label positionChoiceText;
        private System.Windows.Forms.ComboBox positionChoice;
        private System.Windows.Forms.CheckBox employeeNameSearch;
        private System.Windows.Forms.Label employeeNameText;
        private System.Windows.Forms.TextBox employeeName;
        private System.Windows.Forms.Button search;
    }
}