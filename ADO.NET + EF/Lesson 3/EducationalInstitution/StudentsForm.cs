using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class StudentsForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public StudentsForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Group_name FROM Groups ORDER BY Group_name";
                Task<DbDataReader> reader = command.ExecuteReaderAsync();
                while (reader.Result.Read())
                    groupChoice.Items.Add(reader.Result.GetString(reader.Result.GetOrdinal("Group_name")));
                reader.Result.Close();
                if (groupChoice.Items.Count > 0)
                    groupChoice.SelectedIndex = 0;
                else
                    groupChoiceText.Enabled = groupChoice.Enabled = add.Enabled = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupChoiceText.Enabled = groupChoice.Enabled = add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void groupChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                DbParameter parameter = command.CreateParameter();
                command.CommandText = "SELECT Student_id, Student_name, Birthdate, Address, Telephone, Students.Group_id, Group_name FROM Students, Groups WHERE Group_name = '" + groupChoice.Text + "' AND Students.Group_id = Groups.Group_id ORDER BY Student_name";
                parameter.ParameterName = "@groupName";
                parameter.DbType = DbType.String;
                parameter.Value = groupChoice.Text;
                command.Parameters.Add(parameter);
                da.SelectCommand = command;
                dt.Clear();
                da.Fill(dt);
                studentsView.DataSource = dt;
                studentsView.Columns[0].Visible = false;
                studentsView.Columns[1].HeaderText = "ФИО студента";
                studentsView.Columns[1].Width = 190;
                studentsView.Columns[2].HeaderText = "Дата рождения";
                studentsView.Columns[2].Width = 110;
                studentsView.Columns[3].HeaderText = "Домашний адрес";
                studentsView.Columns[3].Width = 190;
                studentsView.Columns[4].HeaderText = "Телефон";
                studentsView.Columns[4].Width = 110;
                studentsView.Columns[5].Visible = false;
                studentsView.Columns[6].Visible = false;
                studentsView.RowHeadersVisible = studentsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = studentsView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupChoiceText.Enabled = groupChoice.Enabled = add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm(connection);
            int maxId = 0;
            if (addStudentForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Student_id) AS Max_student_id FROM Students";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_student_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_student_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Students VALUES (@studentId, @studentName, @birthdate, @address, @telephone, @groupId)";
                    parameter.ParameterName = "@studentId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = maxId + 1;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@studentName";
                    parameter.DbType = DbType.String;
                    parameter.Value = addStudentForm.StudentName;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@birthdate";
                    parameter.DbType = DbType.DateTime;
                    parameter.Value = addStudentForm.Birthdate;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@address";
                    parameter.DbType = DbType.String;
                    parameter.Value = addStudentForm.Address;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@telephone";
                    parameter.DbType = DbType.String;
                    parameter.Value = addStudentForm.Telephone;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addStudentForm.Group;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    for (int i = 0; i < groupChoice.Items.Count; i++)
                        if (groupChoice.Items[i].ToString() == addStudentForm.GroupName)
                        {
                            groupChoice.SelectedIndex = i;
                            groupChoice_SelectedIndexChanged(sender, e);
                            break;
                        }
                    for (int i = 0; i < studentsView.Rows.Count; i++)
                        if (Convert.ToInt32(studentsView.Rows[i].Cells[0].Value) == maxId + 1)
                            studentsView.Rows[i].Cells[1].Selected = true;
                    if (studentsView.Rows.Count > 0)
                        studentsView.RowHeadersVisible = studentsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу студентов заведения была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditStudentForm editStudentForm = new EditStudentForm(connection);
            int id = Convert.ToInt32(studentsView.CurrentRow.Cells[0].Value);
            editStudentForm.StudentName = studentsView.CurrentRow.Cells[1].Value.ToString();
            editStudentForm.Birthdate = studentsView.CurrentRow.Cells[2].Value.ToString();
            editStudentForm.Address = studentsView.CurrentRow.Cells[3].Value.ToString();
            editStudentForm.Telephone = studentsView.CurrentRow.Cells[4].Value.ToString();
            editStudentForm.Group = Convert.ToInt32(studentsView.CurrentRow.Cells[5].Value);
            if (editStudentForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Students SET Student_name = '" + editStudentForm.StudentName + "', Birthdate = '" + editStudentForm.Birthdate + "', Address = '" + editStudentForm.Address + "', Telephone = '" + editStudentForm.Telephone + "', Group_id = " + editStudentForm.Group + " WHERE Student_id = " + studentsView.CurrentRow.Cells[0].Value;
                    parameter.ParameterName = "@studentId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = studentsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@studentName";
                    parameter.DbType = DbType.String;
                    parameter.Value = editStudentForm.StudentName;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@birthdate";
                    parameter.DbType = DbType.DateTime;
                    parameter.Value = editStudentForm.Birthdate;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@address";
                    parameter.DbType = DbType.String;
                    parameter.Value = editStudentForm.Address;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@telephone";
                    parameter.DbType = DbType.String;
                    parameter.Value = editStudentForm.Telephone;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editStudentForm.Group;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    for (int i = 0; i < groupChoice.Items.Count; i++)
                        if (groupChoice.Items[i].ToString() == editStudentForm.GroupName)
                        {
                            groupChoice.SelectedIndex = i;
                            groupChoice_SelectedIndexChanged(sender, e);
                            break;
                        }
                    for (int i = 0; i < studentsView.Rows.Count; i++)
                        if (Convert.ToInt32(studentsView.Rows[i].Cells[0].Value) == id)
                            studentsView.Rows[i].Cells[1].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице студентов заведения была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = studentsView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данные о студенте?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Students WHERE Student_id = @studentId";
                    parameter.ParameterName = "@studentId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = studentsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    studentsView.Update();
                    if (studentsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        studentsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        studentsView.RowHeadersVisible = studentsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы студентов заведения была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StudentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.StudentsFormEnabled = true;
        }
    }
}