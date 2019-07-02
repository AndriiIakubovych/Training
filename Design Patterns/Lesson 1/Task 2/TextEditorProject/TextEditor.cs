using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace TextEditorProject
{
    class TextEditor : Editor
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
                    mainForm.RichTextBox.Clear();
                    ShowMessage = false;
                }
            }
            else
                mainForm.RichTextBox.Clear();
        }

        public override void Open()
        {
            MainForm mainForm = (MainForm)Obj;
            StreamReader sr;
            YesNoCancelForm yesNoCancelForm;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Открытие";
            ofd.Filter = "Текстовые документы|*.txt";
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
                sr = new StreamReader(ofd.FileName);
                mainForm.RichTextBox.Text = sr.ReadToEnd();
                ShowMessage = false;
                sr.Close();
            }
        }

        public override void Save()
        {
            MainForm mainForm = (MainForm)Obj;
            string[] text;
            StreamWriter sw;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранение";
            sfd.Filter = "Текстовые документы|*.txt";
            if (FileName.Length == 0)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    text = mainForm.RichTextBox.Text.Split('\n');
                    sw = new StreamWriter(sfd.FileName);
                    for (int i = 0; i < text.Length; i++)
                        sw.WriteLine(text[i]);
                    ShowMessage = false;
                    sw.Close();
                }
            }
            else
            {
                text = mainForm.RichTextBox.Text.Split('\n');
                sw = new StreamWriter(FileName);
                for (int i = 0; i < text.Length; i++)
                    sw.WriteLine(text[i]);
                ShowMessage = false;
                sw.Close();
            }
        }

        public override void SaveAs()
        {
            MainForm mainForm = (MainForm)Obj;
            string[] text;
            StreamWriter sw;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранение";
            sfd.FileName = Path.GetFileNameWithoutExtension(FileName);
            sfd.Filter = "Текстовые документы|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                text = mainForm.RichTextBox.Text.Split('\n');
                sw = new StreamWriter(sfd.FileName);
                for (int i = 0; i < text.Length; i++)
                    sw.WriteLine(text[i]);
                ShowMessage = false;
                sw.Close();
            }
        }

        protected override void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            MainForm mainForm = (MainForm)Obj;
            e.Graphics.DrawString(mainForm.RichTextBox.Text, mainForm.RichTextBox.Font, System.Drawing.Brushes.Black, new System.Drawing.Point(100, 100));
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