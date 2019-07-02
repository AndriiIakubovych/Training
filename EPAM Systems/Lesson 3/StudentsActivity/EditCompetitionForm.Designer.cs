namespace StudentsActivity
{
    partial class EditCompetitionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCompetitionForm));
            this.competitionNameText = new System.Windows.Forms.Label();
            this.competitionName = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // competitionNameText
            // 
            this.competitionNameText.AutoSize = true;
            this.competitionNameText.Location = new System.Drawing.Point(9, 9);
            this.competitionNameText.Name = "competitionNameText";
            this.competitionNameText.Size = new System.Drawing.Size(94, 13);
            this.competitionNameText.TabIndex = 8;
            this.competitionNameText.Text = "Competition name:";
            // 
            // competitionName
            // 
            this.competitionName.Location = new System.Drawing.Point(12, 25);
            this.competitionName.MaxLength = 255;
            this.competitionName.Name = "competitionName";
            this.competitionName.Size = new System.Drawing.Size(300, 20);
            this.competitionName.TabIndex = 9;
            this.competitionName.TextChanged += new System.EventHandler(this.competitionName_TextChanged);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Image = ((System.Drawing.Image)(resources.GetObject("ok.Image")));
            this.ok.Location = new System.Drawing.Point(12, 60);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(144, 23);
            this.ok.TabIndex = 10;
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
            this.cancel.TabIndex = 11;
            this.cancel.Text = "Cancel";
            this.cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditCompetitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 95);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.competitionName);
            this.Controls.Add(this.competitionNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCompetitionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editing data";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label competitionNameText;
        private System.Windows.Forms.TextBox competitionName;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}