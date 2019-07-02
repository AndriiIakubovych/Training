namespace HotelEconomy
{
    partial class ClientsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            this.clientsView = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.searchParameters = new System.Windows.Forms.GroupBox();
            this.search = new System.Windows.Forms.Button();
            this.roomChoice = new System.Windows.Forms.ComboBox();
            this.roomChoiceText = new System.Windows.Forms.Label();
            this.roomSearch = new System.Windows.Forms.CheckBox();
            this.clientName = new System.Windows.Forms.TextBox();
            this.clientNameText = new System.Windows.Forms.Label();
            this.clientNameSearch = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.clientsView)).BeginInit();
            this.searchParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientsView
            // 
            this.clientsView.AllowUserToAddRows = false;
            this.clientsView.AllowUserToDeleteRows = false;
            this.clientsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.clientsView, "clientsView");
            this.clientsView.MultiSelect = false;
            this.clientsView.Name = "clientsView";
            this.clientsView.ReadOnly = true;
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
            this.searchParameters.Controls.Add(this.roomChoice);
            this.searchParameters.Controls.Add(this.roomChoiceText);
            this.searchParameters.Controls.Add(this.roomSearch);
            this.searchParameters.Controls.Add(this.clientName);
            this.searchParameters.Controls.Add(this.clientNameText);
            this.searchParameters.Controls.Add(this.clientNameSearch);
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
            // roomChoice
            // 
            this.roomChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.roomChoice, "roomChoice");
            this.roomChoice.FormattingEnabled = true;
            this.roomChoice.Name = "roomChoice";
            // 
            // roomChoiceText
            // 
            resources.ApplyResources(this.roomChoiceText, "roomChoiceText");
            this.roomChoiceText.Name = "roomChoiceText";
            // 
            // roomSearch
            // 
            resources.ApplyResources(this.roomSearch, "roomSearch");
            this.roomSearch.Name = "roomSearch";
            this.roomSearch.UseVisualStyleBackColor = true;
            this.roomSearch.CheckedChanged += new System.EventHandler(this.roomSearch_CheckedChanged);
            // 
            // clientName
            // 
            resources.ApplyResources(this.clientName, "clientName");
            this.clientName.Name = "clientName";
            // 
            // clientNameText
            // 
            resources.ApplyResources(this.clientNameText, "clientNameText");
            this.clientNameText.Name = "clientNameText";
            // 
            // clientNameSearch
            // 
            resources.ApplyResources(this.clientNameSearch, "clientNameSearch");
            this.clientNameSearch.Name = "clientNameSearch";
            this.clientNameSearch.UseVisualStyleBackColor = true;
            this.clientNameSearch.CheckedChanged += new System.EventHandler(this.clientNameSearch_CheckedChanged);
            // 
            // ClientsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchParameters);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.clientsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsView)).EndInit();
            this.searchParameters.ResumeLayout(false);
            this.searchParameters.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView clientsView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox searchParameters;
        private System.Windows.Forms.CheckBox clientNameSearch;
        private System.Windows.Forms.Label clientNameText;
        private System.Windows.Forms.TextBox clientName;
        private System.Windows.Forms.CheckBox roomSearch;
        private System.Windows.Forms.Label roomChoiceText;
        private System.Windows.Forms.ComboBox roomChoice;
        private System.Windows.Forms.Button search;
    }
}