using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class GroupsForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public GroupsForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void GroupsForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Group_id, Group_name, Semester, Groups.Specialty_id, Specialty_name FROM Groups, Specialties WHERE Groups.Specialty_id = Specialties.Specialty_id ORDER BY Group_name";
                da.SelectCommand = command;
                da.Fill(dt);
                groupsView.DataSource = dt;
                groupsView.Columns[0].Visible = false;
                groupsView.Columns[1].HeaderText = "Название группы";
                groupsView.Columns[1].Width = 120;
                groupsView.Columns[2].HeaderText = "Семестр";
                groupsView.Columns[2].Width = 70;
                groupsView.Columns[3].Visible = false;
                groupsView.Columns[4].HeaderText = "Специальность";
                groupsView.Columns[4].Width = 150;
                if (groupsView.Rows.Count == 0)
                    groupsView.RowHeadersVisible = groupsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddGroupForm addGroupForm = new AddGroupForm(connection);
            int maxId = 0;
            if (addGroupForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Group_id) AS Max_group_id FROM Groups";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_group_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_group_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Groups VALUES (@groupId, @groupName, @semester, @specialtyId)";
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = (maxId + 1);
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@groupName";
                    parameter.DbType = DbType.String;
                    parameter.Value = addGroupForm.GroupName;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@semester";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addGroupForm.Semester;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@specialtyId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addGroupForm.Specialty;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    groupsView.Update();
                    for (int i = 0; i < groupsView.Rows.Count; i++)
                        if (Convert.ToInt32(groupsView.Rows[i].Cells[0].Value) == maxId + 1)
                            groupsView.Rows[i].Cells[1].Selected = true;
                    if (groupsView.Rows.Count > 0)
                        groupsView.RowHeadersVisible = groupsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу групп была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditGroupForm editGroupForm = new EditGroupForm(connection);
            int index = groupsView.CurrentRow.Index;
            editGroupForm.GroupName = groupsView.CurrentRow.Cells[1].Value.ToString();
            editGroupForm.Semester = groupsView.CurrentRow.Cells[2].Value.ToString();
            editGroupForm.Specialty = Convert.ToInt32(groupsView.CurrentRow.Cells[3].Value);
            if (editGroupForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Groups SET Group_name = @groupName, Semester = @semester, Specialty_id = @specialtyId WHERE Group_id = @groupId";
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = groupsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@groupName";
                    parameter.DbType = DbType.String;
                    parameter.Value = editGroupForm.GroupName;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@semester";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editGroupForm.Semester;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@specialtyId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editGroupForm.Specialty;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    groupsView.Update();
                    groupsView.Rows[index].Cells[1].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице групп была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = groupsView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данные о группе?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Groups WHERE Group_id = @groupId";
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = groupsView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    groupsView.Update();
                    if (groupsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        groupsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        groupsView.RowHeadersVisible = groupsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы групп была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GroupsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.GroupsFormEnabled = true;
        }
    }
}