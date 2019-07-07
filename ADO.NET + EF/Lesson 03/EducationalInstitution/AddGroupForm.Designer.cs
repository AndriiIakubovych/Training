namespace EducationalInstitution
{
    partial class AddGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroupForm));
            this.groupNameText = new System.Windows.Forms.Label();
            this.groupName = new System.Windows.Forms.TextBox();
            this.semesterText = new System.Windows.Forms.Label();
            this.semester = new System.Windows.Forms.TextBox();
            this.specialtyChoiceText = new System.Windows.Forms.Label();
            this.specialtyChoice = new System.Windows.Forms.ComboBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupNameText
            // 
            resources.ApplyResources(this.groupNameText, "groupNameText");
            this.groupNameText.Name = "groupNameText";
            // 
            // groupName
            // 
            resources.ApplyResources(this.groupName, "groupName");
            this.groupName.Name = "groupName";
            this.groupName.TextChanged += new System.EventHandler(this.groupName_TextChanged);
            // 
            // semesterText
            // 
            resources.ApplyResources(this.semesterText, "semesterText");
            this.semesterText.Name = "semesterText";
            // 
            // semester
            // 
            resources.ApplyResources(this.semester, "semester");
            this.semester.Name = "semester";
            this.semester.TextChanged += new System.EventHandler(this.semester_TextChanged);
            // 
            // specialtyChoiceText
            // 
            resources.ApplyResources(this.specialtyChoiceText, "specialtyChoiceText");
            this.specialtyChoiceText.Name = "specialtyChoiceText";
            // 
            // specialtyChoice
            // 
            resources.ApplyResources(this.specialtyChoice, "specialtyChoice");
            this.specialtyChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specialtyChoice.FormattingEnabled = true;
            this.specialtyChoice.Name = "specialtyChoice";
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
            // AddGroupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.specialtyChoice);
            this.Controls.Add(this.specialtyChoiceText);
            this.Controls.Add(this.semester);
            this.Controls.Add(this.semesterText);
            this.Controls.Add(this.groupName);
            this.Controls.Add(this.groupNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddGroupForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AddGroupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label groupNameText;
        private System.Windows.Forms.TextBox groupName;
        private System.Windows.Forms.Label semesterText;
        private System.Windows.Forms.TextBox semester;
        private System.Windows.Forms.Label specialtyChoiceText;
        private System.Windows.Forms.ComboBox specialtyChoice;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}