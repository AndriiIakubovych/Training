using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class CompetitionsForm : Form
    {
        private ActivityContext context;

        public CompetitionsForm(ActivityContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void CompetitionsForm_Load(object sender, EventArgs e)
        {
            try
            {
                competitionsView.DataSource = context.Competitions.ToList();
                competitionsView.Columns[0].Visible = false;
                competitionsView.Columns[1].HeaderText = "Competition name";
                competitionsView.Columns[1].Width = 250;
                competitionsView.Columns[2].Visible = false;
                if (competitionsView.Rows.Count == 0)
                    competitionsView.RowHeadersVisible = competitionsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddCompetitionForm addCompetitionForm = new AddCompetitionForm();
            int maxId;
            if (addCompetitionForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Competition competition = new Competition();
                    maxId = context.Competitions.Any() ? context.Competitions.Select(c => c.CompetitionId).Max() : 0;
                    competition.CompetitionId = maxId + 1;
                    competition.CompetitionName = addCompetitionForm.CompetitionName;
                    context.Competitions.Add(competition);
                    context.SaveChanges();
                    competitionsView.DataSource = context.Competitions.ToList();
                    if (competitionsView.Rows.Count > 0)
                        competitionsView.RowHeadersVisible = competitionsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < competitionsView.Rows.Count; i++)
                        if (Convert.ToInt32(competitionsView.Rows[i].Cells[0].Value) == maxId + 1)
                            competitionsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data adding error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditCompetitionForm editCompetitionForm = new EditCompetitionForm();
            int id = Convert.ToInt32(competitionsView.CurrentRow.Cells[0].Value);
            editCompetitionForm.CompetitionName = competitionsView.CurrentRow.Cells[1].Value.ToString();
            if (editCompetitionForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Competition competition = context.Competitions.Find(id);
                    competition.CompetitionName = editCompetitionForm.CompetitionName;
                    context.SaveChanges();
                    competitionsView.DataSource = context.Competitions.ToList();
                    if (competitionsView.Rows.Count > 0)
                        competitionsView.RowHeadersVisible = competitionsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < competitionsView.Rows.Count; i++)
                        if (Convert.ToInt32(competitionsView.Rows[i].Cells[0].Value) == id)
                            competitionsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data editing error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = competitionsView.CurrentRow.Index;
            int id = Convert.ToInt32(competitionsView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to delete competition data?", "Data removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Competition competition = context.Competitions.Find(id);
                    context.Competitions.Remove(competition);
                    context.SaveChanges();
                    competitionsView.DataSource = context.Competitions.ToList();
                    if (competitionsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        competitionsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        competitionsView.RowHeadersVisible = competitionsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data removing error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}