namespace JewelsSearch
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
            this.colorChoiceText = new System.Windows.Forms.Label();
            this.colorChoice = new System.Windows.Forms.ComboBox();
            this.find = new System.Windows.Forms.Button();
            this.jewelsListText = new System.Windows.Forms.Label();
            this.jewelsList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // colorChoiceText
            // 
            resources.ApplyResources(this.colorChoiceText, "colorChoiceText");
            this.colorChoiceText.Name = "colorChoiceText";
            // 
            // colorChoice
            // 
            this.colorChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorChoice.FormattingEnabled = true;
            resources.ApplyResources(this.colorChoice, "colorChoice");
            this.colorChoice.Name = "colorChoice";
            // 
            // find
            // 
            resources.ApplyResources(this.find, "find");
            this.find.Name = "find";
            this.find.UseVisualStyleBackColor = true;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // jewelsListText
            // 
            resources.ApplyResources(this.jewelsListText, "jewelsListText");
            this.jewelsListText.Name = "jewelsListText";
            // 
            // jewelsList
            // 
            resources.ApplyResources(this.jewelsList, "jewelsList");
            this.jewelsList.Name = "jewelsList";
            this.jewelsList.UseCompatibleStateImageBehavior = false;
            this.jewelsList.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jewelsList);
            this.Controls.Add(this.jewelsListText);
            this.Controls.Add(this.find);
            this.Controls.Add(this.colorChoice);
            this.Controls.Add(this.colorChoiceText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label colorChoiceText;
        private System.Windows.Forms.ComboBox colorChoice;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.Label jewelsListText;
        private System.Windows.Forms.ListView jewelsList;
    }
}