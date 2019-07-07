using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace EducationalInstitution
{
    public partial class AddStudentForm : Form
    {
        private DbConnection connection;
        private Dictionary<int, string> groupsList;
        private int groupId;

        public AddStudentForm(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            groupsList = new Dictionary<int, string>();
        }

        private void AddStudentForm_Load(object sender, System.EventArgs e)
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
                    groupChoiceText.Enabled = groupChoice.Enabled = false;
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void studentName_TextChanged(object sender, System.EventArgs e)
        {
            ok.Enabled = groupChoice.Items.Count > 0 && studentName.Text.Length > 0 && groupChoice.Items.Count > 0;
        }

        public string StudentName
        {
            get { return studentName.Text; }
        }

        public string Birthdate
        {
            get { return birthdate.Text; }
        }

        public string Address
        {
            get { return address.Text; }
        }

        public string Telephone
        {
            get { return telephone.Text; }
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
    }
}