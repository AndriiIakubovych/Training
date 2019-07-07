using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TemperatureDataInput
{
    public partial class MainForm : Form
    {
        private Module module;
        private object graphView;
        private Label[] date = new Label[0];
        private NumericUpDown[] dayTemperatures = new NumericUpDown[0];
        private NumericUpDown[] nightTemperatures = new NumericUpDown[0];
        private Label empty;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Module module, object targetWindow)
        {
            this.module = module;
            graphView = targetWindow;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 1900; i <= DateTime.Now.Year; i++)
                yearChoice.Items.Add(i);
            monthChoice.SelectedIndex = DateTime.Now.Month - 1;
            yearChoice.SelectedIndex = yearChoice.Items.Count - 1;
        }

        private void monthChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { CreateDataTable(monthChoice.SelectedIndex + 1, Convert.ToInt32(yearChoice.Text)); }
            catch (Exception) { }
        }

        private void yearChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { CreateDataTable(monthChoice.SelectedIndex + 1, Convert.ToInt32(yearChoice.Text)); }
            catch (Exception) { }
        }

        public void CreateDataTable(int month, int year)
        {
            const int maxTemperature = 50;
            int daysCount = DateTime.DaysInMonth(year, month);
            for (int i = 0; i < date.Length; i++)
            {
                panel.Controls.Remove(date[i]);
                panel.Controls.Remove(dayTemperatures[i]);
                panel.Controls.Remove(nightTemperatures[i]);
            }
            panel.Controls.Remove(empty);
            date = new Label[daysCount];
            dayTemperatures = new NumericUpDown[daysCount];
            nightTemperatures = new NumericUpDown[daysCount];
            empty = new Label();
            for (int i = 0; i < date.Length; i++)
            {
                date[i] = new Label();
                date[i].AutoSize = true;
                date[i].Text = (i + 1 < 10 ? "0" + (i + 1).ToString() : (i + 1).ToString()) + "." + (month < 10 ? "0" + month.ToString() : month.ToString()) + "." + year + ":";
                dayTemperatures[i] = new NumericUpDown();
                nightTemperatures[i] = new NumericUpDown();
                if (i == 0)
                {
                    date[i].Location = new Point((int)Math.Pow(dayTemperatureText.Margin.Left, 2), dayTemperatureText.Location.Y + dayTemperatureText.Height + dayTemperatureText.Margin.Left * 2 + 1);
                    dayTemperatures[i].Location = new Point(dayTemperatureText.Location.X + dayTemperatureText.Margin.Left, dayTemperatureText.Location.Y + dayTemperatureText.Height + dayTemperatureText.Margin.Left + 1);
                    nightTemperatures[i].Location = new Point(nightTemperatureText.Location.X + nightTemperatureText.Margin.Left, nightTemperatureText.Location.Y + nightTemperatureText.Height + nightTemperatureText.Margin.Left + 1);
                }
                else
                {
                    date[i].Location = new Point((int)Math.Pow(dayTemperatureText.Margin.Left, 2), dayTemperatures[i - 1].Location.Y + dayTemperatures[i - 1].Height + dayTemperatureText.Margin.Left * 2 + 1);
                    dayTemperatures[i].Location = new Point(dayTemperatureText.Location.X + dayTemperatureText.Margin.Left, dayTemperatures[i - 1].Location.Y + dayTemperatures[i - 1].Height + dayTemperatureText.Margin.Left + 1);
                    nightTemperatures[i].Location = new Point(nightTemperatureText.Location.X + nightTemperatureText.Margin.Left, nightTemperatures[i - 1].Location.Y + nightTemperatures[i - 1].Height + nightTemperatureText.Margin.Left + 1);
                }
                dayTemperatures[i].Maximum = nightTemperatures[i].Maximum = maxTemperature;
                dayTemperatures[i].Minimum = nightTemperatures[i].Minimum = -maxTemperature;
                dayTemperatures[i].Width = dayTemperatureText.Width - dayTemperatureText.Margin.Left - (int)Math.Pow(dayTemperatureText.Margin.Left, 2);
                nightTemperatures[i].Width = dayTemperatures[i].Width;
                panel.Controls.Add(date[i]);
                panel.Controls.Add(dayTemperatures[i]);
                panel.Controls.Add(nightTemperatures[i]);
            }
            empty.Location = new Point(0, date[date.Length - 1].Location.Y);
            empty.Width = 1;
            panel.Controls.Add(empty);
        }

        private void createGraph_Click(object sender, EventArgs e)
        {
            List<int> dayTemperaturesList = new List<int>();
            List<int> nightTemperaturesList = new List<int>();
            foreach (var dt in dayTemperatures)
                dayTemperaturesList.Add(Convert.ToInt32(dt.Value));
            foreach (var nt in nightTemperatures)
                nightTemperaturesList.Add(Convert.ToInt32(nt.Value));
            try
            {
                module.GetType("TemperatureGraphView.MainForm").GetMethod("CreateGraph").Invoke(graphView, new object[] { monthChoice.Text, yearChoice.Text, dayTemperaturesList, nightTemperaturesList });
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось подключиться к приложению, отвечающему за прорисовку графика!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}