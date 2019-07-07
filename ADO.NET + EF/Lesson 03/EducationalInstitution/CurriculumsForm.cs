using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class CurriculumsForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public CurriculumsForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void CurriculumsForm_Load(object sender, EventArgs e)
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
                command.CommandText = "SELECT Curriculum_id, Curriculums.Group_id, Group_name, Curriculums.Subject_id, Subject_name, Lectures_count, Practical_lessons_count, Laboratory_lessons_count, Test_form FROM Curriculums, Groups, Subjects WHERE Group_name = @groupName AND Curriculums.Group_id = Groups.Group_id AND Curriculums.Subject_id = Subjects.Subject_id ORDER BY Subject_name";
                parameter.ParameterName = "@groupName";
                parameter.DbType = DbType.String;
                parameter.Value = groupChoice.Text;
                command.Parameters.Add(parameter);
                da.SelectCommand = command;
                dt.Clear();
                da.Fill(dt);
                curriculumsView.DataSource = dt;
                curriculumsView.Columns[0].Visible = false;
                curriculumsView.Columns[1].Visible = false;
                curriculumsView.Columns[2].Visible = false;
                curriculumsView.Columns[3].Visible = false;
                curriculumsView.Columns[4].HeaderText = "Предмет";
                curriculumsView.Columns[4].Width = 170;
                curriculumsView.Columns[5].HeaderText = "Количество лекций";
                curriculumsView.Columns[5].Width = 130;
                curriculumsView.Columns[6].HeaderText = "Количество практик";
                curriculumsView.Columns[6].Width = 135;
                curriculumsView.Columns[7].HeaderText = "Количество лабораторных работ";
                curriculumsView.Columns[7].Width = 200;
                curriculumsView.Columns[8].HeaderText = "Форма зачёта";
                curriculumsView.Columns[8].Width = 110;
                curriculumsView.RowHeadersVisible = curriculumsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = curriculumsView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupChoiceText.Enabled = groupChoice.Enabled = add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddCurriculumForm addCurriculumForm = new AddCurriculumForm(connection);
            int maxId = 0;
            if (addCurriculumForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Curriculum_id) AS Max_curriculum_id FROM Curriculums";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_curriculum_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_curriculum_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Curriculums VALUES (@curriculumId, @groupId, @subjectId, @lecturesCount, @practicalLessonsCount, @laboratoryLessonsCount, @testForm)";
                    parameter.ParameterName = "@curriculumId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = maxId + 1;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addCurriculumForm.Group;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@subjectId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addCurriculumForm.Subject;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@lecturesCount";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addCurriculumForm.LecturesCount;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@practicalLessonsCount";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addCurriculumForm.PracticalLessonsCount;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@laboratoryLessonsCount";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addCurriculumForm.LaboratoryLessonsCount;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@testForm";
                    parameter.DbType = DbType.String;
                    parameter.Value = addCurriculumForm.TestForm;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    for (int i = 0; i < groupChoice.Items.Count; i++)
                        if (groupChoice.Items[i].ToString() == addCurriculumForm.GroupName)
                        {
                            groupChoice.SelectedIndex = i;
                            groupChoice_SelectedIndexChanged(sender, e);
                            break;
                        }
                    for (int i = 0; i < curriculumsView.Rows.Count; i++)
                        if (Convert.ToInt32(curriculumsView.Rows[i].Cells[0].Value) == maxId + 1)
                            curriculumsView.Rows[i].Cells[4].Selected = true;
                    if (curriculumsView.Rows.Count > 0)
                        curriculumsView.RowHeadersVisible = curriculumsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу учебных планов была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditCurriculumForm editCurriculumForm = new EditCurriculumForm(connection);
            int id = Convert.ToInt32(curriculumsView.CurrentRow.Cells[0].Value);
            editCurriculumForm.Group = Convert.ToInt32(curriculumsView.CurrentRow.Cells[1].Value);
            editCurriculumForm.Subject = Convert.ToInt32(curriculumsView.CurrentRow.Cells[3].Value);
            editCurriculumForm.LecturesCount = curriculumsView.CurrentRow.Cells[5].Value.ToString();
            editCurriculumForm.PracticalLessonsCount = curriculumsView.CurrentRow.Cells[6].Value.ToString();
            editCurriculumForm.LaboratoryLessonsCount = curriculumsView.CurrentRow.Cells[7].Value.ToString();
            editCurriculumForm.TestForm = curriculumsView.CurrentRow.Cells[8].Value.ToString();
            if (editCurriculumForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Curriculums SET Group_id = @groupId, Subject_id = @subjectId, Lectures_count = @lecturesCount, Practical_lessons_count = @practicalLessonsCount, Laboratory_lessons_count = @laboratoryLessonsCount, Test_form = @testForm WHERE Curriculum_id = @curriculumId";
                    parameter.ParameterName = "@curriculumId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = curriculumsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editCurriculumForm.Group;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@subjectId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editCurriculumForm.Subject;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@lecturesCount";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editCurriculumForm.LecturesCount;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@practicalLessonsCount";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editCurriculumForm.PracticalLessonsCount;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@laboratoryLessonsCount";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editCurriculumForm.LaboratoryLessonsCount;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@testForm";
                    parameter.DbType = DbType.String;
                    parameter.Value = editCurriculumForm.TestForm;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    for (int i = 0; i < groupChoice.Items.Count; i++)
                        if (groupChoice.Items[i].ToString() == editCurriculumForm.GroupName)
                        {
                            groupChoice.SelectedIndex = i;
                            groupChoice_SelectedIndexChanged(sender, e);
                            break;
                        }
                    for (int i = 0; i < curriculumsView.Rows.Count; i++)
                        if (Convert.ToInt32(curriculumsView.Rows[i].Cells[0].Value) == id)
                            curriculumsView.Rows[i].Cells[4].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице учебных планов была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = curriculumsView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данный пункт из учебного плана?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Curriculums WHERE Curriculum_id = @curriculumId";
                    parameter.ParameterName = "@curriculumId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = curriculumsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    curriculumsView.Update();
                    if (curriculumsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        curriculumsView.Rows[index].Cells[4].Selected = true;
                    }
                    else
                        curriculumsView.RowHeadersVisible = curriculumsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы учебных планов была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CurriculumsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.CurriculumsFormEnabled = true;
        }
    }
}