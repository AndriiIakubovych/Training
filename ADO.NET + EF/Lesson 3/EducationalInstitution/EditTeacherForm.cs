using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace EducationalInstitution
{
    public partial class EditTeacherForm : Form
    {
        private DbConnection connection;
        private Dictionary<int, string> specialtiesList;
        private int specialtyId;

        public EditTeacherForm(DbConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            specialtiesList = new Dictionary<int, string>();
        }

        private void EditTeacherForm_Load(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Specialties ORDER BY Specialty_name";
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    specialtiesList.Add(reader.GetInt32(reader.GetOrdinal("Specialty_id")), reader.GetString(reader.GetOrdinal("Specialty_name")));
                    specialtyChoice.Items.Add(reader.GetString(reader.GetOrdinal("Specialty_name")));
                }
                if (specialtyChoice.Items.Count > 0)
                {
                    specialtyChoice.SelectedIndex = 0;
                    foreach (KeyValuePair<int, string> s in specialtiesList)
                    {
                        if (s.Key == specialtyId)
                        {
                            specialtyChoice.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else
                    specialtyChoiceText.Enabled = specialtyChoice.Enabled = false;
                reader.Close();
                teacherName_TextChanged(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void teacherName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = specialtyChoice.Items.Count > 0 && teacherName.Text.Length > 0;
        }

        public string TeacherName
        {
            get { return teacherName.Text; }
            set { teacherName.Text = value; }
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
            set { specialtyId = value; }
        }
    }
}