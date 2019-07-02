using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public partial class TeachersSchedulesForm : Form
    {
        private MainForm mainForm;
        private DbConnection connection;
        private DbDataAdapter da;
        private DataTable dt;

        public TeachersSchedulesForm(MainForm mainForm, DbConnection connection, DbDataAdapter da)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.connection = connection;
            this.da = da;
            dt = new DataTable();
        }

        private void TeachersSchedulesForm_Load(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Teacher_name FROM Teachers ORDER BY Teacher_name";
                Task<DbDataReader> reader = command.ExecuteReaderAsync();
                while (reader.Result.Read())
                    teacherChoice.Items.Add(reader.Result.GetString(reader.Result.GetOrdinal("Teacher_name")));
                reader.Result.Close();
                if (teacherChoice.Items.Count > 0)
                {
                    teacherChoice.SelectedIndex = 0;
                    dayChoice.SelectedIndex = 0;
                }
                else
                    teacherChoiceText.Enabled = teacherChoice.Enabled = dayChoiceText.Enabled = dayChoice.Enabled = add.Enabled = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                teacherChoiceText.Enabled = teacherChoice.Enabled = dayChoiceText.Enabled = dayChoice.Enabled = add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void teacherChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DbCommand command = connection.CreateCommand();
                DbParameter parameter = command.CreateParameter();
                command.CommandText = "SELECT Schedule_id, Schedules.Teacher_id, Teacher_name, Schedules.Subject_id, Subject_name, Subject_type, Day_number, Schedules.Bell_id, Bell_begin_time, Bell_end_time, Schedules.Auditorium_id, Auditorium_number, Schedules.Group_id, Group_name FROM Schedules, Groups, Subjects, Bells, Auditoriums, Teachers WHERE Teacher_name = @teacherName AND Day_number = @dayNumber AND Schedules.Group_id = Groups.Group_id AND Schedules.Subject_id = Subjects.Subject_id AND Schedules.Bell_id = Bells.Bell_id AND Schedules.Auditorium_id = Auditoriums.Auditorium_id AND Schedules.Teacher_id = Teachers.Teacher_id ORDER BY Bells.Bell_begin_time";
                parameter.ParameterName = "@teacherName";
                parameter.DbType = DbType.String;
                parameter.Value = teacherChoice.Text;
                command.Parameters.Add(parameter);
                parameter = command.CreateParameter();
                parameter.ParameterName = "@dayNumber";
                parameter.DbType = DbType.Int32;
                parameter.Value = dayChoice.SelectedIndex + 1;
                command.Parameters.Add(parameter);
                da.SelectCommand = command;
                dt.Clear();
                da.Fill(dt);
                schedulesView.DataSource = dt;
                schedulesView.Columns[0].Visible = false;
                schedulesView.Columns[1].Visible = false;
                schedulesView.Columns[2].Visible = false;
                schedulesView.Columns[3].Visible = false;
                schedulesView.Columns[4].HeaderText = "Предмет";
                schedulesView.Columns[4].Width = 170;
                schedulesView.Columns[5].HeaderText = "Тип занятия";
                schedulesView.Columns[5].Width = 130;
                schedulesView.Columns[6].Visible = false;
                schedulesView.Columns[7].Visible = false;
                schedulesView.Columns[8].HeaderText = "Начало занятия";
                schedulesView.Columns[8].Width = 115;
                schedulesView.Columns[9].HeaderText = "Окончание занятия";
                schedulesView.Columns[9].Width = 130;
                schedulesView.Columns[10].Visible = false;
                schedulesView.Columns[11].HeaderText = "Аудитория";
                schedulesView.Columns[11].Width = 120;
                schedulesView.Columns[12].Visible = false;
                schedulesView.Columns[13].HeaderText = "Группа";
                schedulesView.Columns[13].Width = 120;
                schedulesView.RowHeadersVisible = schedulesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = schedulesView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                teacherChoiceText.Enabled = teacherChoice.Enabled = dayChoiceText.Enabled = dayChoice.Enabled = add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void dayChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            teacherChoice_SelectedIndexChanged(sender, e);
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddTeacherScheduleForm addGroupScheduleForm = new AddTeacherScheduleForm(connection);
            int maxId = 0;
            if (addGroupScheduleForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "SELECT MAX(Schedule_id) AS Max_schedule_id FROM Schedules";
                    Task<DbDataReader> reader = command.ExecuteReaderAsync();
                    Task<bool> isNull;
                    while (reader.Result.Read())
                    {
                        isNull = reader.Result.IsDBNullAsync(reader.Result.GetOrdinal("Max_schedule_id"));
                        if (!isNull.Result)
                            maxId = reader.Result.GetInt32(reader.Result.GetOrdinal("Max_schedule_id"));
                    }
                    reader.Result.Close();
                    command.CommandText = "INSERT INTO Schedules VALUES (@scheduleId, @groupId, @subjectId, @subjectType, @dayNumber, @bellId, @auditoriumId, @teacherId)";
                    parameter.ParameterName = "@scheduleId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = maxId + 1;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addGroupScheduleForm.Group;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@subjectId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addGroupScheduleForm.Subject;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@subjectType";
                    parameter.DbType = DbType.String;
                    parameter.Value = addGroupScheduleForm.SubjectType;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@dayNumber";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addGroupScheduleForm.DayNumber;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@bellId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addGroupScheduleForm.Bell;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@auditoriumId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addGroupScheduleForm.Auditorium;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@teacherId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = addGroupScheduleForm.Teacher;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    for (int i = 0; i < teacherChoice.Items.Count; i++)
                        if (teacherChoice.Items[i].ToString() == addGroupScheduleForm.TeacherName)
                        {
                            teacherChoice.SelectedIndex = i;
                            dayChoice.SelectedIndex = addGroupScheduleForm.DayNumber - 1;
                            teacherChoice_SelectedIndexChanged(sender, e);
                            break;
                        }
                    for (int i = 0; i < schedulesView.Rows.Count; i++)
                        if (Convert.ToInt32(schedulesView.Rows[i].Cells[0].Value) == maxId + 1)
                            schedulesView.Rows[i].Cells[4].Selected = true;
                    if (schedulesView.Rows.Count > 0)
                        schedulesView.RowHeadersVisible = schedulesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    mainForm.ToolStripStatusLabelText = "В таблицу расписаний преподавателей была добавлена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditTeacherScheduleForm editTeacherScheduleForm = new EditTeacherScheduleForm(connection);
            int id = Convert.ToInt32(schedulesView.CurrentRow.Cells[0].Value);
            editTeacherScheduleForm.Teacher = Convert.ToInt32(schedulesView.CurrentRow.Cells[1].Value);
            editTeacherScheduleForm.Subject = Convert.ToInt32(schedulesView.CurrentRow.Cells[3].Value);
            editTeacherScheduleForm.SubjectType = schedulesView.CurrentRow.Cells[5].Value.ToString();
            editTeacherScheduleForm.DayNumber = Convert.ToInt32(schedulesView.CurrentRow.Cells[6].Value) - 1;
            editTeacherScheduleForm.Bell = Convert.ToInt32(schedulesView.CurrentRow.Cells[7].Value);
            editTeacherScheduleForm.Auditorium = Convert.ToInt32(schedulesView.CurrentRow.Cells[10].Value);
            editTeacherScheduleForm.Group = Convert.ToInt32(schedulesView.CurrentRow.Cells[12].Value);
            if (editTeacherScheduleForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "UPDATE Schedules SET Group_id = @groupId, Subject_id = @subjectId, Subject_type = @subjectType, Day_number = @dayNumber, Bell_id = @bellId, Auditorium_id = @auditoriumId, Teacher_id = @teacherId WHERE Schedule_id = @scheduleId";
                    parameter.ParameterName = "@scheduleId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = schedulesView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@groupId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editTeacherScheduleForm.Group;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@subjectId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editTeacherScheduleForm.Subject;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@subjectType";
                    parameter.DbType = DbType.String;
                    parameter.Value = editTeacherScheduleForm.SubjectType;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@dayNumber";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editTeacherScheduleForm.DayNumber;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@bellId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editTeacherScheduleForm.Bell;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@auditoriumId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editTeacherScheduleForm.Auditorium;
                    command.Parameters.Add(parameter);
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@teacherId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = editTeacherScheduleForm.Teacher;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    for (int i = 0; i < teacherChoice.Items.Count; i++)
                        if (teacherChoice.Items[i].ToString() == editTeacherScheduleForm.TeacherName)
                        {
                            teacherChoice.SelectedIndex = i;
                            dayChoice.SelectedIndex = editTeacherScheduleForm.DayNumber - 1;
                            teacherChoice_SelectedIndexChanged(sender, e);
                            break;
                        }
                    for (int i = 0; i < schedulesView.Rows.Count - 1; i++)
                        if (Convert.ToInt32(schedulesView.Rows[i].Cells[0].Value) == id)
                            schedulesView.Rows[i].Cells[4].Selected = true;
                    mainForm.ToolStripStatusLabelText = "В таблице расписаний преподавателей была изменена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = schedulesView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данный пункт из расписания?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DbCommand command = connection.CreateCommand();
                    DbParameter parameter = command.CreateParameter();
                    command.CommandText = "DELETE FROM Schedules WHERE Schedule_id = @scheduleId";
                    parameter.ParameterName = "@scheduleId";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = schedulesView.CurrentRow.Cells[0].Value;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQueryAsync();
                    dt.Clear();
                    da.Fill(dt);
                    schedulesView.Update();
                    if (schedulesView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        schedulesView.Rows[index].Cells[4].Selected = true;
                    }
                    else
                        schedulesView.RowHeadersVisible = schedulesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                    mainForm.ToolStripStatusLabelText = "Из таблицы расписаний преподавателей была удалена информация";
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TeachersSchedulesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.TeachersSchedulesFormEnabled = true;
        }
    }
}