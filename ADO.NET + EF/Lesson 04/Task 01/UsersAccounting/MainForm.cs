using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace UsersAccounting
{
    public partial class MainForm : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter da;
        private DataTable dt;
        private string password;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                connection = new SqlConnection();
                connection.ConnectionString = "Data Source = .\\SQLEXPRESS; Initial Catalog = Users; Integrated Security = True";
                da = new SqlDataAdapter();
                dt = new DataTable();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Users ORDER BY User_login";
                da.SelectCommand = command;
                da.Fill(dt);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void allUsers_CheckedChanged(object sender, EventArgs e)
        {
            DataRow[] rows;
            usersList.Items.Clear();
            userPassword.Clear();
            address.Clear();
            telephone.Clear();
            userType.Clear();
            if (allUsers.Checked)
                rows = dt.Select();
            else
                rows = dt.Select("Admin_rights = 1");
            foreach (DataRow r in rows)
                usersList.Items.Add(r["User_login"]);
            if (usersList.Items.Count > 0)
                usersList.SelectedIndex = 0;
            userInformation.Enabled = userPasswordText.Enabled = userPassword.Enabled = addressText.Enabled = address.Enabled = telephoneText.Enabled = telephone.Enabled = userTypeText.Enabled = userType.Enabled = delete.Enabled = usersList.Items.Count > 0;
        }

        private void usersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow row;
            for (int i = 0; i < dt.Rows.Count; i++)
                if (dt.Rows[i]["User_login"].ToString() == usersList.SelectedItem.ToString())
                {
                    row = dt.Rows[i];
                    password = row["User_password"].ToString();
                    userPassword.Text = row["User_password"].GetHashCode().ToString();
                    address.Text = row["Address"].ToString();
                    telephone.Text = row["Telephone"].ToString();
                    userType.Text = Convert.ToBoolean(row["Admin_rights"]) ? "Есть" : "Нет";
                    break;
                }
        }

        private void usersList_DoubleClick(object sender, MouseEventArgs e)
        {
            EditUserForm editUserForm;
            if (usersList.Items.Count > 0 && usersList.IndexFromPoint(e.Location) != ListBox.NoMatches)
            {
                editUserForm = new EditUserForm(connection, usersList.SelectedItem.ToString());
                editUserForm.UserLogin = usersList.SelectedItem.ToString();
                editUserForm.UserPassword = userPassword.Text;
                editUserForm.Address = address.Text;
                editUserForm.Telephone = telephone.Text;
                editUserForm.HasAdminRights = userType.Text == "Есть" ? true : false;
                if (editUserForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = "UPDATE Users SET User_login = @userLogin, User_password = @userPassword, Address = @address, Telephone = @telephone, Admin_rights = @adminRights WHERE User_login = @requiredUserLogin";
                        command.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = editUserForm.UserLogin;
                        command.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = editUserForm.UserPassword == userPassword.Text ? password : editUserForm.UserPassword;
                        command.Parameters.Add("@address", SqlDbType.VarChar).Value = editUserForm.Address;
                        command.Parameters.Add("@telephone", SqlDbType.VarChar).Value = editUserForm.Telephone;
                        command.Parameters.Add("@adminRights", SqlDbType.Bit).Value = editUserForm.HasAdminRights ? 1 : 0;
                        command.Parameters.Add("@requiredUserLogin", SqlDbType.VarChar).Value = usersList.SelectedItem;
                        command.ExecuteNonQuery();
                        dt.Clear();
                        da.Fill(dt);
                        usersList.Items.Clear();
                        if (!editUserForm.HasAdminRights)
                            allUsers.Checked = true;
                        allUsers_CheckedChanged(sender, e);
                        for (int i = 0; i < usersList.Items.Count; i++)
                            if (usersList.Items[i].ToString() == editUserForm.UserLogin)
                            {
                                usersList.SelectedIndex = i;
                                break;
                            }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(connection);
            int maxId = 0;
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT MAX(User_id) AS Max_user_id FROM Users";
                    SqlDataReader reader = command.ExecuteReader();
                    bool isNull;
                    while (reader.Read())
                    {
                        isNull = reader.IsDBNull(reader.GetOrdinal("Max_user_id"));
                        if (!isNull)
                            maxId = reader.GetInt32(reader.GetOrdinal("Max_user_id"));
                    }
                    reader.Close();
                    command.CommandText = "INSERT INTO Users VALUES (@userId, @userLogin, @userPassword, @address, @telephone, @adminRights)";
                    command.Parameters.Add("@userId", SqlDbType.Int).Value = maxId + 1;
                    command.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = addUserForm.UserLogin;
                    command.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = addUserForm.UserPassword;
                    command.Parameters.Add("@address", SqlDbType.VarChar).Value = addUserForm.Address;
                    command.Parameters.Add("@telephone", SqlDbType.VarChar).Value = addUserForm.Telephone;
                    command.Parameters.Add("@adminRights", SqlDbType.Bit).Value = addUserForm.HasAdminRights ? 1 : 0;
                    command.ExecuteNonQuery();
                    dt.Clear();
                    da.Fill(dt);
                    usersList.Items.Clear();
                    allUsers.Checked = true;
                    allUsers_CheckedChanged(sender, e);
                    for (int i = 0; i < usersList.Items.Count; i++)
                        if (usersList.Items[i].ToString() == addUserForm.UserLogin)
                        {
                            usersList.SelectedIndex = i;
                            break;
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = usersList.SelectedIndex;
            if (MessageBox.Show("Вы действительно хотите удалить данного пользователя?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Users WHERE User_login = @userLogin";
                    command.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = usersList.SelectedItem;
                    command.ExecuteNonQuery();
                    dt.Clear();
                    da.Fill(dt);
                    usersList.Items.Clear();
                    allUsers_CheckedChanged(sender, e);
                    if (usersList.Items.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        usersList.SelectedIndex = index;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }
    }
}