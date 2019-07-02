using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class StudentsForm : Form
    {
        private ActivityContext context;

        public StudentsForm(ActivityContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                studentsView.DataSource = context.Students.ToList();
                studentsView.Columns[0].Visible = false;
                studentsView.Columns[1].HeaderText = "Full name";
                studentsView.Columns[1].Width = 150;
                studentsView.Columns[2].HeaderText = "Birthdate";
                studentsView.Columns[2].Width = 70;
                studentsView.Columns[3].HeaderText = "Home address";
                studentsView.Columns[3].Width = 270;
                studentsView.Columns[4].HeaderText = "Telephone";
                studentsView.Columns[4].Width = 105;
                studentsView.Columns[5].HeaderText = "University";
                studentsView.Columns[5].Width = 170;
                studentsView.Columns[6].HeaderText = "Course";
                studentsView.Columns[6].Width = 48;
                studentsView.Columns[7].Visible = false;
                studentsView.Columns[8].Visible = false;
                if (studentsView.Rows.Count == 0)
                    studentsView.RowHeadersVisible = studentsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                universityChoice.DataSource = context.Students.Select(s => s.University).Distinct().ToList();
                if (universityChoice.Items.Count > 0)
                    universityChoice.SelectedIndex = 0;
                else
                    universitySearch.Enabled = universityChoiceText.Enabled = universityChoice.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            int maxId;
            if (addStudentForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Student student = new Student();
                    maxId = context.Students.Any() ? context.Students.Select(s => s.StudentId).Max() : 0;
                    student.StudentId = maxId + 1;
                    student.StudentName = addStudentForm.StudentName;
                    student.Birthdate = Convert.ToDateTime(addStudentForm.Birthdate);
                    student.Address = addStudentForm.Address;
                    student.Telephone = addStudentForm.Telephone;
                    student.University = addStudentForm.University;
                    student.Course = addStudentForm.Course.Length > 0 ? Convert.ToInt32(addStudentForm.Course) : 0;
                    context.Students.Add(student);
                    context.SaveChanges();
                    studentsView.DataSource = context.Students.ToList();
                    if (studentsView.Rows.Count > 0)
                        studentsView.RowHeadersVisible = studentsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < studentsView.Rows.Count; i++)
                        if (Convert.ToInt32(studentsView.Rows[i].Cells[0].Value) == maxId + 1)
                            studentsView.Rows[i].Cells[1].Selected = true;
                    universityChoice.DataSource = context.Students.Select(s => s.University).Distinct().ToList();
                    if (universityChoice.Items.Count > 0)
                        universityChoice.SelectedIndex = 0;
                    else
                        universitySearch.Enabled = universityChoiceText.Enabled = universityChoice.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data adding error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditStudentForm editStudentForm = new EditStudentForm();
            int id = Convert.ToInt32(studentsView.CurrentRow.Cells[0].Value);
            editStudentForm.StudentName = studentsView.CurrentRow.Cells[1].Value.ToString();
            editStudentForm.Birthdate = studentsView.CurrentRow.Cells[2].Value.ToString();
            editStudentForm.Address = studentsView.CurrentRow.Cells[3].Value.ToString();
            editStudentForm.Telephone = studentsView.CurrentRow.Cells[4].Value.ToString();
            editStudentForm.University = studentsView.CurrentRow.Cells[5].Value.ToString();
            editStudentForm.Course = studentsView.CurrentRow.Cells[6].Value.ToString();
            if (editStudentForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Student student = context.Students.Find(id);
                    student.StudentName = editStudentForm.StudentName;
                    student.Birthdate = Convert.ToDateTime(editStudentForm.Birthdate);
                    student.Address = editStudentForm.Address;
                    student.Telephone = editStudentForm.Telephone;
                    student.University = editStudentForm.University;
                    student.Course = editStudentForm.Course.Length > 0 ? Convert.ToInt32(editStudentForm.Course) : 0;
                    context.SaveChanges();
                    studentsView.DataSource = context.Students.ToList();
                    if (studentsView.Rows.Count > 0)
                        studentsView.RowHeadersVisible = studentsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < studentsView.Rows.Count; i++)
                        if (Convert.ToInt32(studentsView.Rows[i].Cells[0].Value) == id)
                            studentsView.Rows[i].Cells[1].Selected = true;
                    universityChoice.DataSource = context.Students.Select(s => s.University).Distinct().ToList();
                    if (universityChoice.Items.Count > 0)
                        universityChoice.SelectedIndex = 0;
                    else
                        universitySearch.Enabled = universityChoiceText.Enabled = universityChoice.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Data editing error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = studentsView.CurrentRow.Index;
            int id = Convert.ToInt32(studentsView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to delete student's data?", "Data removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Student student = context.Students.Find(id);
                    context.Students.Remove(student);
                    context.SaveChanges();
                    studentsView.DataSource = context.Students.ToList();
                    if (studentsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        studentsView.Rows[index].Cells[1].Selected = true;
                        universityChoice.DataSource = context.Students.Select(s => s.University).Distinct().ToList();
                        if (universityChoice.Items.Count > 0)
                            universityChoice.SelectedIndex = 0;
                        else
                            universitySearch.Enabled = universityChoiceText.Enabled = universityChoice.Enabled = false;
                    }
                    else
                        studentsView.RowHeadersVisible = studentsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
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

        private void universitySearch_CheckedChanged(object sender, EventArgs e)
        {
            universityChoiceText.Enabled = universityChoice.Enabled = universitySearch.Checked;
        }

        private void search_Click(object sender, EventArgs e)
        {
            studentsView.DataSource = context.Students.Where(s => s.StudentName.Contains(studentNameSearch.Checked ? studentName.Text : "") && s.University == (universitySearch.Checked ? universityChoice.Text : s.University)).ToList();
        }
    }
}