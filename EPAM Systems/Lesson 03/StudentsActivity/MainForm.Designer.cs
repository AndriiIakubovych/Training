namespace StudentsActivity
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.directoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.olympiadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.competitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsParticipationsInOlympiadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsParticipationsInCompetitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripStudents = new System.Windows.Forms.ToolStripButton();
            this.toolStripOlympiads = new System.Windows.Forms.ToolStripButton();
            this.toolStripCompetitions = new System.Windows.Forms.ToolStripButton();
            this.toolStripFirstSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOlympiadStudentParticipation = new System.Windows.Forms.ToolStripButton();
            this.toolStripCompetitionStudentParticipation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSecondSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripExit = new System.Windows.Forms.ToolStripButton();
            this.olympiadChoiceText = new System.Windows.Forms.Label();
            this.olympiadChoice = new System.Windows.Forms.ComboBox();
            this.olympiadStudentsDataText = new System.Windows.Forms.Label();
            this.olympiadStudentsView = new System.Windows.Forms.DataGridView();
            this.competitionChoiceText = new System.Windows.Forms.Label();
            this.competitionChoice = new System.Windows.Forms.ComboBox();
            this.competitionStudentsDataText = new System.Windows.Forms.Label();
            this.competitionStudentsView = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olympiadStudentsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitionStudentsView)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoriesToolStripMenuItem,
            this.operationalInformationToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(580, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Main menu";
            // 
            // directoriesToolStripMenuItem
            // 
            this.directoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem,
            this.olympiadsToolStripMenuItem,
            this.competitionsToolStripMenuItem,
            this.toolStripMenuItemSeparator,
            this.exitToolStripMenuItem});
            this.directoriesToolStripMenuItem.Name = "directoriesToolStripMenuItem";
            this.directoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.directoriesToolStripMenuItem.Text = "Directories";
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.studentsToolStripMenuItem.Text = "Students";
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // olympiadsToolStripMenuItem
            // 
            this.olympiadsToolStripMenuItem.Name = "olympiadsToolStripMenuItem";
            this.olympiadsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.olympiadsToolStripMenuItem.Text = "Olympiads";
            this.olympiadsToolStripMenuItem.Click += new System.EventHandler(this.olympiadsToolStripMenuItem_Click);
            // 
            // competitionsToolStripMenuItem
            // 
            this.competitionsToolStripMenuItem.Name = "competitionsToolStripMenuItem";
            this.competitionsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.competitionsToolStripMenuItem.Text = "Competitions";
            this.competitionsToolStripMenuItem.Click += new System.EventHandler(this.competitionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSeparator
            // 
            this.toolStripMenuItemSeparator.Name = "toolStripMenuItemSeparator";
            this.toolStripMenuItemSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // operationalInformationToolStripMenuItem
            // 
            this.operationalInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsParticipationsInOlympiadsToolStripMenuItem,
            this.studentsParticipationsInCompetitionsToolStripMenuItem});
            this.operationalInformationToolStripMenuItem.Name = "operationalInformationToolStripMenuItem";
            this.operationalInformationToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.operationalInformationToolStripMenuItem.Text = "Operational information";
            // 
            // studentsParticipationsInOlympiadsToolStripMenuItem
            // 
            this.studentsParticipationsInOlympiadsToolStripMenuItem.Name = "studentsParticipationsInOlympiadsToolStripMenuItem";
            this.studentsParticipationsInOlympiadsToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.studentsParticipationsInOlympiadsToolStripMenuItem.Text = "Student participations in Olympiad";
            this.studentsParticipationsInOlympiadsToolStripMenuItem.Click += new System.EventHandler(this.studentsParticipationsInOlympiadsToolStripMenuItem_Click);
            // 
            // studentsParticipationsInCompetitionsToolStripMenuItem
            // 
            this.studentsParticipationsInCompetitionsToolStripMenuItem.Name = "studentsParticipationsInCompetitionsToolStripMenuItem";
            this.studentsParticipationsInCompetitionsToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.studentsParticipationsInCompetitionsToolStripMenuItem.Text = "Student participations in competition";
            this.studentsParticipationsInCompetitionsToolStripMenuItem.Click += new System.EventHandler(this.studentsParticipationsInCompetitionsToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStudents,
            this.toolStripOlympiads,
            this.toolStripCompetitions,
            this.toolStripFirstSeparator,
            this.toolStripOlympiadStudentParticipation,
            this.toolStripCompetitionStudentParticipation,
            this.toolStripSecondSeparator,
            this.toolStripExit});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(580, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "Tool bar";
            // 
            // toolStripStudents
            // 
            this.toolStripStudents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStudents.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStudents.Image")));
            this.toolStripStudents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStudents.Name = "toolStripStudents";
            this.toolStripStudents.Size = new System.Drawing.Size(23, 22);
            this.toolStripStudents.Text = "Students";
            this.toolStripStudents.Click += new System.EventHandler(this.toolStripStudents_Click);
            // 
            // toolStripOlympiads
            // 
            this.toolStripOlympiads.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOlympiads.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOlympiads.Image")));
            this.toolStripOlympiads.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOlympiads.Name = "toolStripOlympiads";
            this.toolStripOlympiads.Size = new System.Drawing.Size(23, 22);
            this.toolStripOlympiads.Text = "Olympiads";
            this.toolStripOlympiads.Click += new System.EventHandler(this.toolStripOlympiads_Click);
            // 
            // toolStripCompetitions
            // 
            this.toolStripCompetitions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCompetitions.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCompetitions.Image")));
            this.toolStripCompetitions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCompetitions.Name = "toolStripCompetitions";
            this.toolStripCompetitions.Size = new System.Drawing.Size(23, 22);
            this.toolStripCompetitions.Text = "Competitions";
            this.toolStripCompetitions.Click += new System.EventHandler(this.toolStripCompetitions_Click);
            // 
            // toolStripFirstSeparator
            // 
            this.toolStripFirstSeparator.Name = "toolStripFirstSeparator";
            this.toolStripFirstSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripOlympiadStudentParticipation
            // 
            this.toolStripOlympiadStudentParticipation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOlympiadStudentParticipation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOlympiadStudentParticipation.Image")));
            this.toolStripOlympiadStudentParticipation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOlympiadStudentParticipation.Name = "toolStripOlympiadStudentParticipation";
            this.toolStripOlympiadStudentParticipation.Size = new System.Drawing.Size(23, 22);
            this.toolStripOlympiadStudentParticipation.Text = "Student participations in Olympiad";
            this.toolStripOlympiadStudentParticipation.Click += new System.EventHandler(this.toolStripOlympiadStudentParticipation_Click);
            // 
            // toolStripCompetitionStudentParticipation
            // 
            this.toolStripCompetitionStudentParticipation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCompetitionStudentParticipation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCompetitionStudentParticipation.Image")));
            this.toolStripCompetitionStudentParticipation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCompetitionStudentParticipation.Name = "toolStripCompetitionStudentParticipation";
            this.toolStripCompetitionStudentParticipation.Size = new System.Drawing.Size(23, 22);
            this.toolStripCompetitionStudentParticipation.Text = "Student participations in competition";
            this.toolStripCompetitionStudentParticipation.Click += new System.EventHandler(this.toolStripCompetitionStudentParticipation_Click);
            // 
            // toolStripSecondSeparator
            // 
            this.toolStripSecondSeparator.Name = "toolStripSecondSeparator";
            this.toolStripSecondSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripExit
            // 
            this.toolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExit.Image")));
            this.toolStripExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Size = new System.Drawing.Size(23, 22);
            this.toolStripExit.Text = "Exit";
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // olympiadChoiceText
            // 
            this.olympiadChoiceText.AutoSize = true;
            this.olympiadChoiceText.Location = new System.Drawing.Point(12, 58);
            this.olympiadChoiceText.Name = "olympiadChoiceText";
            this.olympiadChoiceText.Size = new System.Drawing.Size(53, 13);
            this.olympiadChoiceText.TabIndex = 3;
            this.olympiadChoiceText.Text = "Olympiad:";
            // 
            // olympiadChoice
            // 
            this.olympiadChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.olympiadChoice.FormattingEnabled = true;
            this.olympiadChoice.Location = new System.Drawing.Point(15, 74);
            this.olympiadChoice.Name = "olympiadChoice";
            this.olympiadChoice.Size = new System.Drawing.Size(238, 21);
            this.olympiadChoice.TabIndex = 4;
            this.olympiadChoice.SelectedIndexChanged += new System.EventHandler(this.olympiadChoice_SelectedIndexChanged);
            // 
            // olympiadStudentsDataText
            // 
            this.olympiadStudentsDataText.AutoSize = true;
            this.olympiadStudentsDataText.Location = new System.Drawing.Point(12, 108);
            this.olympiadStudentsDataText.Name = "olympiadStudentsDataText";
            this.olympiadStudentsDataText.Size = new System.Drawing.Size(141, 13);
            this.olympiadStudentsDataText.TabIndex = 5;
            this.olympiadStudentsDataText.Text = "Participants of the Olympiad:";
            // 
            // olympiadStudentsView
            // 
            this.olympiadStudentsView.AllowUserToAddRows = false;
            this.olympiadStudentsView.AllowUserToDeleteRows = false;
            this.olympiadStudentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.olympiadStudentsView.Location = new System.Drawing.Point(15, 124);
            this.olympiadStudentsView.MultiSelect = false;
            this.olympiadStudentsView.Name = "olympiadStudentsView";
            this.olympiadStudentsView.ReadOnly = true;
            this.olympiadStudentsView.Size = new System.Drawing.Size(550, 150);
            this.olympiadStudentsView.TabIndex = 6;
            // 
            // competitionChoiceText
            // 
            this.competitionChoiceText.AutoSize = true;
            this.competitionChoiceText.Location = new System.Drawing.Point(12, 286);
            this.competitionChoiceText.Name = "competitionChoiceText";
            this.competitionChoiceText.Size = new System.Drawing.Size(65, 13);
            this.competitionChoiceText.TabIndex = 7;
            this.competitionChoiceText.Text = "Competition:";
            // 
            // competitionChoice
            // 
            this.competitionChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitionChoice.FormattingEnabled = true;
            this.competitionChoice.Location = new System.Drawing.Point(15, 302);
            this.competitionChoice.Name = "competitionChoice";
            this.competitionChoice.Size = new System.Drawing.Size(238, 21);
            this.competitionChoice.TabIndex = 8;
            this.competitionChoice.SelectedIndexChanged += new System.EventHandler(this.competitionChoice_SelectedIndexChanged);
            // 
            // competitionStudentsDataText
            // 
            this.competitionStudentsDataText.AutoSize = true;
            this.competitionStudentsDataText.Location = new System.Drawing.Point(12, 336);
            this.competitionStudentsDataText.Name = "competitionStudentsDataText";
            this.competitionStudentsDataText.Size = new System.Drawing.Size(152, 13);
            this.competitionStudentsDataText.TabIndex = 9;
            this.competitionStudentsDataText.Text = "Participants of the competition:";
            // 
            // competitionStudentsView
            // 
            this.competitionStudentsView.AllowUserToAddRows = false;
            this.competitionStudentsView.AllowUserToDeleteRows = false;
            this.competitionStudentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.competitionStudentsView.Location = new System.Drawing.Point(15, 352);
            this.competitionStudentsView.MultiSelect = false;
            this.competitionStudentsView.Name = "competitionStudentsView";
            this.competitionStudentsView.ReadOnly = true;
            this.competitionStudentsView.Size = new System.Drawing.Size(550, 150);
            this.competitionStudentsView.TabIndex = 10;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 518);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(580, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "Status bar";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 540);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.competitionStudentsView);
            this.Controls.Add(this.competitionStudentsDataText);
            this.Controls.Add(this.competitionChoice);
            this.Controls.Add(this.competitionChoiceText);
            this.Controls.Add(this.olympiadStudentsView);
            this.Controls.Add(this.olympiadStudentsDataText);
            this.Controls.Add(this.olympiadChoice);
            this.Controls.Add(this.olympiadChoiceText);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration of student\'s participation in Olympiads and competitions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olympiadStudentsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitionStudentsView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem directoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem olympiadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem competitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationalInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsParticipationsInOlympiadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsParticipationsInCompetitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripStudents;
        private System.Windows.Forms.ToolStripButton toolStripOlympiads;
        private System.Windows.Forms.ToolStripButton toolStripCompetitions;
        private System.Windows.Forms.ToolStripSeparator toolStripFirstSeparator;
        private System.Windows.Forms.ToolStripButton toolStripOlympiadStudentParticipation;
        private System.Windows.Forms.ToolStripButton toolStripCompetitionStudentParticipation;
        private System.Windows.Forms.ToolStripSeparator toolStripSecondSeparator;
        private System.Windows.Forms.ToolStripButton toolStripExit;
        private System.Windows.Forms.Label olympiadChoiceText;
        private System.Windows.Forms.ComboBox olympiadChoice;
        private System.Windows.Forms.Label olympiadStudentsDataText;
        private System.Windows.Forms.DataGridView olympiadStudentsView;
        private System.Windows.Forms.Label competitionChoiceText;
        private System.Windows.Forms.ComboBox competitionChoice;
        private System.Windows.Forms.Label competitionStudentsDataText;
        private System.Windows.Forms.DataGridView competitionStudentsView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}