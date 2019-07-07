namespace EducationalInstitution
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditoriumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialtiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsSchedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachersSchedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curriculumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bellsSchedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripStudents = new System.Windows.Forms.ToolStripButton();
            this.toolStripTeachers = new System.Windows.Forms.ToolStripButton();
            this.toolStripAuditoriums = new System.Windows.Forms.ToolStripButton();
            this.toolStripSubjects = new System.Windows.Forms.ToolStripButton();
            this.toolStripGroups = new System.Windows.Forms.ToolStripButton();
            this.toolStripSpecialties = new System.Windows.Forms.ToolStripButton();
            this.toolStripGroupsSchedules = new System.Windows.Forms.ToolStripButton();
            this.toolStripTeachersSchedules = new System.Windows.Forms.ToolStripButton();
            this.toolStripCurriculums = new System.Windows.Forms.ToolStripButton();
            this.toolStripBellsSchedules = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.mainMenu.MdiWindowListItem = this.windowToolStripMenuItem;
            this.mainMenu.Name = "mainMenu";
            // 
            // informationToolStripMenuItem
            // 
            resources.ApplyResources(this.informationToolStripMenuItem, "informationToolStripMenuItem");
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem,
            this.teachersToolStripMenuItem,
            this.auditoriumsToolStripMenuItem,
            this.subjectsToolStripMenuItem,
            this.groupsToolStripMenuItem,
            this.specialtiesToolStripMenuItem,
            this.groupsSchedulesToolStripMenuItem,
            this.teachersSchedulesToolStripMenuItem,
            this.curriculumsToolStripMenuItem,
            this.bellsSchedulesToolStripMenuItem,
            this.separatorToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            // 
            // studentsToolStripMenuItem
            // 
            resources.ApplyResources(this.studentsToolStripMenuItem, "studentsToolStripMenuItem");
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // teachersToolStripMenuItem
            // 
            resources.ApplyResources(this.teachersToolStripMenuItem, "teachersToolStripMenuItem");
            this.teachersToolStripMenuItem.Name = "teachersToolStripMenuItem";
            this.teachersToolStripMenuItem.Click += new System.EventHandler(this.teachersToolStripMenuItem_Click);
            // 
            // auditoriumsToolStripMenuItem
            // 
            resources.ApplyResources(this.auditoriumsToolStripMenuItem, "auditoriumsToolStripMenuItem");
            this.auditoriumsToolStripMenuItem.Name = "auditoriumsToolStripMenuItem";
            this.auditoriumsToolStripMenuItem.Click += new System.EventHandler(this.auditoriumsToolStripMenuItem_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            resources.ApplyResources(this.subjectsToolStripMenuItem, "subjectsToolStripMenuItem");
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Click += new System.EventHandler(this.subjectsToolStripMenuItem_Click);
            // 
            // groupsToolStripMenuItem
            // 
            resources.ApplyResources(this.groupsToolStripMenuItem, "groupsToolStripMenuItem");
            this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
            this.groupsToolStripMenuItem.Click += new System.EventHandler(this.groupsToolStripMenuItem_Click);
            // 
            // specialtiesToolStripMenuItem
            // 
            resources.ApplyResources(this.specialtiesToolStripMenuItem, "specialtiesToolStripMenuItem");
            this.specialtiesToolStripMenuItem.Name = "specialtiesToolStripMenuItem";
            this.specialtiesToolStripMenuItem.Click += new System.EventHandler(this.specialtiesToolStripMenuItem_Click);
            // 
            // groupsSchedulesToolStripMenuItem
            // 
            resources.ApplyResources(this.groupsSchedulesToolStripMenuItem, "groupsSchedulesToolStripMenuItem");
            this.groupsSchedulesToolStripMenuItem.Name = "groupsSchedulesToolStripMenuItem";
            this.groupsSchedulesToolStripMenuItem.Click += new System.EventHandler(this.groupsSchedulesToolStripMenuItem_Click);
            // 
            // teachersSchedulesToolStripMenuItem
            // 
            resources.ApplyResources(this.teachersSchedulesToolStripMenuItem, "teachersSchedulesToolStripMenuItem");
            this.teachersSchedulesToolStripMenuItem.Name = "teachersSchedulesToolStripMenuItem";
            this.teachersSchedulesToolStripMenuItem.Click += new System.EventHandler(this.teachersSchedulesToolStripMenuItem_Click);
            // 
            // curriculumsToolStripMenuItem
            // 
            resources.ApplyResources(this.curriculumsToolStripMenuItem, "curriculumsToolStripMenuItem");
            this.curriculumsToolStripMenuItem.Name = "curriculumsToolStripMenuItem";
            this.curriculumsToolStripMenuItem.Click += new System.EventHandler(this.curriculumsToolStripMenuItem_Click);
            // 
            // bellsSchedulesToolStripMenuItem
            // 
            resources.ApplyResources(this.bellsSchedulesToolStripMenuItem, "bellsSchedulesToolStripMenuItem");
            this.bellsSchedulesToolStripMenuItem.Name = "bellsSchedulesToolStripMenuItem";
            this.bellsSchedulesToolStripMenuItem.Click += new System.EventHandler(this.bellsSchedulesToolStripMenuItem_Click);
            // 
            // separatorToolStripMenuItem
            // 
            resources.ApplyResources(this.separatorToolStripMenuItem, "separatorToolStripMenuItem");
            this.separatorToolStripMenuItem.Name = "separatorToolStripMenuItem";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            resources.ApplyResources(this.windowToolStripMenuItem, "windowToolStripMenuItem");
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.DropDownOpening += new System.EventHandler(this.windowToolStripMenuItem_DropDownOpening);
            // 
            // cascadeToolStripMenuItem
            // 
            resources.ApplyResources(this.cascadeToolStripMenuItem, "cascadeToolStripMenuItem");
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripStudents, this.toolStripTeachers, this.toolStripAuditoriums, this.toolStripSubjects, this.toolStripGroups, this.toolStripSpecialties, this.toolStripGroupsSchedules, this.toolStripTeachersSchedules, this.toolStripCurriculums, this.toolStripBellsSchedules, this.toolStripSeparator, this.toolStripExit });
            this.toolStrip.Name = "toolStrip";
            // 
            // toolStripStudents
            // 
            resources.ApplyResources(this.toolStripStudents, "toolStripStudents");
            this.toolStripStudents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStudents.Name = "toolStripStudents";
            this.toolStripStudents.Click += new System.EventHandler(this.toolStripStudents_Click);
            // 
            // toolStripTeachers
            // 
            resources.ApplyResources(this.toolStripTeachers, "toolStripTeachers");
            this.toolStripTeachers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTeachers.Name = "toolStripTeachers";
            this.toolStripTeachers.Click += new System.EventHandler(this.toolStripTeachers_Click);
            // 
            // toolStripAuditoriums
            // 
            resources.ApplyResources(this.toolStripAuditoriums, "toolStripAuditoriums");
            this.toolStripAuditoriums.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAuditoriums.Name = "toolStripAuditoriums";
            this.toolStripAuditoriums.Click += new System.EventHandler(this.toolStripAuditoriums_Click);
            // 
            // toolStripSubjects
            // 
            resources.ApplyResources(this.toolStripSubjects, "toolStripSubjects");
            this.toolStripSubjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSubjects.Name = "toolStripSubjects";
            this.toolStripSubjects.Click += new System.EventHandler(this.toolStripSubjects_Click);
            // 
            // toolStripGroups
            // 
            resources.ApplyResources(this.toolStripGroups, "toolStripGroups");
            this.toolStripGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripGroups.Name = "toolStripGroups";
            this.toolStripGroups.Click += new System.EventHandler(this.toolStripGroups_Click);
            // 
            // toolStripSpecialties
            // 
            resources.ApplyResources(this.toolStripSpecialties, "toolStripSpecialties");
            this.toolStripSpecialties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSpecialties.Name = "toolStripSpecialties";
            this.toolStripSpecialties.Click += new System.EventHandler(this.toolStripSpecialties_Click);
            // 
            // toolStripGroupsSchedules
            // 
            resources.ApplyResources(this.toolStripGroupsSchedules, "toolStripGroupsSchedules");
            this.toolStripGroupsSchedules.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripGroupsSchedules.Name = "toolStripGroupsSchedules";
            this.toolStripGroupsSchedules.Click += new System.EventHandler(this.toolStripGroupsSchedules_Click);
            // 
            // toolStripTeachersSchedules
            // 
            resources.ApplyResources(this.toolStripTeachersSchedules, "toolStripTeachersSchedules");
            this.toolStripTeachersSchedules.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTeachersSchedules.Name = "toolStripTeachersSchedules";
            this.toolStripTeachersSchedules.Click += new System.EventHandler(this.toolStripTeachersSchedules_Click);
            // 
            // toolStripCurriculums
            // 
            resources.ApplyResources(this.toolStripCurriculums, "toolStripCurriculums");
            this.toolStripCurriculums.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCurriculums.Name = "toolStripCurriculums";
            this.toolStripCurriculums.Click += new System.EventHandler(this.toolStripCurriculums_Click);
            // 
            // toolStripBellsSchedules
            // 
            resources.ApplyResources(this.toolStripBellsSchedules, "toolStripBellsSchedules");
            this.toolStripBellsSchedules.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBellsSchedules.Name = "toolStripBellsSchedules";
            this.toolStripBellsSchedules.Click += new System.EventHandler(this.toolStripBellsSchedules_Click);
            // 
            // toolStripSeparator
            // 
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            this.toolStripSeparator.Name = "toolStripSeparator";
            // 
            // toolStripExit
            // 
            resources.ApplyResources(this.toolStripExit, "toolStripExit");
            this.toolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabel });
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditoriumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupsSchedulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachersSchedulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curriculumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bellsSchedulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator separatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialtiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripStudents;
        private System.Windows.Forms.ToolStripButton toolStripTeachers;
        private System.Windows.Forms.ToolStripButton toolStripAuditoriums;
        private System.Windows.Forms.ToolStripButton toolStripSubjects;
        private System.Windows.Forms.ToolStripButton toolStripGroups;
        private System.Windows.Forms.ToolStripButton toolStripSpecialties;
        private System.Windows.Forms.ToolStripButton toolStripGroupsSchedules;
        private System.Windows.Forms.ToolStripButton toolStripTeachersSchedules;
        private System.Windows.Forms.ToolStripButton toolStripCurriculums;
        private System.Windows.Forms.ToolStripButton toolStripBellsSchedules;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolStripExit;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}