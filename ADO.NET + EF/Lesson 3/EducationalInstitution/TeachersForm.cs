using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class TeachersForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public TeachersForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void TeachersForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Teacher_id, Teacher_name, Birthdate, Address, Telephone, Teachers.Specialty_id, Specialty_name FROM Teachers, Specialties WHERE Teachers.Specialty_id = Specialties.Specialty_id ORDER BY Teacher_name";
                da.SelectCommand = command;
                da.Fill(dt);
                teachersView.DataSource = dt;
                teachersView.Columns[0].Visible = false;
                teachersView.Columns[1].HeaderText = "ФИО преподавателя";
                teachersView.Columns[1].Width = 190;
                teachersView.Columns[2].HeaderText = "Дата рождения";
                teachersView.Columns[2].Width = 110;
                teachersView.Columns[3].HeaderText = "Домашний адрес";
                teachersView.Columns[3].Width = 190;
                teachersView.Columns[4].HeaderText = "Телефон";
                teachersView.Columns[4].Width = 110;
                teachersView.Columns[5].Visible = false;
                teachersView.Columns[6].HeaderText = "Специальность";
                teachersView.Columns[6].Width = 150;
                if (teachersView.Rows.Count == 0)
                    teachersView.RowHeadersVisible = teachersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddTeacherForm addTeacherForm = new AddTeacherForm(connection);
            int maxId = 0;
            if (addTeacherForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Teacher_id) AS Max_teacher_id FROM Teachers";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_teacher_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_teacher_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Teachers VALUES (@teacherId, @teacherName, @birthdate, @address, @telephone, @specialtyId)";
                    parameter.ParameterName = "@teacherId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = maxId + 1;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@teacherName";
                    parameter.DbType = DbType.String;
                    parameter.Value = addTeacherForm.TeacherName;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@birthdate";
                    parameter.DbType = DbType.DateTime;
                    parameter.Value = addTeacherForm.Birthdate;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@address";
                    parameter.DbType = DbType.String;
                    parameter.Value = addTeacherForm.Address;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@telephone";
                    parameter.DbType = DbType.String;
                    parameter.Value = addTeacherForm.Telephone;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@specialtyId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addTeacherForm.Specialty;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    teachersView.Update();
                    for (int i = 0; i < teachersView.Rows.Count; i++)
                        if (Convert.ToInt32(teachersView.Rows[i].Cells[0].Value) == maxId + 1)
                            teachersView.Rows[i].Cells[1].Selected = true;
                    if (teachersView.Rows.Count > 0)
                        teachersView.RowHeadersVisible = teachersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу преподавателей заведения была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditTeacherForm editTeacherForm = new EditTeacherForm(connection);
            int index = teachersView.CurrentRow.Index;
            editTeacherForm.TeacherName = teachersView.CurrentRow.Cells[1].Value.ToString();
            editTeacherForm.Birthdate = teachersView.CurrentRow.Cells[2].Value.ToString();
            editTeacherForm.Address = teachersView.CurrentRow.Cells[3].Value.ToString();
            editTeacherForm.Telephone = teachersView.CurrentRow.Cells[4].Value.ToString();
            editTeacherForm.Specialty = Convert.ToInt32(teachersView.CurrentRow.Cells[5].Value);
            if (editTeacherForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Teachers SET Teacher_name = @teacherName, Birthdate = @birthdate, Address = @address, Telephone = @telephone, Specialty_id = @specialtyId WHERE Teacher_id = @teacherId";
                    parameter.ParameterName = "@teacherId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = teachersView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@teacherName";
                    parameter.DbType = DbType.String;
                    parameter.Value = editTeacherForm.TeacherName;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@birthdate";
                    parameter.DbType = DbType.DateTime;
                    parameter.Value = editTeacherForm.Birthdate;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@address";
                    parameter.DbType = DbType.String;
                    parameter.Value = editTeacherForm.Address;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@telephone";
                    parameter.DbType = DbType.String;
                    parameter.Value = editTeacherForm.Telephone;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@specialtyId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editTeacherForm.Specialty;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    teachersView.Update();
                    teachersView.Rows[index].Cells[1].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице преподавателей заведения была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = teachersView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данные о преподавателе?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Teachers WHERE Teacher_id = @teacherId";
                    parameter.ParameterName = "@teacherId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = teachersView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    teachersView.Update();
                    if (teachersView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        teachersView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        teachersView.RowHeadersVisible = teachersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы преподавателей заведения была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TeachersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.TeachersFormEnabled = true;
        }
    }
}