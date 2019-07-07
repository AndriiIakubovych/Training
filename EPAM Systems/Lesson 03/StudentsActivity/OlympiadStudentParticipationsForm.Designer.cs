namespace StudentsActivity
{
    partial class OlympiadStudentParticipationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OlympiadStudentParticipationsForm));
            this.olympiadStudentParticipationsView = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.searchParameters = new System.Windows.Forms.GroupBox();
            this.studentNameSearch = new System.Windows.Forms.CheckBox();
            this.studentNameText = new System.Windows.Forms.Label();
            this.studentName = new System.Windows.Forms.TextBox();
            this.olympiadNameSearch = new System.Windows.Forms.CheckBox();
            this.olympiadNameChoiceText = new System.Windows.Forms.Label();
            this.olympiadNameChoice = new System.Windows.Forms.ComboBox();
            this.participationDateSearch = new System.Windows.Forms.CheckBox();
            this.participationDateText = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.separator = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.resultsSearch = new System.Windows.Forms.CheckBox();
            this.resultsChoiceText = new System.Windows.Forms.Label();
            this.resultsChoice = new System.Windows.Forms.ComboBox();
            this.search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.olympiadStudentParticipationsView)).BeginInit();
            this.searchParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // olympiadStudentParticipationsView
            // 
            this.olympiadStudentParticipationsView.AllowUserToAddRows = false;
            this.olympiadStudentParticipationsView.AllowUserToDeleteRows = false;
            this.olympiadStudentParticipationsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.olympiadStudentParticipationsView.Location = new System.Drawing.Point(12, 12);
            this.olympiadStudentParticipationsView.MultiSelect = false;
            this.olympiadStudentParticipationsView.Name = "olympiadStudentParticipationsView";
            this.olympiadStudentParticipationsView.ReadOnly = true;
            this.olympiadStudentParticipationsView.Size = new System.Drawing.Size(460, 172);
            this.olympiadStudentParticipationsView.TabIndex = 0;
            // 
            // add
            // 
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("add.Image")));
            this.add.Location = new System.Drawing.Point(12, 199);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(146, 23);
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
            this.edit.Location = new System.Drawing.Point(169, 199);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(146, 23);
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
            this.delete.Location = new System.Drawing.Point(327, 199);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(146, 23);
            this.delete.TabIndex = 3;
            this.delete.Text = "Delete";
            this.delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // searchParameters
            // 
            this.searchParameters.Controls.Add(this.studentNameSearch);
            this.searchParameters.Controls.Add(this.studentNameText);
            this.searchParameters.Controls.Add(this.studentName);
            this.searchParameters.Controls.Add(this.olympiadNameSearch);
            this.searchParameters.Controls.Add(this.olympiadNameChoiceText);
            this.searchParameters.Controls.Add(this.olympiadNameChoice);
            this.searchParameters.Controls.Add(this.participationDateSearch);
            this.searchParameters.Controls.Add(this.participationDateText);
            this.searchParameters.Controls.Add(this.startDate);
            this.searchParameters.Controls.Add(this.separator);
            this.searchParameters.Controls.Add(this.endDate);
            this.searchParameters.Controls.Add(this.resultsSearch);
            this.searchParameters.Controls.Add(this.resultsChoiceText);
            this.searchParameters.Controls.Add(this.resultsChoice);
            this.searchParameters.Controls.Add(this.search);
            this.searchParameters.Location = new System.Drawing.Point(12, 232);
            this.searchParameters.Name = "searchParameters";
            this.searchParameters.Size = new System.Drawing.Size(460, 200);
            this.searchParameters.TabIndex = 4;
            this.searchParameters.TabStop = false;
            this.searchParameters.Text = "Search parameters";
            // 
            // studentNameSearch
            // 
            this.studentNameSearch.AutoSize = true;
            this.studentNameSearch.Location = new System.Drawing.Point(15, 19);
            this.studentNameSearch.Name = "studentNameSearch";
            this.studentNameSearch.Size = new System.Drawing.Size(148, 17);
            this.studentNameSearch.TabIndex = 5;
            this.studentNameSearch.Text = "Search by student\'s name";
            this.studentNameSearch.UseVisualStyleBackColor = true;
            this.studentNameSearch.CheckedChanged += new System.EventHandler(this.studentNameSearch_CheckedChanged);
            // 
            // studentNameText
            // 
            this.studentNameText.AutoSize = true;
            this.studentNameText.Enabled = false;
            this.studentNameText.Location = new System.Drawing.Point(12, 39);
            this.studentNameText.Name = "studentNameText";
            this.studentNameText.Size = new System.Drawing.Size(127, 13);
            this.studentNameText.TabIndex = 6;
            this.studentNameText.Text = "Enter the student\'s name:";
            // 
            // studentName
            // 
            this.studentName.Enabled = false;
            this.studentName.Location = new System.Drawing.Point(15, 55);
            this.studentName.Name = "studentName";
            this.studentName.Size = new System.Drawing.Size(230, 20);
            this.studentName.TabIndex = 7;
            // 
            // olympiadNameSearch
            // 
            this.olympiadNameSearch.AutoSize = true;
            this.olympiadNameSearch.Location = new System.Drawing.Point(15, 90);
            this.olympiadNameSearch.Name = "olympiadNameSearch";
            this.olympiadNameSearch.Size = new System.Drawing.Size(156, 17);
            this.olympiadNameSearch.TabIndex = 8;
            this.olympiadNameSearch.Text = "Search by Olympiad\'s name";
            this.olympiadNameSearch.UseVisualStyleBackColor = true;
            this.olympiadNameSearch.CheckedChanged += new System.EventHandler(this.olympiadNameSearch_CheckedChanged);
            // 
            // olympiadNameChoiceText
            // 
            this.olympiadNameChoiceText.AutoSize = true;
            this.olympiadNameChoiceText.Enabled = false;
            this.olympiadNameChoiceText.Location = new System.Drawing.Point(12, 110);
            this.olympiadNameChoiceText.Name = "olympiadNameChoiceText";
            this.olympiadNameChoiceText.Size = new System.Drawing.Size(146, 13);
            this.olympiadNameChoiceText.TabIndex = 9;
            this.olympiadNameChoiceText.Text = "Choose the Olympiad\'s name:";
            // 
            // olympiadNameChoice
            // 
            this.olympiadNameChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.olympiadNameChoice.Enabled = false;
            this.olympiadNameChoice.FormattingEnabled = true;
            this.olympiadNameChoice.Location = new System.Drawing.Point(15, 126);
            this.olympiadNameChoice.Name = "olympiadNameChoice";
            this.olympiadNameChoice.Size = new System.Drawing.Size(230, 21);
            this.olympiadNameChoice.TabIndex = 19;
            // 
            // participationDateSearch
            // 
            this.participationDateSearch.AutoSize = true;
            this.participationDateSearch.Location = new System.Drawing.Point(259, 19);
            this.participationDateSearch.Name = "participationDateSearch";
            this.participationDateSearch.Size = new System.Drawing.Size(158, 17);
            this.participationDateSearch.TabIndex = 11;
            this.participationDateSearch.Text = "Search by participation date";
            this.participationDateSearch.UseVisualStyleBackColor = true;
            this.participationDateSearch.CheckedChanged += new System.EventHandler(this.participationDateSearch_CheckedChanged);
            // 
            // participationDateText
            // 
            this.participationDateText.AutoSize = true;
            this.participationDateText.Enabled = false;
            this.participationDateText.Location = new System.Drawing.Point(256, 39);
            this.participationDateText.Name = "participationDateText";
            this.participationDateText.Size = new System.Drawing.Size(184, 13);
            this.participationDateText.TabIndex = 12;
            this.participationDateText.Text = "Enter the start date and the end date:";
            // 
            // startDate
            // 
            this.startDate.Enabled = false;
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(259, 55);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(85, 20);
            this.startDate.TabIndex = 13;
            // 
            // separator
            // 
            this.separator.AutoSize = true;
            this.separator.Enabled = false;
            this.separator.Location = new System.Drawing.Point(347, 58);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(10, 13);
            this.separator.TabIndex = 14;
            this.separator.Text = "-";
            // 
            // endDate
            // 
            this.endDate.Enabled = false;
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(360, 55);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(85, 20);
            this.endDate.TabIndex = 15;
            // 
            // resultsSearch
            // 
            this.resultsSearch.AutoSize = true;
            this.resultsSearch.Location = new System.Drawing.Point(259, 90);
            this.resultsSearch.Name = "resultsSearch";
            this.resultsSearch.Size = new System.Drawing.Size(179, 17);
            this.resultsSearch.TabIndex = 16;
            this.resultsSearch.Text = "Search by results of participation";
            this.resultsSearch.UseVisualStyleBackColor = true;
            this.resultsSearch.CheckedChanged += new System.EventHandler(this.resultsSearch_CheckedChanged);
            // 
            // resultsChoiceText
            // 
            this.resultsChoiceText.AutoSize = true;
            this.resultsChoiceText.Enabled = false;
            this.resultsChoiceText.Location = new System.Drawing.Point(256, 110);
            this.resultsChoiceText.Name = "resultsChoiceText";
            this.resultsChoiceText.Size = new System.Drawing.Size(151, 13);
            this.resultsChoiceText.TabIndex = 17;
            this.resultsChoiceText.Text = "Choose results of participation:";
            // 
            // resultsChoice
            // 
            this.resultsChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resultsChoice.Enabled = false;
            this.resultsChoice.FormattingEnabled = true;
            this.resultsChoice.Items.AddRange(new object[] { "Participant", "Awardee", "Winner" });
            this.resultsChoice.Location = new System.Drawing.Point(259, 126);
            this.resultsChoice.Name = "resultsChoice";
            this.resultsChoice.Size = new System.Drawing.Size(186, 21);
            this.resultsChoice.TabIndex = 18;
            // 
            // search
            // 
            this.search.Image = ((System.Drawing.Image)(resources.GetObject("search.Image")));
            this.search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.search.Location = new System.Drawing.Point(15, 161);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(431, 23);
            this.search.TabIndex = 13;
            this.search.Text = "Find";
            this.search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // OlympiadStudentParticipationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 444);
            this.Controls.Add(this.searchParameters);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.olympiadStudentParticipationsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OlympiadStudentParticipationsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student participations in Olympiad";
            this.Load += new System.EventHandler(this.OlympiadStudentParticipationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olympiadStudentParticipationsView)).EndInit();
            this.searchParameters.ResumeLayout(false);
            this.searchParameters.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView olympiadStudentParticipationsView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox searchParameters;
        private System.Windows.Forms.CheckBox studentNameSearch;
        private System.Windows.Forms.Label studentNameText;
        private System.Windows.Forms.TextBox studentName;
        private System.Windows.Forms.CheckBox olympiadNameSearch;
        private System.Windows.Forms.Label olympiadNameChoiceText;
        private System.Windows.Forms.ComboBox olympiadNameChoice;
        private System.Windows.Forms.CheckBox participationDateSearch;
        private System.Windows.Forms.Label participationDateText;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.CheckBox resultsSearch;
        private System.Windows.Forms.Label resultsChoiceText;
        private System.Windows.Forms.ComboBox resultsChoice;
        private System.Windows.Forms.Button search;
    }
}