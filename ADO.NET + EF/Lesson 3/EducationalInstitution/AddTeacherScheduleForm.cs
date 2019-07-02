using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace EducationalInstitution
{
    public partial class AddTeacherScheduleForm : Form
    {
        private DbConnection connection;
        private Dictionary<int, string> teachersList;
        private Dictionary<int, string> subjectsList;
        private Dictionary<int, string> bellsList;
        private Dictionary<int, string> auditoriumsList;
        private Dictionary<int, string> groupsList;
        private int teacherId;
        private int subjectId;
        private int bellId;
        private int auditoriumId;
        private int groupId;

        public AddTeacherScheduleForm(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            teachersList = new Dictionary<int, string>();
            subjectsList = new Dictionary<int, string>();
            bellsList = new Dictionary<int, string>();
            auditoriumsList = new Dictionary<int, string>();
            groupsList = new Dictionary<int, string>();
        }

        private void AddTeacherScheduleForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Teachers ORDER BY Teacher_name";
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teachersList.Add(reader.GetInt32(reader.GetOrdinal("Teacher_id")), reader.GetString(reader.GetOrdinal("Teacher_name")));
                    teacherChoice.Items.Add(reader.GetString(reader.GetOrdinal("Teacher_name")));
                }
                if (teacherChoice.Items.Count > 0)
                    teacherChoice.SelectedIndex = 0;
                else
                    teacherChoiceText.Enabled = teacherChoice.Enabled = ok.Enabled = false;
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
                subjectTypeChoice.SelectedIndex = 0;
                dayChoice.SelectedIndex = 0;
                command.CommandText = "SELECT * FROM Bells ORDER BY Bell_begin_time";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bellsList.Add(reader.GetInt32(reader.GetOrdinal("Bell_id")), reader.GetValue(reader.GetOrdinal("Bell_begin_time")).ToString());
                    timeChoice.Items.Add(reader.GetValue(reader.GetOrdinal("Bell_begin_time")).ToString());
                }
                if (timeChoice.Items.Count > 0)
                    timeChoice.SelectedIndex = 0;
                else
                    timeChoiceText.Enabled = timeChoice.Enabled = ok.Enabled = false;
                reader.Close();
                command.CommandText = "SELECT * FROM Auditoriums";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    auditoriumsList.Add(reader.GetInt32(reader.GetOrdinal("Auditorium_id")), reader.GetString(reader.GetOrdinal("Auditorium_number")));
                    auditoriumChoice.Items.Add(reader.GetString(reader.GetOrdinal("Auditorium_number")));
                }
                if (auditoriumChoice.Items.Count > 0)
                    auditoriumChoice.SelectedIndex = 0;
                else
                    auditoriumChoiceText.Enabled = auditoriumChoice.Enabled = ok.Enabled = false;
                reader.Close();
                command.CommandText = "SELECT * FROM Groups ORDER BY Group_name";
                reader = command.ExecuteReader();
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
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int Teacher
        {
            get
            {
                foreach (KeyValuePair<int, string> t in teachersList)
                    if (t.Value == teacherChoice.Text)
                    {
                        teacherId = t.Key;
                        break;
                    }
                return teacherId;
            }
        }

        public string TeacherName
        {
            get { return teacherChoice.Text; }
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

        public string SubjectType
        {
            get { return subjectTypeChoice.Text; }
        }

        public int DayNumber
        {
            get { return dayChoice.SelectedIndex + 1; }
        }

        public int Bell
        {
            get
            {
                foreach (KeyValuePair<int, string> b in bellsList)
                    if (b.Value == timeChoice.Text)
                    {
                        bellId = b.Key;
                        break;
                    }
                return bellId;
            }
        }

        public int Auditorium
        {
            get
            {
                foreach (KeyValuePair<int, string> a in auditoriumsList)
                    if (a.Value == auditoriumChoice.Text)
                    {
                        auditoriumId = a.Key;
                        break;
                    }
                return auditoriumId;
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
    }
}