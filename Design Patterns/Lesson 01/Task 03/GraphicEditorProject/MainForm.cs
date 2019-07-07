using System;
using System.Windows.Forms;

namespace GraphicEditorProject
{
    partial class MainForm : Form
    {
        private EditorFactory factory = new EditorFactory();
        private Editor graphicEditor;

        public CustomPictureBox CustomPictureBox { get; set; }

        public ToolStripButton ToolStripColor
        {
            get { return toolStripColor; }
        }

        public Panel Panel
        {
            get { return panel; }
        }

        public ToolStripStatusLabel ToolStripStatusLabel
        {
            get { return toolStripStatusLabel; }
        }

        public MainForm()
        {
            InitializeComponent();
            graphicEditor = factory.CreateEditor("Graphic");
            graphicEditor.Obj = this;
            CustomPictureBox = new CustomPictureBox(graphicEditor, this);
            toolStripThickness.SelectedIndex = 0;
            panel.Controls.Add(CustomPictureBox);
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicEditor.Create();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicEditor.Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicEditor.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicEditor.SaveAs();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicEditor.Print();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicEditor.Close(true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = graphicEditor.Close(false);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomPictureBox.Items.Clear();
            CustomPictureBox.Refresh();
            CustomPictureBox.Dock = DockStyle.Fill;
        }

        private void toolStripPencil_Click(object sender, EventArgs e)
        {
            ChangeButtonsState(sender);
            if (toolStripPencil.Checked)
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.PENCIL;
                CustomPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
        }

        private void toolStripLine_Click(object sender, EventArgs e)
        {
            ChangeButtonsState(sender);
            if (toolStripLine.Checked)
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.LINE;
                CustomPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
        }

        private void toolStripRectangle_Click(object sender, EventArgs e)
        {
            ChangeButtonsState(sender);
            if (toolStripRectangle.Checked)
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.RECTANGLE;
                CustomPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
        }

        private void toolStripFilledRectangle_Click(object sender, EventArgs e)
        {
            ChangeButtonsState(sender);
            if (toolStripFilledRectangle.Checked)
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.FILLED_RECTANGLE;
                CustomPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
        }

        private void toolStripEllipse_Click(object sender, EventArgs e)
        {
            ChangeButtonsState(sender);
            if (toolStripEllipse.Checked)
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.ELLIPSE;
                CustomPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
        }

        private void toolStripFilledEllipse_Click(object sender, EventArgs e)
        {
            ChangeButtonsState(sender);
            if (toolStripFilledEllipse.Checked)
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.FILLED_ELLIPSE;
                CustomPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
        }

        private void toolStripBrush_Click(object sender, EventArgs e)
        {
            ChangeButtonsState(sender);
            if (toolStripBrush.Checked)
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.BRUSH;
                CustomPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
        }

        private void toolStripEraser_Click(object sender, EventArgs e)
        {
            ChangeButtonsState(sender);
            if (toolStripEraser.Checked)
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.ERASER;
                CustomPictureBox.Cursor = Cursors.Cross;
            }
            else
            {
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
        }

        private void toolStripThickness_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(toolStripThickness.Text) > 0)
                    CustomPictureBox.Pen.Width = Convert.ToInt32(toolStripThickness.Text);
            }
            catch (Exception) { }
        }

        private void toolStripColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                toolStripColor.BackColor = CustomPictureBox.Pen.Color = cd.Color;
        }

        private void toolStripClear_Click(object sender, EventArgs e)
        {
            CustomPictureBox.Items.Clear();
            CustomPictureBox.Refresh();
            CustomPictureBox.Dock = DockStyle.Fill;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ChangeButtonsState(sender);
                CustomPictureBox.CurrentItem = CustomPictureBox.Item.NONE;
                CustomPictureBox.Cursor = Cursors.Default;
            }
            if (e.Control && e.KeyCode == Keys.Z && CustomPictureBox.Items.Count > 0)
            {
                CustomPictureBox.ItemsBuffer.Add(CustomPictureBox.Items[CustomPictureBox.Items.Count - 1]);
                CustomPictureBox.Items.RemoveAt(CustomPictureBox.Items.Count - 1);
                CustomPictureBox.Invalidate();
            }
            if (e.Control && e.KeyCode == Keys.Y && CustomPictureBox.ItemsBuffer.Count > 0)
            {
                CustomPictureBox.Items.Add(CustomPictureBox.ItemsBuffer[CustomPictureBox.ItemsBuffer.Count - 1]);
                CustomPictureBox.ItemsBuffer.RemoveAt(CustomPictureBox.ItemsBuffer.Count - 1);
                CustomPictureBox.Invalidate();
            }
        }

        void ChangeButtonsState(object sender)
        {
            ToolStripButton toolStripButton = null;
            for (int i = 0; i < toolStrip.Items.Count; i++)
            {
                if (toolStrip.Items[i].GetType() == typeof(ToolStripButton))
                    toolStripButton = (ToolStripButton)toolStrip.Items[i];
                if (toolStripButton != sender)
                    toolStripButton.Checked = false;
            }
        }
    }
}