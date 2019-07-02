namespace ObjectsMeasurement
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
            this.sizePanel = new System.Windows.Forms.Panel();
            this.objectWidth = new System.Windows.Forms.Label();
            this.objectHeight = new System.Windows.Forms.Label();
            this.hiddenElement = new System.Windows.Forms.TextBox();
            this.measure = new System.Windows.Forms.Button();
            this.sizePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sizePanel
            // 
            this.sizePanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sizePanel.Controls.Add(this.objectWidth);
            this.sizePanel.Controls.Add(this.objectHeight);
            this.sizePanel.Location = new System.Drawing.Point(0, 0);
            this.sizePanel.Name = "sizePanel";
            this.sizePanel.Size = new System.Drawing.Size(284, 53);
            this.sizePanel.TabIndex = 0;
            // 
            // objectWidth
            // 
            this.objectWidth.AutoSize = true;
            this.objectWidth.Location = new System.Drawing.Point(12, 9);
            this.objectWidth.Name = "objectWidth";
            this.objectWidth.Size = new System.Drawing.Size(72, 13);
            this.objectWidth.TabIndex = 0;
            this.objectWidth.Text = "Ширина: 0 px";
            // 
            // objectHeight
            // 
            this.objectHeight.AutoSize = true;
            this.objectHeight.Location = new System.Drawing.Point(12, 31);
            this.objectHeight.Name = "objectHeight";
            this.objectHeight.Size = new System.Drawing.Size(71, 13);
            this.objectHeight.TabIndex = 1;
            this.objectHeight.Text = "Высота: 0 px";
            // 
            // hiddenElement
            // 
            this.hiddenElement.Location = new System.Drawing.Point(12, 66);
            this.hiddenElement.Name = "hiddenElement";
            this.hiddenElement.Size = new System.Drawing.Size(0, 20);
            this.hiddenElement.TabIndex = 1;
            // 
            // measure
            // 
            this.measure.Image = ((System.Drawing.Image)(resources.GetObject("measure.Image")));
            this.measure.Location = new System.Drawing.Point(85, 64);
            this.measure.Name = "measure";
            this.measure.Size = new System.Drawing.Size(114, 24);
            this.measure.TabIndex = 3;
            this.measure.Text = "Измерить";
            this.measure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.measure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.measure.UseVisualStyleBackColor = true;
            this.measure.Click += new System.EventHandler(this.Measure_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(284, 99);
            this.Controls.Add(this.measure);
            this.Controls.Add(this.hiddenElement);
            this.Controls.Add(this.sizePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Измерение объектов";
            this.sizePanel.ResumeLayout(false);
            this.sizePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sizePanel;
        private System.Windows.Forms.Label objectWidth;
        private System.Windows.Forms.Label objectHeight;
        private System.Windows.Forms.TextBox hiddenElement;
        private System.Windows.Forms.Button measure;
    }
}