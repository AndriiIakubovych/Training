namespace WorkingDays
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.employeeLastNameText = new System.Windows.Forms.Label();
            this.employeeLastName = new System.Windows.Forms.TextBox();
            this.show = new System.Windows.Forms.Button();
            this.employeesViewText = new System.Windows.Forms.Label();
            this.employeesView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // employeeLastNameText
            // 
            resources.ApplyResources(this.employeeLastNameText, "employeeLastNameText");
            this.employeeLastNameText.Name = "employeeLastNameText";
            // 
            // employeeLastName
            // 
            resources.ApplyResources(this.employeeLastName, "employeeLastName");
            this.employeeLastName.Name = "employeeLastName";
            // 
            // show
            // 
            resources.ApplyResources(this.show, "show");
            this.show.Name = "show";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // employeesViewText
            // 
            resources.ApplyResources(this.employeesViewText, "employeesViewText");
            this.employeesViewText.Name = "employeesViewText";
            // 
            // employeesView
            // 
            resources.ApplyResources(this.employeesView, "employeesView");
            this.employeesView.Name = "employeesView";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.employeesView);
            this.Controls.Add(this.employeesViewText);
            this.Controls.Add(this.show);
            this.Controls.Add(this.employeeLastName);
            this.Controls.Add(this.employeeLastNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label employeeLastNameText;
        private System.Windows.Forms.TextBox employeeLastName;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.Label employeesViewText;
        private System.Windows.Forms.TreeView employeesView;
    }
}