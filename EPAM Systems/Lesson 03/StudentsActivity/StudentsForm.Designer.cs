namespace StudentsActivity
{
    partial class StudentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsForm));
            this.studentsView = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.searchParameters = new System.Windows.Forms.GroupBox();
            this.search = new System.Windows.Forms.Button();
            this.studentName = new System.Windows.Forms.TextBox();
            this.studentNameText = new System.Windows.Forms.Label();
            this.studentNameSearch = new System.Windows.Forms.CheckBox();
            this.universitySearch = new System.Windows.Forms.CheckBox();
            this.universityChoiceText = new System.Windows.Forms.Label();
            this.universityChoice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.studentsView)).BeginInit();
            this.searchParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentsView
            // 
            this.studentsView.AllowUserToAddRows = false;
            this.studentsView.AllowUserToDeleteRows = false;
            this.studentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsView.Location = new System.Drawing.Point(12, 12);
            this.studentsView.MultiSelect = false;
            this.studentsView.Name = "studentsView";
            this.studentsView.ReadOnly = true;
            this.studentsView.Size = new System.Drawing.Size(550, 194);
            this.studentsView.TabIndex = 0;
            // 
            // add
            // 
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("add.Image")));
            this.add.Location = new System.Drawing.Point(12, 219);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(176, 23);
            this.add.TabIndex = 1;
            this.add.Text = "Add";
            this.add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // edit
            // 
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.Location = new System.Drawing.Point(199, 219);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(176, 23);
            this.edit.TabIndex = 2;
            this.edit.Text = "Edit";
            this.edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // delete
            // 
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.Location = new System.Drawing.Point(386, 219);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(176, 23);
            this.delete.TabIndex = 3;
            this.delete.Text = "Delete";
            this.delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // searchParameters
            // 
            this.searchParameters.Controls.Add(this.universityChoice);
            this.searchParameters.Controls.Add(this.universityChoiceText);
            this.searchParameters.Controls.Add(this.universitySearch);
            this.searchParameters.Controls.Add(this.search);
            this.searchParameters.Controls.Add(this.studentName);
            this.searchParameters.Controls.Add(this.studentNameText);
            this.searchParameters.Controls.Add(this.studentNameSearch);
            this.searchParameters.Location = new System.Drawing.Point(12, 249);
            this.searchParameters.Name = "searchParameters";
            this.searchParameters.Size = new System.Drawing.Size(550, 164);
            this.searchParameters.TabIndex = 4;
            this.searchParameters.TabStop = false;
            this.searchParameters.Text = "Search parameters";
            // 
            // search
            // 
            this.search.Image = ((System.Drawing.Image)(resources.GetObject("search.Image")));
            this.search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.search.Location = new System.Drawing.Point(374, 71);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(162, 23);
            this.search.TabIndex = 12;
            this.search.Text = "Find";
            this.search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // studentName
            // 
            this.studentName.Enabled = false;
            this.studentName.Location = new System.Drawing.Point(15, 56);
            this.studentName.Name = "studentName";
            this.studentName.Size = new System.Drawing.Size(348, 20);
            this.studentName.TabIndex = 2;
            // 
            // studentNameText
            // 
            this.studentNameText.AutoSize = true;
            this.studentNameText.Enabled = false;
            this.studentNameText.Location = new System.Drawing.Point(12, 40);
            this.studentNameText.Name = "studentNameText";
            this.studentNameText.Size = new System.Drawing.Size(127, 13);
            this.studentNameText.TabIndex = 1;
            this.studentNameText.Text = "Enter the student\'s name:";
            // 
            // studentNameSearch
            // 
            this.studentNameSearch.AutoSize = true;
            this.studentNameSearch.Location = new System.Drawing.Point(15, 20);
            this.studentNameSearch.Name = "studentNameSearch";
            this.studentNameSearch.Size = new System.Drawing.Size(148, 17);
            this.studentNameSearch.TabIndex = 0;
            this.studentNameSearch.Text = "Search by student\'s name";
            this.studentNameSearch.UseVisualStyleBackColor = true;
            this.studentNameSearch.CheckedChanged += new System.EventHandler(this.studentNameSearch_CheckedChanged);
            // 
            // universitySearch
            // 
            this.universitySearch.AutoSize = true;
            this.universitySearch.Location = new System.Drawing.Point(15, 91);
            this.universitySearch.Name = "universitySearch";
            this.universitySearch.Size = new System.Drawing.Size(121, 17);
            this.universitySearch.TabIndex = 13;
            this.universitySearch.Text = "Search by university";
            this.universitySearch.UseVisualStyleBackColor = true;
            this.universitySearch.CheckedChanged += new System.EventHandler(this.universitySearch_CheckedChanged);
            // 
            // universityChoiceText
            // 
            this.universityChoiceText.AutoSize = true;
            this.universityChoiceText.Enabled = false;
            this.universityChoiceText.Location = new System.Drawing.Point(12, 111);
            this.universityChoiceText.Name = "universityChoiceText";
            this.universityChoiceText.Size = new System.Drawing.Size(111, 13);
            this.universityChoiceText.TabIndex = 14;
            this.universityChoiceText.Text = "Choose the university:";
            // 
            // universityChoice
            // 
            this.universityChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.universityChoice.Enabled = false;
            this.universityChoice.FormattingEnabled = true;
            this.universityChoice.Location = new System.Drawing.Point(15, 127);
            this.universityChoice.Name = "universityChoice";
            this.universityChoice.Size = new System.Drawing.Size(348, 21);
            this.universityChoice.TabIndex = 15;
            // 
            // StudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 425);
            this.Controls.Add(this.searchParameters);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.studentsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Students";
            this.Load += new System.EventHandler(this.StudentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentsView)).EndInit();
            this.searchParameters.ResumeLayout(false);
            this.searchParameters.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView studentsView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox searchParameters;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox studentName;
        private System.Windows.Forms.Label studentNameText;
        private System.Windows.Forms.CheckBox studentNameSearch;
        private System.Windows.Forms.ComboBox universityChoice;
        private System.Windows.Forms.Label universityChoiceText;
        private System.Windows.Forms.CheckBox universitySearch;
    }
}