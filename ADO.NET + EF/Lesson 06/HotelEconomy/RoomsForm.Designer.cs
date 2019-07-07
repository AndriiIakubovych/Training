namespace HotelEconomy
{
    partial class RoomsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomsForm));
            this.roomsView = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.searchParameters = new System.Windows.Forms.GroupBox();
            this.search = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.secondSeparator = new System.Windows.Forms.Label();
            this.beginningDate = new System.Windows.Forms.DateTimePicker();
            this.freeDateText = new System.Windows.Forms.Label();
            this.freeSearch = new System.Windows.Forms.CheckBox();
            this.secondPrice = new System.Windows.Forms.TextBox();
            this.firstSeparator = new System.Windows.Forms.Label();
            this.firstPrice = new System.Windows.Forms.TextBox();
            this.priceText = new System.Windows.Forms.Label();
            this.priceSearch = new System.Windows.Forms.CheckBox();
            this.placesCountChoice = new System.Windows.Forms.ComboBox();
            this.placesCountChoiceText = new System.Windows.Forms.Label();
            this.placesCountSearch = new System.Windows.Forms.CheckBox();
            this.categoryChoice = new System.Windows.Forms.ComboBox();
            this.categoryChoiceText = new System.Windows.Forms.Label();
            this.categorySearch = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.roomsView)).BeginInit();
            this.searchParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomsView
            // 
            this.roomsView.AllowUserToAddRows = false;
            this.roomsView.AllowUserToDeleteRows = false;
            this.roomsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.roomsView, "roomsView");
            this.roomsView.MultiSelect = false;
            this.roomsView.Name = "roomsView";
            this.roomsView.ReadOnly = true;
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
            this.searchParameters.Controls.Add(this.secondSeparator);
            this.searchParameters.Controls.Add(this.beginningDate);
            this.searchParameters.Controls.Add(this.freeDateText);
            this.searchParameters.Controls.Add(this.freeSearch);
            this.searchParameters.Controls.Add(this.secondPrice);
            this.searchParameters.Controls.Add(this.firstSeparator);
            this.searchParameters.Controls.Add(this.firstPrice);
            this.searchParameters.Controls.Add(this.priceText);
            this.searchParameters.Controls.Add(this.priceSearch);
            this.searchParameters.Controls.Add(this.placesCountChoice);
            this.searchParameters.Controls.Add(this.placesCountChoiceText);
            this.searchParameters.Controls.Add(this.placesCountSearch);
            this.searchParameters.Controls.Add(this.categoryChoice);
            this.searchParameters.Controls.Add(this.categoryChoiceText);
            this.searchParameters.Controls.Add(this.categorySearch);
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
            // secondSeparator
            // 
            resources.ApplyResources(this.secondSeparator, "secondSeparator");
            this.secondSeparator.Name = "secondSeparator";
            // 
            // beginningDate
            // 
            resources.ApplyResources(this.beginningDate, "beginningDate");
            this.beginningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.beginningDate.Name = "beginningDate";
            // 
            // freeDateText
            // 
            resources.ApplyResources(this.freeDateText, "freeDateText");
            this.freeDateText.Name = "freeDateText";
            // 
            // freeSearch
            // 
            resources.ApplyResources(this.freeSearch, "freeSearch");
            this.freeSearch.Name = "freeSearch";
            this.freeSearch.UseVisualStyleBackColor = true;
            this.freeSearch.CheckedChanged += new System.EventHandler(this.freeSearch_CheckedChanged);
            // 
            // secondPrice
            // 
            resources.ApplyResources(this.secondPrice, "secondPrice");
            this.secondPrice.Name = "secondPrice";
            // 
            // firstSeparator
            // 
            resources.ApplyResources(this.firstSeparator, "firstSeparator");
            this.firstSeparator.Name = "firstSeparator";
            // 
            // firstPrice
            // 
            resources.ApplyResources(this.firstPrice, "firstPrice");
            this.firstPrice.Name = "firstPrice";
            // 
            // priceText
            // 
            resources.ApplyResources(this.priceText, "priceText");
            this.priceText.Name = "priceText";
            // 
            // priceSearch
            // 
            resources.ApplyResources(this.priceSearch, "priceSearch");
            this.priceSearch.Name = "priceSearch";
            this.priceSearch.UseVisualStyleBackColor = true;
            this.priceSearch.CheckedChanged += new System.EventHandler(this.priceSearch_CheckedChanged);
            // 
            // placesCountChoice
            // 
            this.placesCountChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.placesCountChoice, "placesCountChoice");
            this.placesCountChoice.FormattingEnabled = true;
            this.placesCountChoice.Items.AddRange(new object[] { resources.GetString("placesCountChoice.Items"), resources.GetString("placesCountChoice.Items1"), resources.GetString("placesCountChoice.Items2") });
            this.placesCountChoice.Name = "placesCountChoice";
            // 
            // placesCountChoiceText
            // 
            resources.ApplyResources(this.placesCountChoiceText, "placesCountChoiceText");
            this.placesCountChoiceText.Name = "placesCountChoiceText";
            // 
            // placesCountSearch
            // 
            resources.ApplyResources(this.placesCountSearch, "placesCountSearch");
            this.placesCountSearch.Name = "placesCountSearch";
            this.placesCountSearch.UseVisualStyleBackColor = true;
            this.placesCountSearch.CheckedChanged += new System.EventHandler(this.placesCountSearch_CheckedChanged);
            // 
            // categoryChoice
            // 
            this.categoryChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.categoryChoice, "categoryChoice");
            this.categoryChoice.FormattingEnabled = true;
            this.categoryChoice.Items.AddRange(new object[] { resources.GetString("categoryChoice.Items"), resources.GetString("categoryChoice.Items1"), resources.GetString("categoryChoice.Items2") });
            this.categoryChoice.Name = "categoryChoice";
            // 
            // categoryChoiceText
            // 
            resources.ApplyResources(this.categoryChoiceText, "categoryChoiceText");
            this.categoryChoiceText.Name = "categoryChoiceText";
            // 
            // categorySearch
            // 
            resources.ApplyResources(this.categorySearch, "categorySearch");
            this.categorySearch.Name = "categorySearch";
            this.categorySearch.UseVisualStyleBackColor = true;
            this.categorySearch.CheckedChanged += new System.EventHandler(this.categorySearch_CheckedChanged);
            // 
            // RoomsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchParameters);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.roomsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.RoomsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomsView)).EndInit();
            this.searchParameters.ResumeLayout(false);
            this.searchParameters.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView roomsView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox searchParameters;
        private System.Windows.Forms.CheckBox categorySearch;
        private System.Windows.Forms.Label categoryChoiceText;
        private System.Windows.Forms.ComboBox categoryChoice;
        private System.Windows.Forms.CheckBox placesCountSearch;
        private System.Windows.Forms.Label placesCountChoiceText;
        private System.Windows.Forms.ComboBox placesCountChoice;
        private System.Windows.Forms.CheckBox priceSearch;
        private System.Windows.Forms.Label priceText;
        private System.Windows.Forms.TextBox firstPrice;
        private System.Windows.Forms.Label firstSeparator;
        private System.Windows.Forms.TextBox secondPrice;
        private System.Windows.Forms.CheckBox freeSearch;
        private System.Windows.Forms.Label freeDateText;
        private System.Windows.Forms.DateTimePicker beginningDate;
        private System.Windows.Forms.Label secondSeparator;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Button search;
    }
}