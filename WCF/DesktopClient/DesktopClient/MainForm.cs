using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DesktopClient.ServiceReference;

namespace DesktopClient
{
    public partial class MainForm : Form
    {
        private ServiceClient client;
        private Note[] notes;
        private DateTime currentDate;
        private List<int> notesIdList;
        private bool canChangeState;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            client = new ServiceClient();
            notesIdList = new List<int>();
            try
            {
                notes = client.GetNotes();
                currentDate = DateTime.Now;
                canChangeState = false;
                foreach (var n in notes)
                    if (n.BeginningTime.ToShortDateString() == currentDate.ToShortDateString())
                    {
                        notesIdList.Add(n.NoteId);
                        checkedListBox.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                        if (n.Done)
                            checkedListBox.SetItemCheckState(checkedListBox.Items.Count - 1, CheckState.Checked);
                    }
                if (checkedListBox.Items.Count > 0)
                    checkedListBox.SelectedIndex = 0;
                else
                    edit.Enabled = delete.Enabled = false;
                canChangeState = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с сервером!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void monthView_SelectionChanged(object sender, EventArgs e)
        {
            currentDate = monthView.SelectionStart.Date;
            notesIdList.Clear();
            checkedListBox.Items.Clear();
            description.Clear();
            canChangeState = false;
            foreach (var n in notes)
                if (n.BeginningTime.ToShortDateString() == currentDate.ToShortDateString())
                {
                    notesIdList.Add(n.NoteId);
                    checkedListBox.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                    if (n.Done)
                        checkedListBox.SetItemCheckState(checkedListBox.Items.Count - 1, CheckState.Checked);
                }
            if (checkedListBox.Items.Count > 0)
            {
                checkedListBox.SelectedIndex = 0;
                edit.Enabled = delete.Enabled = true;
            }
            else
                edit.Enabled = delete.Enabled = false;
            canChangeState = true;
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var n in notes)
                if (n.NoteId == notesIdList[checkedListBox.SelectedIndex])
                {
                    description.Text = n.Description;
                    break;
                }
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int id;
            try
            {
                if (canChangeState)
                {
                    id = notesIdList[checkedListBox.SelectedIndex];
                    foreach (var n in notes)
                        if (n.NoteId == id)
                        {
                            client.ChangeNoteState(id);
                            n.Done = !n.Done;
                            break;
                        }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка изменения состояния!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddNoteForm addNoteForm = new AddNoteForm();
            int id = 0;
            if (addNoteForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    id = client.AddNote(addNoteForm.NoteName, new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, addNoteForm.BeginningTime.Hour, addNoteForm.BeginningTime.Minute, 0), new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, addNoteForm.EndTime.Hour, addNoteForm.EndTime.Minute, 0), addNoteForm.Description);
                    notesIdList.Clear();
                    checkedListBox.Items.Clear();
                    description.Clear();
                    notes = client.GetNotes();
                    canChangeState = false;
                    foreach (var n in notes)
                        if (n.BeginningTime.ToShortDateString() == currentDate.ToShortDateString())
                        {
                            notesIdList.Add(n.NoteId);
                            checkedListBox.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                            if (n.Done)
                                checkedListBox.SetItemCheckState(checkedListBox.Items.Count - 1, CheckState.Checked);
                        }
                    for (int i = 0; i < notesIdList.Count; i++)
                        if (notesIdList[i] == id)
                        {
                            checkedListBox.SelectedIndex = i;
                            break;
                        }
                    edit.Enabled = delete.Enabled = checkedListBox.Items.Count > 0;
                    canChangeState = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditNoteForm editNoteForm = new EditNoteForm();
            int id = notesIdList[checkedListBox.SelectedIndex];
            foreach (var n in notes)
                if (n.NoteId == id)
                {
                    editNoteForm.NoteName = n.NoteName;
                    editNoteForm.BeginningTime = n.BeginningTime;
                    editNoteForm.EndTime = n.EndTime;
                    editNoteForm.Description = n.Description;
                    break;
                }
            if (editNoteForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    client.EditNote(id, editNoteForm.NoteName, new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, editNoteForm.BeginningTime.Hour, editNoteForm.BeginningTime.Minute, 0), new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, editNoteForm.EndTime.Hour, editNoteForm.EndTime.Minute, 0), editNoteForm.Description);
                    notesIdList.Clear();
                    checkedListBox.Items.Clear();
                    description.Clear();
                    notes = client.GetNotes();
                    canChangeState = false;
                    foreach (var n in notes)
                        if (n.BeginningTime.ToShortDateString() == currentDate.ToShortDateString())
                        {
                            notesIdList.Add(n.NoteId);
                            checkedListBox.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                            if (n.Done)
                                checkedListBox.SetItemCheckState(checkedListBox.Items.Count - 1, CheckState.Checked);
                        }
                    for (int i = 0; i < notesIdList.Count; i++)
                        if (notesIdList[i] == id)
                        {
                            checkedListBox.SelectedIndex = i;
                            break;
                        }
                    canChangeState = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = checkedListBox.SelectedIndex;
            if (MessageBox.Show("Вы действительно хотите удалить данную заметку?", "Удаление заметки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    client.DeleteNote(notesIdList[index]);
                    notesIdList.Clear();
                    checkedListBox.Items.Clear();
                    description.Clear();
                    notes = client.GetNotes();
                    canChangeState = false;
                    foreach (var n in notes)
                        if (n.BeginningTime.ToShortDateString() == currentDate.ToShortDateString())
                        {
                            notesIdList.Add(n.NoteId);
                            checkedListBox.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                            if (n.Done)
                                checkedListBox.SetItemCheckState(checkedListBox.Items.Count - 1, CheckState.Checked);
                        }
                    if (checkedListBox.Items.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        checkedListBox.SelectedIndex = index;
                    }
                    else
                        edit.Enabled = delete.Enabled = false;
                    canChangeState = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}