using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class SubjectsForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public SubjectsForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void SubjectsForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Subjects ORDER BY Subject_name";
                da.SelectCommand = command;
                da.Fill(dt);
                subjectsView.DataSource = dt;
                subjectsView.Columns[0].Visible = false;
                subjectsView.Columns[1].HeaderText = "Название предмета";
                subjectsView.Columns[1].Width = 170;
                if (subjectsView.Rows.Count == 0)
                    subjectsView.RowHeadersVisible = subjectsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddSubjectForm addSubjectForm = new AddSubjectForm();
            int maxId = 0;
            if (addSubjectForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Subject_id) AS Max_subject_id FROM Subjects";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_subject_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_subject_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Subjects VALUES (@subjectId, @subjectName)";
                    parameter.ParameterName = "@subjectId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = maxId + 1;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@subjectName";
                    parameter.DbType = DbType.String;
                    parameter.Value = addSubjectForm.SubjectName;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    subjectsView.Update();
                    for (int i = 0; i < subjectsView.Rows.Count; i++)
                        if (Convert.ToInt32(subjectsView.Rows[i].Cells[0].Value) == maxId + 1)
                            subjectsView.Rows[i].Cells[1].Selected = true;
                    if (subjectsView.Rows.Count > 0)
                        subjectsView.RowHeadersVisible = subjectsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу читаемых предметов была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditSubjectForm editSubjectForm = new EditSubjectForm();
            int index = subjectsView.CurrentRow.Index;
            editSubjectForm.SubjectName = subjectsView.CurrentRow.Cells[1].Value.ToString();
            if (editSubjectForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Subjects SET Subject_name = @subjectName WHERE Subject_id = @subjectId";
                    parameter.ParameterName = "@subjectId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = subjectsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@subjectName";
                    parameter.DbType = DbType.String;
                    parameter.Value = editSubjectForm.SubjectName;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    subjectsView.Update();
                    subjectsView.Rows[index].Cells[1].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице читаемых предметов была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = subjectsView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данный предмет из таблицы?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Subjects WHERE Subject_id = @subjectId";
                    parameter.ParameterName = "@subjectId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = subjectsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    subjectsView.Update();
                    if (subjectsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        subjectsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        subjectsView.RowHeadersVisible = subjectsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы читаемых предметов была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SubjectsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.SubjectsFormEnabled = true;
        }
    }
}