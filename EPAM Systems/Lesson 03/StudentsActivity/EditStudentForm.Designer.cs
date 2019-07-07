namespace StudentsActivity
{
    partial class EditStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditStudentForm));
            this.studentNameText = new System.Windows.Forms.Label();
            this.studentName = new System.Windows.Forms.TextBox();
            this.birthdateText = new System.Windows.Forms.Label();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.addressText = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.telephoneText = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.MaskedTextBox();
            this.universityText = new System.Windows.Forms.Label();
            this.university = new System.Windows.Forms.TextBox();
            this.courseText = new System.Windows.Forms.Label();
            this.course = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Image = ((System.Drawing.Image)(resources.GetObject("cancel.Image")));
            this.cancel.Location = new System.Drawing.Point(180, 301);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(156, 23);
            this.cancel.TabIndex = 27;
            this.cancel.Text = "Cancel";
            this.cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.Image = ((System.Drawing.Image)(resources.GetObject("ok.Image")));
            this.ok.Location = new System.Drawing.Point(12, 301);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(156, 23);
            this.ok.TabIndex = 26;
            this.ok.Text = "OK";
            this.ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ok.UseVisualStyleBackColor = true;
            this.ok.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ok_MouseDown);
            // 
            // studentNameText
            // 
            this.studentNameText.AutoSize = true;
            this.studentNameText.Location = new System.Drawing.Point(9, 9);
            this.studentNameText.Name = "studentNameText";
            this.studentNameText.Size = new System.Drawing.Size(83, 13);
            this.studentNameText.TabIndex = 14;
            this.studentNameText.Text = "Student\'s name:";
            // 
            // studentName
            // 
            this.studentName.Location = new System.Drawing.Point(12, 25);
            this.studentName.MaxLength = 50;
            this.studentName.Name = "studentName";
            this.studentName.Size = new System.Drawing.Size(324, 20);
            this.studentName.TabIndex = 15;
            this.studentName.TextChanged += new System.EventHandler(this.studentName_TextChanged);
            // 
            // birthdateText
            // 
            this.birthdateText.AutoSize = true;
            this.birthdateText.Location = new System.Drawing.Point(9, 57);
            this.birthdateText.Name = "birthdateText";
            this.birthdateText.Size = new System.Drawing.Size(52, 13);
            this.birthdateText.TabIndex = 16;
            this.birthdateText.Text = "Birthdate:";
            // 
            // birthdate
            // 
            this.birthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdate.Location = new System.Drawing.Point(12, 73);
            this.birthdate.Name = "birthdate";
            this.birthdate.Size = new System.Drawing.Size(324, 20);
            this.birthdate.TabIndex = 17;
            // 
            // addressText
            // 
            this.addressText.AutoSize = true;
            this.addressText.Location = new System.Drawing.Point(9, 105);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(78, 13);
            this.addressText.TabIndex = 18;
            this.addressText.Text = "Home address:";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(12, 121);
            this.address.MaxLength = 255;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(324, 20);
            this.address.TabIndex = 19;
            // 
            // telephoneText
            // 
            this.telephoneText.AutoSize = true;
            this.telephoneText.Location = new System.Drawing.Point(9, 153);
            this.telephoneText.Name = "telephoneText";
            this.telephoneText.Size = new System.Drawing.Size(61, 13);
            this.telephoneText.TabIndex = 20;
            this.telephoneText.Text = "Telephone:";
            // 
            // telephone
            // 
            this.telephone.Location = new System.Drawing.Point(12, 169);
            this.telephone.Mask = "+0 (000) 000-00-00";
            this.telephone.Name = "telephone";
            this.telephone.Size = new System.Drawing.Size(324, 20);
            this.telephone.TabIndex = 21;
            // 
            // universityText
            // 
            this.universityText.AutoSize = true;
            this.universityText.Location = new System.Drawing.Point(9, 202);
            this.universityText.Name = "universityText";
            this.universityText.Size = new System.Drawing.Size(56, 13);
            this.universityText.TabIndex = 22;
            this.universityText.Text = "University:";
            // 
            // university
            // 
            this.university.Location = new System.Drawing.Point(12, 218);
            this.university.MaxLength = 100;
            this.university.Name = "university";
            this.university.Size = new System.Drawing.Size(324, 20);
            this.university.TabIndex = 23;
            // 
            // courseText
            // 
            this.courseText.AutoSize = true;
            this.courseText.Location = new System.Drawing.Point(9, 250);
            this.courseText.Name = "courseText";
            this.courseText.Size = new System.Drawing.Size(43, 13);
            this.courseText.TabIndex = 24;
            this.courseText.Text = "Course:";
            // 
            // course
            // 
            this.course.Location = new System.Drawing.Point(12, 266);
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(324, 20);
            this.course.TabIndex = 25;
            // 
            // EditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 336);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.course);
            this.Controls.Add(this.courseText);
            this.Controls.Add(this.university);
            this.Controls.Add(this.universityText);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.telephoneText);
            this.Controls.Add(this.address);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.birthdateText);
            this.Controls.Add(this.studentName);
            this.Controls.Add(this.studentNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditStudentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editing data";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label studentNameText;
        private System.Windows.Forms.TextBox studentName;
        private System.Windows.Forms.Label birthdateText;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Label addressText;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label telephoneText;
        private System.Windows.Forms.MaskedTextBox telephone;
        private System.Windows.Forms.Label universityText;
        private System.Windows.Forms.TextBox university;
        private System.Windows.Forms.Label courseText;
        private System.Windows.Forms.TextBox course;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}