using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ObjectsMeasurement
{
    public partial class ScreenForm : Form
    {
        private MainForm mainForm;
        private Label objectWidth;
        private Label objectHeight;
        private int x;
        private int y;
        private int width;
        private int height;
        private bool measure = false;

        public ScreenForm(MainForm mainForm, Label objectWidth, Label objectHeight)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.objectWidth = objectWidth;
            this.objectHeight = objectHeight;
            Location = Screen.FromControl(mainForm).WorkingArea.Location;
        }

        public void UpdateScreenForm()
        {
            Bitmap screenBitmap;
            Graphics graphics;
            Hide();
            Thread.Sleep(200);
            screenBitmap = new Bitmap(Screen.FromControl(mainForm).Bounds.Width, Screen.FromControl(mainForm).Bounds.Height);
            graphics = Graphics.FromImage(screenBitmap as Image);
            graphics.CopyFromScreen(Location.X, Location.Y, 0, 0, screenBitmap.Size);
            using (MemoryStream ms = new MemoryStream())
            {
                screenBitmap.Save(ms, ImageFormat.Bmp);
                pictureBox.Size = new Size(Width, Height);
                pictureBox.Image = Image.FromStream(ms);
            }
            Show();
            Cursor = Cursors.Cross;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                measure = measure ? false : true;
                if (measure)
                {
                    sizeArea.UseFading = false;
                    sizeArea.Active = true;
                }
                else
                {
                    sizeArea.Hide(pictureBox);
                    sizeArea.Active = false;
                    objectWidth.Text = "Ширина: " + width + " px";
                    objectHeight.Text = "Высота: " + height + " px";
                    mainForm.Visible = true;
                    Close();
                }
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (measure)
            {
                width = e.X > x ? e.X - x : x - e.X;
                height = e.Y > y ? e.Y - y : y - e.Y;
                pictureBox.Refresh();
                pictureBox.CreateGraphics().DrawRectangle(new Pen(Color.Black, 1), e.X > x ? x : e.X, e.Y > y ? y : e.Y, width, height);
                sizeArea.Show(width.ToString() + " x " + height.ToString() + " px", pictureBox, e.X > x ? x + width + 5 : x + 5, e.Y > y ? y : e.Y);
            }
        }

        private void ScreenForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                measure = false;
                sizeArea.Hide(pictureBox);
                sizeArea.Active = false;
                mainForm.Visible = true;
                Close();
            }
        }
    }
}