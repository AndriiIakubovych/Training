namespace SalesViewing
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
            this.tableChoiceText = new System.Windows.Forms.Label();
            this.tableChoice = new System.Windows.Forms.ComboBox();
            this.tableViewText = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableChoiceText
            // 
            resources.ApplyResources(this.tableChoiceText, "tableChoiceText");
            this.tableChoiceText.Name = "tableChoiceText";
            // 
            // tableChoice
            // 
            resources.ApplyResources(this.tableChoice, "tableChoice");
            this.tableChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableChoice.FormattingEnabled = true;
            this.tableChoice.Items.AddRange(new object[] { resources.GetString("tableChoice.Items"), resources.GetString("tableChoice.Items1"), resources.GetString("tableChoice.Items2") });
            this.tableChoice.Name = "tableChoice";
            this.tableChoice.SelectedIndexChanged += new System.EventHandler(this.tableChoice_SelectedIndexChanged);
            // 
            // tableViewText
            // 
            resources.ApplyResources(this.tableViewText, "tableViewText");
            this.tableViewText.Name = "tableViewText";
            // 
            // dataGridView
            // 
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.tableViewText);
            this.Controls.Add(this.tableChoice);
            this.Controls.Add(this.tableChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label tableChoiceText;
        private System.Windows.Forms.ComboBox tableChoice;
        private System.Windows.Forms.Label tableViewText;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}