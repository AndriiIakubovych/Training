namespace StudentsActivity
{
    partial class EditOlympiadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOlympiadForm));
            this.olympiadNameText = new System.Windows.Forms.Label();
            this.olympiadName = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // olympiadNameText
            // 
            this.olympiadNameText.AutoSize = true;
            this.olympiadNameText.Location = new System.Drawing.Point(9, 9);
            this.olympiadNameText.Name = "olympiadNameText";
            this.olympiadNameText.Size = new System.Drawing.Size(82, 13);
            this.olympiadNameText.TabIndex = 4;
            this.olympiadNameText.Text = "Olympiad name:";
            // 
            // olympiadName
            // 
            this.olympiadName.Location = new System.Drawing.Point(12, 25);
            this.olympiadName.MaxLength = 255;
            this.olympiadName.Name = "olympiadName";
            this.olympiadName.Size = new System.Drawing.Size(300, 20);
            this.olympiadName.TabIndex = 5;
            this.olympiadName.TextChanged += new System.EventHandler(this.olympiadName_TextChanged);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Image = ((System.Drawing.Image)(resources.GetObject("ok.Image")));
            this.ok.Location = new System.Drawing.Point(12, 60);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(144, 23);
            this.ok.TabIndex = 6;
            this.ok.Text = "OK";
            this.ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Image = ((System.Drawing.Image)(resources.GetObject("cancel.Image")));
            this.cancel.Location = new System.Drawing.Point(168, 60);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(144, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel";
            this.cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditOlympiadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 95);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.olympiadName);
            this.Controls.Add(this.olympiadNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOlympiadForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editing data";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label olympiadNameText;
        private System.Windows.Forms.TextBox olympiadName;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}