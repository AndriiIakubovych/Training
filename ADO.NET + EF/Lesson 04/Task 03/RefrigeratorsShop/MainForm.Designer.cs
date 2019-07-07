namespace RefrigeratorsShop
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
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripProducts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSellers = new System.Windows.Forms.ToolStripButton();
            this.toolStripBuyers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripExit = new System.Windows.Forms.ToolStripButton();
            this.productsLists = new System.Windows.Forms.GroupBox();
            this.chosenCount = new System.Windows.Forms.TextBox();
            this.chosenCountText = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.buyerProductsList = new System.Windows.Forms.ListBox();
            this.deleteFromList = new System.Windows.Forms.Button();
            this.addToList = new System.Windows.Forms.Button();
            this.shopProductsList = new System.Windows.Forms.ListBox();
            this.productInformation = new System.Windows.Forms.GroupBox();
            this.fvolumeText = new System.Windows.Forms.Label();
            this.sell = new System.Windows.Forms.Button();
            this.count = new System.Windows.Forms.TextBox();
            this.countText = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.priceText = new System.Windows.Forms.Label();
            this.noise = new System.Windows.Forms.TextBox();
            this.noiseText = new System.Windows.Forms.Label();
            this.power = new System.Windows.Forms.TextBox();
            this.powerText = new System.Windows.Forms.Label();
            this.fdefrosting = new System.Windows.Forms.TextBox();
            this.fdefrostingText = new System.Windows.Forms.Label();
            this.rdefrosting = new System.Windows.Forms.TextBox();
            this.rdefrostingText = new System.Windows.Forms.Label();
            this.fvolume = new System.Windows.Forms.TextBox();
            this.rvolume = new System.Windows.Forms.TextBox();
            this.rvolumeText = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.TextBox();
            this.sizeText = new System.Windows.Forms.Label();
            this.carrangement = new System.Windows.Forms.TextBox();
            this.carrangementText = new System.Windows.Forms.Label();
            this.cameras = new System.Windows.Forms.TextBox();
            this.camerasText = new System.Windows.Forms.Label();
            this.consumption = new System.Windows.Forms.TextBox();
            this.consumptionText = new System.Windows.Forms.Label();
            this.control = new System.Windows.Forms.TextBox();
            this.controlText = new System.Windows.Forms.Label();
            this.category = new System.Windows.Forms.TextBox();
            this.categoryText = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.TextBox();
            this.typeText = new System.Windows.Forms.Label();
            this.productName = new System.Windows.Forms.TextBox();
            this.productNameText = new System.Windows.Forms.Label();
            this.productPhoto = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.productsLists.SuspendLayout();
            this.productInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productPhoto)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem,
            this.sellersToolStripMenuItem,
            this.buyersToolStripMenuItem,
            this.separatorMenuItem,
            this.exitToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            resources.ApplyResources(this.dataToolStripMenuItem, "dataToolStripMenuItem");
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            resources.ApplyResources(this.productsToolStripMenuItem, "productsToolStripMenuItem");
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            this.productsToolStripMenuItem.MouseLeave += new System.EventHandler(this.productsToolStripMenuItem_MouseLeave);
            this.productsToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.productsToolStripMenuItem_MouseMove);
            // 
            // sellersToolStripMenuItem
            // 
            this.sellersToolStripMenuItem.Name = "sellersToolStripMenuItem";
            resources.ApplyResources(this.sellersToolStripMenuItem, "sellersToolStripMenuItem");
            this.sellersToolStripMenuItem.Click += new System.EventHandler(this.sellersToolStripMenuItem_Click);
            this.sellersToolStripMenuItem.MouseLeave += new System.EventHandler(this.sellersToolStripMenuItem_MouseLeave);
            this.sellersToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sellersToolStripMenuItem_MouseMove);
            // 
            // buyersToolStripMenuItem
            // 
            this.buyersToolStripMenuItem.Name = "buyersToolStripMenuItem";
            resources.ApplyResources(this.buyersToolStripMenuItem, "buyersToolStripMenuItem");
            this.buyersToolStripMenuItem.Click += new System.EventHandler(this.buyersToolStripMenuItem_Click);
            this.buyersToolStripMenuItem.MouseLeave += new System.EventHandler(this.buyersToolStripMenuItem_MouseLeave);
            this.buyersToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buyersToolStripMenuItem_MouseMove);
            // 
            // separatorMenuItem
            // 
            this.separatorMenuItem.Name = "separatorMenuItem";
            resources.ApplyResources(this.separatorMenuItem, "separatorMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            this.exitToolStripMenuItem.MouseLeave += new System.EventHandler(this.exitToolStripMenuItem_MouseLeave);
            this.exitToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exitToolStripMenuItem_MouseMove);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripProducts, this.toolStripSellers, this.toolStripBuyers, this.toolStripSeparator, this.toolStripExit });
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // toolStripProducts
            // 
            this.toolStripProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripProducts, "toolStripProducts");
            this.toolStripProducts.Name = "toolStripProducts";
            this.toolStripProducts.Click += new System.EventHandler(this.toolStripProducts_Click);
            this.toolStripProducts.MouseLeave += new System.EventHandler(this.toolStripProducts_MouseLeave);
            this.toolStripProducts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripProducts_MouseMove);
            // 
            // toolStripSellers
            // 
            this.toolStripSellers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripSellers, "toolStripSellers");
            this.toolStripSellers.Name = "toolStripSellers";
            this.toolStripSellers.Click += new System.EventHandler(this.toolStripSellers_Click);
            this.toolStripSellers.MouseLeave += new System.EventHandler(this.toolStripSellers_MouseLeave);
            this.toolStripSellers.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripSellers_MouseMove);
            // 
            // toolStripBuyers
            // 
            this.toolStripBuyers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripBuyers, "toolStripBuyers");
            this.toolStripBuyers.Name = "toolStripBuyers";
            this.toolStripBuyers.Click += new System.EventHandler(this.toolStripBuyers_Click);
            this.toolStripBuyers.MouseLeave += new System.EventHandler(this.toolStripBuyers_MouseLeave);
            this.toolStripBuyers.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripBuyers_MouseMove);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // toolStripExit
            // 
            this.toolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripExit, "toolStripExit");
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            this.toolStripExit.MouseLeave += new System.EventHandler(this.toolStripExit_MouseLeave);
            this.toolStripExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripExit_MouseMove);
            // 
            // productsLists
            // 
            this.productsLists.Controls.Add(this.chosenCount);
            this.productsLists.Controls.Add(this.chosenCountText);
            this.productsLists.Controls.Add(this.update);
            this.productsLists.Controls.Add(this.buyerProductsList);
            this.productsLists.Controls.Add(this.deleteFromList);
            this.productsLists.Controls.Add(this.addToList);
            this.productsLists.Controls.Add(this.shopProductsList);
            resources.ApplyResources(this.productsLists, "productsLists");
            this.productsLists.Name = "productsLists";
            this.productsLists.TabStop = false;
            // 
            // chosenCount
            // 
            this.chosenCount.BackColor = System.Drawing.SystemColors.Window;
            this.chosenCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.chosenCount, "chosenCount");
            this.chosenCount.Name = "chosenCount";
            this.chosenCount.ReadOnly = true;
            // 
            // chosenCountText
            // 
            resources.ApplyResources(this.chosenCountText, "chosenCountText");
            this.chosenCountText.Name = "chosenCountText";
            // 
            // update
            // 
            resources.ApplyResources(this.update, "update");
            this.update.Name = "update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // buyerProductsList
            // 
            this.buyerProductsList.FormattingEnabled = true;
            resources.ApplyResources(this.buyerProductsList, "buyerProductsList");
            this.buyerProductsList.Name = "buyerProductsList";
            this.buyerProductsList.Sorted = true;
            this.buyerProductsList.SelectedIndexChanged += new System.EventHandler(this.buyerProductsList_SelectedIndexChanged);
            // 
            // deleteFromList
            // 
            resources.ApplyResources(this.deleteFromList, "deleteFromList");
            this.deleteFromList.Name = "deleteFromList";
            this.deleteFromList.UseVisualStyleBackColor = true;
            this.deleteFromList.Click += new System.EventHandler(this.deleteFromList_Click);
            // 
            // addToList
            // 
            resources.ApplyResources(this.addToList, "addToList");
            this.addToList.Name = "addToList";
            this.addToList.UseVisualStyleBackColor = true;
            this.addToList.Click += new System.EventHandler(this.addToList_Click);
            // 
            // shopProductsList
            // 
            this.shopProductsList.FormattingEnabled = true;
            resources.ApplyResources(this.shopProductsList, "shopProductsList");
            this.shopProductsList.Name = "shopProductsList";
            this.shopProductsList.Sorted = true;
            this.shopProductsList.SelectedIndexChanged += new System.EventHandler(this.shopProductsList_SelectedIndexChanged);
            // 
            // productInformation
            // 
            this.productInformation.Controls.Add(this.fvolumeText);
            this.productInformation.Controls.Add(this.sell);
            this.productInformation.Controls.Add(this.count);
            this.productInformation.Controls.Add(this.countText);
            this.productInformation.Controls.Add(this.price);
            this.productInformation.Controls.Add(this.priceText);
            this.productInformation.Controls.Add(this.noise);
            this.productInformation.Controls.Add(this.noiseText);
            this.productInformation.Controls.Add(this.power);
            this.productInformation.Controls.Add(this.powerText);
            this.productInformation.Controls.Add(this.fdefrosting);
            this.productInformation.Controls.Add(this.fdefrostingText);
            this.productInformation.Controls.Add(this.rdefrosting);
            this.productInformation.Controls.Add(this.rdefrostingText);
            this.productInformation.Controls.Add(this.fvolume);
            this.productInformation.Controls.Add(this.rvolume);
            this.productInformation.Controls.Add(this.rvolumeText);
            this.productInformation.Controls.Add(this.size);
            this.productInformation.Controls.Add(this.sizeText);
            this.productInformation.Controls.Add(this.carrangement);
            this.productInformation.Controls.Add(this.carrangementText);
            this.productInformation.Controls.Add(this.cameras);
            this.productInformation.Controls.Add(this.camerasText);
            this.productInformation.Controls.Add(this.consumption);
            this.productInformation.Controls.Add(this.consumptionText);
            this.productInformation.Controls.Add(this.control);
            this.productInformation.Controls.Add(this.controlText);
            this.productInformation.Controls.Add(this.category);
            this.productInformation.Controls.Add(this.categoryText);
            this.productInformation.Controls.Add(this.type);
            this.productInformation.Controls.Add(this.typeText);
            this.productInformation.Controls.Add(this.productName);
            this.productInformation.Controls.Add(this.productNameText);
            this.productInformation.Controls.Add(this.productPhoto);
            resources.ApplyResources(this.productInformation, "productInformation");
            this.productInformation.Name = "productInformation";
            this.productInformation.TabStop = false;
            // 
            // fvolumeText
            // 
            resources.ApplyResources(this.fvolumeText, "fvolumeText");
            this.fvolumeText.Name = "fvolumeText";
            // 
            // sell
            // 
            resources.ApplyResources(this.sell, "sell");
            this.sell.Name = "sell";
            this.sell.UseVisualStyleBackColor = true;
            this.sell.Click += new System.EventHandler(this.sell_Click);
            // 
            // count
            // 
            this.count.BackColor = System.Drawing.SystemColors.Window;
            this.count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.count, "count");
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // countText
            // 
            resources.ApplyResources(this.countText, "countText");
            this.countText.Name = "countText";
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.SystemColors.Window;
            this.price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.price, "price");
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // priceText
            // 
            resources.ApplyResources(this.priceText, "priceText");
            this.priceText.Name = "priceText";
            // 
            // noise
            // 
            this.noise.BackColor = System.Drawing.SystemColors.Window;
            this.noise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.noise, "noise");
            this.noise.Name = "noise";
            this.noise.ReadOnly = true;
            // 
            // noiseText
            // 
            resources.ApplyResources(this.noiseText, "noiseText");
            this.noiseText.Name = "noiseText";
            // 
            // power
            // 
            this.power.BackColor = System.Drawing.SystemColors.Window;
            this.power.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.power, "power");
            this.power.Name = "power";
            this.power.ReadOnly = true;
            // 
            // powerText
            // 
            resources.ApplyResources(this.powerText, "powerText");
            this.powerText.Name = "powerText";
            // 
            // fdefrosting
            // 
            this.fdefrosting.BackColor = System.Drawing.SystemColors.Window;
            this.fdefrosting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.fdefrosting, "fdefrosting");
            this.fdefrosting.Name = "fdefrosting";
            this.fdefrosting.ReadOnly = true;
            // 
            // fdefrostingText
            // 
            resources.ApplyResources(this.fdefrostingText, "fdefrostingText");
            this.fdefrostingText.Name = "fdefrostingText";
            // 
            // rdefrosting
            // 
            this.rdefrosting.BackColor = System.Drawing.SystemColors.Window;
            this.rdefrosting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.rdefrosting, "rdefrosting");
            this.rdefrosting.Name = "rdefrosting";
            this.rdefrosting.ReadOnly = true;
            // 
            // rdefrostingText
            // 
            resources.ApplyResources(this.rdefrostingText, "rdefrostingText");
            this.rdefrostingText.Name = "rdefrostingText";
            // 
            // fvolume
            // 
            this.fvolume.BackColor = System.Drawing.SystemColors.Window;
            this.fvolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.fvolume, "fvolume");
            this.fvolume.Name = "fvolume";
            this.fvolume.ReadOnly = true;
            // 
            // rvolume
            // 
            this.rvolume.BackColor = System.Drawing.SystemColors.Window;
            this.rvolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.rvolume, "rvolume");
            this.rvolume.Name = "rvolume";
            this.rvolume.ReadOnly = true;
            // 
            // rvolumeText
            // 
            resources.ApplyResources(this.rvolumeText, "rvolumeText");
            this.rvolumeText.Name = "rvolumeText";
            // 
            // size
            // 
            this.size.BackColor = System.Drawing.SystemColors.Window;
            this.size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.size, "size");
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // sizeText
            // 
            resources.ApplyResources(this.sizeText, "sizeText");
            this.sizeText.Name = "sizeText";
            // 
            // carrangement
            // 
            this.carrangement.BackColor = System.Drawing.SystemColors.Window;
            this.carrangement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.carrangement, "carrangement");
            this.carrangement.Name = "carrangement";
            this.carrangement.ReadOnly = true;
            // 
            // carrangementText
            // 
            resources.ApplyResources(this.carrangementText, "carrangementText");
            this.carrangementText.Name = "carrangementText";
            // 
            // cameras
            // 
            this.cameras.BackColor = System.Drawing.SystemColors.Window;
            this.cameras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.cameras, "cameras");
            this.cameras.Name = "cameras";
            this.cameras.ReadOnly = true;
            // 
            // camerasText
            // 
            resources.ApplyResources(this.camerasText, "camerasText");
            this.camerasText.Name = "camerasText";
            // 
            // consumption
            // 
            this.consumption.BackColor = System.Drawing.SystemColors.Window;
            this.consumption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.consumption, "consumption");
            this.consumption.Name = "consumption";
            this.consumption.ReadOnly = true;
            // 
            // consumptionText
            // 
            resources.ApplyResources(this.consumptionText, "consumptionText");
            this.consumptionText.Name = "consumptionText";
            // 
            // control
            // 
            this.control.BackColor = System.Drawing.SystemColors.Window;
            this.control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.control, "control");
            this.control.Name = "control";
            this.control.ReadOnly = true;
            // 
            // controlText
            // 
            resources.ApplyResources(this.controlText, "controlText");
            this.controlText.Name = "controlText";
            // 
            // category
            // 
            this.category.BackColor = System.Drawing.SystemColors.Window;
            this.category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.category, "category");
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // categoryText
            // 
            resources.ApplyResources(this.categoryText, "categoryText");
            this.categoryText.Name = "categoryText";
            // 
            // type
            // 
            this.type.BackColor = System.Drawing.SystemColors.Window;
            this.type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.type, "type");
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // typeText
            // 
            resources.ApplyResources(this.typeText, "typeText");
            this.typeText.Name = "typeText";
            // 
            // productName
            // 
            this.productName.BackColor = System.Drawing.SystemColors.Window;
            this.productName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.productName, "productName");
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            // 
            // productNameText
            // 
            resources.ApplyResources(this.productNameText, "productNameText");
            this.productNameText.Name = "productNameText";
            // 
            // productPhoto
            // 
            this.productPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.productPhoto, "productPhoto");
            this.productPhoto.Name = "productPhoto";
            this.productPhoto.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.SizingGrip = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.productInformation);
            this.Controls.Add(this.productsLists);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.productsLists.ResumeLayout(false);
            this.productsLists.PerformLayout();
            this.productInformation.ResumeLayout(false);
            this.productInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productPhoto)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buyersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator separatorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripProducts;
        private System.Windows.Forms.ToolStripButton toolStripSellers;
        private System.Windows.Forms.ToolStripButton toolStripBuyers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolStripExit;
        private System.Windows.Forms.GroupBox productsLists;
        private System.Windows.Forms.ListBox shopProductsList;
        private System.Windows.Forms.Button addToList;
        private System.Windows.Forms.Button deleteFromList;
        private System.Windows.Forms.ListBox buyerProductsList;
        private System.Windows.Forms.Label chosenCountText;
        private System.Windows.Forms.TextBox chosenCount;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.GroupBox productInformation;
        private System.Windows.Forms.PictureBox productPhoto;
        private System.Windows.Forms.Label productNameText;
        private System.Windows.Forms.TextBox productName;
        private System.Windows.Forms.Label typeText;
        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.Label categoryText;
        private System.Windows.Forms.TextBox category;
        private System.Windows.Forms.Label controlText;
        private System.Windows.Forms.TextBox control;
        private System.Windows.Forms.Label consumptionText;
        private System.Windows.Forms.TextBox consumption;
        private System.Windows.Forms.Label camerasText;
        private System.Windows.Forms.TextBox cameras;
        private System.Windows.Forms.Label carrangementText;
        private System.Windows.Forms.TextBox carrangement;
        private System.Windows.Forms.Label sizeText;
        private System.Windows.Forms.TextBox size;
        private System.Windows.Forms.Label rvolumeText;
        private System.Windows.Forms.TextBox rvolume;
        private System.Windows.Forms.Label fvolumeText;
        private System.Windows.Forms.TextBox fvolume;
        private System.Windows.Forms.Label rdefrostingText;
        private System.Windows.Forms.TextBox rdefrosting;
        private System.Windows.Forms.Label fdefrostingText;
        private System.Windows.Forms.TextBox fdefrosting;
        private System.Windows.Forms.Label powerText;
        private System.Windows.Forms.TextBox power;
        private System.Windows.Forms.Label noiseText;
        private System.Windows.Forms.TextBox noise;
        private System.Windows.Forms.Label priceText;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label countText;
        private System.Windows.Forms.TextBox count;
        private System.Windows.Forms.Button sell;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}