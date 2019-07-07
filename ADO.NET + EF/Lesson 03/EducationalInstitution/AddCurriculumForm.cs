using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace EducationalInstitution
{
    public partial class AddCurriculumForm : Form
    {
        private DbConnection connection;
        private Dictionary<int, string> groupsList;
        private Dictionary<int, string> subjectsList;
        private int groupId;
        private int subjectId;

        public AddCurriculumForm(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            groupsList = new Dictionary<int, string>();
            subjectsList = new Dictionary<int, string>();
        }

        private void AddCurriculumForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Groups ORDER BY Group_name";
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    groupsList.Add(reader.GetInt32(reader.GetOrdinal("Group_id")), reader.GetString(reader.GetOrdinal("Group_name")));
                    groupChoice.Items.Add(reader.GetString(reader.GetOrdinal("Group_name")));
                }
                if (groupChoice.Items.Count > 0)
                    groupChoice.SelectedIndex = 0;
                else
                    groupChoiceText.Enabled = groupChoice.Enabled = ok.Enabled = false;
                reader.Close();
                command.CommandText = "SELECT * FROM Subjects ORDER BY Subject_name";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    subjectsList.Add(reader.GetInt32(reader.GetOrdinal("Subject_id")), reader.GetString(reader.GetOrdinal("Subject_name")));
                    subjectChoice.Items.Add(reader.GetString(reader.GetOrdinal("Subject_name")));
                }
                if (subjectChoice.Items.Count > 0)
                    subjectChoice.SelectedIndex = 0;
                else
                    subjectChoiceText.Enabled = subjectChoice.Enabled = ok.Enabled = false;
                reader.Close();
                testFormChoice.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lecturesCount_TextChanged(object sender, System.EventArgs e)
        {
            ok.Enabled = groupChoice.Items.Count > 0 && subjectChoice.Items.Count > 0 && lecturesCount.Text.Length > 0 && practicalLessonsCount.Text.Length > 0 && laboratoryLessonsCount.Text.Length > 0;
        }

        private void practicalLessonsCount_TextChanged(object sender, System.EventArgs e)
        {
            lecturesCount_TextChanged(sender, e);
        }

        private void laboratoryLessonsCount_TextChanged(object sender, System.EventArgs e)
        {
            lecturesCount_TextChanged(sender, e);
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lecturesCount.Text) >= 0 && Convert.ToInt32(practicalLessonsCount.Text) >= 0 && Convert.ToInt32(laboratoryLessonsCount.Text) >= 0)
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Некоторые значения введены неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int Group
        {
            get
            {
                foreach (KeyValuePair<int, string> g in groupsList)
                    if (g.Value == groupChoice.Text)
                    {
                        groupId = g.Key;
                        break;
                    }
                return groupId;
            }
        }

        public string GroupName
        {
            get { return groupChoice.Text; }
        }

        public int Subject
        {
            get
            {
                foreach (KeyValuePair<int, string> s in subjectsList)
                    if (s.Value == subjectChoice.Text)
                    {
                        subjectId = s.Key;
                        break;
                    }
                return subjectId;
            }
        }

        public string LecturesCount
        {
            get { return lecturesCount.Text; }
        }

        public string PracticalLessonsCount
        {
            get { return practicalLessonsCount.Text; }
        }

        public string LaboratoryLessonsCount
        {
            get { return laboratoryLessonsCount.Text; }
        }

        public string TestForm
        {
            get { return testFormChoice.Text; }
        }
    }
}