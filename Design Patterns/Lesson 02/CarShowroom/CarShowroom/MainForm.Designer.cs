namespace CarShowroom
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.carsNamesList = new System.Windows.Forms.ListBox();
            this.panel = new System.Windows.Forms.Panel();
            this.carId = new System.Windows.Forms.TextBox();
            this.carName = new System.Windows.Forms.Label();
            this.carImage = new System.Windows.Forms.PictureBox();
            this.engineTypeText = new System.Windows.Forms.Label();
            this.engineType = new System.Windows.Forms.TextBox();
            this.engineVolumeText = new System.Windows.Forms.Label();
            this.engineVolume = new System.Windows.Forms.TextBox();
            this.powerText = new System.Windows.Forms.Label();
            this.power = new System.Windows.Forms.TextBox();
            this.accelerationText = new System.Windows.Forms.Label();
            this.acceleration = new System.Windows.Forms.TextBox();
            this.maxSpeenText = new System.Windows.Forms.Label();
            this.maxSpeed = new System.Windows.Forms.TextBox();
            this.fuelTankCapacityText = new System.Windows.Forms.Label();
            this.fuelTankCapacity = new System.Windows.Forms.TextBox();
            this.transmissionText = new System.Windows.Forms.Label();
            this.transmission = new System.Windows.Forms.TextBox();
            this.driveText = new System.Windows.Forms.Label();
            this.drive = new System.Windows.Forms.TextBox();
            this.weightText = new System.Windows.Forms.Label();
            this.weight = new System.Windows.Forms.TextBox();
            this.priceText = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.operationsToolStripMenuItem });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(738, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Главное меню";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addToolStripMenuItem, this.editToolStripMenuItem, this.deleteToolStripMenuItem, this.toolStripMenuItem, this.exitToolStripMenuItem });
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.operationsToolStripMenuItem.Text = "Операции";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripMenuItem.Image")));
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addToolStripMenuItem.Text = "Добавить";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editToolStripMenuItem.Text = "Редактировать";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(151, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addToolStripButton, this.editToolStripButton, this.deleteToolStripButton, this.toolStripSeparator, this.exitToolStripButton });
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(738, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "Панель инструментов";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addToolStripButton.Text = "Добавить";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editToolStripButton.Text = "Редактировать";
            this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Удалить";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // exitToolStripButton
            // 
            this.exitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripButton.Image")));
            this.exitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolStripButton.Name = "exitToolStripButton";
            this.exitToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.exitToolStripButton.Text = "Выход";
            this.exitToolStripButton.Click += new System.EventHandler(this.exitToolStripButton_Click);
            // 
            // carsNamesList
            // 
            this.carsNamesList.Dock = System.Windows.Forms.DockStyle.Left;
            this.carsNamesList.FormattingEnabled = true;
            this.carsNamesList.Location = new System.Drawing.Point(0, 49);
            this.carsNamesList.Name = "carsNamesList";
            this.carsNamesList.Size = new System.Drawing.Size(246, 563);
            this.carsNamesList.Sorted = true;
            this.carsNamesList.TabIndex = 4;
            this.carsNamesList.SelectedIndexChanged += new System.EventHandler(this.carsNamesList_SelectedIndexChanged);
            this.carsNamesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.carsNamesList_MouseDoubleClick);
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.carId);
            this.panel.Controls.Add(this.carName);
            this.panel.Controls.Add(this.carImage);
            this.panel.Controls.Add(this.engineTypeText);
            this.panel.Controls.Add(this.engineType);
            this.panel.Controls.Add(this.engineVolumeText);
            this.panel.Controls.Add(this.engineVolume);
            this.panel.Controls.Add(this.powerText);
            this.panel.Controls.Add(this.power);
            this.panel.Controls.Add(this.accelerationText);
            this.panel.Controls.Add(this.acceleration);
            this.panel.Controls.Add(this.maxSpeenText);
            this.panel.Controls.Add(this.maxSpeed);
            this.panel.Controls.Add(this.fuelTankCapacityText);
            this.panel.Controls.Add(this.fuelTankCapacity);
            this.panel.Controls.Add(this.transmissionText);
            this.panel.Controls.Add(this.transmission);
            this.panel.Controls.Add(this.driveText);
            this.panel.Controls.Add(this.drive);
            this.panel.Controls.Add(this.weightText);
            this.panel.Controls.Add(this.weight);
            this.panel.Controls.Add(this.priceText);
            this.panel.Controls.Add(this.price);
            this.panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel.Location = new System.Drawing.Point(252, 49);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(486, 563);
            this.panel.TabIndex = 3;
            // 
            // carId
            // 
            this.carId.BackColor = System.Drawing.SystemColors.Window;
            this.carId.Location = new System.Drawing.Point(-1, 280);
            this.carId.Name = "carId";
            this.carId.ReadOnly = true;
            this.carId.Size = new System.Drawing.Size(0, 20);
            this.carId.TabIndex = 23;
            // 
            // carName
            // 
            this.carName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.carName.Location = new System.Drawing.Point(-3, 1);
            this.carName.Name = "carName";
            this.carName.Size = new System.Drawing.Size(487, 47);
            this.carName.TabIndex = 42;
            this.carName.Text = "АВТОМОБИЛЬ";
            this.carName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // carImage
            // 
            this.carImage.Image = ((System.Drawing.Image)(resources.GetObject("carImage.Image")));
            this.carImage.Location = new System.Drawing.Point(0, 50);
            this.carImage.Name = "carImage";
            this.carImage.Size = new System.Drawing.Size(484, 250);
            this.carImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carImage.TabIndex = 21;
            this.carImage.TabStop = false;
            // 
            // engineTypeText
            // 
            this.engineTypeText.AutoSize = true;
            this.engineTypeText.Location = new System.Drawing.Point(8, 320);
            this.engineTypeText.Name = "engineTypeText";
            this.engineTypeText.Size = new System.Drawing.Size(84, 13);
            this.engineTypeText.TabIndex = 22;
            this.engineTypeText.Text = "Тип двигателя:";
            // 
            // engineType
            // 
            this.engineType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.engineType.Location = new System.Drawing.Point(11, 336);
            this.engineType.Name = "engineType";
            this.engineType.Size = new System.Drawing.Size(225, 20);
            this.engineType.TabIndex = 43;
            // 
            // engineVolumeText
            // 
            this.engineVolumeText.AutoSize = true;
            this.engineVolumeText.Location = new System.Drawing.Point(246, 320);
            this.engineVolumeText.Name = "engineVolumeText";
            this.engineVolumeText.Size = new System.Drawing.Size(100, 13);
            this.engineVolumeText.TabIndex = 24;
            this.engineVolumeText.Text = "Объём двигателя:";
            // 
            // engineVolume
            // 
            this.engineVolume.BackColor = System.Drawing.SystemColors.Window;
            this.engineVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.engineVolume.Location = new System.Drawing.Point(249, 336);
            this.engineVolume.Name = "engineVolume";
            this.engineVolume.ReadOnly = true;
            this.engineVolume.Size = new System.Drawing.Size(225, 20);
            this.engineVolume.TabIndex = 25;
            // 
            // powerText
            // 
            this.powerText.AutoSize = true;
            this.powerText.Location = new System.Drawing.Point(8, 368);
            this.powerText.Name = "powerText";
            this.powerText.Size = new System.Drawing.Size(63, 13);
            this.powerText.TabIndex = 26;
            this.powerText.Text = "Мощность:";
            // 
            // power
            // 
            this.power.BackColor = System.Drawing.SystemColors.Window;
            this.power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.power.Location = new System.Drawing.Point(11, 384);
            this.power.Name = "power";
            this.power.ReadOnly = true;
            this.power.Size = new System.Drawing.Size(225, 20);
            this.power.TabIndex = 27;
            // 
            // accelerationText
            // 
            this.accelerationText.AutoSize = true;
            this.accelerationText.Location = new System.Drawing.Point(246, 368);
            this.accelerationText.Name = "accelerationText";
            this.accelerationText.Size = new System.Drawing.Size(109, 13);
            this.accelerationText.TabIndex = 28;
            this.accelerationText.Text = "Разгон до 100 км/ч:";
            // 
            // acceleration
            // 
            this.acceleration.BackColor = System.Drawing.SystemColors.Window;
            this.acceleration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acceleration.Location = new System.Drawing.Point(249, 384);
            this.acceleration.Name = "acceleration";
            this.acceleration.ReadOnly = true;
            this.acceleration.Size = new System.Drawing.Size(225, 20);
            this.acceleration.TabIndex = 29;
            // 
            // maxSpeenText
            // 
            this.maxSpeenText.AutoSize = true;
            this.maxSpeenText.Location = new System.Drawing.Point(8, 416);
            this.maxSpeenText.Name = "maxSpeenText";
            this.maxSpeenText.Size = new System.Drawing.Size(137, 13);
            this.maxSpeenText.TabIndex = 30;
            this.maxSpeenText.Text = "Максимальная скорость:";
            // 
            // maxSpeed
            // 
            this.maxSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.maxSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxSpeed.Location = new System.Drawing.Point(11, 432);
            this.maxSpeed.Name = "maxSpeed";
            this.maxSpeed.ReadOnly = true;
            this.maxSpeed.Size = new System.Drawing.Size(225, 20);
            this.maxSpeed.TabIndex = 31;
            // 
            // fuelTankCapacityText
            // 
            this.fuelTankCapacityText.AutoSize = true;
            this.fuelTankCapacityText.Location = new System.Drawing.Point(246, 416);
            this.fuelTankCapacityText.Name = "fuelTankCapacityText";
            this.fuelTankCapacityText.Size = new System.Drawing.Size(133, 13);
            this.fuelTankCapacityText.TabIndex = 32;
            this.fuelTankCapacityText.Text = "Объём топливного бака:";
            // 
            // fuelTankCapacity
            // 
            this.fuelTankCapacity.BackColor = System.Drawing.SystemColors.Window;
            this.fuelTankCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fuelTankCapacity.Location = new System.Drawing.Point(249, 432);
            this.fuelTankCapacity.Name = "fuelTankCapacity";
            this.fuelTankCapacity.ReadOnly = true;
            this.fuelTankCapacity.Size = new System.Drawing.Size(225, 20);
            this.fuelTankCapacity.TabIndex = 33;
            // 
            // transmissionText
            // 
            this.transmissionText.AutoSize = true;
            this.transmissionText.Location = new System.Drawing.Point(8, 464);
            this.transmissionText.Name = "transmissionText";
            this.transmissionText.Size = new System.Drawing.Size(79, 13);
            this.transmissionText.TabIndex = 34;
            this.transmissionText.Text = "Трансмиссия:";
            // 
            // transmission
            // 
            this.transmission.BackColor = System.Drawing.SystemColors.Window;
            this.transmission.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transmission.Location = new System.Drawing.Point(11, 480);
            this.transmission.Name = "transmission";
            this.transmission.ReadOnly = true;
            this.transmission.Size = new System.Drawing.Size(225, 20);
            this.transmission.TabIndex = 35;
            // 
            // driveText
            // 
            this.driveText.AutoSize = true;
            this.driveText.Location = new System.Drawing.Point(246, 464);
            this.driveText.Name = "driveText";
            this.driveText.Size = new System.Drawing.Size(48, 13);
            this.driveText.TabIndex = 36;
            this.driveText.Text = "Привод:";
            // 
            // drive
            // 
            this.drive.BackColor = System.Drawing.SystemColors.Window;
            this.drive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drive.Location = new System.Drawing.Point(249, 480);
            this.drive.Name = "drive";
            this.drive.ReadOnly = true;
            this.drive.Size = new System.Drawing.Size(225, 20);
            this.drive.TabIndex = 37;
            // 
            // weightText
            // 
            this.weightText.AutoSize = true;
            this.weightText.Location = new System.Drawing.Point(8, 512);
            this.weightText.Name = "weightText";
            this.weightText.Size = new System.Drawing.Size(43, 13);
            this.weightText.TabIndex = 38;
            this.weightText.Text = "Масса:";
            // 
            // weight
            // 
            this.weight.BackColor = System.Drawing.SystemColors.Window;
            this.weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weight.Location = new System.Drawing.Point(11, 528);
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Size = new System.Drawing.Size(225, 20);
            this.weight.TabIndex = 39;
            // 
            // priceText
            // 
            this.priceText.AutoSize = true;
            this.priceText.Location = new System.Drawing.Point(246, 512);
            this.priceText.Name = "priceText";
            this.priceText.Size = new System.Drawing.Size(36, 13);
            this.priceText.TabIndex = 40;
            this.priceText.Text = "Цена:";
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.SystemColors.Window;
            this.price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.price.Location = new System.Drawing.Point(249, 528);
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Size = new System.Drawing.Size(225, 20);
            this.price.TabIndex = 41;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 612);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(738, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "Строка состояния";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel.Text = "Готово";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(738, 634);
            this.Controls.Add(this.carsNamesList);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автосалон";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton exitToolStripButton;
        private System.Windows.Forms.ListBox carsNamesList;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox carId;
        private System.Windows.Forms.Label carName;
        private System.Windows.Forms.PictureBox carImage;
        private System.Windows.Forms.Label engineTypeText;
        private System.Windows.Forms.TextBox engineType;
        private System.Windows.Forms.Label engineVolumeText;
        private System.Windows.Forms.TextBox engineVolume;
        private System.Windows.Forms.Label powerText;
        private System.Windows.Forms.TextBox power;
        private System.Windows.Forms.Label accelerationText;
        private System.Windows.Forms.TextBox acceleration;
        private System.Windows.Forms.Label maxSpeenText;
        private System.Windows.Forms.TextBox maxSpeed;
        private System.Windows.Forms.Label fuelTankCapacityText;
        private System.Windows.Forms.TextBox fuelTankCapacity;
        private System.Windows.Forms.Label transmissionText;
        private System.Windows.Forms.TextBox transmission;
        private System.Windows.Forms.Label driveText;
        private System.Windows.Forms.TextBox drive;
        private System.Windows.Forms.Label weightText;
        private System.Windows.Forms.TextBox weight;
        private System.Windows.Forms.Label priceText;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}