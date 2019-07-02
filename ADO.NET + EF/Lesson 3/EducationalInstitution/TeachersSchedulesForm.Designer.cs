namespace EducationalInstitution
{
    partial class TeachersSchedulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeachersSchedulesForm));
            this.teacherChoiceText = new System.Windows.Forms.Label();
            this.teacherChoice = new System.Windows.Forms.ComboBox();
            this.dayChoiceText = new System.Windows.Forms.Label();
            this.dayChoice = new System.Windows.Forms.ComboBox();
            this.schedulesView = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.schedulesView)).BeginInit();
            this.SuspendLayout();
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
            this.teacherChoice.SelectedIndexChanged += new System.EventHandler(this.teacherChoice_SelectedIndexChanged);
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
            this.dayChoice.SelectedIndexChanged += new System.EventHandler(this.dayChoice_SelectedIndexChanged);
            // 
            // schedulesView
            // 
            resources.ApplyResources(this.schedulesView, "schedulesView");
            this.schedulesView.AllowUserToAddRows = false;
            this.schedulesView.AllowUserToDeleteRows = false;
            this.schedulesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schedulesView.MultiSelect = false;
            this.schedulesView.Name = "schedulesView";
            this.schedulesView.ReadOnly = true;
            // 
            // add
            // 
            resources.ApplyResources(this.add, "add");
            this.add.Name = "add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // edit
            // 
            resources.ApplyResources(this.edit, "edit");
            this.edit.Name = "edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // delete
            // 
            resources.ApplyResources(this.delete, "delete");
            this.delete.Name = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // TeachersSchedulesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.schedulesView);
            this.Controls.Add(this.dayChoice);
            this.Controls.Add(this.dayChoiceText);
            this.Controls.Add(this.teacherChoice);
            this.Controls.Add(this.teacherChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeachersSchedulesForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeachersSchedulesForm_FormClosed);
            this.Load += new System.EventHandler(this.TeachersSchedulesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulesView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label teacherChoiceText;
        private System.Windows.Forms.ComboBox teacherChoice;
        private System.Windows.Forms.Label dayChoiceText;
        private System.Windows.Forms.ComboBox dayChoice;
        private System.Windows.Forms.DataGridView schedulesView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
    }
}