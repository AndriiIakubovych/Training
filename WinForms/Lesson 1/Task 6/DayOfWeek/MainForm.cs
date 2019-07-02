using System;
using System.Windows.Forms;

namespace DayOfWeek
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            DateTime d;
            string[] dayOfWeek = new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
            try
            {
                d = Convert.ToDateTime(date.Text);
                day.Text = dayOfWeek[Convert.ToInt32(d.DayOfWeek) - 1];
            }
            catch (Exception)
            {
                MessageBox.Show("Дата введена неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}