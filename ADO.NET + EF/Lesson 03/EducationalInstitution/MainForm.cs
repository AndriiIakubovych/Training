using System;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;

namespace EducationalInstitution
{
    public partial class MainForm : Form
    {
        private DbProviderFactory factory;
        private DbConnection connection;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                factory = DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["provider"]);
                connection = factory.CreateConnection();
                connection.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
                connection.OpenAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            StudentsForm studentsForm = new StudentsForm(this, connection, da) { MdiParent = this };
            studentsForm.Show();
            studentsToolStripMenuItem.Enabled = toolStripStudents.Enabled = false;
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            TeachersForm teachersForm = new TeachersForm(this, connection, da) { MdiParent = this };
            teachersForm.Show();
            teachersToolStripMenuItem.Enabled = toolStripTeachers.Enabled = false;
        }

        private void auditoriumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            AuditoriumsForm auditoriumsForm = new AuditoriumsForm(this, connection, da) { MdiParent = this };
            auditoriumsForm.Show();
            auditoriumsToolStripMenuItem.Enabled = toolStripAuditoriums.Enabled = false;
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            SubjectsForm subjectsForm = new SubjectsForm(this, connection, da) { MdiParent = this };
            subjectsForm.Show();
            subjectsToolStripMenuItem.Enabled = toolStripSubjects.Enabled = false;
        }

        private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            GroupsForm groupsForm = new GroupsForm(this, connection, da) { MdiParent = this };
            groupsForm.Show();
            groupsToolStripMenuItem.Enabled = toolStripGroups.Enabled = false;
        }

        private void specialtiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            SpecialtiesForm specialtiesForm = new SpecialtiesForm(this, connection, da) { MdiParent = this };
            specialtiesForm.Show();
            specialtiesToolStripMenuItem.Enabled = toolStripSpecialties.Enabled = false;
        }

        private void groupsSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            GroupsSchedulesForm groupsSchedulesForm = new GroupsSchedulesForm(this, connection, da) { MdiParent = this };
            groupsSchedulesForm.Show();
            groupsSchedulesToolStripMenuItem.Enabled = toolStripGroupsSchedules.Enabled = false;
        }

        private void teachersSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            TeachersSchedulesForm teachersSchedulesForm = new TeachersSchedulesForm(this, connection, da) { MdiParent = this };
            teachersSchedulesForm.Show();
            teachersSchedulesToolStripMenuItem.Enabled = toolStripTeachersSchedules.Enabled = false;
        }

        private void curriculumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            CurriculumsForm curriculumsForm = new CurriculumsForm(this, connection, da) { MdiParent = this };
            curriculumsForm.Show();
            curriculumsToolStripMenuItem.Enabled = toolStripCurriculums.Enabled = false;
        }

        private void bellsSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbDataAdapter da = factory.CreateDataAdapter();
            BellsForm bellsForm = new BellsForm(this, connection, da) { MdiParent = this };
            bellsForm.Show();
            bellsSchedulesToolStripMenuItem.Enabled = toolStripBellsSchedules.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void windowToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (windowToolStripMenuItem.DropDownItems.Count == 2)
                windowToolStripMenuItem.DropDownItems[windowToolStripMenuItem.DropDownItems.Count - 1].Visible = false;
        }

        private void toolStripStudents_Click(object sender, EventArgs e)
        {
            studentsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripTeachers_Click(object sender, EventArgs e)
        {
            teachersToolStripMenuItem_Click(sender, e);
        }

        private void toolStripAuditoriums_Click(object sender, EventArgs e)
        {
            auditoriumsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripSubjects_Click(object sender, EventArgs e)
        {
            subjectsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripGroups_Click(object sender, EventArgs e)
        {
            groupsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripSpecialties_Click(object sender, EventArgs e)
        {
            specialtiesToolStripMenuItem_Click(sender, e);
        }

        private void toolStripGroupsSchedules_Click(object sender, EventArgs e)
        {
            groupsSchedulesToolStripMenuItem_Click(sender, e);
        }

        private void toolStripTeachersSchedules_Click(object sender, EventArgs e)
        {
            teachersSchedulesToolStripMenuItem_Click(sender, e);
        }

        private void toolStripCurriculums_Click(object sender, EventArgs e)
        {
            curriculumsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripBellsSchedules_Click(object sender, EventArgs e)
        {
            bellsSchedulesToolStripMenuItem_Click(sender, e);
        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }

        public bool StudentsFormEnabled
        {
            get { return studentsToolStripMenuItem.Enabled; }
            set { toolStripStudents.Enabled = studentsToolStripMenuItem.Enabled = value; }
        }

        public bool TeachersFormEnabled
        {
            get { return teachersToolStripMenuItem.Enabled; }
            set { toolStripTeachers.Enabled = teachersToolStripMenuItem.Enabled = value; }
        }

        public bool AuditoriumsFormEnabled
        {
            get { return auditoriumsToolStripMenuItem.Enabled; }
            set { toolStripAuditoriums.Enabled = auditoriumsToolStripMenuItem.Enabled = value; }
        }

        public bool SubjectsFormEnabled
        {
            get { return subjectsToolStripMenuItem.Enabled; }
            set { toolStripSubjects.Enabled = subjectsToolStripMenuItem.Enabled = value; }
        }

        public bool GroupsFormEnabled
        {
            get { return groupsToolStripMenuItem.Enabled; }
            set { toolStripGroups.Enabled = groupsToolStripMenuItem.Enabled = value; }
        }

        public bool SpecialtiesFormEnabled
        {
            get { return specialtiesToolStripMenuItem.Enabled; }
            set { toolStripSpecialties.Enabled = specialtiesToolStripMenuItem.Enabled = value; }
        }

        public bool GroupsSchedulesFormEnabled
        {
            get { return groupsSchedulesToolStripMenuItem.Enabled; }
            set { toolStripGroupsSchedules.Enabled = groupsSchedulesToolStripMenuItem.Enabled = value; }
        }

        public bool TeachersSchedulesFormEnabled
        {
            get { return teachersSchedulesToolStripMenuItem.Enabled; }
            set { toolStripTeachersSchedules.Enabled = teachersSchedulesToolStripMenuItem.Enabled = value; }
        }

        public bool CurriculumsFormEnabled
        {
            get { return curriculumsToolStripMenuItem.Enabled; }
            set { toolStripCurriculums.Enabled = curriculumsToolStripMenuItem.Enabled = value; }
        }

        public bool BellsSchedulesFormEnabled
        {
            get { return bellsSchedulesToolStripMenuItem.Enabled; }
            set { toolStripBellsSchedules.Enabled = bellsSchedulesToolStripMenuItem.Enabled = value; }
        }

        public string ToolStripStatusLabelText
        {
            get { return toolStripStatusLabel.Text; }
            set { toolStripStatusLabel.Text = value; }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }
    }
}