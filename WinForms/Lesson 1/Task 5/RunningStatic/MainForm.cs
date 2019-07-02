using System;
using System.Drawing;
using System.Windows.Forms;

namespace RunningStatic
{
    public partial class MainForm : Form
    {
        private Label staticElement;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int width = 137, height = 20;
            staticElement = new Label();
            staticElement.BorderStyle = BorderStyle.FixedSingle;
            staticElement.BackColor = SystemColors.Info;
            staticElement.Location = new Point(rand.Next(1, ClientSize.Width - width), rand.Next(1, ClientSize.Height - height));
            staticElement.AutoSize = false;
            staticElement.Size = new Size(width, height);
            staticElement.Text = "Статический элемент";
            staticElement.Font = new Font("Microsoft Sans Serif", 9F);
            Controls.Add(staticElement);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            Random rand = new Random();
            if (e.X >= (staticElement.Location.X - 10) && e.Y >= (staticElement.Location.Y - 10) && e.X <= (staticElement.Location.X + staticElement.Width + 10) && e.Y <= (staticElement.Location.Y + staticElement.Height + 10))
            {
                do
                    staticElement.Location = new Point(rand.Next(1, ClientSize.Width - staticElement.Width), rand.Next(1, ClientSize.Height - staticElement.Height));
                while (e.X >= (staticElement.Location.X - 10) && e.Y >= (staticElement.Location.Y - 10) && e.X <= (staticElement.Location.X + staticElement.Width + 10) && e.Y <= (staticElement.Location.Y + staticElement.Height + 10));
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (staticElement.Location.X + staticElement.Width > ClientSize.Width || staticElement.Location.Y + staticElement.Height > ClientSize.Height)
                staticElement.Location = new Point(rand.Next(1, ClientSize.Width - staticElement.Width), rand.Next(1, ClientSize.Height - staticElement.Height));
        }
    }
}