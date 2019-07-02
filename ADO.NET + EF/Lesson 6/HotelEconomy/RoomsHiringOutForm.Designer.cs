namespace HotelEconomy
{
    partial class RoomsHiringOutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomsHiringOutForm));
            this.roomsHiringOutView = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.searchParameters = new System.Windows.Forms.GroupBox();
            this.search = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.separator = new System.Windows.Forms.Label();
            this.beginningDate = new System.Windows.Forms.DateTimePicker();
            this.periodText = new System.Windows.Forms.Label();
            this.periodSearch = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.roomsHiringOutView)).BeginInit();
            this.searchParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomsHiringOutView
            // 
            this.roomsHiringOutView.AllowUserToAddRows = false;
            this.roomsHiringOutView.AllowUserToDeleteRows = false;
            this.roomsHiringOutView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.roomsHiringOutView, "roomsHiringOutView");
            this.roomsHiringOutView.MultiSelect = false;
            this.roomsHiringOutView.Name = "roomsHiringOutView";
            this.roomsHiringOutView.ReadOnly = true;
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
            this.searchParameters.Controls.Add(this.endDate);
            this.searchParameters.Controls.Add(this.separator);
            this.searchParameters.Controls.Add(this.beginningDate);
            this.searchParameters.Controls.Add(this.periodText);
            this.searchParameters.Controls.Add(this.periodSearch);
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
            // endDate
            // 
            resources.ApplyResources(this.endDate, "endDate");
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Name = "endDate";
            // 
            // separator
            // 
            resources.ApplyResources(this.separator, "separator");
            this.separator.Name = "separator";
            // 
            // beginningDate
            // 
            resources.ApplyResources(this.beginningDate, "beginningDate");
            this.beginningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.beginningDate.Name = "beginningDate";
            // 
            // periodText
            // 
            resources.ApplyResources(this.periodText, "periodText");
            this.periodText.Name = "periodText";
            // 
            // periodSearch
            // 
            resources.ApplyResources(this.periodSearch, "periodSearch");
            this.periodSearch.Name = "periodSearch";
            this.periodSearch.UseVisualStyleBackColor = true;
            this.periodSearch.CheckedChanged += new System.EventHandler(this.periodSearch_CheckedChanged);
            // 
            // RoomsHiringOutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchParameters);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.roomsHiringOutView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomsHiringOutForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.RoomsHiringOutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomsHiringOutView)).EndInit();
            this.searchParameters.ResumeLayout(false);
            this.searchParameters.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView roomsHiringOutView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox searchParameters;
        private System.Windows.Forms.CheckBox periodSearch;
        private System.Windows.Forms.Label periodText;
        private System.Windows.Forms.DateTimePicker beginningDate;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Button search;
    }
}