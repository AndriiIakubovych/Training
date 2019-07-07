using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class OlympiadsForm : Form
    {
        private ActivityContext context;

        public OlympiadsForm(ActivityContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void OlympiadsForm_Load(object sender, EventArgs e)
        {
            try
            {
                olympiadsView.DataSource = context.Olympiads.ToList();
                olympiadsView.Columns[0].Visible = false;
                olympiadsView.Columns[1].HeaderText = "Olympiad name";
                olympiadsView.Columns[1].Width = 250;
                olympiadsView.Columns[2].Visible = false;
                if (olympiadsView.Rows.Count == 0)
                    olympiadsView.RowHeadersVisible = olympiadsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddOlympiadForm addOlympiadForm = new AddOlympiadForm();
            int maxId;
            if (addOlympiadForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Olympiad olympiad = new Olympiad();
                    maxId = context.Olympiads.Any() ? context.Olympiads.Select(o => o.OlympiadId).Max() : 0;
                    olympiad.OlympiadId = maxId + 1;
                    olympiad.OlympiadName = addOlympiadForm.OlympiadName;
                    context.Olympiads.Add(olympiad);
                    context.SaveChanges();
                    olympiadsView.DataSource = context.Olympiads.ToList();
                    if (olympiadsView.Rows.Count > 0)
                        olympiadsView.RowHeadersVisible = olympiadsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < olympiadsView.Rows.Count; i++)
                        if (Convert.ToInt32(olympiadsView.Rows[i].Cells[0].Value) == maxId + 1)
                            olympiadsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data adding error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditOlympiadForm editOlympiadForm = new EditOlympiadForm();
            int id = Convert.ToInt32(olympiadsView.CurrentRow.Cells[0].Value);
            editOlympiadForm.OlympiadName = olympiadsView.CurrentRow.Cells[1].Value.ToString();
            if (editOlympiadForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Olympiad olympiad = context.Olympiads.Find(id);
                    olympiad.OlympiadName = editOlympiadForm.OlympiadName;
                    context.SaveChanges();
                    olympiadsView.DataSource = context.Olympiads.ToList();
                    if (olympiadsView.Rows.Count > 0)
                        olympiadsView.RowHeadersVisible = olympiadsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < olympiadsView.Rows.Count; i++)
                        if (Convert.ToInt32(olympiadsView.Rows[i].Cells[0].Value) == id)
                            olympiadsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data editing error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = olympiadsView.CurrentRow.Index;
            int id = Convert.ToInt32(olympiadsView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to delete Olympiad data?", "Data removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Olympiad olympiad = context.Olympiads.Find(id);
                    context.Olympiads.Remove(olympiad);
                    context.SaveChanges();
                    olympiadsView.DataSource = context.Olympiads.ToList();
                    if (olympiadsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        olympiadsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        olympiadsView.RowHeadersVisible = olympiadsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data removing error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}