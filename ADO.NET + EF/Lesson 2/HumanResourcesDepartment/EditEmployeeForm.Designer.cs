namespace HumanResourcesDepartment
{
    partial class EditEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEmployeeForm));
            this.employeeNameText = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.TextBox();
            this.birthdateText = new System.Windows.Forms.Label();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.positionText = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.TextBox();
            this.hiringOrderNumberText = new System.Windows.Forms.Label();
            this.hiringOrderNumber = new System.Windows.Forms.TextBox();
            this.firingOrderNumberText = new System.Windows.Forms.Label();
            this.firingOrderNumber = new System.Windows.Forms.TextBox();
            this.changePhoto = new System.Windows.Forms.CheckBox();
            this.photo = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // employeeNameText
            // 
            resources.ApplyResources(this.employeeNameText, "employeeNameText");
            this.employeeNameText.Name = "employeeNameText";
            // 
            // employeeName
            // 
            resources.ApplyResources(this.employeeName, "employeeName");
            this.employeeName.Name = "employeeName";
            this.employeeName.TextChanged += new System.EventHandler(this.employeeName_TextChanged);
            // 
            // birthdateText
            // 
            resources.ApplyResources(this.birthdateText, "birthdateText");
            this.birthdateText.Name = "birthdateText";
            // 
            // birthdate
            // 
            resources.ApplyResources(this.birthdate, "birthdate");
            this.birthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdate.Name = "birthdate";
            // 
            // positionText
            // 
            resources.ApplyResources(this.positionText, "positionText");
            this.positionText.Name = "positionText";
            // 
            // position
            // 
            resources.ApplyResources(this.position, "position");
            this.position.Name = "position";
            this.position.TextChanged += new System.EventHandler(this.position_TextChanged);
            // 
            // hiringOrderNumberText
            // 
            resources.ApplyResources(this.hiringOrderNumberText, "hiringOrderNumberText");
            this.hiringOrderNumberText.Name = "hiringOrderNumberText";
            // 
            // hiringOrderNumber
            // 
            resources.ApplyResources(this.hiringOrderNumber, "hiringOrderNumber");
            this.hiringOrderNumber.Name = "hiringOrderNumber";
            // 
            // firingOrderNumberText
            // 
            resources.ApplyResources(this.firingOrderNumberText, "firingOrderNumberText");
            this.firingOrderNumberText.Name = "firingOrderNumberText";
            // 
            // firingOrderNumber
            // 
            resources.ApplyResources(this.firingOrderNumber, "firingOrderNumber");
            this.firingOrderNumber.Name = "firingOrderNumber";
            // 
            // changePhoto
            // 
            resources.ApplyResources(this.changePhoto, "changePhoto");
            this.changePhoto.Name = "changePhoto";
            this.changePhoto.UseVisualStyleBackColor = true;
            this.changePhoto.CheckedChanged += new System.EventHandler(this.changePhoto_CheckedChanged);
            // 
            // photo
            // 
            resources.ApplyResources(this.photo, "photo");
            this.photo.BackColor = System.Drawing.SystemColors.Window;
            this.photo.Name = "photo";
            this.photo.ReadOnly = true;
            // 
            // openFile
            // 
            resources.ApplyResources(this.openFile, "openFile");
            this.openFile.Name = "openFile";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
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
            // EditEmployeeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.changePhoto);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.photo);
            this.Controls.Add(this.firingOrderNumber);
            this.Controls.Add(this.firingOrderNumberText);
            this.Controls.Add(this.hiringOrderNumber);
            this.Controls.Add(this.hiringOrderNumberText);
            this.Controls.Add(this.position);
            this.Controls.Add(this.positionText);
            this.Controls.Add(this.birthdateText);
            this.Controls.Add(this.employeeName);
            this.Controls.Add(this.employeeNameText);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditEmployeeForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label employeeNameText;
        private System.Windows.Forms.TextBox employeeName;
        private System.Windows.Forms.Label birthdateText;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Label positionText;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.Label hiringOrderNumberText;
        private System.Windows.Forms.TextBox hiringOrderNumber;
        private System.Windows.Forms.Label firingOrderNumberText;
        private System.Windows.Forms.TextBox firingOrderNumber;
        private System.Windows.Forms.CheckBox changePhoto;
        private System.Windows.Forms.TextBox photo;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}