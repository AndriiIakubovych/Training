using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Statics
{
    public partial class MainForm : Form
    {
        private int x;
        private int y;
        private int staticNumber;
        private bool draw;
        private Label selection;
        private List<Label> statics;

        public MainForm()
        {
            InitializeComponent();
            staticNumber = 0;
            draw = false;
            selection = new Label();
            selection.BorderStyle = BorderStyle.FixedSingle;
            selection.Location = new Point(x, y);
            selection.AutoSize = false;
            selection.BackColor = SystemColors.InactiveCaption;
            selection.Visible = false;
            Controls.Add(selection);
            statics = new List<Label>();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                x = e.X;
                y = e.Y;
                selection.Visible = true;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            int width, height;
            if (draw)
            {
                width = e.X > x ? e.X - x : x - e.X;
                height = e.Y > y ? e.Y - y : y - e.Y;
                selection.Location = new Point(e.X > x ? x : e.X, e.Y > y ? y : e.Y);
                selection.Width = width;
                selection.Height = height;
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            int width, height;
            Label newStatic;
            if (e.Button == MouseButtons.Left)
            {
                draw = false;
                width = e.X > x ? e.X - x : x - e.X;
                height = e.Y > y ? e.Y - y : y - e.Y;
                selection.Visible = false;
                if (width >= 10 && height >= 10)
                {
                    newStatic = new Label();
                    newStatic.BorderStyle = BorderStyle.FixedSingle;
                    newStatic.Location = new Point(e.X > x ? x : e.X, e.Y > y ? y : e.Y);
                    newStatic.AutoSize = false;
                    newStatic.Size = new Size(width, height);
                    newStatic.Text = (staticNumber + 1).ToString();
                    newStatic.Font = new Font("Microsoft Sans Serif", 6F);
                    newStatic.BackColor = SystemColors.Info;
                    statics.Add(newStatic);
                    Controls.Clear();
                    Controls.Add(selection);
                    for (int i = statics.Count - 1; i >= 0; i--)
                        Controls.Add(statics[i]);
                    newStatic.MouseClick += new MouseEventHandler(static_MouseClick);
                    newStatic.DoubleClick += new EventHandler(static_DoubleClick);
                    staticNumber++;
                }
                else
                    if (width != 0 && height != 0)
                    MessageBox.Show("Минимальный размер статического элемента должен быть 10х10!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void static_MouseClick(object sender, MouseEventArgs e)
        {
            Label currentStatic;
            if (e.Button == MouseButtons.Right)
            {
                currentStatic = (Label)sender;
                MessageBox.Show("Площадь элемента: " + (currentStatic.Width * currentStatic.Height).ToString() + " px\nКоординаты элемента: x = " + currentStatic.Location.X.ToString() + ", y = " + currentStatic.Location.Y.ToString(), "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void static_DoubleClick(object sender, EventArgs e)
        {
            Label currentStatic = (Label)sender;
            MouseEventArgs mouse = (MouseEventArgs)e;
            int currentX, currentY;
            currentX = currentStatic.Location.X + mouse.X;
            currentY = currentStatic.Location.Y + mouse.Y;
            for (int i = 0; i < statics.Count; i++)
                if (currentX >= statics[i].Location.X && currentX <= statics[i].Location.X + statics[i].Width && currentY >= statics[i].Location.Y && currentY <= statics[i].Location.Y + statics[i].Height)
                {
                    Controls.Remove(statics[i]);
                    statics.RemoveAt(i);
                    break;
                }
        }
    }
}