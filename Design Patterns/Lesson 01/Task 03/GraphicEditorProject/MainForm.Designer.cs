namespace GraphicEditorProject
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstSeparatorStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondSeparatorStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripPencil = new System.Windows.Forms.ToolStripButton();
            this.toolStripLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripFilledRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripFilledEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripBrush = new System.Windows.Forms.ToolStripButton();
            this.toolStripEraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripThickness = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripColor = new System.Windows.Forms.ToolStripButton();
            this.secondToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripClear = new System.Windows.Forms.ToolStripButton();
            this.panel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem, this.editToolStripMenuItem });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "Главное меню";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.firstSeparatorStripMenuItem,
            this.printToolStripMenuItem,
            this.secondSeparatorStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.createToolStripMenuItem.Text = "Создать";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // firstSeparatorStripMenuItem
            // 
            this.firstSeparatorStripMenuItem.Name = "firstSeparatorStripMenuItem";
            this.firstSeparatorStripMenuItem.Size = new System.Drawing.Size(222, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.printToolStripMenuItem.Text = "Печать";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // secondSeparatorStripMenuItem
            // 
            this.secondSeparatorStripMenuItem.Name = "secondSeparatorStripMenuItem";
            this.secondSeparatorStripMenuItem.Size = new System.Drawing.Size(222, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.editToolStripMenuItem.Text = "Правка";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.clearToolStripMenuItem.Text = "Очистить";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripPencil, this.toolStripLine, this.toolStripRectangle, this.toolStripFilledRectangle, this.toolStripEllipse, this.toolStripFilledEllipse, this.toolStripBrush, this.toolStripEraser, this.toolStripSeparator, this.toolStripThickness, this.toolStripColor, this.secondToolStripSeparator, this.toolStripClear });
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(684, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "Панель инструментов";
            // 
            // toolStripPencil
            // 
            this.toolStripPencil.CheckOnClick = true;
            this.toolStripPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPencil.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPencil.Image")));
            this.toolStripPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPencil.Name = "toolStripPencil";
            this.toolStripPencil.Size = new System.Drawing.Size(23, 22);
            this.toolStripPencil.Text = "Карандаш";
            this.toolStripPencil.Click += new System.EventHandler(this.toolStripPencil_Click);
            // 
            // toolStripLine
            // 
            this.toolStripLine.CheckOnClick = true;
            this.toolStripLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLine.Image")));
            this.toolStripLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLine.Name = "toolStripLine";
            this.toolStripLine.Size = new System.Drawing.Size(23, 22);
            this.toolStripLine.Text = "Линия";
            this.toolStripLine.Click += new System.EventHandler(this.toolStripLine_Click);
            // 
            // toolStripRectangle
            // 
            this.toolStripRectangle.CheckOnClick = true;
            this.toolStripRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRectangle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRectangle.Image")));
            this.toolStripRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRectangle.Name = "toolStripRectangle";
            this.toolStripRectangle.Size = new System.Drawing.Size(23, 22);
            this.toolStripRectangle.Text = "Прямоугольник";
            this.toolStripRectangle.Click += new System.EventHandler(this.toolStripRectangle_Click);
            // 
            // toolStripFilledRectangle
            // 
            this.toolStripFilledRectangle.CheckOnClick = true;
            this.toolStripFilledRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFilledRectangle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFilledRectangle.Image")));
            this.toolStripFilledRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFilledRectangle.Name = "toolStripFilledRectangle";
            this.toolStripFilledRectangle.Size = new System.Drawing.Size(23, 22);
            this.toolStripFilledRectangle.Text = "Закрашенный прямоугольник";
            this.toolStripFilledRectangle.Click += new System.EventHandler(this.toolStripFilledRectangle_Click);
            // 
            // toolStripEllipse
            // 
            this.toolStripEllipse.CheckOnClick = true;
            this.toolStripEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEllipse.Image")));
            this.toolStripEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEllipse.Name = "toolStripEllipse";
            this.toolStripEllipse.Size = new System.Drawing.Size(23, 22);
            this.toolStripEllipse.Text = "Овал";
            this.toolStripEllipse.Click += new System.EventHandler(this.toolStripEllipse_Click);
            // 
            // toolStripFilledEllipse
            // 
            this.toolStripFilledEllipse.CheckOnClick = true;
            this.toolStripFilledEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFilledEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFilledEllipse.Image")));
            this.toolStripFilledEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFilledEllipse.Name = "toolStripFilledEllipse";
            this.toolStripFilledEllipse.Size = new System.Drawing.Size(23, 22);
            this.toolStripFilledEllipse.Text = "Закрашенный овал";
            this.toolStripFilledEllipse.Click += new System.EventHandler(this.toolStripFilledEllipse_Click);
            // 
            // toolStripBrush
            // 
            this.toolStripBrush.CheckOnClick = true;
            this.toolStripBrush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBrush.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBrush.Image")));
            this.toolStripBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBrush.Name = "toolStripBrush";
            this.toolStripBrush.Size = new System.Drawing.Size(23, 22);
            this.toolStripBrush.Text = "Палитра";
            this.toolStripBrush.Click += new System.EventHandler(this.toolStripBrush_Click);
            // 
            // toolStripEraser
            // 
            this.toolStripEraser.CheckOnClick = true;
            this.toolStripEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripEraser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEraser.Image")));
            this.toolStripEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEraser.Name = "toolStripEraser";
            this.toolStripEraser.Size = new System.Drawing.Size(23, 22);
            this.toolStripEraser.Text = "Резинка";
            this.toolStripEraser.Click += new System.EventHandler(this.toolStripEraser_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripThickness
            // 
            this.toolStripThickness.AutoSize = false;
            this.toolStripThickness.Items.AddRange(new object[] { "1", "5", "10", "15", "20" });
            this.toolStripThickness.Name = "toolStripThickness";
            this.toolStripThickness.Size = new System.Drawing.Size(35, 23);
            this.toolStripThickness.ToolTipText = "Толщина";
            this.toolStripThickness.TextChanged += new System.EventHandler(this.toolStripThickness_TextChanged);
            // 
            // toolStripColor
            // 
            this.toolStripColor.AutoSize = false;
            this.toolStripColor.BackColor = System.Drawing.Color.Black;
            this.toolStripColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripColor.Image")));
            this.toolStripColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColor.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripColor.Name = "toolStripColor";
            this.toolStripColor.Size = new System.Drawing.Size(16, 16);
            this.toolStripColor.Text = "Цвет";
            this.toolStripColor.Click += new System.EventHandler(this.toolStripColor_Click);
            // 
            // secondToolStripSeparator
            // 
            this.secondToolStripSeparator.Name = "secondToolStripSeparator";
            this.secondToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripClear
            // 
            this.toolStripClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClear.Image")));
            this.toolStripClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClear.Name = "toolStripClear";
            this.toolStripClear.Size = new System.Drawing.Size(23, 22);
            this.toolStripClear.Text = "Очистить";
            this.toolStripClear.Click += new System.EventHandler(this.toolStripClear_Click);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 49);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(684, 440);
            this.panel.TabIndex = 4;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 489);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(684, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "Строка состояния";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel.Text = "X: 1, Y: 1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Графический редактор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator firstSeparatorStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator secondSeparatorStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripPencil;
        private System.Windows.Forms.ToolStripButton toolStripLine;
        private System.Windows.Forms.ToolStripButton toolStripRectangle;
        private System.Windows.Forms.ToolStripButton toolStripFilledRectangle;
        private System.Windows.Forms.ToolStripButton toolStripEllipse;
        private System.Windows.Forms.ToolStripButton toolStripFilledEllipse;
        private System.Windows.Forms.ToolStripButton toolStripBrush;
        private System.Windows.Forms.ToolStripButton toolStripEraser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripComboBox toolStripThickness;
        private System.Windows.Forms.ToolStripButton toolStripColor;
        private System.Windows.Forms.ToolStripSeparator secondToolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolStripClear;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}