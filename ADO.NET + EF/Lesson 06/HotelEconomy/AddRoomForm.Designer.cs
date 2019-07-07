namespace HotelEconomy
{
    partial class AddRoomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRoomForm));
            this.roomNumberText = new System.Windows.Forms.Label();
            this.roomNumber = new System.Windows.Forms.TextBox();
            this.floorText = new System.Windows.Forms.Label();
            this.floor = new System.Windows.Forms.TextBox();
            this.categoryChoiceText = new System.Windows.Forms.Label();
            this.categoryChoice = new System.Windows.Forms.ComboBox();
            this.placesCountChoiceText = new System.Windows.Forms.Label();
            this.placesCountChoice = new System.Windows.Forms.ComboBox();
            this.priceText = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.employeeChoiceText = new System.Windows.Forms.Label();
            this.employeeChoice = new System.Windows.Forms.ComboBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roomNumberText
            // 
            resources.ApplyResources(this.roomNumberText, "roomNumberText");
            this.roomNumberText.Name = "roomNumberText";
            // 
            // roomNumber
            // 
            resources.ApplyResources(this.roomNumber, "roomNumber");
            this.roomNumber.Name = "roomNumber";
            this.roomNumber.TextChanged += new System.EventHandler(this.roomNumber_TextChanged);
            // 
            // floorText
            // 
            resources.ApplyResources(this.floorText, "floorText");
            this.floorText.Name = "floorText";
            // 
            // floor
            // 
            resources.ApplyResources(this.floor, "floor");
            this.floor.Name = "floor";
            this.floor.TextChanged += new System.EventHandler(this.floor_TextChanged);
            // 
            // categoryChoiceText
            // 
            resources.ApplyResources(this.categoryChoiceText, "categoryChoiceText");
            this.categoryChoiceText.Name = "categoryChoiceText";
            // 
            // categoryChoice
            // 
            this.categoryChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryChoice.FormattingEnabled = true;
            this.categoryChoice.Items.AddRange(new object[] {
            resources.GetString("categoryChoice.Items"),
            resources.GetString("categoryChoice.Items1"),
            resources.GetString("categoryChoice.Items2")});
            resources.ApplyResources(this.categoryChoice, "categoryChoice");
            this.categoryChoice.Name = "categoryChoice";
            // 
            // placesCountChoiceText
            // 
            resources.ApplyResources(this.placesCountChoiceText, "placesCountChoiceText");
            this.placesCountChoiceText.Name = "placesCountChoiceText";
            // 
            // placesCountChoice
            // 
            this.placesCountChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.placesCountChoice.FormattingEnabled = true;
            this.placesCountChoice.Items.AddRange(new object[] {
            resources.GetString("placesCountChoice.Items"),
            resources.GetString("placesCountChoice.Items1"),
            resources.GetString("placesCountChoice.Items2")});
            resources.ApplyResources(this.placesCountChoice, "placesCountChoice");
            this.placesCountChoice.Name = "placesCountChoice";
            // 
            // priceText
            // 
            resources.ApplyResources(this.priceText, "priceText");
            this.priceText.Name = "priceText";
            // 
            // price
            // 
            resources.ApplyResources(this.price, "price");
            this.price.Name = "price";
            this.price.TextChanged += new System.EventHandler(this.price_TextChanged);
            // 
            // employeeChoiceText
            // 
            resources.ApplyResources(this.employeeChoiceText, "employeeChoiceText");
            this.employeeChoiceText.Name = "employeeChoiceText";
            // 
            // employeeChoice
            // 
            this.employeeChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeChoice.FormattingEnabled = true;
            resources.ApplyResources(this.employeeChoice, "employeeChoice");
            this.employeeChoice.Name = "employeeChoice";
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
            // AddRoomForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.employeeChoice);
            this.Controls.Add(this.employeeChoiceText);
            this.Controls.Add(this.price);
            this.Controls.Add(this.priceText);
            this.Controls.Add(this.placesCountChoice);
            this.Controls.Add(this.placesCountChoiceText);
            this.Controls.Add(this.categoryChoice);
            this.Controls.Add(this.categoryChoiceText);
            this.Controls.Add(this.floor);
            this.Controls.Add(this.floorText);
            this.Controls.Add(this.roomNumber);
            this.Controls.Add(this.roomNumberText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRoomForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AddRoomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label roomNumberText;
        private System.Windows.Forms.TextBox roomNumber;
        private System.Windows.Forms.Label floorText;
        private System.Windows.Forms.TextBox floor;
        private System.Windows.Forms.Label categoryChoiceText;
        private System.Windows.Forms.ComboBox categoryChoice;
        private System.Windows.Forms.Label placesCountChoiceText;
        private System.Windows.Forms.ComboBox placesCountChoice;
        private System.Windows.Forms.Label priceText;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label employeeChoiceText;
        private System.Windows.Forms.ComboBox employeeChoice;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}