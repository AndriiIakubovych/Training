using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicEditorProject
{
    class CustomPictureBox : PictureBox
    {
        private Editor editor;
        private MainForm mainForm;
        private Point start = Point.Empty;
        private Point end = Point.Empty;

        public enum Item { NONE, PENCIL, LINE, RECTANGLE, FILLED_RECTANGLE, ELLIPSE, FILLED_ELLIPSE, BRUSH, ERASER }

        public List<Tuple<Item, Pen, Point, Point>> Items { get; set; }
        public List<Tuple<Item, Pen, Point, Point>> ItemsBuffer { get; set; }
        public Pen Pen { get; set; }
        public Item CurrentItem { get; set; }

        public CustomPictureBox(Editor editor, MainForm mainForm)
        {
            this.editor = editor;
            this.mainForm = mainForm;
            BackColor = Color.White;
            Dock = DockStyle.Fill;
            SizeMode = PictureBoxSizeMode.AutoSize;
            DoubleBuffered = true;
            Items = new List<Tuple<Item, Pen, Point, Point>>();
            ItemsBuffer = new List<Tuple<Item, Pen, Point, Point>>();
            Pen = new Pen(Color.Black, 5);
            Pen.StartCap = Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            CurrentItem = Item.NONE;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Bitmap bitmap;
            Graphics graphics;
            Rectangle rect;
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                start = e.Location;
                if (CurrentItem == Item.BRUSH)
                {
                    bitmap = new Bitmap(Width, Height);
                    graphics = Graphics.FromImage(bitmap);
                    rect = RectangleToScreen(ClientRectangle);
                    graphics.CopyFromScreen(rect.Location, Point.Empty, Size);
                    graphics.Dispose();
                    Pen.Color = bitmap.GetPixel(e.X, e.Y);
                    mainForm.ToolStripColor.BackColor = Pen.Color;
                }
            }
            end = Point.Empty;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Pen newPen;
            base.OnMouseMove(e);
            mainForm.ToolStripStatusLabel.Text = "X: " + e.X + ", Y: " + e.Y;
            if (e.Button == MouseButtons.Left)
            {
                end = e.Location;
                if (CurrentItem == Item.PENCIL && !start.IsEmpty)
                {
                    newPen = new Pen(Pen.Color, Pen.Width);
                    newPen.StartCap = newPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    Items.Add(new Tuple<Item, Pen, Point, Point>(CurrentItem, newPen, start, end));
                    start = e.Location;
                    editor.ShowMessage = true;
                }
                if (CurrentItem == Item.ERASER && !start.IsEmpty)
                {
                    newPen = new Pen(BackColor, Pen.Width);
                    newPen.StartCap = newPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    Items.Add(new Tuple<Item, Pen, Point, Point>(CurrentItem, newPen, start, end));
                    start = e.Location;
                    editor.ShowMessage = true;
                }
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Pen newPen;
            base.OnMouseUp(e);
            if (!start.IsEmpty && !end.IsEmpty)
            {
                newPen = new Pen(Pen.Color, Pen.Width);
                newPen.StartCap = newPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                if (CurrentItem != Item.PENCIL && CurrentItem != Item.BRUSH && CurrentItem != Item.ERASER)
                    Items.Add(new Tuple<Item, Pen, Point, Point>(CurrentItem, newPen, start, end));
            }
            start = Point.Empty;
            end = Point.Empty;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var i in Items)
                switch (i.Item1)
                {
                    case Item.PENCIL:
                        e.Graphics.DrawLine(i.Item2, i.Item3, i.Item4);
                        break;
                    case Item.LINE:
                        e.Graphics.DrawLine(i.Item2, i.Item3, i.Item4);
                        break;
                    case Item.RECTANGLE:
                        e.Graphics.DrawRectangle(i.Item2, i.Item4.X > i.Item3.X ? i.Item3.X : i.Item4.X, i.Item4.Y > i.Item3.Y ? i.Item3.Y : i.Item4.Y, i.Item4.X > i.Item3.X ? i.Item4.X - i.Item3.X : i.Item3.X - i.Item4.X, i.Item4.Y > i.Item3.Y ? i.Item4.Y - i.Item3.Y : i.Item3.Y - i.Item4.Y);
                        break;
                    case Item.FILLED_RECTANGLE:
                        e.Graphics.FillRectangle(i.Item2.Brush, i.Item4.X > i.Item3.X ? i.Item3.X : i.Item4.X, i.Item4.Y > i.Item3.Y ? i.Item3.Y : i.Item4.Y, i.Item4.X > i.Item3.X ? i.Item4.X - i.Item3.X : i.Item3.X - i.Item4.X, i.Item4.Y > i.Item3.Y ? i.Item4.Y - i.Item3.Y : i.Item3.Y - i.Item4.Y);
                        break;
                    case Item.ELLIPSE:
                        e.Graphics.DrawEllipse(i.Item2, i.Item4.X > i.Item3.X ? i.Item3.X : i.Item4.X, i.Item4.Y > i.Item3.Y ? i.Item3.Y : i.Item4.Y, i.Item4.X > i.Item3.X ? i.Item4.X - i.Item3.X : i.Item3.X - i.Item4.X, i.Item4.Y > i.Item3.Y ? i.Item4.Y - i.Item3.Y : i.Item3.Y - i.Item4.Y);
                        break;
                    case Item.FILLED_ELLIPSE:
                        e.Graphics.FillEllipse(i.Item2.Brush, i.Item4.X > i.Item3.X ? i.Item3.X : i.Item4.X, i.Item4.Y > i.Item3.Y ? i.Item3.Y : i.Item4.Y, i.Item4.X > i.Item3.X ? i.Item4.X - i.Item3.X : i.Item3.X - i.Item4.X, i.Item4.Y > i.Item3.Y ? i.Item4.Y - i.Item3.Y : i.Item3.Y - i.Item4.Y);
                        break;
                    case Item.ERASER:
                        e.Graphics.DrawLine(i.Item2, i.Item3, i.Item4);
                        break;
                }
            if (!start.IsEmpty && !end.IsEmpty)
                switch (CurrentItem)
                {
                    case Item.LINE:
                        e.Graphics.DrawLine(Pen, start, end);
                        editor.ShowMessage = true;
                        break;
                    case Item.RECTANGLE:
                        e.Graphics.DrawRectangle(Pen, end.X > start.X ? start.X : end.X, end.Y > start.Y ? start.Y : end.Y, end.X > start.X ? end.X - start.X : start.X - end.X, end.Y > start.Y ? end.Y - start.Y : start.Y - end.Y);
                        editor.ShowMessage = true;
                        break;
                    case Item.FILLED_RECTANGLE:
                        e.Graphics.FillRectangle(Pen.Brush, end.X > start.X ? start.X : end.X, end.Y > start.Y ? start.Y : end.Y, end.X > start.X ? end.X - start.X : start.X - end.X, end.Y > start.Y ? end.Y - start.Y : start.Y - end.Y);
                        editor.ShowMessage = true;
                        break;
                    case Item.ELLIPSE:
                        e.Graphics.DrawEllipse(Pen, end.X > start.X ? start.X : end.X, end.Y > start.Y ? start.Y : end.Y, end.X > start.X ? end.X - start.X : start.X - end.X, end.Y > start.Y ? end.Y - start.Y : start.Y - end.Y);
                        editor.ShowMessage = true;
                        break;
                    case Item.FILLED_ELLIPSE:
                        e.Graphics.FillEllipse(Pen.Brush, end.X > start.X ? start.X : end.X, end.Y > start.Y ? start.Y : end.Y, end.X > start.X ? end.X - start.X : start.X - end.X, end.Y > start.Y ? end.Y - start.Y : start.Y - end.Y);
                        editor.ShowMessage = true;
                        break;
                }
        }
    }
}