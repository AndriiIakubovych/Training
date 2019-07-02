using System.Windows.Forms;

namespace MouseInformation
{
    public partial class MainForm : Form
    {
        private int width;
        private int height;

        public MainForm()
        {
            InitializeComponent();
            width = ClientSize.Width;
            height = ClientSize.Height;
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            int border = 10;
            if (ModifierKeys == Keys.Control)
                Close();
            if (e.Button == MouseButtons.Left)
            {
                if (e.X > border && e.Y > border && e.X < ClientSize.Width - border && e.Y < ClientSize.Height - border)
                    MessageBox.Show("Текущая точка находится внутри прямоугольника!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    if (e.X < border || e.Y < border || e.X > ClientSize.Width - border || e.Y > ClientSize.Height - border)
                        MessageBox.Show("Текущая точка находится снаружи от прямоугольника!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Текущая точка находится на границе прямоугольника!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Button == MouseButtons.Right)
            {
                width = ClientSize.Width;
                height = ClientSize.Height;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "Ширина = " + width + ", высота = " + height + ", x = " + e.X + ", y = " + e.Y;
        }
    }
}