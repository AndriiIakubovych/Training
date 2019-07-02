namespace StudentsActivity
{
    partial class EditOlympiadStudentParticipationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOlympiadStudentParticipationForm));
            this.studentChoiceText = new System.Windows.Forms.Label();
            this.studentChoice = new System.Windows.Forms.ComboBox();
            this.olympiadChoiceText = new System.Windows.Forms.Label();
            this.olympiadChoice = new System.Windows.Forms.ComboBox();
            this.participationDateText = new System.Windows.Forms.Label();
            this.participationDate = new System.Windows.Forms.DateTimePicker();
            this.placeText = new System.Windows.Forms.Label();
            this.place = new System.Windows.Forms.TextBox();
            this.resultsChoiceText = new System.Windows.Forms.Label();
            this.resultsChoice = new System.Windows.Forms.ComboBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentChoiceText
            // 
            this.studentChoiceText.AutoSize = true;
            this.studentChoiceText.Location = new System.Drawing.Point(9, 9);
            this.studentChoiceText.Name = "studentChoiceText";
            this.studentChoiceText.Size = new System.Drawing.Size(47, 13);
            this.studentChoiceText.TabIndex = 12;
            this.studentChoiceText.Text = "Student:";
            // 
            // studentChoice
            // 
            this.studentChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentChoice.FormattingEnabled = true;
            this.studentChoice.Location = new System.Drawing.Point(12, 25);
            this.studentChoice.Name = "studentChoice";
            this.studentChoice.Size = new System.Drawing.Size(324, 21);
            this.studentChoice.TabIndex = 13;
            // 
            // olympiadChoiceText
            // 
            this.olympiadChoiceText.AutoSize = true;
            this.olympiadChoiceText.Location = new System.Drawing.Point(9, 58);
            this.olympiadChoiceText.Name = "olympiadChoiceText";
            this.olympiadChoiceText.Size = new System.Drawing.Size(53, 13);
            this.olympiadChoiceText.TabIndex = 14;
            this.olympiadChoiceText.Text = "Olympiad:";
            // 
            // olympiadChoice
            // 
            this.olympiadChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.olympiadChoice.FormattingEnabled = true;
            this.olympiadChoice.Location = new System.Drawing.Point(12, 74);
            this.olympiadChoice.Name = "olympiadChoice";
            this.olympiadChoice.Size = new System.Drawing.Size(324, 21);
            this.olympiadChoice.TabIndex = 15;
            // 
            // participationDateText
            // 
            this.participationDateText.AutoSize = true;
            this.participationDateText.Location = new System.Drawing.Point(9, 107);
            this.participationDateText.Name = "participationDateText";
            this.participationDateText.Size = new System.Drawing.Size(92, 13);
            this.participationDateText.TabIndex = 16;
            this.participationDateText.Text = "Participation date:";
            // 
            // participationDate
            // 
            this.participationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.participationDate.Location = new System.Drawing.Point(12, 123);
            this.participationDate.Name = "participationDate";
            this.participationDate.Size = new System.Drawing.Size(324, 20);
            this.participationDate.TabIndex = 17;
            // 
            // placeText
            // 
            this.placeText.AutoSize = true;
            this.placeText.Location = new System.Drawing.Point(9, 155);
            this.placeText.Name = "placeText";
            this.placeText.Size = new System.Drawing.Size(37, 13);
            this.placeText.TabIndex = 18;
            this.placeText.Text = "Place:";
            // 
            // place
            // 
            this.place.Location = new System.Drawing.Point(11, 171);
            this.place.MaxLength = 255;
            this.place.Name = "place";
            this.place.Size = new System.Drawing.Size(325, 20);
            this.place.TabIndex = 19;
            this.place.TextChanged += new System.EventHandler(this.place_TextChanged);
            // 
            // resultsChoiceText
            // 
            this.resultsChoiceText.AutoSize = true;
            this.resultsChoiceText.Location = new System.Drawing.Point(8, 203);
            this.resultsChoiceText.Name = "resultsChoiceText";
            this.resultsChoiceText.Size = new System.Drawing.Size(117, 13);
            this.resultsChoiceText.TabIndex = 20;
            this.resultsChoiceText.Text = "Results of participation:";
            // 
            // resultsChoice
            // 
            this.resultsChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resultsChoice.FormattingEnabled = true;
            this.resultsChoice.Items.AddRange(new object[] { "Participant", "Awardee", "Winner" });
            this.resultsChoice.Location = new System.Drawing.Point(11, 219);
            this.resultsChoice.Name = "resultsChoice";
            this.resultsChoice.Size = new System.Drawing.Size(325, 21);
            this.resultsChoice.TabIndex = 21;
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Image = ((System.Drawing.Image)(resources.GetObject("ok.Image")));
            this.ok.Location = new System.Drawing.Point(12, 255);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(156, 23);
            this.ok.TabIndex = 22;
            this.ok.Text = "OK";
            this.ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Image = ((System.Drawing.Image)(resources.GetObject("cancel.Image")));
            this.cancel.Location = new System.Drawing.Point(180, 255);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(156, 23);
            this.cancel.TabIndex = 23;
            this.cancel.Text = "Cancel";
            this.cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditOlympiadStudentParticipationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 290);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.resultsChoice);
            this.Controls.Add(this.resultsChoiceText);
            this.Controls.Add(this.place);
            this.Controls.Add(this.placeText);
            this.Controls.Add(this.participationDate);
            this.Controls.Add(this.participationDateText);
            this.Controls.Add(this.olympiadChoice);
            this.Controls.Add(this.olympiadChoiceText);
            this.Controls.Add(this.studentChoice);
            this.Controls.Add(this.studentChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOlympiadStudentParticipationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editing data";
            this.Load += new System.EventHandler(this.EditOlympiadStudentParticipationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label studentChoiceText;
        private System.Windows.Forms.ComboBox studentChoice;
        private System.Windows.Forms.Label olympiadChoiceText;
        private System.Windows.Forms.ComboBox olympiadChoice;
        private System.Windows.Forms.Label participationDateText;
        private System.Windows.Forms.DateTimePicker participationDate;
        private System.Windows.Forms.Label placeText;
        private System.Windows.Forms.TextBox place;
        private System.Windows.Forms.Label resultsChoiceText;
        private System.Windows.Forms.ComboBox resultsChoice;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}