using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace EducationalInstitution
{
    public partial class AddGroupForm : Form
    {
        private DbConnection connection;
        private Dictionary<int, string> specialtiesList;
        private int specialtyId;

        public AddGroupForm(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            specialtiesList = new Dictionary<int, string>();
        }

        private void AddGroupForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Specialties ORDER BY Specialty_name";
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    specialtiesList.Add(reader.GetInt32(reader.GetOrdinal("Specialty_id")), reader.GetString(reader.GetOrdinal("Specialty_name")));
                    specialtyChoice.Items.Add(reader.GetString(reader.GetOrdinal("Specialty_name")));
                }
                if (specialtyChoice.Items.Count > 0)
                    specialtyChoice.SelectedIndex = 0;
                else
                    specialtyChoiceText.Enabled = specialtyChoice.Enabled = false;
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = specialtyChoice.Items.Count > 0 && groupName.Text.Length > 0 && semester.Text.Length > 0;
        }

        private void semester_TextChanged(object sender, EventArgs e)
        {
            groupName_TextChanged(sender, e);
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (Semester.Length == 0 || (Convert.ToInt32(Semester) > 0))
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Некоторые значения введены неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GroupName
        {
            get { return groupName.Text; }
        }

        public string Semester
        {
            get { return semester.Text; }
        }

        public int Specialty
        {
            get
            {
                foreach (KeyValuePair<int, string> s in specialtiesList)
                    if (s.Value == specialtyChoice.Text)
                    {
                        specialtyId = s.Key;
                        break;
                    }
                return specialtyId;
            }
        }
    }
}