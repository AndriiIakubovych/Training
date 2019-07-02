using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class BellsForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public BellsForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void BellsForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Bells ORDER BY Bell_begin_time";
                da.SelectCommand = command;
                da.Fill(dt);
                bellsView.DataSource = dt;
                bellsView.Columns[0].Visible = false;
                bellsView.Columns[1].HeaderText = "Время начала занятия";
                bellsView.Columns[1].Width = 150;
                bellsView.Columns[2].HeaderText = "Время окончания занятия";
                bellsView.Columns[2].Width = 165;
                if (bellsView.Rows.Count == 0)
                    bellsView.RowHeadersVisible = bellsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddBellForm addBellForm = new AddBellForm();
            int maxId = 0;
            if (addBellForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Bell_id) AS Max_bell_id FROM Bells";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_bell_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_bell_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Bells VALUES (@bellId, @bellBeginTime, @bellEndTime)";
                    parameter.ParameterName = "@bellId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = (maxId + 1);
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@bellBeginTime";
                    parameter.DbType = DbType.DateTime;
                    parameter.Value = addBellForm.BellBeginTime;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@bellEndTime";
                    parameter.DbType = DbType.DateTime;
                    parameter.Value = addBellForm.BellEndTime;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    addBellForm.Update();
                    for (int i = 0; i < bellsView.Rows.Count; i++)
                        if (Convert.ToInt32(bellsView.Rows[i].Cells[0].Value) == maxId + 1)
                            bellsView.Rows[i].Cells[1].Selected = true;
                    if (bellsView.Rows.Count > 0)
                        bellsView.RowHeadersVisible = bellsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу расписания звонков была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditBellForm editBellForm = new EditBellForm();
            int index = bellsView.CurrentRow.Index;
            editBellForm.BellBeginTime = bellsView.CurrentRow.Cells[1].Value.ToString();
            editBellForm.BellEndTime = bellsView.CurrentRow.Cells[2].Value.ToString();
            if (editBellForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Bells SET Bell_begin_time = @bellBeginTime, Bell_end_time = @bellEndTime WHERE Bell_id = @bellId";
                    parameter.ParameterName = "@bellId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = bellsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@bellBeginTime";
                    parameter.DbType = DbType.DateTime;
                    parameter.Value = editBellForm.BellBeginTime;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@bellEndTime";
                    parameter.DbType = DbType.DateTime;
                    parameter.Value = editBellForm.BellEndTime;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    bellsView.Update();
                    bellsView.Rows[index].Cells[1].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице расписания звонков была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = bellsView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данный пункт из расписания?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Bells WHERE Bell_id = @bellId";
                    parameter.ParameterName = "@bellId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = bellsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    bellsView.Update();
                    if (bellsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        bellsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        bellsView.RowHeadersVisible = bellsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы расписания звонков была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BellsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.BellsSchedulesFormEnabled = true;
        }
    }
}