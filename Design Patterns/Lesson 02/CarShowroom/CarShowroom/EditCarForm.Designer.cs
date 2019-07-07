namespace CarShowroom
{
    partial class EditCarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCarForm));
            this.carNameText = new System.Windows.Forms.Label();
            this.carName = new System.Windows.Forms.TextBox();
            this.carPhotoText = new System.Windows.Forms.Label();
            this.carPhoto = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.engineTypeChoice = new System.Windows.Forms.Label();
            this.engineType = new System.Windows.Forms.ComboBox();
            this.engineVolumeText = new System.Windows.Forms.Label();
            this.engineVolume = new System.Windows.Forms.NumericUpDown();
            this.powerText = new System.Windows.Forms.Label();
            this.power = new System.Windows.Forms.NumericUpDown();
            this.acceleration = new System.Windows.Forms.NumericUpDown();
            this.accelerationText = new System.Windows.Forms.Label();
            this.fuelTankCapacity = new System.Windows.Forms.NumericUpDown();
            this.fuelTankCapacityText = new System.Windows.Forms.Label();
            this.maxSpeed = new System.Windows.Forms.NumericUpDown();
            this.maxSpeedText = new System.Windows.Forms.Label();
            this.driveChoice = new System.Windows.Forms.Label();
            this.transmissionChoice = new System.Windows.Forms.Label();
            this.transmission = new System.Windows.Forms.ComboBox();
            this.drive = new System.Windows.Forms.ComboBox();
            this.price = new System.Windows.Forms.NumericUpDown();
            this.priceText = new System.Windows.Forms.Label();
            this.weight = new System.Windows.Forms.NumericUpDown();
            this.weightText = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.engineVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.power)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceleration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelTankCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weight)).BeginInit();
            this.SuspendLayout();
            // 
            // carNameText
            // 
            this.carNameText.AutoSize = true;
            this.carNameText.Location = new System.Drawing.Point(9, 9);
            this.carNameText.Name = "carNameText";
            this.carNameText.Size = new System.Drawing.Size(124, 13);
            this.carNameText.TabIndex = 0;
            this.carNameText.Text = "Название автомобиля:";
            // 
            // carName
            // 
            this.carName.Location = new System.Drawing.Point(12, 25);
            this.carName.Name = "carName";
            this.carName.Size = new System.Drawing.Size(460, 20);
            this.carName.TabIndex = 1;
            this.carName.TextChanged += new System.EventHandler(this.carName_TextChanged);
            // 
            // carPhotoText
            // 
            this.carPhotoText.AutoSize = true;
            this.carPhotoText.Location = new System.Drawing.Point(9, 57);
            this.carPhotoText.Name = "carPhotoText";
            this.carPhotoText.Size = new System.Drawing.Size(75, 13);
            this.carPhotoText.TabIndex = 2;
            this.carPhotoText.Text = "Фотография:";
            // 
            // carPhoto
            // 
            this.carPhoto.Location = new System.Drawing.Point(12, 73);
            this.carPhoto.Name = "carPhoto";
            this.carPhoto.ReadOnly = true;
            this.carPhoto.Size = new System.Drawing.Size(426, 20);
            this.carPhoto.TabIndex = 3;
            this.carPhoto.TextChanged += new System.EventHandler(this.carPhoto_TextChanged);
            // 
            // openFile
            // 
            this.openFile.Image = ((System.Drawing.Image)(resources.GetObject("openFile.Image")));
            this.openFile.Location = new System.Drawing.Point(444, 72);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(28, 22);
            this.openFile.TabIndex = 4;
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Файлы изображений|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            // 
            // engineTypeChoice
            // 
            this.engineTypeChoice.AutoSize = true;
            this.engineTypeChoice.Location = new System.Drawing.Point(9, 105);
            this.engineTypeChoice.Name = "engineTypeChoice";
            this.engineTypeChoice.Size = new System.Drawing.Size(84, 13);
            this.engineTypeChoice.TabIndex = 5;
            this.engineTypeChoice.Text = "Тип двигателя:";
            // 
            // engineType
            // 
            this.engineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engineType.FormattingEnabled = true;
            this.engineType.Items.AddRange(new object[] { "Бензиновый", "Газовый", "Дизельный", "Поршневой", "Роторно-поршневой" });
            this.engineType.Location = new System.Drawing.Point(12, 121);
            this.engineType.Name = "engineType";
            this.engineType.Size = new System.Drawing.Size(460, 21);
            this.engineType.TabIndex = 6;
            // 
            // engineVolumeText
            // 
            this.engineVolumeText.AutoSize = true;
            this.engineVolumeText.Location = new System.Drawing.Point(9, 154);
            this.engineVolumeText.Name = "engineVolumeText";
            this.engineVolumeText.Size = new System.Drawing.Size(100, 13);
            this.engineVolumeText.TabIndex = 7;
            this.engineVolumeText.Text = "Объём двигателя:";
            // 
            // engineVolume
            // 
            this.engineVolume.Location = new System.Drawing.Point(12, 170);
            this.engineVolume.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.engineVolume.Name = "engineVolume";
            this.engineVolume.Size = new System.Drawing.Size(460, 20);
            this.engineVolume.TabIndex = 8;
            // 
            // powerText
            // 
            this.powerText.AutoSize = true;
            this.powerText.Location = new System.Drawing.Point(9, 202);
            this.powerText.Name = "powerText";
            this.powerText.Size = new System.Drawing.Size(93, 13);
            this.powerText.TabIndex = 9;
            this.powerText.Text = "Мощность (л. с.):";
            // 
            // power
            // 
            this.power.Location = new System.Drawing.Point(12, 218);
            this.power.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(224, 20);
            this.power.TabIndex = 10;
            // 
            // acceleration
            // 
            this.acceleration.Location = new System.Drawing.Point(248, 218);
            this.acceleration.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.acceleration.Name = "acceleration";
            this.acceleration.Size = new System.Drawing.Size(224, 20);
            this.acceleration.TabIndex = 12;
            // 
            // accelerationText
            // 
            this.accelerationText.AutoSize = true;
            this.accelerationText.Location = new System.Drawing.Point(245, 202);
            this.accelerationText.Name = "accelerationText";
            this.accelerationText.Size = new System.Drawing.Size(124, 13);
            this.accelerationText.TabIndex = 11;
            this.accelerationText.Text = "Разгон до 100 км/ч (с):";
            // 
            // fuelTankCapacity
            // 
            this.fuelTankCapacity.Location = new System.Drawing.Point(248, 266);
            this.fuelTankCapacity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.fuelTankCapacity.Name = "fuelTankCapacity";
            this.fuelTankCapacity.Size = new System.Drawing.Size(224, 20);
            this.fuelTankCapacity.TabIndex = 16;
            // 
            // fuelTankCapacityText
            // 
            this.fuelTankCapacityText.AutoSize = true;
            this.fuelTankCapacityText.Location = new System.Drawing.Point(245, 250);
            this.fuelTankCapacityText.Name = "fuelTankCapacityText";
            this.fuelTankCapacityText.Size = new System.Drawing.Size(148, 13);
            this.fuelTankCapacityText.TabIndex = 15;
            this.fuelTankCapacityText.Text = "Объём топливного бака (л):";
            // 
            // maxSpeed
            // 
            this.maxSpeed.Location = new System.Drawing.Point(12, 266);
            this.maxSpeed.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.maxSpeed.Name = "maxSpeed";
            this.maxSpeed.Size = new System.Drawing.Size(224, 20);
            this.maxSpeed.TabIndex = 14;
            // 
            // maxSpeedText
            // 
            this.maxSpeedText.AutoSize = true;
            this.maxSpeedText.Location = new System.Drawing.Point(9, 250);
            this.maxSpeedText.Name = "maxSpeedText";
            this.maxSpeedText.Size = new System.Drawing.Size(170, 13);
            this.maxSpeedText.TabIndex = 13;
            this.maxSpeedText.Text = "Максимальная скорость (км/ч):";
            // 
            // driveChoice
            // 
            this.driveChoice.AutoSize = true;
            this.driveChoice.Location = new System.Drawing.Point(245, 298);
            this.driveChoice.Name = "driveChoice";
            this.driveChoice.Size = new System.Drawing.Size(48, 13);
            this.driveChoice.TabIndex = 19;
            this.driveChoice.Text = "Привод:";
            // 
            // transmissionChoice
            // 
            this.transmissionChoice.AutoSize = true;
            this.transmissionChoice.Location = new System.Drawing.Point(9, 298);
            this.transmissionChoice.Name = "transmissionChoice";
            this.transmissionChoice.Size = new System.Drawing.Size(79, 13);
            this.transmissionChoice.TabIndex = 17;
            this.transmissionChoice.Text = "Трансмиссия:";
            // 
            // transmission
            // 
            this.transmission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transmission.FormattingEnabled = true;
            this.transmission.Items.AddRange(new object[] { "Автоматическая", "Механическая" });
            this.transmission.Location = new System.Drawing.Point(12, 314);
            this.transmission.Name = "transmission";
            this.transmission.Size = new System.Drawing.Size(224, 21);
            this.transmission.TabIndex = 20;
            // 
            // drive
            // 
            this.drive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drive.FormattingEnabled = true;
            this.drive.Items.AddRange(new object[] { "Передний", "Задний", "Полный" });
            this.drive.Location = new System.Drawing.Point(248, 314);
            this.drive.Name = "drive";
            this.drive.Size = new System.Drawing.Size(224, 21);
            this.drive.TabIndex = 21;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(248, 363);
            this.price.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(224, 20);
            this.price.TabIndex = 25;
            // 
            // priceText
            // 
            this.priceText.AutoSize = true;
            this.priceText.Location = new System.Drawing.Point(245, 347);
            this.priceText.Name = "priceText";
            this.priceText.Size = new System.Drawing.Size(65, 13);
            this.priceText.TabIndex = 24;
            this.priceText.Text = "Цена (грн.):";
            // 
            // weight
            // 
            this.weight.DecimalPlaces = 1;
            this.weight.Location = new System.Drawing.Point(12, 363);
            this.weight.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(224, 20);
            this.weight.TabIndex = 23;
            // 
            // weightText
            // 
            this.weightText.AutoSize = true;
            this.weightText.Location = new System.Drawing.Point(9, 347);
            this.weightText.Name = "weightText";
            this.weightText.Size = new System.Drawing.Size(63, 13);
            this.weightText.TabIndex = 22;
            this.weightText.Text = "Масса (кг):";
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Enabled = false;
            this.ok.Image = ((System.Drawing.Image)(resources.GetObject("ok.Image")));
            this.ok.Location = new System.Drawing.Point(12, 397);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(224, 23);
            this.ok.TabIndex = 26;
            this.ok.Text = "Подтвердить";
            this.ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Image = ((System.Drawing.Image)(resources.GetObject("cancel.Image")));
            this.cancel.Location = new System.Drawing.Point(248, 397);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(224, 23);
            this.cancel.TabIndex = 27;
            this.cancel.Text = "Отмена";
            this.cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EditCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 433);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.price);
            this.Controls.Add(this.priceText);
            this.Controls.Add(this.weight);
            this.Controls.Add(this.weightText);
            this.Controls.Add(this.drive);
            this.Controls.Add(this.transmission);
            this.Controls.Add(this.driveChoice);
            this.Controls.Add(this.transmissionChoice);
            this.Controls.Add(this.fuelTankCapacity);
            this.Controls.Add(this.fuelTankCapacityText);
            this.Controls.Add(this.maxSpeed);
            this.Controls.Add(this.maxSpeedText);
            this.Controls.Add(this.acceleration);
            this.Controls.Add(this.accelerationText);
            this.Controls.Add(this.power);
            this.Controls.Add(this.powerText);
            this.Controls.Add(this.engineVolume);
            this.Controls.Add(this.engineVolumeText);
            this.Controls.Add(this.engineType);
            this.Controls.Add(this.engineTypeChoice);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.carPhoto);
            this.Controls.Add(this.carPhotoText);
            this.Controls.Add(this.carName);
            this.Controls.Add(this.carNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCarForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование данных";
            ((System.ComponentModel.ISupportInitialize)(this.engineVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.power)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceleration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelTankCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label carNameText;
        private System.Windows.Forms.TextBox carName;
        private System.Windows.Forms.Label carPhotoText;
        private System.Windows.Forms.TextBox carPhoto;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label engineTypeChoice;
        private System.Windows.Forms.ComboBox engineType;
        private System.Windows.Forms.Label engineVolumeText;
        private System.Windows.Forms.NumericUpDown engineVolume;
        private System.Windows.Forms.Label powerText;
        private System.Windows.Forms.NumericUpDown power;
        private System.Windows.Forms.NumericUpDown acceleration;
        private System.Windows.Forms.Label accelerationText;
        private System.Windows.Forms.NumericUpDown fuelTankCapacity;
        private System.Windows.Forms.Label fuelTankCapacityText;
        private System.Windows.Forms.NumericUpDown maxSpeed;
        private System.Windows.Forms.Label maxSpeedText;
        private System.Windows.Forms.Label driveChoice;
        private System.Windows.Forms.Label transmissionChoice;
        private System.Windows.Forms.ComboBox transmission;
        private System.Windows.Forms.ComboBox drive;
        private System.Windows.Forms.NumericUpDown price;
        private System.Windows.Forms.Label priceText;
        private System.Windows.Forms.NumericUpDown weight;
        private System.Windows.Forms.Label weightText;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}