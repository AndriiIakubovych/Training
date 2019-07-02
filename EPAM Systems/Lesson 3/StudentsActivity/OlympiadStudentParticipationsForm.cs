using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class OlympiadStudentParticipationsForm : Form
    {
        private ActivityContext context;

        public OlympiadStudentParticipationsForm(ActivityContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void OlympiadStudentParticipationsForm_Load(object sender, EventArgs e)
        {
            try
            {
                olympiadStudentParticipationsView.DataSource = context.OlympiadStudentParticipations.Select(o => new { o.ParticipationId, o.Student.StudentName, o.Olympiad.OlympiadName, o.ParticipationDate, o.Place, o.Results }).ToList();
                olympiadStudentParticipationsView.Columns[0].Visible = false;
                olympiadStudentParticipationsView.Columns[1].HeaderText = "Student name";
                olympiadStudentParticipationsView.Columns[1].Width = 150;
                olympiadStudentParticipationsView.Columns[2].HeaderText = "Olympiad name";
                olympiadStudentParticipationsView.Columns[2].Width = 250;
                olympiadStudentParticipationsView.Columns[3].HeaderText = "Participation date";
                olympiadStudentParticipationsView.Columns[3].Width = 115;
                olympiadStudentParticipationsView.Columns[4].HeaderText = "Place";
                olympiadStudentParticipationsView.Columns[4].Width = 270;
                olympiadStudentParticipationsView.Columns[5].HeaderText = "Results";
                olympiadStudentParticipationsView.Columns[5].Width = 80;
                if (olympiadStudentParticipationsView.Rows.Count == 0)
                    olympiadStudentParticipationsView.RowHeadersVisible = olympiadStudentParticipationsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                olympiadNameChoice.DataSource = context.Olympiads.Select(o => o.OlympiadName).ToList();
                olympiadNameChoice.SelectedIndex = 0;
                resultsChoice.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddOlympiadStudentParticipationForm addOlympiadStudentParticipationForm = new AddOlympiadStudentParticipationForm(context);
            int maxId;
            if (addOlympiadStudentParticipationForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OlympiadStudentParticipation olympiadStudentParticipation = new OlympiadStudentParticipation();
                    maxId = context.OlympiadStudentParticipations.Any() ? context.OlympiadStudentParticipations.Select(o => o.ParticipationId).Max() : 0;
                    olympiadStudentParticipation.ParticipationId = maxId + 1;
                    olympiadStudentParticipation.StudentId = addOlympiadStudentParticipationForm.StudentId;
                    olympiadStudentParticipation.OlympiadId = addOlympiadStudentParticipationForm.OlympiadId;
                    olympiadStudentParticipation.ParticipationDate = Convert.ToDateTime(addOlympiadStudentParticipationForm.ParticipationDate);
                    olympiadStudentParticipation.Place = addOlympiadStudentParticipationForm.Place;
                    olympiadStudentParticipation.Results = addOlympiadStudentParticipationForm.Results;
                    context.OlympiadStudentParticipations.Add(olympiadStudentParticipation);
                    context.SaveChanges();
                    olympiadStudentParticipationsView.DataSource = context.OlympiadStudentParticipations.Select(o => new { o.ParticipationId, o.Student.StudentName, o.Olympiad.OlympiadName, o.ParticipationDate, o.Place, o.Results }).ToList();
                    if (olympiadStudentParticipationsView.Rows.Count > 0)
                        olympiadStudentParticipationsView.RowHeadersVisible = olympiadStudentParticipationsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < olympiadStudentParticipationsView.Rows.Count; i++)
                        if (Convert.ToInt32(olympiadStudentParticipationsView.Rows[i].Cells[0].Value) == maxId + 1)
                            olympiadStudentParticipationsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data adding error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditOlympiadStudentParticipationForm editOlympiadStudentParticipationForm = new EditOlympiadStudentParticipationForm(context);
            int id = Convert.ToInt32(olympiadStudentParticipationsView.CurrentRow.Cells[0].Value);
            editOlympiadStudentParticipationForm.StudentName = olympiadStudentParticipationsView.CurrentRow.Cells[1].Value.ToString();
            editOlympiadStudentParticipationForm.OlympiadName = olympiadStudentParticipationsView.CurrentRow.Cells[2].Value.ToString();
            editOlympiadStudentParticipationForm.ParticipationDate = olympiadStudentParticipationsView.CurrentRow.Cells[3].Value.ToString();
            editOlympiadStudentParticipationForm.Place = olympiadStudentParticipationsView.CurrentRow.Cells[4].Value.ToString();
            editOlympiadStudentParticipationForm.ResultsName = olympiadStudentParticipationsView.CurrentRow.Cells[5].Value.ToString();
            if (editOlympiadStudentParticipationForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OlympiadStudentParticipation olympiadStudentParticipation = context.OlympiadStudentParticipations.Find(id);
                    olympiadStudentParticipation.StudentId = editOlympiadStudentParticipationForm.StudentId;
                    olympiadStudentParticipation.OlympiadId = editOlympiadStudentParticipationForm.OlympiadId;
                    olympiadStudentParticipation.ParticipationDate = Convert.ToDateTime(editOlympiadStudentParticipationForm.ParticipationDate);
                    olympiadStudentParticipation.Place = editOlympiadStudentParticipationForm.Place;
                    olympiadStudentParticipation.Results = editOlympiadStudentParticipationForm.Results;
                    context.SaveChanges();
                    olympiadStudentParticipationsView.DataSource = context.OlympiadStudentParticipations.Select(o => new { o.ParticipationId, o.Student.StudentName, o.Olympiad.OlympiadName, o.ParticipationDate, o.Place, o.Results }).ToList();
                    if (olympiadStudentParticipationsView.Rows.Count > 0)
                        olympiadStudentParticipationsView.RowHeadersVisible = olympiadStudentParticipationsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < olympiadStudentParticipationsView.Rows.Count; i++)
                        if (Convert.ToInt32(olympiadStudentParticipationsView.Rows[i].Cells[0].Value) == id)
                            olympiadStudentParticipationsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data editing error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = olympiadStudentParticipationsView.CurrentRow.Index;
            int id = Convert.ToInt32(olympiadStudentParticipationsView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to delete data of student participation?", "Data removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    OlympiadStudentParticipation olympiadStudentParticipation = context.OlympiadStudentParticipations.Find(id);
                    context.OlympiadStudentParticipations.Remove(olympiadStudentParticipation);
                    context.SaveChanges();
                    olympiadStudentParticipationsView.DataSource = context.OlympiadStudentParticipations.Select(o => new { o.ParticipationId, o.Student.StudentName, o.Olympiad.OlympiadName, o.ParticipationDate, o.Place, o.Results }).ToList();
                    if (olympiadStudentParticipationsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        olympiadStudentParticipationsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        olympiadStudentParticipationsView.RowHeadersVisible = olympiadStudentParticipationsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data removing error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void studentNameSearch_CheckedChanged(object sender, EventArgs e)
        {
            studentNameText.Enabled = studentName.Enabled = studentNameSearch.Checked;
        }

        private void olympiadNameSearch_CheckedChanged(object sender, EventArgs e)
        {
            olympiadNameChoiceText.Enabled = olympiadNameChoice.Enabled = olympiadNameSearch.Checked;
        }

        private void participationDateSearch_CheckedChanged(object sender, EventArgs e)
        {
            participationDateText.Enabled = startDate.Enabled = separator.Enabled = endDate.Enabled = participationDateSearch.Checked;
        }

        private void resultsSearch_CheckedChanged(object sender, EventArgs e)
        {
            resultsChoiceText.Enabled = resultsChoice.Enabled = resultsSearch.Checked;
        }

        private void search_Click(object sender, EventArgs e)
        {
            olympiadStudentParticipationsView.DataSource = context.OlympiadStudentParticipations.Select(o => new { o.ParticipationId, o.Student.StudentName, o.Olympiad.OlympiadName, o.ParticipationDate, o.Place, o.Results }).Where(o => o.StudentName.Contains(studentNameSearch.Checked ? studentName.Text : "") && o.OlympiadName == (olympiadNameSearch.Checked ? olympiadNameChoice.Text : o.OlympiadName) && o.ParticipationDate >= (participationDateSearch.Checked ? startDate.Value.Date : o.ParticipationDate) && o.ParticipationDate <= (participationDateSearch.Checked ? endDate.Value.Date : o.ParticipationDate) && o.Results == (resultsSearch.Checked ? resultsChoice.Text : o.Results)).ToList();
        }
    }
}