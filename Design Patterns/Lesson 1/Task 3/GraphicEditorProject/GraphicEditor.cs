using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace GraphicEditorProject
{
    class GraphicEditor : Editor
    {
        public override void Create()
        {
            MainForm mainForm = (MainForm)Obj;
            YesNoCancelForm yesNoCancelForm;
            if (ShowMessage)
            {
                yesNoCancelForm = new YesNoCancelForm();
                if (yesNoCancelForm.ShowDialog() == DialogResult.OK)
                {
                    if (yesNoCancelForm.YesClick)
                        Save();
                    mainForm.CustomPictureBox.Items.Clear();
                    mainForm.CustomPictureBox.Refresh();
                    mainForm.CustomPictureBox.Dock = DockStyle.Fill;
                    ShowMessage = false;
                }
            }
            else
            {
                mainForm.CustomPictureBox.Items.Clear();
                mainForm.CustomPictureBox.Refresh();
                mainForm.CustomPictureBox.Dock = DockStyle.Fill;
            }
        }

        public override void Open()
        {
            MainForm mainForm = (MainForm)Obj;
            YesNoCancelForm yesNoCancelForm;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Открытие";
            ofd.Filter = "Файлы изображений|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if (ShowMessage)
            {
                yesNoCancelForm = new YesNoCancelForm();
                if (yesNoCancelForm.ShowDialog() == DialogResult.OK)
                {
                    if (yesNoCancelForm.YesClick)
                        Save();
                    ShowMessage = false;
                }
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileName = ofd.FileName;
                mainForm.CustomPictureBox.Image = (Image)Image.FromFile(ofd.FileName).Clone();
                if (mainForm.CustomPictureBox.Image.Width > mainForm.CustomPictureBox.Width || mainForm.CustomPictureBox.Image.Height > mainForm.CustomPictureBox.Height)
                    mainForm.CustomPictureBox.Dock = DockStyle.None;
                mainForm.CustomPictureBox.Items.Clear();
                ShowMessage = false;
            }
        }

        public override void Save()
        {
            MainForm mainForm = (MainForm)Obj;
            Bitmap bitmap;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранение";
            sfd.Filter = "JPEG (*jpg; *.jpeg)|*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|WMF (*.wmf)|*.wmf";
            if (FileName.Length == 0)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bitmap = new Bitmap(mainForm.CustomPictureBox.Width, mainForm.CustomPictureBox.Height);
                    mainForm.CustomPictureBox.DrawToBitmap(bitmap, mainForm.CustomPictureBox.Bounds);
                    switch (Path.GetExtension(sfd.FileName))
                    {
                        case ".jpg":
                            bitmap.Save(sfd.FileName, ImageFormat.Jpeg);
                            break;
                        case ".png":
                            bitmap.Save(sfd.FileName, ImageFormat.Png);
                            break;
                        case ".gif":
                            bitmap.Save(sfd.FileName, ImageFormat.Gif);
                            break;
                        case ".bmp":
                            bitmap.Save(sfd.FileName, ImageFormat.Bmp);
                            break;
                        case ".wmf":
                            bitmap.Save(sfd.FileName, ImageFormat.Wmf);
                            break;
                    }
                    bitmap.Dispose();
                    ShowMessage = false;
                }
            }
            else
            {
                bitmap = new Bitmap(mainForm.CustomPictureBox.Width, mainForm.CustomPictureBox.Height);
                mainForm.CustomPictureBox.DrawToBitmap(bitmap, mainForm.CustomPictureBox.Bounds);
                switch (Path.GetExtension(sfd.FileName))
                {
                    case ".jpg":
                        bitmap.Save(sfd.FileName, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        bitmap.Save(sfd.FileName, ImageFormat.Png);
                        break;
                    case ".gif":
                        bitmap.Save(sfd.FileName, ImageFormat.Gif);
                        break;
                    case ".bmp":
                        bitmap.Save(sfd.FileName, ImageFormat.Bmp);
                        break;
                    case ".wmf":
                        bitmap.Save(sfd.FileName, ImageFormat.Wmf);
                        break;
                }
                bitmap.Dispose();
                ShowMessage = false;
            }
        }

        public override void SaveAs()
        {
            MainForm mainForm = (MainForm)Obj;
            Bitmap bitmap;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранение";
            sfd.FileName = Path.GetFileNameWithoutExtension(FileName);
            sfd.Filter = "JPEG (*jpg; *.jpeg)|*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|WMF (*.wmf)|*.wmf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bitmap = new Bitmap(mainForm.CustomPictureBox.Width, mainForm.CustomPictureBox.Height);
                mainForm.CustomPictureBox.DrawToBitmap(bitmap, mainForm.CustomPictureBox.Bounds);
                switch (Path.GetExtension(sfd.FileName))
                {
                    case ".jpg":
                        bitmap.Save(sfd.FileName, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        bitmap.Save(sfd.FileName, ImageFormat.Png);
                        break;
                    case ".gif":
                        bitmap.Save(sfd.FileName, ImageFormat.Gif);
                        break;
                    case ".bmp":
                        bitmap.Save(sfd.FileName, ImageFormat.Bmp);
                        break;
                    case ".wmf":
                        bitmap.Save(sfd.FileName, ImageFormat.Wmf);
                        break;
                }
                bitmap.Dispose();
                ShowMessage = false;
            }
        }

        protected override void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            MainForm mainForm = (MainForm)Obj;
            Bitmap bitmap = new Bitmap(mainForm.CustomPictureBox.Width, mainForm.CustomPictureBox.Height);
            mainForm.CustomPictureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, mainForm.CustomPictureBox.Width, mainForm.CustomPictureBox.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
            bitmap.Dispose();
        }

        public override void Print()
        {
            MainForm mainForm = (MainForm)Obj;
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.ShowIcon = false;
            ((Form)ppd).WindowState = FormWindowState.Maximized;
            ppd.Document = PrintDocument;
            if (ppd.ShowDialog() == DialogResult.OK)
                PrintDocument.Print();
        }

        public override bool Close(bool flag)
        {
            MainForm mainForm = (MainForm)Obj;
            YesNoCancelForm yesNoCancelForm;
            if (ShowMessage)
            {
                yesNoCancelForm = new YesNoCancelForm();
                if (yesNoCancelForm.ShowDialog() == DialogResult.OK)
                {
                    if (yesNoCancelForm.YesClick)
                        Save();
                    if (flag)
                        mainForm.Close();
                    return false;
                }
                return true;
            }
            else
            {
                if (flag)
                    mainForm.Close();
                return false;
            }
        }
    }
}