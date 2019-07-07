using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class UsersForm : Form
    {
        private HotelContext context;

        public UsersForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            var userQuery = from userItem in context.Users orderby userItem.UserName select userItem;
            usersView.DataSource = userQuery.ToList();
            usersView.Columns[0].Visible = false;
            usersView.Columns[1].HeaderText = "Имя пользователя";
            usersView.Columns[1].Width = 150;
            usersView.Columns[2].Visible = false;
            usersView.Columns[3].HeaderText = "Права администратора";
            usersView.Columns[3].Width = 150;
            if (usersView.Rows.Count == 0)
                usersView.RowHeadersVisible = usersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            int maxId;
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    User user = new User();
                    IEnumerable<int> userIdQuery = from userItem in context.Users select userItem.UserId;
                    maxId = userIdQuery.Max();
                    user.UserId = maxId + 1;
                    user.UserName = addUserForm.UserName;
                    user.UserPassword = addUserForm.UserPassword;
                    user.AdminRights = addUserForm.AdminRights;
                    context.Users.Add(user);
                    context.SaveChanges();
                    var userQuery = from userItem in context.Users orderby userItem.UserName select userItem;
                    usersView.DataSource = userQuery.ToList();
                    if (usersView.Rows.Count > 0)
                        usersView.RowHeadersVisible = usersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < usersView.Rows.Count; i++)
                        if (Convert.ToInt32(usersView.Rows[i].Cells[0].Value) == maxId + 1)
                            usersView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditUserForm editUserForm = new EditUserForm();
            int id = Convert.ToInt32(usersView.CurrentRow.Cells[0].Value);
            editUserForm.UserName = usersView.CurrentRow.Cells[1].Value.ToString();
            editUserForm.UserPassword = usersView.CurrentRow.Cells[2].Value.ToString();
            editUserForm.AdminRights = Convert.ToBoolean(usersView.CurrentRow.Cells[3].Value);
            if (editUserForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    User user = context.Users.Find(id);
                    user.UserName = editUserForm.UserName;
                    user.UserPassword = editUserForm.UserPassword;
                    user.AdminRights = editUserForm.AdminRights;
                    context.SaveChanges();
                    var userQuery = from userItem in context.Users orderby userItem.UserName select userItem;
                    usersView.DataSource = userQuery.ToList();
                    for (int i = 0; i < usersView.Rows.Count; i++)
                        if (Convert.ToInt32(usersView.Rows[i].Cells[0].Value) == id)
                            usersView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = usersView.CurrentRow.Index;
            int id = Convert.ToInt32(usersView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить данные о пользователе?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    User user = context.Users.Find(id);
                    context.Users.Remove(user);
                    context.SaveChanges();
                    var userQuery = from userItem in context.Users orderby userItem.UserName select userItem;
                    usersView.DataSource = userQuery.ToList();
                    if (usersView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        usersView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        usersView.RowHeadersVisible = usersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}