using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace EducationalInstitution
{
    public partial class EditStudentForm : Form
    {
        private DbConnection connection;
        private Dictionary<int, string> groupsList;
        private int groupId;

        public EditStudentForm(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            groupsList = new Dictionary<int, string>();
        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Groups ORDER BY Group_name";
                DbDataReader reader = command.ExecuteReader();
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
                    groupChoiceText.Enabled = groupChoice.Enabled = false;
                reader.Close();
                studentName_TextChanged(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void studentName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = groupChoice.Items.Count > 0 && studentName.Text.Length > 0;
        }

        public string StudentName
        {
            get { return studentName.Text; }
            set { studentName.Text = value; }
        }

        public string Birthdate
        {
            get { return birthdate.Text; }
            set { birthdate.Text = value; }
        }

        public string Address
        {
            get { return address.Text; }
            set { address.Text = value; }
        }

        public string Telephone
        {
            get { return telephone.Text; }
            set { telephone.Text = value; }
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

        public string GroupName
        {
            get { return groupChoice.Text; }
        }
    }
}