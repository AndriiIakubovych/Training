using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class SpecialtiesForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public SpecialtiesForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void SpecialtiesForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Specialties";
                da.SelectCommand = command;
                da.Fill(dt);
                specialtiesView.DataSource = dt;
                specialtiesView.Columns[0].Visible = false;
                specialtiesView.Columns[1].HeaderText = "Название специальности";
                specialtiesView.Columns[1].Width = 160;
                if (specialtiesView.Rows.Count == 0)
                    specialtiesView.RowHeadersVisible = specialtiesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddSpecialtyForm addSpecialtyForm = new AddSpecialtyForm();
            int maxId = 0;
            if (addSpecialtyForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Specialty_id) AS Max_specialty_id FROM Specialties";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_specialty_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_specialty_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Specialties VALUES (@specialtyId, @specialtyName)";
                    parameter.ParameterName = "@specialtyId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = maxId + 1;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@specialtyName";
                    parameter.DbType = DbType.String;
                    parameter.Value = addSpecialtyForm.SpecialtyName;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    specialtiesView.Update();
                    for (int i = 0; i < specialtiesView.Rows.Count; i++)
                        if (Convert.ToInt32(specialtiesView.Rows[i].Cells[0].Value) == maxId + 1)
                            specialtiesView.Rows[i].Cells[1].Selected = true;
                    if (specialtiesView.Rows.Count > 0)
                        specialtiesView.RowHeadersVisible = specialtiesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу специальностей была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditSpecialtyForm editSpecialtyForm = new EditSpecialtyForm();
            int index = specialtiesView.CurrentRow.Index;
            editSpecialtyForm.SpecialtyName = specialtiesView.CurrentRow.Cells[1].Value.ToString();
            if (editSpecialtyForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Specialties SET Specialty_name = @specialtyName WHERE Specialty_id = @specialtyId";
                    parameter.ParameterName = "@specialtyId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = specialtiesView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@specialtyName";
                    parameter.DbType = DbType.String;
                    parameter.Value = editSpecialtyForm.SpecialtyName;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    specialtiesView.Update();
                    specialtiesView.Rows[index].Cells[1].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице специальностей была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = specialtiesView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данную специальность из таблицы?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Specialties WHERE Specialty_id = @specialtyId";
                    parameter.ParameterName = "@specialtyId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = specialtiesView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    specialtiesView.Update();
                    if (specialtiesView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        specialtiesView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        specialtiesView.RowHeadersVisible = specialtiesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы специальностей была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SpecialtiesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.SpecialtiesFormEnabled = true;
        }
    }
}