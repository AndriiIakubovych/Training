namespace BooksSearch
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
            this.searchSettings = new System.Windows.Forms.GroupBox();
            this.find = new System.Windows.Forms.Button();
            this.pressChoice = new System.Windows.Forms.ComboBox();
            this.authorChoice = new System.Windows.Forms.ComboBox();
            this.pressSearch = new System.Windows.Forms.CheckBox();
            this.authorSearch = new System.Windows.Forms.CheckBox();
            this.booksView = new System.Windows.Forms.DataGridView();
            this.searchSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchSettings
            // 
            this.searchSettings.Controls.Add(this.find);
            this.searchSettings.Controls.Add(this.pressChoice);
            this.searchSettings.Controls.Add(this.authorChoice);
            this.searchSettings.Controls.Add(this.pressSearch);
            this.searchSettings.Controls.Add(this.authorSearch);
            resources.ApplyResources(this.searchSettings, "searchSettings");
            this.searchSettings.Name = "searchSettings";
            this.searchSettings.TabStop = false;
            // 
            // find
            // 
            resources.ApplyResources(this.find, "find");
            this.find.Name = "find";
            this.find.UseVisualStyleBackColor = true;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // pressChoice
            // 
            this.pressChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.pressChoice, "pressChoice");
            this.pressChoice.FormattingEnabled = true;
            this.pressChoice.Name = "pressChoice";
            // 
            // authorChoice
            // 
            this.authorChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.authorChoice, "authorChoice");
            this.authorChoice.FormattingEnabled = true;
            this.authorChoice.Name = "authorChoice";
            // 
            // pressSearch
            // 
            resources.ApplyResources(this.pressSearch, "pressSearch");
            this.pressSearch.Name = "pressSearch";
            this.pressSearch.UseVisualStyleBackColor = true;
            this.pressSearch.CheckedChanged += new System.EventHandler(this.pressSearch_CheckedChanged);
            // 
            // authorSearch
            // 
            resources.ApplyResources(this.authorSearch, "authorSearch");
            this.authorSearch.Name = "authorSearch";
            this.authorSearch.UseVisualStyleBackColor = true;
            this.authorSearch.CheckedChanged += new System.EventHandler(this.authorSearch_CheckedChanged);
            // 
            // booksView
            // 
            this.booksView.AllowUserToAddRows = false;
            this.booksView.AllowUserToDeleteRows = false;
            this.booksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.booksView, "booksView");
            this.booksView.MultiSelect = false;
            this.booksView.Name = "booksView";
            this.booksView.ReadOnly = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.booksView);
            this.Controls.Add(this.searchSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.searchSettings.ResumeLayout(false);
            this.searchSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox searchSettings;
        private System.Windows.Forms.CheckBox authorSearch;
        private System.Windows.Forms.CheckBox pressSearch;
        private System.Windows.Forms.ComboBox authorChoice;
        private System.Windows.Forms.ComboBox pressChoice;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.DataGridView booksView;
    }
}