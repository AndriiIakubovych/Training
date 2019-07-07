namespace HotelEconomy
{
    partial class AddExpenseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpenseForm));
            this.expenseNameText = new System.Windows.Forms.Label();
            this.expenseName = new System.Windows.Forms.TextBox();
            this.expenseDateText = new System.Windows.Forms.Label();
            this.expenseDate = new System.Windows.Forms.DateTimePicker();
            this.expenseSumText = new System.Windows.Forms.Label();
            this.expenseSum = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // expenseNameText
            // 
            resources.ApplyResources(this.expenseNameText, "expenseNameText");
            this.expenseNameText.Name = "expenseNameText";
            // 
            // expenseName
            // 
            resources.ApplyResources(this.expenseName, "expenseName");
            this.expenseName.Name = "expenseName";
            this.expenseName.TextChanged += new System.EventHandler(this.expenseName_TextChanged);
            // 
            // expenseDateText
            // 
            resources.ApplyResources(this.expenseDateText, "expenseDateText");
            this.expenseDateText.Name = "expenseDateText";
            // 
            // expenseDate
            // 
            this.expenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.expenseDate, "expenseDate");
            this.expenseDate.Name = "expenseDate";
            // 
            // expenseSumText
            // 
            resources.ApplyResources(this.expenseSumText, "expenseSumText");
            this.expenseSumText.Name = "expenseSumText";
            // 
            // expenseSum
            // 
            resources.ApplyResources(this.expenseSum, "expenseSum");
            this.expenseSum.Name = "expenseSum";
            this.expenseSum.TextChanged += new System.EventHandler(this.expenseSum_TextChanged);
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
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // AddExpenseForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.expenseSum);
            this.Controls.Add(this.expenseSumText);
            this.Controls.Add(this.expenseDate);
            this.Controls.Add(this.expenseDateText);
            this.Controls.Add(this.expenseName);
            this.Controls.Add(this.expenseNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddExpenseForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label expenseNameText;
        private System.Windows.Forms.TextBox expenseName;
        private System.Windows.Forms.Label expenseDateText;
        private System.Windows.Forms.DateTimePicker expenseDate;
        private System.Windows.Forms.Label expenseSumText;
        private System.Windows.Forms.TextBox expenseSum;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}