using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TemperatureGraphView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            chart.Series[0].Points.AddXY(1, 1);
        }

        public void CreateGraph(string month, string year, List<int> dayTemperaturesList, List<int> nightTemperaturesList)
        {
            Action action = () =>
            {
                chart.Series[0].Points.Clear();
                chart.Series[1].Points.Clear();
                chart.ChartAreas[0].AxisX.Maximum = dayTemperaturesList.Count;
                chart.Titles[0].Text = "График изменения температуры воздуха за " + month + " " + year;
                for (int i = 0; i < dayTemperaturesList.Count; i++)
                {
                    chart.Series[0].Points.AddXY(i + 1, dayTemperaturesList[i]);
                    chart.Series[1].Points.AddXY(i + 1, nightTemperaturesList[i]);
                }
            };
            Invoke(action);
        }

        private void saveGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.SaveImage("graph.png", ChartImageFormat.Png);
            MessageBox.Show("График сохранён!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}