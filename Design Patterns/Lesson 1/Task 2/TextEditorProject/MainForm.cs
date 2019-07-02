using System;
using System.Windows.Forms;

namespace TextEditorProject
{
    public partial class MainForm : Form
    {
        private EditorFactory factory = new EditorFactory();
        private Editor textEditor;

        public RichTextBox RichTextBox
        {
            get { return richTextBox; }
        }

        public MainForm()
        {
            InitializeComponent();
            textEditor = factory.CreateEditor("Text");
            textEditor.Obj = this;
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            textEditor.ShowMessage = true;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditor.Create();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditor.Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditor.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditor.SaveAs();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditor.Print();          
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditor.Close(true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = textEditor.Close(false);
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            int hIndex = richTextBox.SelectionStart;
            int line = richTextBox.GetLineFromCharIndex(hIndex);
            int vIndex = richTextBox.GetFirstCharIndexFromLine(line);
            int column = hIndex - vIndex;
            toolStripStatusLabel.Text = "Строка: " + (line + 1) + ", столбец: " + (column + 1);
        }
    }
}