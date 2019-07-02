namespace DesktopClient
{
    partial class EditNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditNoteForm));
            this.noteNameText = new System.Windows.Forms.Label();
            this.noteName = new System.Windows.Forms.TextBox();
            this.beginningTimeText = new System.Windows.Forms.Label();
            this.beginningTime = new System.Windows.Forms.DateTimePicker();
            this.endTimeText = new System.Windows.Forms.Label();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.descriptionText = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // noteNameText
            // 
            resources.ApplyResources(this.noteNameText, "noteNameText");
            this.noteNameText.Name = "noteNameText";
            // 
            // noteName
            // 
            resources.ApplyResources(this.noteName, "noteName");
            this.noteName.Name = "noteName";
            this.noteName.TextChanged += new System.EventHandler(this.noteName_TextChanged);
            // 
            // beginningTimeText
            // 
            resources.ApplyResources(this.beginningTimeText, "beginningTimeText");
            this.beginningTimeText.Name = "beginningTimeText";
            // 
            // beginningTime
            // 
            this.beginningTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.beginningTime, "beginningTime");
            this.beginningTime.Name = "beginningTime";
            this.beginningTime.ShowUpDown = true;
            // 
            // endTimeText
            // 
            resources.ApplyResources(this.endTimeText, "endTimeText");
            this.endTimeText.Name = "endTimeText";
            // 
            // endTime
            // 
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.endTime, "endTime");
            this.endTime.Name = "endTime";
            this.endTime.ShowUpDown = true;
            // 
            // descriptionText
            // 
            resources.ApplyResources(this.descriptionText, "descriptionText");
            this.descriptionText.Name = "descriptionText";
            // 
            // description
            // 
            resources.ApplyResources(this.description, "description");
            this.description.Name = "description";
            // 
            // ok
            // 
            resources.ApplyResources(this.ok, "ok");
            this.ok.Name = "ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ok_MouseDown);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditNoteForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.description);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.endTimeText);
            this.Controls.Add(this.beginningTime);
            this.Controls.Add(this.beginningTimeText);
            this.Controls.Add(this.noteName);
            this.Controls.Add(this.noteNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditNoteForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label noteNameText;
        private System.Windows.Forms.TextBox noteName;
        private System.Windows.Forms.Label beginningTimeText;
        private System.Windows.Forms.DateTimePicker beginningTime;
        private System.Windows.Forms.Label endTimeText;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.Label descriptionText;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}