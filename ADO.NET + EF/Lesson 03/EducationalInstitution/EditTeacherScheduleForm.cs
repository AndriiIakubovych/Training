using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace EducationalInstitution
{
    public partial class EditTeacherScheduleForm : Form
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

        public EditTeacherScheduleForm(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            teachersList = new Dictionary<int, string>();
            subjectsList = new Dictionary<int, string>();
            bellsList = new Dictionary<int, string>();
            auditoriumsList = new Dictionary<int, string>();
            groupsList = new Dictionary<int, string>();
        }

        private void EditTeacherScheduleForm_Load(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Teachers ORDER BY Teacher_name";
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teachersList.Add(reader.GetInt32(reader.GetOrdinal("Teacher_id")), reader.GetString(reader.GetOrdinal("Teacher_name")));
                    teacherChoice.Items.Add(reader.GetString(reader.GetOrdinal("Teacher_name")));
                }
                if (teacherChoice.Items.Count > 0)
                {
                    teacherChoice.SelectedIndex = 0;
                    foreach (KeyValuePair<int, string> t in teachersList)
                    {
                        if (t.Key == teacherId)
                        {
                            teacherChoice.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else
                    teacherChoiceText.Enabled = teacherChoice.Enabled = ok.Enabled = false;
                reader.Close();
                i = 0;
                command.CommandText = "SELECT * FROM Subjects ORDER BY Subject_name";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    subjectsList.Add(reader.GetInt32(reader.GetOrdinal("Subject_id")), reader.GetString(reader.GetOrdinal("Subject_name")));
                    subjectChoice.Items.Add(reader.GetString(reader.GetOrdinal("Subject_name")));
                }
                if (subjectChoice.Items.Count > 0)
                {
                    subjectChoice.SelectedIndex = 0;
                    foreach (KeyValuePair<int, string> s in subjectsList)
                    {
                        if (s.Key == subjectId)
                        {
                            subjectChoice.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else
                    subjectChoiceText.Enabled = subjectChoice.Enabled = ok.Enabled = false;
                reader.Close();
                for (i = 0; i < subjectTypeChoice.Items.Count; i++)
                    if (subjectTypeChoice.Items[i].ToString() == SubjectType)
                    {
                        subjectTypeChoice.SelectedIndex = i;
                        break;
                    }
                i = 0;
                command.CommandText = "SELECT * FROM Bells ORDER BY Bell_begin_time";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bellsList.Add(reader.GetInt32(reader.GetOrdinal("Bell_id")), reader.GetValue(reader.GetOrdinal("Bell_begin_time")).ToString());
                    timeChoice.Items.Add(reader.GetValue(reader.GetOrdinal("Bell_begin_time")).ToString());
                }
                if (timeChoice.Items.Count > 0)
                {
                    timeChoice.SelectedIndex = 0;
                    foreach (KeyValuePair<int, string> r in bellsList)
                    {
                        if (r.Key == bellId)
                        {
                            timeChoice.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else
                    timeChoiceText.Enabled = timeChoice.Enabled = ok.Enabled = false;
                reader.Close();
                i = 0;
                command.CommandText = "SELECT * FROM Auditoriums";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    auditoriumsList.Add(reader.GetInt32(reader.GetOrdinal("Auditorium_id")), reader.GetString(reader.GetOrdinal("Auditorium_number")));
                    auditoriumChoice.Items.Add(reader.GetString(reader.GetOrdinal("Auditorium_number")));
                }
                if (auditoriumChoice.Items.Count > 0)
                {
                    auditoriumChoice.SelectedIndex = 0;
                    foreach (KeyValuePair<int, string> a in auditoriumsList)
                    {
                        if (a.Key == auditoriumId)
                        {
                            auditoriumChoice.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else
                    auditoriumChoiceText.Enabled = auditoriumChoice.Enabled = ok.Enabled = false;
                reader.Close();
                i = 0;
                command.CommandText = "SELECT * FROM Groups ORDER BY Group_name";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    groupsList.Add(reader.GetInt32(reader.GetOrdinal("Group_id")), reader.GetString(reader.GetOrdinal("Group_name")));
                    groupChoice.Items.Add(reader.GetString(reader.GetOrdinal("Group_name")));
                }
                if (groupChoice.Items.Count > 0)
                {
                    groupChoice.SelectedIndex = 0;
                    foreach (KeyValuePair<int, string> g in groupsList)
                    {
                        if (g.Key == groupId)
                        {
                            groupChoice.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
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
            set { teacherId = value; }
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
            set { subjectId = value; }
        }

        public string SubjectType
        {
            get { return subjectTypeChoice.Text; }
            set { subjectTypeChoice.Text = value; }
        }

        public int DayNumber
        {
            get { return dayChoice.SelectedIndex + 1; }
            set { dayChoice.SelectedIndex = value; }
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
            set { bellId = value; }
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
            set { auditoriumId = value; }
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
            set { groupId = value; }
        }
    }
}