using System;
using System.Windows.Forms;

namespace PeriodCalculation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            days.Checked = true;
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            RadioButton checkedButton = new RadioButton();
            DateTime currentDate = DateTime.Now;
            double periodDuration = 0;
            int checkedButtonNumber = -1;
            try
            {
                for (int i = 0; i < variants.Controls.Count; i++)
                {
                    checkedButton = (RadioButton)variants.Controls[i];
                    if (checkedButton.Checked)
                    {
                        checkedButtonNumber = i;
                        break;
                    }
                }
                switch (checkedButtonNumber)
                {
                    case 5:
                        periodDuration = (Convert.ToDateTime(date.Text) - currentDate).Days;
                        periodDuration = Math.Round(periodDuration / 365, 1);
                        break;
                    case 4:
                        periodDuration = (Convert.ToDateTime(date.Text) - currentDate).Days;
                        periodDuration = Math.Round(periodDuration / 30, 1);
                        break;
                    case 3:
                        periodDuration = (Convert.ToDateTime(date.Text) - currentDate).Days;
                        break;
                    case 2:
                        periodDuration = (Convert.ToDateTime(date.Text) - currentDate).Days * 24;
                        break;
                    case 1:
                        periodDuration = (Convert.ToDateTime(date.Text) - currentDate).Days * 24 * 60;
                        break;
                    case 0:
                        periodDuration = (Convert.ToDateTime(date.Text) - currentDate).Days * 24 * 60 * 60;
                        break;
                }
                if (periodDuration < 0)
                    throw new Exception();
                period.Text = periodDuration.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Дата введена неверно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}