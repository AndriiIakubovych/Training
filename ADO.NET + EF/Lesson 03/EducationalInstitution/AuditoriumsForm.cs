using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class AuditoriumsForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public AuditoriumsForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void AuditoriumsForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Auditoriums";
                da.SelectCommand = command;
                da.Fill(dt);
                auditoriumsView.DataSource = dt;
                auditoriumsView.Columns[0].Visible = false;
                auditoriumsView.Columns[1].HeaderText = "Номер аудитории";
                auditoriumsView.Columns[1].Width = 120;
                if (auditoriumsView.Rows.Count == 0)
                    auditoriumsView.RowHeadersVisible = auditoriumsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddAuditoriumForm addAuditoriumForm = new AddAuditoriumForm();
            int maxId = 0;
            if (addAuditoriumForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Auditorium_id) AS Max_auditorium_id FROM Auditoriums";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_auditorium_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_auditorium_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Auditoriums VALUES (@auditoriumId, @auditoriumNumber)";
                    parameter.ParameterName = "@auditoriumId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = (maxId + 1);
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@auditoriumNumber";
                    parameter.DbType = DbType.String;
                    parameter.Value = addAuditoriumForm.AuditoriumNumber;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    auditoriumsView.Update();
                    if (auditoriumsView.Rows.Count > 0)
                        auditoriumsView.RowHeadersVisible = auditoriumsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < auditoriumsView.Rows.Count; i++)
                        if (Convert.ToInt32(auditoriumsView.Rows[i].Cells[0].Value) == maxId + 1)
                            auditoriumsView.Rows[i].Cells[1].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу учебных аудиторий была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditAuditoriumForm editAuditoriumForm = new EditAuditoriumForm();
            int index = auditoriumsView.CurrentRow.Index;
            editAuditoriumForm.AuditoriumNumber = auditoriumsView.CurrentRow.Cells[1].Value.ToString();
            if (editAuditoriumForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Auditoriums SET Auditorium_number = @auditoriumNumber WHERE Auditorium_id = @auditoriumId";
                    parameter.ParameterName = "@auditoriumId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = auditoriumsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@auditoriumNumber";
                    parameter.DbType = DbType.String;
                    parameter.Value = editAuditoriumForm.AuditoriumNumber;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    auditoriumsView.Update();
                    auditoriumsView.Rows[index].Cells[1].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице учебных аудиторий была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = auditoriumsView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данную аудиторию из таблицы?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Auditoriums WHERE Auditorium_id = @auditoriumId";
                    parameter.ParameterName = "@auditoriumId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = auditoriumsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    auditoriumsView.Update();
                    if (auditoriumsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        auditoriumsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        auditoriumsView.RowHeadersVisible = auditoriumsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы учебных аудиторий была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AuditoriumsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.AuditoriumsFormEnabled = true;
        }
    }
}