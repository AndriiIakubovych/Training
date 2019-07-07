namespace EducationalInstitution
{
    partial class EditGroupScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditGroupScheduleForm));
            this.groupChoiceText = new System.Windows.Forms.Label();
            this.groupChoice = new System.Windows.Forms.ComboBox();
            this.subjectChoiceText = new System.Windows.Forms.Label();
            this.subjectChoice = new System.Windows.Forms.ComboBox();
            this.subjectTypeChoiceText = new System.Windows.Forms.Label();
            this.subjectTypeChoice = new System.Windows.Forms.ComboBox();
            this.dayChoiceText = new System.Windows.Forms.Label();
            this.dayChoice = new System.Windows.Forms.ComboBox();
            this.timeChoiceText = new System.Windows.Forms.Label();
            this.timeChoice = new System.Windows.Forms.ComboBox();
            this.auditoriumChoiceText = new System.Windows.Forms.Label();
            this.auditoriumChoice = new System.Windows.Forms.ComboBox();
            this.teacherChoiceText = new System.Windows.Forms.Label();
            this.teacherChoice = new System.Windows.Forms.ComboBox();
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
            // subjectTypeChoiceText
            // 
            resources.ApplyResources(this.subjectTypeChoiceText, "subjectTypeChoiceText");
            this.subjectTypeChoiceText.Name = "subjectTypeChoiceText";
            // 
            // subjectTypeChoice
            // 
            resources.ApplyResources(this.subjectTypeChoice, "subjectTypeChoice");
            this.subjectTypeChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectTypeChoice.FormattingEnabled = true;
            this.subjectTypeChoice.Items.AddRange(new object[] { resources.GetString("subjectTypeChoice.Items"), resources.GetString("subjectTypeChoice.Items1"), resources.GetString("subjectTypeChoice.Items2") });
            this.subjectTypeChoice.Name = "subjectTypeChoice";
            // 
            // dayChoiceText
            // 
            resources.ApplyResources(this.dayChoiceText, "dayChoiceText");
            this.dayChoiceText.Name = "dayChoiceText";
            // 
            // dayChoice
            // 
            resources.ApplyResources(this.dayChoice, "dayChoice");
            this.dayChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dayChoice.FormattingEnabled = true;
            this.dayChoice.Items.AddRange(new object[] { resources.GetString("dayChoice.Items"), resources.GetString("dayChoice.Items1"), resources.GetString("dayChoice.Items2"), resources.GetString("dayChoice.Items3"), resources.GetString("dayChoice.Items4"), resources.GetString("dayChoice.Items5"), resources.GetString("dayChoice.Items6") });
            this.dayChoice.Name = "dayChoice";
            // 
            // timeChoiceText
            // 
            resources.ApplyResources(this.timeChoiceText, "timeChoiceText");
            this.timeChoiceText.Name = "timeChoiceText";
            // 
            // timeChoice
            // 
            resources.ApplyResources(this.timeChoice, "timeChoice");
            this.timeChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeChoice.FormattingEnabled = true;
            this.timeChoice.Name = "timeChoice";
            // 
            // auditoriumChoiceText
            // 
            resources.ApplyResources(this.auditoriumChoiceText, "auditoriumChoiceText");
            this.auditoriumChoiceText.Name = "auditoriumChoiceText";
            // 
            // auditoriumChoice
            // 
            resources.ApplyResources(this.auditoriumChoice, "auditoriumChoice");
            this.auditoriumChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.auditoriumChoice.FormattingEnabled = true;
            this.auditoriumChoice.Name = "auditoriumChoice";
            // 
            // teacherChoiceText
            // 
            resources.ApplyResources(this.teacherChoiceText, "teacherChoiceText");
            this.teacherChoiceText.Name = "teacherChoiceText";
            // 
            // teacherChoice
            // 
            resources.ApplyResources(this.teacherChoice, "teacherChoice");
            this.teacherChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teacherChoice.FormattingEnabled = true;
            this.teacherChoice.Name = "teacherChoice";
            // 
            // ok
            // 
            resources.ApplyResources(this.ok, "ok");
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Name = "ok";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditGroupScheduleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.teacherChoice);
            this.Controls.Add(this.teacherChoiceText);
            this.Controls.Add(this.auditoriumChoice);
            this.Controls.Add(this.auditoriumChoiceText);
            this.Controls.Add(this.timeChoice);
            this.Controls.Add(this.timeChoiceText);
            this.Controls.Add(this.dayChoice);
            this.Controls.Add(this.dayChoiceText);
            this.Controls.Add(this.subjectTypeChoice);
            this.Controls.Add(this.subjectTypeChoiceText);
            this.Controls.Add(this.subjectChoice);
            this.Controls.Add(this.subjectChoiceText);
            this.Controls.Add(this.groupChoice);
            this.Controls.Add(this.groupChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditGroupScheduleForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EditGroupScheduleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label groupChoiceText;
        private System.Windows.Forms.ComboBox groupChoice;
        private System.Windows.Forms.Label subjectChoiceText;
        private System.Windows.Forms.ComboBox subjectChoice;
        private System.Windows.Forms.Label subjectTypeChoiceText;
        private System.Windows.Forms.ComboBox subjectTypeChoice;
        private System.Windows.Forms.Label dayChoiceText;
        private System.Windows.Forms.ComboBox dayChoice;
        private System.Windows.Forms.Label timeChoiceText;
        private System.Windows.Forms.ComboBox timeChoice;
        private System.Windows.Forms.Label auditoriumChoiceText;
        private System.Windows.Forms.ComboBox auditoriumChoice;
        private System.Windows.Forms.Label teacherChoiceText;
        private System.Windows.Forms.ComboBox teacherChoice;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}