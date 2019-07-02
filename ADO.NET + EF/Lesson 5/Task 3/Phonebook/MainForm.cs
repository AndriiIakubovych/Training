using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Phonebook
{
    public partial class MainForm : Form
    {
        private List<Directory> directoryList;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("directory.dat", FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                directoryList = new List<Directory>();
                directoryList = (List<Directory>)bf.Deserialize(fs);
                fs.Close();
                var directoryQuery = from directoryItem in directoryList select directoryItem;
                directoryView.DataSource = directoryQuery.ToList();
                directoryView.Columns[0].Visible = false;
                directoryView.Columns[1].HeaderText = "Имя";
                directoryView.Columns[1].Width = 200;
                directoryView.Columns[2].HeaderText = "Адрес";
                directoryView.Columns[2].Width = 200;
                directoryView.Columns[3].HeaderText = "Телефон";
                directoryView.Columns[3].Width = 105;
                if (directoryView.Rows.Count == 0)
                    directoryView.RowHeadersVisible = directoryView.ColumnHeadersVisible = sortType.Enabled = noSort.Enabled = nameSort.Enabled = telephoneSort.Enabled = sort.Enabled = edit.Enabled = delete.Enabled = false;
                else
                    directoryView.Rows[0].Cells[1].Selected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void sort_Click(object sender, EventArgs e)
        {
            IEnumerable<Directory> directoryQuery = null;
            if (noSort.Checked)
                directoryQuery = from directoryItem in directoryList select directoryItem;
            if (nameSort.Checked)
                directoryQuery = from directoryItem in directoryList orderby directoryItem.Name select directoryItem;
            if (telephoneSort.Checked)
                directoryQuery = from directoryItem in directoryList orderby directoryItem.Telephone select directoryItem;
            directoryView.DataSource = directoryQuery.ToList();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddRowForm addRowForm = new AddRowForm();
            int maxId;
            FileStream fs;
            BinaryFormatter bf;
            if (addRowForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IEnumerable<int> directoryIdQuery = from directoryItem in directoryList select directoryItem.Id;
                    maxId = directoryIdQuery.Max();
                    directoryList.Add(new Directory(maxId + 1, addRowForm.NameData, addRowForm.Address, addRowForm.Telephone));
                    sort_Click(sender, e);
                    fs = new FileStream("directory.dat", FileMode.Create, FileAccess.ReadWrite);
                    bf = new BinaryFormatter();
                    bf.Serialize(fs, directoryList);
                    fs.Close();
                    if (directoryView.Rows.Count > 0)
                        directoryView.RowHeadersVisible = directoryView.ColumnHeadersVisible = sortType.Enabled = noSort.Enabled = nameSort.Enabled = telephoneSort.Enabled = sort.Enabled = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < directoryView.Rows.Count; i++)
                        if (Convert.ToInt32(directoryView.Rows[i].Cells[0].Value) == maxId + 1)
                            directoryView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditRowForm editRowForm = new EditRowForm();
            int index = directoryView.CurrentRow.Index;
            FileStream fs;
            BinaryFormatter bf;
            editRowForm.NameData = directoryView.CurrentRow.Cells[1].Value.ToString();
            editRowForm.Address = directoryView.CurrentRow.Cells[2].Value.ToString();
            editRowForm.Telephone = directoryView.CurrentRow.Cells[3].Value.ToString();
            if (editRowForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    for (int i = 0; i < directoryList.Count; i++)
                        if (directoryList[i].Id == Convert.ToInt32(directoryView.CurrentRow.Cells[0].Value))
                            directoryList[i] = new Directory(directoryList[i].Id, editRowForm.NameData, editRowForm.Address, editRowForm.Telephone);
                    sort_Click(sender, e);
                    directoryView.Rows[index].Cells[1].Selected = true;
                    fs = new FileStream("directory.dat", FileMode.Create, FileAccess.ReadWrite);
                    bf = new BinaryFormatter();
                    bf.Serialize(fs, directoryList);
                    fs.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирование данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = directoryView.CurrentRow.Index;
            FileStream fs;
            BinaryFormatter bf;
            if (MessageBox.Show("Вы действительно хотите удалить данную запись из справочника?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                directoryList.RemoveAll(d => d.Id == Convert.ToInt32(directoryView.Rows[index].Cells[0].Value));
                sort_Click(sender, e);
                fs = new FileStream("directory.dat", FileMode.Create, FileAccess.ReadWrite);
                bf = new BinaryFormatter();
                bf.Serialize(fs, directoryList);
                fs.Close();
                if (directoryView.Rows.Count > 0)
                {
                    index = index > 0 ? index - 1 : 0;
                    directoryView.Rows[index].Cells[1].Selected = true;
                }
                else
                    directoryView.RowHeadersVisible = directoryView.ColumnHeadersVisible = sortType.Enabled = noSort.Enabled = nameSort.Enabled = telephoneSort.Enabled = sort.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }
    }
}