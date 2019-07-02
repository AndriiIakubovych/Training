namespace EducationalInstitution
{
    partial class EditCurriculumForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCurriculumForm));
            this.groupChoiceText = new System.Windows.Forms.Label();
            this.groupChoice = new System.Windows.Forms.ComboBox();
            this.subjectChoiceText = new System.Windows.Forms.Label();
            this.subjectChoice = new System.Windows.Forms.ComboBox();
            this.lecturesCountText = new System.Windows.Forms.Label();
            this.lecturesCount = new System.Windows.Forms.TextBox();
            this.practicalLessonsCountText = new System.Windows.Forms.Label();
            this.practicalLessonsCount = new System.Windows.Forms.TextBox();
            this.laboratoryLessonsCountText = new System.Windows.Forms.Label();
            this.laboratoryLessonsCount = new System.Windows.Forms.TextBox();
            this.testFormChoiceText = new System.Windows.Forms.Label();
            this.testFormChoice = new System.Windows.Forms.ComboBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupChoiceText
            // 
            resources.ApplyResources(this.groupChoiceText, "groupChoiceText");
            this.groupChoiceText.Name = "groupChoiceText";
            // 
            // groupChoice
            // 
            resources.ApplyResources(this.groupChoice, "groupChoice");
            this.groupChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupChoice.FormattingEnabled = true;
            this.groupChoice.Name = "groupChoice";
            // 
            // subjectChoiceText
            // 
            resources.ApplyResources(this.subjectChoiceText, "subjectChoiceText");
            this.subjectChoiceText.Name = "subjectChoiceText";
            // 
            // subjectChoice
            // 
            resources.ApplyResources(this.subjectChoice, "subjectChoice");
            this.subjectChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectChoice.FormattingEnabled = true;
            this.subjectChoice.Name = "subjectChoice";
            // 
            // lecturesCountText
            // 
            resources.ApplyResources(this.lecturesCountText, "lecturesCountText");
            this.lecturesCountText.Name = "lecturesCountText";
            // 
            // lecturesCount
            // 
            resources.ApplyResources(this.lecturesCount, "lecturesCount");
            this.lecturesCount.Name = "lecturesCount";
            this.lecturesCount.TextChanged += new System.EventHandler(this.lecturesCount_TextChanged);
            // 
            // practicalLessonsCountText
            // 
            resources.ApplyResources(this.practicalLessonsCountText, "practicalLessonsCountText");
            this.practicalLessonsCountText.Name = "practicalLessonsCountText";
            // 
            // practicalLessonsCount
            // 
            resources.ApplyResources(this.practicalLessonsCount, "practicalLessonsCount");
            this.practicalLessonsCount.Name = "practicalLessonsCount";
            this.practicalLessonsCount.TextChanged += new System.EventHandler(this.practicalLessonsCount_TextChanged);
            // 
            // laboratoryLessonsCountText
            // 
            resources.ApplyResources(this.laboratoryLessonsCountText, "laboratoryLessonsCountText");
            this.laboratoryLessonsCountText.Name = "laboratoryLessonsCountText";
            // 
            // laboratoryLessonsCount
            // 
            resources.ApplyResources(this.laboratoryLessonsCount, "laboratoryLessonsCount");
            this.laboratoryLessonsCount.Name = "laboratoryLessonsCount";
            this.laboratoryLessonsCount.TextChanged += new System.EventHandler(this.laboratoryLessonsCount_TextChanged);
            // 
            // testFormChoiceText
            // 
            resources.ApplyResources(this.testFormChoiceText, "testFormChoiceText");
            this.testFormChoiceText.Name = "testFormChoiceText";
            // 
            // testFormChoice
            // 
            resources.ApplyResources(this.testFormChoice, "testFormChoice");
            this.testFormChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.testFormChoice.FormattingEnabled = true;
            this.testFormChoice.Items.AddRange(new object[] { resources.GetString("testFormChoice.Items"), resources.GetString("testFormChoice.Items1") });
            this.testFormChoice.Name = "testFormChoice";
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
            // EditCurriculumForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.testFormChoice);
            this.Controls.Add(this.testFormChoiceText);
            this.Controls.Add(this.laboratoryLessonsCount);
            this.Controls.Add(this.laboratoryLessonsCountText);
            this.Controls.Add(this.practicalLessonsCount);
            this.Controls.Add(this.practicalLessonsCountText);
            this.Controls.Add(this.lecturesCount);
            this.Controls.Add(this.lecturesCountText);
            this.Controls.Add(this.subjectChoice);
            this.Controls.Add(this.subjectChoiceText);
            this.Controls.Add(this.groupChoice);
            this.Controls.Add(this.groupChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCurriculumForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EditCurriculumForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label groupChoiceText;
        private System.Windows.Forms.ComboBox groupChoice;
        private System.Windows.Forms.Label subjectChoiceText;
        private System.Windows.Forms.ComboBox subjectChoice;
        private System.Windows.Forms.Label lecturesCountText;
        private System.Windows.Forms.TextBox lecturesCount;
        private System.Windows.Forms.Label practicalLessonsCountText;
        private System.Windows.Forms.TextBox practicalLessonsCount;
        private System.Windows.Forms.Label laboratoryLessonsCountText;
        private System.Windows.Forms.TextBox laboratoryLessonsCount;
        private System.Windows.Forms.Label testFormChoiceText;
        private System.Windows.Forms.ComboBox testFormChoice;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}