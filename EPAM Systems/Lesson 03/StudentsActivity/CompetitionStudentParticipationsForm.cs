using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class CompetitionStudentParticipationsForm : Form
    {
        private ActivityContext context;

        public CompetitionStudentParticipationsForm(ActivityContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void CompetitionStudentParticipationsForm_Load(object sender, EventArgs e)
        {
            try
            {
                competitionStudentParticipationsView.DataSource = context.CompetitionStudentParticipations.Select(c => new { c.ParticipationId, c.Student.StudentName, c.Competition.CompetitionName, c.ParticipationDate, c.Place, c.Results }).ToList();
                competitionStudentParticipationsView.Columns[0].Visible = false;
                competitionStudentParticipationsView.Columns[1].HeaderText = "Student name";
                competitionStudentParticipationsView.Columns[1].Width = 150;
                competitionStudentParticipationsView.Columns[2].HeaderText = "Competition name";
                competitionStudentParticipationsView.Columns[2].Width = 250;
                competitionStudentParticipationsView.Columns[3].HeaderText = "Participation date";
                competitionStudentParticipationsView.Columns[3].Width = 115;
                competitionStudentParticipationsView.Columns[4].HeaderText = "Place";
                competitionStudentParticipationsView.Columns[4].Width = 270;
                competitionStudentParticipationsView.Columns[5].HeaderText = "Results";
                competitionStudentParticipationsView.Columns[5].Width = 80;
                if (competitionStudentParticipationsView.Rows.Count == 0)
                    competitionStudentParticipationsView.RowHeadersVisible = competitionStudentParticipationsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                competitionNameChoice.DataSource = context.Competitions.Select(c => c.CompetitionName).ToList();
                competitionNameChoice.SelectedIndex = 0;
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
            AddCompetitionStudentParticipationForm addCompetitionStudentParticipationForm = new AddCompetitionStudentParticipationForm(context);
            int maxId;
            if (addCompetitionStudentParticipationForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CompetitionStudentParticipation competitionStudentParticipation = new CompetitionStudentParticipation();
                    maxId = context.CompetitionStudentParticipations.Any() ? context.CompetitionStudentParticipations.Select(c => c.ParticipationId).Max() : 0;
                    competitionStudentParticipation.ParticipationId = maxId + 1;
                    competitionStudentParticipation.StudentId = addCompetitionStudentParticipationForm.StudentId;
                    competitionStudentParticipation.CompetitionId = addCompetitionStudentParticipationForm.CompetitionId;
                    competitionStudentParticipation.ParticipationDate = Convert.ToDateTime(addCompetitionStudentParticipationForm.ParticipationDate);
                    competitionStudentParticipation.Place = addCompetitionStudentParticipationForm.Place;
                    competitionStudentParticipation.Results = addCompetitionStudentParticipationForm.Results;
                    context.CompetitionStudentParticipations.Add(competitionStudentParticipation);
                    context.SaveChanges();
                    competitionStudentParticipationsView.DataSource = context.CompetitionStudentParticipations.Select(c => new { c.ParticipationId, c.Student.StudentName, c.Competition.CompetitionName, c.ParticipationDate, c.Place, c.Results }).ToList();
                    if (competitionStudentParticipationsView.Rows.Count > 0)
                        competitionStudentParticipationsView.RowHeadersVisible = competitionStudentParticipationsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < competitionStudentParticipationsView.Rows.Count; i++)
                        if (Convert.ToInt32(competitionStudentParticipationsView.Rows[i].Cells[0].Value) == maxId + 1)
                            competitionStudentParticipationsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data adding error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditCompetitionStudentParticipationForm editCompetitionStudentParticipationForm = new EditCompetitionStudentParticipationForm(context);
            int id = Convert.ToInt32(competitionStudentParticipationsView.CurrentRow.Cells[0].Value);
            editCompetitionStudentParticipationForm.StudentName = competitionStudentParticipationsView.CurrentRow.Cells[1].Value.ToString();
            editCompetitionStudentParticipationForm.CompetitionName = competitionStudentParticipationsView.CurrentRow.Cells[2].Value.ToString();
            editCompetitionStudentParticipationForm.ParticipationDate = competitionStudentParticipationsView.CurrentRow.Cells[3].Value.ToString();
            editCompetitionStudentParticipationForm.Place = competitionStudentParticipationsView.CurrentRow.Cells[4].Value.ToString();
            editCompetitionStudentParticipationForm.ResultsName = competitionStudentParticipationsView.CurrentRow.Cells[5].Value.ToString();
            if (editCompetitionStudentParticipationForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CompetitionStudentParticipation competitionStudentParticipation = context.CompetitionStudentParticipations.Find(id);
                    competitionStudentParticipation.StudentId = editCompetitionStudentParticipationForm.StudentId;
                    competitionStudentParticipation.CompetitionId = editCompetitionStudentParticipationForm.CompetitionId;
                    competitionStudentParticipation.ParticipationDate = Convert.ToDateTime(editCompetitionStudentParticipationForm.ParticipationDate);
                    competitionStudentParticipation.Place = editCompetitionStudentParticipationForm.Place;
                    competitionStudentParticipation.Results = editCompetitionStudentParticipationForm.Results;
                    context.SaveChanges();
                    competitionStudentParticipationsView.DataSource = context.CompetitionStudentParticipations.Select(c => new { c.ParticipationId, c.Student.StudentName, c.Competition.CompetitionName, c.ParticipationDate, c.Place, c.Results }).ToList();
                    if (competitionStudentParticipationsView.Rows.Count > 0)
                        competitionStudentParticipationsView.RowHeadersVisible = competitionStudentParticipationsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < competitionStudentParticipationsView.Rows.Count; i++)
                        if (Convert.ToInt32(competitionStudentParticipationsView.Rows[i].Cells[0].Value) == id)
                            competitionStudentParticipationsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data editing error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = competitionStudentParticipationsView.CurrentRow.Index;
            int id = Convert.ToInt32(competitionStudentParticipationsView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to delete data of student participation?", "Data removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    CompetitionStudentParticipation competitionStudentParticipation = context.CompetitionStudentParticipations.Find(id);
                    context.CompetitionStudentParticipations.Remove(competitionStudentParticipation);
                    context.SaveChanges();
                    competitionStudentParticipationsView.DataSource = context.CompetitionStudentParticipations.Select(c => new { c.ParticipationId, c.Student.StudentName, c.Competition.CompetitionName, c.ParticipationDate, c.Place, c.Results }).ToList();
                    if (competitionStudentParticipationsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        competitionStudentParticipationsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        competitionStudentParticipationsView.RowHeadersVisible = competitionStudentParticipationsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
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

        private void competitionNameSearch_CheckedChanged(object sender, EventArgs e)
        {
            competitionNameChoiceText.Enabled = competitionNameChoice.Enabled = competitionNameSearch.Checked;
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
            competitionStudentParticipationsView.DataSource = context.CompetitionStudentParticipations.Select(c => new { c.ParticipationId, c.Student.StudentName, c.Competition.CompetitionName, c.ParticipationDate, c.Place, c.Results }).Where(c => c.StudentName.Contains(studentNameSearch.Checked ? studentName.Text : "") && c.CompetitionName == (competitionNameSearch.Checked ? competitionNameChoice.Text : c.CompetitionName) && c.ParticipationDate >= (participationDateSearch.Checked ? startDate.Value.Date : c.ParticipationDate) && c.ParticipationDate <= (participationDateSearch.Checked ? endDate.Value.Date : c.ParticipationDate) && c.Results == (resultsSearch.Checked ? resultsChoice.Text : c.Results)).ToList();
        }
    }
}