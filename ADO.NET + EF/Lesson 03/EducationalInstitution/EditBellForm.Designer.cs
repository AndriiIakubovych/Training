namespace EducationalInstitution
{
    partial class EditBellForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBellForm));
            this.bellBeginTimeText = new System.Windows.Forms.Label();
            this.bellBeginTime = new System.Windows.Forms.DateTimePicker();
            this.bellEndTimeText = new System.Windows.Forms.Label();
            this.bellEndTime = new System.Windows.Forms.DateTimePicker();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bellBeginTimeText
            // 
            resources.ApplyResources(this.bellBeginTimeText, "bellBeginTimeText");
            this.bellBeginTimeText.Name = "bellBeginTimeText";
            // 
            // bellBeginTime
            // 
            resources.ApplyResources(this.bellBeginTime, "bellBeginTime");
            this.bellBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.bellBeginTime.Name = "bellBeginTime";
            this.bellBeginTime.ShowUpDown = true;
            this.bellBeginTime.Value = new System.DateTime(2017, 6, 13, 0, 0, 0, 0);
            // 
            // bellEndTimeText
            // 
            resources.ApplyResources(this.bellEndTimeText, "bellEndTimeText");
            this.bellEndTimeText.Name = "bellEndTimeText";
            // 
            // bellEndTime
            // 
            resources.ApplyResources(this.bellEndTime, "bellEndTime");
            this.bellEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.bellEndTime.Name = "bellEndTime";
            this.bellEndTime.ShowUpDown = true;
            this.bellEndTime.Value = new System.DateTime(2017, 6, 13, 0, 0, 0, 0);
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
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditBellForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.bellEndTime);
            this.Controls.Add(this.bellEndTimeText);
            this.Controls.Add(this.bellBeginTime);
            this.Controls.Add(this.bellBeginTimeText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBellForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label bellBeginTimeText;
        private System.Windows.Forms.DateTimePicker bellBeginTime;
        private System.Windows.Forms.Label bellEndTimeText;
        private System.Windows.Forms.DateTimePicker bellEndTime;
    }
}