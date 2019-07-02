using System;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    AddWindow.Visible = EditWindow.Visible = DeleteWindow.Visible = DataErrorInfo.Visible = false;
                    ClientData.DataInitialize();
                    ClientData.CurrentDate = Calendar.TodaysDate;
                    foreach (var n in ClientData.Notes)
                        if (n.BeginningTime.ToShortDateString() == ClientData.CurrentDate.ToShortDateString())
                        {
                            ClientData.NotesIdList.Add(n.NoteId);
                            NotesList.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                        }
                    if (NotesList.Items.Count > 0)
                    {
                        NotesList.SelectedIndex = 0;
                        NotesList_SelectedIndexChanged(sender, e);
                    }
                    CheckEnabled();
                }
                catch (Exception)
                {
                    Calendar.Enabled = NotesList.Enabled = Add.Enabled = Edit.Enabled = Delete.Enabled = Done.Enabled = Description.Enabled = false;
                    Add.ID = "NewAdd";
                    Delete.ID = "NewDelete";
                    Edit.ID = "NewEdit";
                    Delete.ID = "NewDelete";
                    DataErrorInfo.Text = "Ошибка соединения с сервером!";
                    DataErrorInfo.Visible = true;
                }
            }
        }

        private void CheckEnabled()
        {
            if (NotesList.Items.Count > 0)
                Edit.Enabled = Delete.Enabled = Done.Enabled = true;
            else
            {
                Edit.Enabled = Delete.Enabled = Done.Enabled = false;
                Edit.ID = "NewEdit";
                Delete.ID = "NewDelete";
                Done.Checked = false;
            }
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            ClientData.CurrentDate = Calendar.SelectedDate;
            ClientData.NotesIdList.Clear();
            NotesList.Items.Clear();
            Done.Checked = false;
            Description.Text = "";
            foreach (var n in ClientData.Notes)
                if (n.BeginningTime.ToShortDateString() == ClientData.CurrentDate.ToShortDateString())
                {
                    ClientData.NotesIdList.Add(n.NoteId);
                    NotesList.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                }
            if (NotesList.Items.Count > 0)
            {
                NotesList.SelectedIndex = 0;
                NotesList_SelectedIndexChanged(sender, e);
                Edit.Enabled = Delete.Enabled = true;
            }
            CheckEnabled();
        }

        protected void NotesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var n in ClientData.Notes)
                if (n.NoteId == ClientData.NotesIdList[NotesList.SelectedIndex])
                {
                    Done.Checked = n.Done;
                    Description.Text = n.Description;
                    break;
                }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            AddNoteName.Text = AddBeginningTime.Value = AddEndTime.Value = AddDescription.Text = "";
            AddError.Visible = false;
            AddWindow.Visible = true;
            CheckEnabled();
        }

        protected void AddOk_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                if (AddNoteName.Text.Length > 0 && AddBeginningTime.Value.Length > 0 && AddEndTime.Value.Length > 0 && DateTime.Parse(AddEndTime.Value) > DateTime.Parse(AddBeginningTime.Value))
                {
                    AddError.Visible = false;
                    AddWindow.Visible = false;
                    id = ClientData.Client.AddNote(AddNoteName.Text, new DateTime(ClientData.CurrentDate.Year, ClientData.CurrentDate.Month, ClientData.CurrentDate.Day, DateTime.Parse(AddBeginningTime.Value).Hour, DateTime.Parse(AddBeginningTime.Value).Minute, DateTime.Parse(AddBeginningTime.Value).Second), new DateTime(ClientData.CurrentDate.Year, ClientData.CurrentDate.Month, ClientData.CurrentDate.Day, DateTime.Parse(AddEndTime.Value).Hour, DateTime.Parse(AddEndTime.Value).Minute, DateTime.Parse(AddEndTime.Value).Second), AddDescription.Text);
                    ClientData.NotesIdList.Clear();
                    NotesList.Items.Clear();
                    Done.Checked = false;
                    Description.Text = "";
                    ClientData.DataInitialize();
                    foreach (var n in ClientData.Notes)
                        if (n.BeginningTime.ToShortDateString() == ClientData.CurrentDate.ToShortDateString())
                        {
                            ClientData.NotesIdList.Add(n.NoteId);
                            NotesList.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                        }
                    for (int i = 0; i < ClientData.NotesIdList.Count; i++)
                        if (ClientData.NotesIdList[i] == id)
                        {
                            NotesList.SelectedIndex = i;
                            NotesList_SelectedIndexChanged(sender, e);
                            break;
                        }
                    DataErrorInfo.Visible = false;
                }
                else
                    AddError.Visible = true;
                CheckEnabled();
            }
            catch (Exception)
            {
                DataErrorInfo.Text = "Ошибка добавления данных!";
                DataErrorInfo.Visible = true;
            }
        }

        protected void AddCancel_Click(object sender, EventArgs e)
        {
            AddWindow.Visible = false;
            CheckEnabled();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            int id = ClientData.NotesIdList[NotesList.SelectedIndex];
            foreach (var n in ClientData.Notes)
                if (n.NoteId == id)
                {
                    EditNoteName.Text = n.NoteName;
                    EditBeginningTime.Value = n.BeginningTime.ToShortTimeString();
                    EditEndTime.Value = n.EndTime.ToShortTimeString();
                    EditDescription.Text = n.Description;
                    break;
                }
            EditError.Visible = false;
            EditWindow.Visible = true;
            CheckEnabled();
        }

        protected void EditOk_Click(object sender, EventArgs e)
        {
            int id = ClientData.NotesIdList[NotesList.SelectedIndex];
            try
            {
                if (EditNoteName.Text.Length > 0 && EditBeginningTime.Value.Length > 0 && EditEndTime.Value.Length > 0 && DateTime.Parse(EditEndTime.Value) > DateTime.Parse(EditBeginningTime.Value))
                {
                    EditError.Visible = false;
                    EditWindow.Visible = false;
                    ClientData.Client.EditNote(id, EditNoteName.Text, new DateTime(ClientData.CurrentDate.Year, ClientData.CurrentDate.Month, ClientData.CurrentDate.Day, DateTime.Parse(EditBeginningTime.Value).Hour, DateTime.Parse(EditBeginningTime.Value).Minute, DateTime.Parse(EditBeginningTime.Value).Second), new DateTime(ClientData.CurrentDate.Year, ClientData.CurrentDate.Month, ClientData.CurrentDate.Day, DateTime.Parse(EditEndTime.Value).Hour, DateTime.Parse(EditEndTime.Value).Minute, DateTime.Parse(EditEndTime.Value).Second), EditDescription.Text);
                    ClientData.NotesIdList.Clear();
                    NotesList.Items.Clear();
                    Description.Text = "";
                    ClientData.DataInitialize();
                    foreach (var n in ClientData.Notes)
                        if (n.BeginningTime.ToShortDateString() == ClientData.CurrentDate.ToShortDateString())
                        {
                            ClientData.NotesIdList.Add(n.NoteId);
                            NotesList.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                        }
                    for (int i = 0; i < ClientData.NotesIdList.Count; i++)
                        if (ClientData.NotesIdList[i] == id)
                        {
                            NotesList.SelectedIndex = i;
                            NotesList_SelectedIndexChanged(sender, e);
                            DataErrorInfo.Visible = false;
                            break;
                        }
                }
                else
                    EditError.Visible = true;
                CheckEnabled();
            }
            catch (Exception)
            {
                DataErrorInfo.Text = "Ошибка редактирования данных!";
                DataErrorInfo.Visible = true;
            }
        }

        protected void EditCancel_Click(object sender, EventArgs e)
        {
            EditWindow.Visible = false;
            CheckEnabled();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            DeleteWindow.Visible = true;
            CheckEnabled();
        }

        protected void DeleteYes_Click(object sender, EventArgs e)
        {
            int index = NotesList.SelectedIndex;
            try
            {
                ClientData.Client.DeleteNote(ClientData.NotesIdList[index]);
                ClientData.NotesIdList.Clear();
                NotesList.Items.Clear();
                Description.Text = "";
                ClientData.DataInitialize();
                foreach (var n in ClientData.Notes)
                    if (n.BeginningTime.ToShortDateString() == ClientData.CurrentDate.ToShortDateString())
                    {
                        ClientData.NotesIdList.Add(n.NoteId);
                        NotesList.Items.Add(n.NoteName + " (" + n.BeginningTime.ToShortTimeString() + " - " + n.EndTime.ToShortTimeString() + ")");
                    }
                if (NotesList.Items.Count > 0)
                {
                    index = index > 0 ? index - 1 : 0;
                    NotesList.SelectedIndex = index;
                    NotesList_SelectedIndexChanged(sender, e);
                }
                DeleteWindow.Visible = false;
                CheckEnabled();
                DataErrorInfo.Visible = false;
            }
            catch (Exception)
            {
                DataErrorInfo.Text = "Ошибка удаления данных!";
                DataErrorInfo.Visible = true;
            }
        }

        protected void DeleteNo_Click(object sender, EventArgs e)
        {
            DeleteWindow.Visible = false;
            CheckEnabled();
        }

        protected void Done_CheckedChanged(object sender, EventArgs e)
        {
            int id = ClientData.NotesIdList[NotesList.SelectedIndex];
            try
            {
                foreach (var n in ClientData.Notes)
                    if (n.NoteId == id)
                    {
                        ClientData.Client.ChangeNoteState(id);
                        n.Done = !n.Done;
                        DataErrorInfo.Visible = false;
                        break;
                    }
            }
            catch (Exception)
            {
                DataErrorInfo.Text = "Ошибка изменения состояния!";
                DataErrorInfo.Visible = true;
            }
        }
    }
}