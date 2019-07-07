namespace RefrigeratorsShop
{
    partial class AddProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductForm));
            this.productNameText = new System.Windows.Forms.Label();
            this.productName = new System.Windows.Forms.TextBox();
            this.photoFileNameText = new System.Windows.Forms.Label();
            this.photoFileName = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.typeChoiceText = new System.Windows.Forms.Label();
            this.typeChoice = new System.Windows.Forms.ComboBox();
            this.categoryChoiceText = new System.Windows.Forms.Label();
            this.categoryChoice = new System.Windows.Forms.ComboBox();
            this.controlChoiceText = new System.Windows.Forms.Label();
            this.controlChoice = new System.Windows.Forms.ComboBox();
            this.consumptionChoiceText = new System.Windows.Forms.Label();
            this.consumptionChoice = new System.Windows.Forms.ComboBox();
            this.camerasChoiceText = new System.Windows.Forms.Label();
            this.camerasChoice = new System.Windows.Forms.ComboBox();
            this.carrangementChoiceText = new System.Windows.Forms.Label();
            this.carrangementChoice = new System.Windows.Forms.ComboBox();
            this.widthText = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.TextBox();
            this.heightText = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.TextBox();
            this.depthText = new System.Windows.Forms.Label();
            this.depth = new System.Windows.Forms.TextBox();
            this.rvolumeText = new System.Windows.Forms.Label();
            this.rvolume = new System.Windows.Forms.TextBox();
            this.fvolumeText = new System.Windows.Forms.Label();
            this.fvolume = new System.Windows.Forms.TextBox();
            this.rdefrostingText = new System.Windows.Forms.Label();
            this.rdefrosting = new System.Windows.Forms.ComboBox();
            this.fdefrostingText = new System.Windows.Forms.Label();
            this.fdefrosting = new System.Windows.Forms.ComboBox();
            this.powerText = new System.Windows.Forms.Label();
            this.power = new System.Windows.Forms.TextBox();
            this.noiseText = new System.Windows.Forms.Label();
            this.noise = new System.Windows.Forms.TextBox();
            this.priceText = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.countText = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productNameText
            // 
            resources.ApplyResources(this.productNameText, "productNameText");
            this.productNameText.Name = "productNameText";
            // 
            // productName
            // 
            resources.ApplyResources(this.productName, "productName");
            this.productName.Name = "productName";
            this.productName.TextChanged += new System.EventHandler(this.productName_TextChanged);
            // 
            // photoFileNameText
            // 
            resources.ApplyResources(this.photoFileNameText, "photoFileNameText");
            this.photoFileNameText.Name = "photoFileNameText";
            // 
            // photoFileName
            // 
            this.photoFileName.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.photoFileName, "photoFileName");
            this.photoFileName.Name = "photoFileName";
            this.photoFileName.ReadOnly = true;
            // 
            // openFile
            // 
            resources.ApplyResources(this.openFile, "openFile");
            this.openFile.Name = "openFile";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // typeChoiceText
            // 
            resources.ApplyResources(this.typeChoiceText, "typeChoiceText");
            this.typeChoiceText.Name = "typeChoiceText";
            // 
            // typeChoice
            // 
            this.typeChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeChoice.FormattingEnabled = true;
            this.typeChoice.Items.AddRange(new object[] { resources.GetString("typeChoice.Items"), resources.GetString("typeChoice.Items1"), resources.GetString("typeChoice.Items2"), resources.GetString("typeChoice.Items3"), resources.GetString("typeChoice.Items4"), resources.GetString("typeChoice.Items5"), resources.GetString("typeChoice.Items6"), resources.GetString("typeChoice.Items7") });
            resources.ApplyResources(this.typeChoice, "typeChoice");
            this.typeChoice.Name = "typeChoice";
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
            this.categoryChoice.Items.AddRange(new object[] { resources.GetString("categoryChoice.Items"), resources.GetString("categoryChoice.Items1") });
            resources.ApplyResources(this.categoryChoice, "categoryChoice");
            this.categoryChoice.Name = "categoryChoice";
            // 
            // controlChoiceText
            // 
            resources.ApplyResources(this.controlChoiceText, "controlChoiceText");
            this.controlChoiceText.Name = "controlChoiceText";
            // 
            // controlChoice
            // 
            this.controlChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.controlChoice.FormattingEnabled = true;
            this.controlChoice.Items.AddRange(new object[] { resources.GetString("controlChoice.Items"), resources.GetString("controlChoice.Items1")});
            resources.ApplyResources(this.controlChoice, "controlChoice");
            this.controlChoice.Name = "controlChoice";
            // 
            // consumptionChoiceText
            // 
            resources.ApplyResources(this.consumptionChoiceText, "consumptionChoiceText");
            this.consumptionChoiceText.Name = "consumptionChoiceText";
            // 
            // consumptionChoice
            // 
            this.consumptionChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.consumptionChoice.FormattingEnabled = true;
            this.consumptionChoice.Items.AddRange(new object[] { resources.GetString("consumptionChoice.Items"), resources.GetString("consumptionChoice.Items1"), resources.GetString("consumptionChoice.Items2"), resources.GetString("consumptionChoice.Items3"), resources.GetString("consumptionChoice.Items4"), resources.GetString("consumptionChoice.Items5"), resources.GetString("consumptionChoice.Items6"), resources.GetString("consumptionChoice.Items7"), resources.GetString("consumptionChoice.Items8") });
            resources.ApplyResources(this.consumptionChoice, "consumptionChoice");
            this.consumptionChoice.Name = "consumptionChoice";
            // 
            // camerasChoiceText
            // 
            resources.ApplyResources(this.camerasChoiceText, "camerasChoiceText");
            this.camerasChoiceText.Name = "camerasChoiceText";
            // 
            // camerasChoice
            // 
            this.camerasChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camerasChoice.FormattingEnabled = true;
            this.camerasChoice.Items.AddRange(new object[] { resources.GetString("camerasChoice.Items"), resources.GetString("camerasChoice.Items1"), resources.GetString("camerasChoice.Items2"), resources.GetString("camerasChoice.Items3"), resources.GetString("camerasChoice.Items4") });
            resources.ApplyResources(this.camerasChoice, "camerasChoice");
            this.camerasChoice.Name = "camerasChoice";
            // 
            // carrangementChoiceText
            // 
            resources.ApplyResources(this.carrangementChoiceText, "carrangementChoiceText");
            this.carrangementChoiceText.Name = "carrangementChoiceText";
            // 
            // carrangementChoice
            // 
            this.carrangementChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carrangementChoice.FormattingEnabled = true;
            this.carrangementChoice.Items.AddRange(new object[] { resources.GetString("carrangementChoice.Items"), resources.GetString("carrangementChoice.Items1"), resources.GetString("carrangementChoice.Items2"), resources.GetString("carrangementChoice.Items3") });
            resources.ApplyResources(this.carrangementChoice, "carrangementChoice");
            this.carrangementChoice.Name = "carrangementChoice";
            // 
            // widthText
            // 
            resources.ApplyResources(this.widthText, "widthText");
            this.widthText.Name = "widthText";
            // 
            // width
            // 
            resources.ApplyResources(this.width, "width");
            this.width.Name = "width";
            this.width.TextChanged += new System.EventHandler(this.width_TextChanged);
            // 
            // heightText
            // 
            resources.ApplyResources(this.heightText, "heightText");
            this.heightText.Name = "heightText";
            // 
            // height
            // 
            resources.ApplyResources(this.height, "height");
            this.height.Name = "height";
            this.height.TextChanged += new System.EventHandler(this.height_TextChanged);
            // 
            // depthText
            // 
            resources.ApplyResources(this.depthText, "depthText");
            this.depthText.Name = "depthText";
            // 
            // depth
            // 
            resources.ApplyResources(this.depth, "depth");
            this.depth.Name = "depth";
            this.depth.TextChanged += new System.EventHandler(this.depth_TextChanged);
            // 
            // rvolumeText
            // 
            resources.ApplyResources(this.rvolumeText, "rvolumeText");
            this.rvolumeText.Name = "rvolumeText";
            // 
            // rvolume
            // 
            resources.ApplyResources(this.rvolume, "rvolume");
            this.rvolume.Name = "rvolume";
            // 
            // fvolumeText
            // 
            resources.ApplyResources(this.fvolumeText, "fvolumeText");
            this.fvolumeText.Name = "fvolumeText";
            // 
            // fvolume
            // 
            resources.ApplyResources(this.fvolume, "fvolume");
            this.fvolume.Name = "fvolume";
            // 
            // rdefrostingText
            // 
            resources.ApplyResources(this.rdefrostingText, "rdefrostingText");
            this.rdefrostingText.Name = "rdefrostingText";
            // 
            // rdefrosting
            // 
            this.rdefrosting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rdefrosting.FormattingEnabled = true;
            this.rdefrosting.Items.AddRange(new object[] { resources.GetString("rdefrosting.Items"), resources.GetString("rdefrosting.Items1"), resources.GetString("rdefrosting.Items2"), resources.GetString("rdefrosting.Items3") });
            resources.ApplyResources(this.rdefrosting, "rdefrosting");
            this.rdefrosting.Name = "rdefrosting";
            // 
            // fdefrostingText
            // 
            resources.ApplyResources(this.fdefrostingText, "fdefrostingText");
            this.fdefrostingText.Name = "fdefrostingText";
            // 
            // fdefrosting
            // 
            this.fdefrosting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fdefrosting.FormattingEnabled = true;
            this.fdefrosting.Items.AddRange(new object[] { resources.GetString("fdefrosting.Items"), resources.GetString("fdefrosting.Items1"), resources.GetString("fdefrosting.Items2") });
            resources.ApplyResources(this.fdefrosting, "fdefrosting");
            this.fdefrosting.Name = "fdefrosting";
            // 
            // powerText
            // 
            resources.ApplyResources(this.powerText, "powerText");
            this.powerText.Name = "powerText";
            // 
            // power
            // 
            resources.ApplyResources(this.power, "power");
            this.power.Name = "power";
            this.power.TextChanged += new System.EventHandler(this.power_TextChanged);
            // 
            // noiseText
            // 
            resources.ApplyResources(this.noiseText, "noiseText");
            this.noiseText.Name = "noiseText";
            // 
            // noise
            // 
            resources.ApplyResources(this.noise, "noise");
            this.noise.Name = "noise";
            this.noise.TextChanged += new System.EventHandler(this.noise_TextChanged);
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
            // countText
            // 
            resources.ApplyResources(this.countText, "countText");
            this.countText.Name = "countText";
            // 
            // count
            // 
            resources.ApplyResources(this.count, "count");
            this.count.Name = "count";
            this.count.TextChanged += new System.EventHandler(this.count_TextChanged);
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
            // AddProductForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.count);
            this.Controls.Add(this.countText);
            this.Controls.Add(this.price);
            this.Controls.Add(this.priceText);
            this.Controls.Add(this.noise);
            this.Controls.Add(this.noiseText);
            this.Controls.Add(this.power);
            this.Controls.Add(this.powerText);
            this.Controls.Add(this.fdefrosting);
            this.Controls.Add(this.fdefrostingText);
            this.Controls.Add(this.rdefrosting);
            this.Controls.Add(this.rdefrostingText);
            this.Controls.Add(this.fvolume);
            this.Controls.Add(this.fvolumeText);
            this.Controls.Add(this.rvolume);
            this.Controls.Add(this.rvolumeText);
            this.Controls.Add(this.depth);
            this.Controls.Add(this.depthText);
            this.Controls.Add(this.height);
            this.Controls.Add(this.heightText);
            this.Controls.Add(this.width);
            this.Controls.Add(this.widthText);
            this.Controls.Add(this.carrangementChoice);
            this.Controls.Add(this.carrangementChoiceText);
            this.Controls.Add(this.camerasChoice);
            this.Controls.Add(this.camerasChoiceText);
            this.Controls.Add(this.consumptionChoice);
            this.Controls.Add(this.consumptionChoiceText);
            this.Controls.Add(this.controlChoice);
            this.Controls.Add(this.controlChoiceText);
            this.Controls.Add(this.categoryChoice);
            this.Controls.Add(this.categoryChoiceText);
            this.Controls.Add(this.typeChoice);
            this.Controls.Add(this.typeChoiceText);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.photoFileName);
            this.Controls.Add(this.photoFileNameText);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.productNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label productNameText;
        private System.Windows.Forms.TextBox productName;
        private System.Windows.Forms.Label photoFileNameText;
        private System.Windows.Forms.TextBox photoFileName;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label typeChoiceText;
        private System.Windows.Forms.ComboBox typeChoice;
        private System.Windows.Forms.Label categoryChoiceText;
        private System.Windows.Forms.ComboBox categoryChoice;
        private System.Windows.Forms.Label controlChoiceText;
        private System.Windows.Forms.ComboBox controlChoice;
        private System.Windows.Forms.Label consumptionChoiceText;
        private System.Windows.Forms.ComboBox consumptionChoice;
        private System.Windows.Forms.Label camerasChoiceText;
        private System.Windows.Forms.ComboBox camerasChoice;
        private System.Windows.Forms.Label carrangementChoiceText;
        private System.Windows.Forms.ComboBox carrangementChoice;
        private System.Windows.Forms.Label widthText;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Label heightText;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.Label depthText;
        private System.Windows.Forms.TextBox depth;
        private System.Windows.Forms.Label rvolumeText;
        private System.Windows.Forms.TextBox rvolume;
        private System.Windows.Forms.Label fvolumeText;
        private System.Windows.Forms.TextBox fvolume;
        private System.Windows.Forms.Label rdefrostingText;
        private System.Windows.Forms.ComboBox rdefrosting;
        private System.Windows.Forms.Label fdefrostingText;
        private System.Windows.Forms.ComboBox fdefrosting;
        private System.Windows.Forms.Label powerText;
        private System.Windows.Forms.TextBox power;
        private System.Windows.Forms.Label noiseText;
        private System.Windows.Forms.TextBox noise;
        private System.Windows.Forms.Label priceText;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label countText;
        private System.Windows.Forms.TextBox count;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}