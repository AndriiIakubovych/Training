namespace RefrigeratorsShop
{
    partial class SaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleForm));
            this.saleDateText = new System.Windows.Forms.Label();
            this.saleDate = new System.Windows.Forms.DateTimePicker();
            this.buyerChoiceText = new System.Windows.Forms.Label();
            this.buyerChoice = new System.Windows.Forms.ComboBox();
            this.sellerChoiceText = new System.Windows.Forms.Label();
            this.sellerChoice = new System.Windows.Forms.ComboBox();
            this.sumText = new System.Windows.Forms.Label();
            this.sum = new System.Windows.Forms.TextBox();
            this.checkFileNameText = new System.Windows.Forms.Label();
            this.checkFileName = new System.Windows.Forms.TextBox();
            this.saveFile = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.printCheck = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saleDateText
            // 
            resources.ApplyResources(this.saleDateText, "saleDateText");
            this.saleDateText.Name = "saleDateText";
            // 
            // saleDate
            // 
            this.saleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.saleDate, "saleDate");
            this.saleDate.Name = "saleDate";
            // 
            // buyerChoiceText
            // 
            resources.ApplyResources(this.buyerChoiceText, "buyerChoiceText");
            this.buyerChoiceText.Name = "buyerChoiceText";
            // 
            // buyerChoice
            // 
            this.buyerChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buyerChoice.FormattingEnabled = true;
            resources.ApplyResources(this.buyerChoice, "buyerChoice");
            this.buyerChoice.Name = "buyerChoice";
            this.buyerChoice.Sorted = true;
            // 
            // sellerChoiceText
            // 
            resources.ApplyResources(this.sellerChoiceText, "sellerChoiceText");
            this.sellerChoiceText.Name = "sellerChoiceText";
            // 
            // sellerChoice
            // 
            this.sellerChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sellerChoice.FormattingEnabled = true;
            resources.ApplyResources(this.sellerChoice, "sellerChoice");
            this.sellerChoice.Name = "sellerChoice";
            // 
            // sumText
            // 
            resources.ApplyResources(this.sumText, "sumText");
            this.sumText.Name = "sumText";
            // 
            // sum
            // 
            this.sum.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.sum, "sum");
            this.sum.Name = "sum";
            this.sum.ReadOnly = true;
            // 
            // checkFileNameText
            // 
            resources.ApplyResources(this.checkFileNameText, "checkFileNameText");
            this.checkFileNameText.Name = "checkFileNameText";
            // 
            // checkFileName
            // 
            this.checkFileName.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.checkFileName, "checkFileName");
            this.checkFileName.Name = "checkFileName";
            this.checkFileName.ReadOnly = true;
            // 
            // saveFile
            // 
            resources.ApplyResources(this.saveFile, "saveFile");
            this.saveFile.Name = "saveFile";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "check.xml";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // printCheck
            // 
            resources.ApplyResources(this.printCheck, "printCheck");
            this.printCheck.Name = "printCheck";
            this.printCheck.UseVisualStyleBackColor = true;
            this.printCheck.Click += new System.EventHandler(this.printCheck_Click);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.ok, "ok");
            this.ok.Name = "ok";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // SaleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.saveFile);
            this.Controls.Add(this.printCheck);
            this.Controls.Add(this.checkFileName);
            this.Controls.Add(this.checkFileNameText);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.sumText);
            this.Controls.Add(this.sellerChoice);
            this.Controls.Add(this.sellerChoiceText);
            this.Controls.Add(this.buyerChoice);
            this.Controls.Add(this.buyerChoiceText);
            this.Controls.Add(this.saleDate);
            this.Controls.Add(this.saleDateText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaleForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SaleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label saleDateText;
        private System.Windows.Forms.DateTimePicker saleDate;
        private System.Windows.Forms.Label buyerChoiceText;
        private System.Windows.Forms.ComboBox buyerChoice;
        private System.Windows.Forms.Label sellerChoiceText;
        private System.Windows.Forms.ComboBox sellerChoice;
        private System.Windows.Forms.Label sumText;
        private System.Windows.Forms.TextBox sum;
        private System.Windows.Forms.Label checkFileNameText;
        private System.Windows.Forms.TextBox checkFileName;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button printCheck;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}