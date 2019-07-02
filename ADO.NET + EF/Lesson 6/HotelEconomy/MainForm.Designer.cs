namespace HotelEconomy
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
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsHiringOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripClients = new System.Windows.Forms.ToolStripButton();
            this.toolStripRooms = new System.Windows.Forms.ToolStripButton();
            this.toolStripEmployees = new System.Windows.Forms.ToolStripButton();
            this.toolStripFirstSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRoomsHiringOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripExpenses = new System.Windows.Forms.ToolStripButton();
            this.toolStripSecondSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.hotelData = new System.Windows.Forms.GroupBox();
            this.update = new System.Windows.Forms.Button();
            this.employeesCount = new System.Windows.Forms.TextBox();
            this.employeesCountText = new System.Windows.Forms.Label();
            this.roomsCount = new System.Windows.Forms.TextBox();
            this.roomsCountText = new System.Windows.Forms.Label();
            this.clientsCountShow = new System.Windows.Forms.Button();
            this.clientsCount = new System.Windows.Forms.TextBox();
            this.clientsCountText = new System.Windows.Forms.Label();
            this.clientsEndDate = new System.Windows.Forms.DateTimePicker();
            this.clientsSeparator = new System.Windows.Forms.Label();
            this.clientsBeginningDate = new System.Windows.Forms.DateTimePicker();
            this.clientsPeriodText = new System.Windows.Forms.Label();
            this.clientsIncomesData = new System.Windows.Forms.GroupBox();
            this.incomesCalculate = new System.Windows.Forms.Button();
            this.incomes = new System.Windows.Forms.TextBox();
            this.incomesText = new System.Windows.Forms.Label();
            this.incomesEndDate = new System.Windows.Forms.DateTimePicker();
            this.incomesSeparator = new System.Windows.Forms.Label();
            this.incomesBeginningDate = new System.Windows.Forms.DateTimePicker();
            this.incomesPeriodText = new System.Windows.Forms.Label();
            this.expensesData = new System.Windows.Forms.GroupBox();
            this.expensesCalculate = new System.Windows.Forms.Button();
            this.expenses = new System.Windows.Forms.TextBox();
            this.expensesText = new System.Windows.Forms.Label();
            this.expensesEndDate = new System.Windows.Forms.DateTimePicker();
            this.expensesSeparator = new System.Windows.Forms.Label();
            this.expensesBeginningDate = new System.Windows.Forms.DateTimePicker();
            this.expensesPeriodText = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.hotelData.SuspendLayout();
            this.clientsIncomesData.SuspendLayout();
            this.expensesData.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.directoriesToolStripMenuItem,
            this.operationalInformationToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersDataToolStripMenuItem,
            this.changeUserToolStripMenuItem,
            this.toolStripMenuItem,
            this.exitToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            resources.ApplyResources(this.usersToolStripMenuItem, "usersToolStripMenuItem");
            // 
            // usersDataToolStripMenuItem
            // 
            this.usersDataToolStripMenuItem.Name = "usersDataToolStripMenuItem";
            resources.ApplyResources(this.usersDataToolStripMenuItem, "usersDataToolStripMenuItem");
            this.usersDataToolStripMenuItem.Click += new System.EventHandler(this.usersDataToolStripMenuItem_Click);
            // 
            // changeUserToolStripMenuItem
            // 
            this.changeUserToolStripMenuItem.Name = "changeUserToolStripMenuItem";
            resources.ApplyResources(this.changeUserToolStripMenuItem, "changeUserToolStripMenuItem");
            this.changeUserToolStripMenuItem.Click += new System.EventHandler(this.changeUserToolStripMenuItem_Click);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            resources.ApplyResources(this.toolStripMenuItem, "toolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // directoriesToolStripMenuItem
            // 
            this.directoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientsToolStripMenuItem,
            this.roomsToolStripMenuItem,
            this.employeesToolStripMenuItem});
            this.directoriesToolStripMenuItem.Name = "directoriesToolStripMenuItem";
            resources.ApplyResources(this.directoriesToolStripMenuItem, "directoriesToolStripMenuItem");
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            resources.ApplyResources(this.clientsToolStripMenuItem, "clientsToolStripMenuItem");
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            resources.ApplyResources(this.roomsToolStripMenuItem, "roomsToolStripMenuItem");
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            resources.ApplyResources(this.employeesToolStripMenuItem, "employeesToolStripMenuItem");
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // operationalInformationToolStripMenuItem
            // 
            this.operationalInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomsHiringOutToolStripMenuItem,
            this.expensesDataToolStripMenuItem});
            this.operationalInformationToolStripMenuItem.Name = "operationalInformationToolStripMenuItem";
            resources.ApplyResources(this.operationalInformationToolStripMenuItem, "operationalInformationToolStripMenuItem");
            // 
            // roomsHiringOutToolStripMenuItem
            // 
            this.roomsHiringOutToolStripMenuItem.Name = "roomsHiringOutToolStripMenuItem";
            resources.ApplyResources(this.roomsHiringOutToolStripMenuItem, "roomsHiringOutToolStripMenuItem");
            this.roomsHiringOutToolStripMenuItem.Click += new System.EventHandler(this.roomsHiringOutToolStripMenuItem_Click);
            // 
            // expensesDataToolStripMenuItem
            // 
            this.expensesDataToolStripMenuItem.Name = "expensesDataToolStripMenuItem";
            resources.ApplyResources(this.expensesDataToolStripMenuItem, "expensesDataToolStripMenuItem");
            this.expensesDataToolStripMenuItem.Click += new System.EventHandler(this.expensesDataToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripClients, this.toolStripRooms, this.toolStripEmployees, this.toolStripFirstSeparator, this.toolStripRoomsHiringOut, this.toolStripExpenses, this.toolStripSecondSeparator, this.toolStripExit });
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // toolStripClients
            // 
            this.toolStripClients.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripClients, "toolStripClients");
            this.toolStripClients.Name = "toolStripClients";
            this.toolStripClients.Click += new System.EventHandler(this.toolStripClients_Click);
            // 
            // toolStripRooms
            // 
            this.toolStripRooms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripRooms, "toolStripRooms");
            this.toolStripRooms.Name = "toolStripRooms";
            this.toolStripRooms.Click += new System.EventHandler(this.toolStripRooms_Click);
            // 
            // toolStripEmployees
            // 
            this.toolStripEmployees.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripEmployees, "toolStripEmployees");
            this.toolStripEmployees.Name = "toolStripEmployees";
            this.toolStripEmployees.Click += new System.EventHandler(this.toolStripEmployees_Click);
            // 
            // toolStripFirstSeparator
            // 
            this.toolStripFirstSeparator.Name = "toolStripFirstSeparator";
            resources.ApplyResources(this.toolStripFirstSeparator, "toolStripFirstSeparator");
            // 
            // toolStripRoomsHiringOut
            // 
            this.toolStripRoomsHiringOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripRoomsHiringOut, "toolStripRoomsHiringOut");
            this.toolStripRoomsHiringOut.Name = "toolStripRoomsHiringOut";
            this.toolStripRoomsHiringOut.Click += new System.EventHandler(this.toolStripRoomsHiringOut_Click);
            // 
            // toolStripExpenses
            // 
            this.toolStripExpenses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripExpenses, "toolStripExpenses");
            this.toolStripExpenses.Name = "toolStripExpenses";
            this.toolStripExpenses.Click += new System.EventHandler(this.toolStripExpenses_Click);
            // 
            // toolStripSecondSeparator
            // 
            this.toolStripSecondSeparator.Name = "toolStripSecondSeparator";
            resources.ApplyResources(this.toolStripSecondSeparator, "toolStripSecondSeparator");
            // 
            // toolStripExit
            // 
            this.toolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripExit, "toolStripExit");
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabel });
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.SizingGrip = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            // 
            // logo
            // 
            resources.ApplyResources(this.logo, "logo");
            this.logo.Name = "logo";
            this.logo.TabStop = false;
            // 
            // hotelData
            // 
            this.hotelData.Controls.Add(this.update);
            this.hotelData.Controls.Add(this.employeesCount);
            this.hotelData.Controls.Add(this.employeesCountText);
            this.hotelData.Controls.Add(this.roomsCount);
            this.hotelData.Controls.Add(this.roomsCountText);
            this.hotelData.Controls.Add(this.clientsCountShow);
            this.hotelData.Controls.Add(this.clientsCount);
            this.hotelData.Controls.Add(this.clientsCountText);
            this.hotelData.Controls.Add(this.clientsEndDate);
            this.hotelData.Controls.Add(this.clientsSeparator);
            this.hotelData.Controls.Add(this.clientsBeginningDate);
            this.hotelData.Controls.Add(this.clientsPeriodText);
            resources.ApplyResources(this.hotelData, "hotelData");
            this.hotelData.Name = "hotelData";
            this.hotelData.TabStop = false;
            // 
            // update
            // 
            resources.ApplyResources(this.update, "update");
            this.update.Name = "update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // employeesCount
            // 
            this.employeesCount.BackColor = System.Drawing.SystemColors.Window;
            this.employeesCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.employeesCount, "employeesCount");
            this.employeesCount.Name = "employeesCount";
            this.employeesCount.ReadOnly = true;
            // 
            // employeesCountText
            // 
            resources.ApplyResources(this.employeesCountText, "employeesCountText");
            this.employeesCountText.Name = "employeesCountText";
            // 
            // roomsCount
            // 
            this.roomsCount.BackColor = System.Drawing.SystemColors.Window;
            this.roomsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.roomsCount, "roomsCount");
            this.roomsCount.Name = "roomsCount";
            this.roomsCount.ReadOnly = true;
            // 
            // roomsCountText
            // 
            resources.ApplyResources(this.roomsCountText, "roomsCountText");
            this.roomsCountText.Name = "roomsCountText";
            // 
            // clientsCountShow
            // 
            resources.ApplyResources(this.clientsCountShow, "clientsCountShow");
            this.clientsCountShow.Name = "clientsCountShow";
            this.clientsCountShow.UseVisualStyleBackColor = true;
            this.clientsCountShow.Click += new System.EventHandler(this.clientsCountShow_Click);
            // 
            // clientsCount
            // 
            this.clientsCount.BackColor = System.Drawing.SystemColors.Window;
            this.clientsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.clientsCount, "clientsCount");
            this.clientsCount.Name = "clientsCount";
            this.clientsCount.ReadOnly = true;
            // 
            // clientsCountText
            // 
            resources.ApplyResources(this.clientsCountText, "clientsCountText");
            this.clientsCountText.Name = "clientsCountText";
            // 
            // clientsEndDate
            // 
            this.clientsEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.clientsEndDate, "clientsEndDate");
            this.clientsEndDate.Name = "clientsEndDate";
            // 
            // clientsSeparator
            // 
            resources.ApplyResources(this.clientsSeparator, "clientsSeparator");
            this.clientsSeparator.Name = "clientsSeparator";
            // 
            // clientsBeginningDate
            // 
            this.clientsBeginningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.clientsBeginningDate, "clientsBeginningDate");
            this.clientsBeginningDate.Name = "clientsBeginningDate";
            // 
            // clientsPeriodText
            // 
            resources.ApplyResources(this.clientsPeriodText, "clientsPeriodText");
            this.clientsPeriodText.Name = "clientsPeriodText";
            // 
            // clientsIncomesData
            // 
            this.clientsIncomesData.Controls.Add(this.incomesCalculate);
            this.clientsIncomesData.Controls.Add(this.incomes);
            this.clientsIncomesData.Controls.Add(this.incomesText);
            this.clientsIncomesData.Controls.Add(this.incomesEndDate);
            this.clientsIncomesData.Controls.Add(this.incomesSeparator);
            this.clientsIncomesData.Controls.Add(this.incomesBeginningDate);
            this.clientsIncomesData.Controls.Add(this.incomesPeriodText);
            resources.ApplyResources(this.clientsIncomesData, "clientsIncomesData");
            this.clientsIncomesData.Name = "clientsIncomesData";
            this.clientsIncomesData.TabStop = false;
            // 
            // incomesCalculate
            // 
            resources.ApplyResources(this.incomesCalculate, "incomesCalculate");
            this.incomesCalculate.Name = "incomesCalculate";
            this.incomesCalculate.UseVisualStyleBackColor = true;
            this.incomesCalculate.Click += new System.EventHandler(this.incomesCalculate_Click);
            // 
            // incomes
            // 
            this.incomes.BackColor = System.Drawing.SystemColors.Window;
            this.incomes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.incomes, "incomes");
            this.incomes.Name = "incomes";
            this.incomes.ReadOnly = true;
            // 
            // incomesText
            // 
            resources.ApplyResources(this.incomesText, "incomesText");
            this.incomesText.Name = "incomesText";
            // 
            // incomesEndDate
            // 
            this.incomesEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.incomesEndDate, "incomesEndDate");
            this.incomesEndDate.Name = "incomesEndDate";
            // 
            // incomesSeparator
            // 
            resources.ApplyResources(this.incomesSeparator, "incomesSeparator");
            this.incomesSeparator.Name = "incomesSeparator";
            // 
            // incomesBeginningDate
            // 
            this.incomesBeginningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.incomesBeginningDate, "incomesBeginningDate");
            this.incomesBeginningDate.Name = "incomesBeginningDate";
            // 
            // incomesPeriodText
            // 
            resources.ApplyResources(this.incomesPeriodText, "incomesPeriodText");
            this.incomesPeriodText.Name = "incomesPeriodText";
            // 
            // expensesData
            // 
            this.expensesData.Controls.Add(this.expensesCalculate);
            this.expensesData.Controls.Add(this.expenses);
            this.expensesData.Controls.Add(this.expensesText);
            this.expensesData.Controls.Add(this.expensesEndDate);
            this.expensesData.Controls.Add(this.expensesSeparator);
            this.expensesData.Controls.Add(this.expensesBeginningDate);
            this.expensesData.Controls.Add(this.expensesPeriodText);
            resources.ApplyResources(this.expensesData, "expensesData");
            this.expensesData.Name = "expensesData";
            this.expensesData.TabStop = false;
            // 
            // expensesCalculate
            // 
            resources.ApplyResources(this.expensesCalculate, "expensesCalculate");
            this.expensesCalculate.Name = "expensesCalculate";
            this.expensesCalculate.UseVisualStyleBackColor = true;
            this.expensesCalculate.Click += new System.EventHandler(this.expensesCalculate_Click);
            // 
            // expenses
            // 
            this.expenses.BackColor = System.Drawing.SystemColors.Window;
            this.expenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.expenses, "expenses");
            this.expenses.Name = "expenses";
            this.expenses.ReadOnly = true;
            // 
            // expensesText
            // 
            resources.ApplyResources(this.expensesText, "expensesText");
            this.expensesText.Name = "expensesText";
            // 
            // expensesEndDate
            // 
            this.expensesEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.expensesEndDate, "expensesEndDate");
            this.expensesEndDate.Name = "expensesEndDate";
            // 
            // expensesSeparator
            // 
            resources.ApplyResources(this.expensesSeparator, "expensesSeparator");
            this.expensesSeparator.Name = "expensesSeparator";
            // 
            // expensesBeginningDate
            // 
            this.expensesBeginningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.expensesBeginningDate, "expensesBeginningDate");
            this.expensesBeginningDate.Name = "expensesBeginningDate";
            // 
            // expensesPeriodText
            // 
            resources.ApplyResources(this.expensesPeriodText, "expensesPeriodText");
            this.expensesPeriodText.Name = "expensesPeriodText";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hotelData);
            this.Controls.Add(this.expensesData);
            this.Controls.Add(this.clientsIncomesData);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.hotelData.ResumeLayout(false);
            this.hotelData.PerformLayout();
            this.clientsIncomesData.ResumeLayout(false);
            this.clientsIncomesData.PerformLayout();
            this.expensesData.ResumeLayout(false);
            this.expensesData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationalInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsHiringOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesDataToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripClients;
        private System.Windows.Forms.ToolStripButton toolStripRooms;
        private System.Windows.Forms.ToolStripButton toolStripEmployees;
        private System.Windows.Forms.ToolStripSeparator toolStripFirstSeparator;
        private System.Windows.Forms.ToolStripButton toolStripRoomsHiringOut;
        private System.Windows.Forms.ToolStripButton toolStripExpenses;
        private System.Windows.Forms.ToolStripSeparator toolStripSecondSeparator;
        private System.Windows.Forms.ToolStripButton toolStripExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.GroupBox hotelData;
        private System.Windows.Forms.Label clientsPeriodText;
        private System.Windows.Forms.DateTimePicker clientsBeginningDate;
        private System.Windows.Forms.Label clientsSeparator;
        private System.Windows.Forms.DateTimePicker clientsEndDate;
        private System.Windows.Forms.Label clientsCountText;
        private System.Windows.Forms.TextBox clientsCount;
        private System.Windows.Forms.Button clientsCountShow;
        private System.Windows.Forms.Label roomsCountText;
        private System.Windows.Forms.TextBox roomsCount;
        private System.Windows.Forms.Label employeesCountText;
        private System.Windows.Forms.TextBox employeesCount;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.GroupBox clientsIncomesData;
        private System.Windows.Forms.Label incomesPeriodText;
        private System.Windows.Forms.DateTimePicker incomesBeginningDate;
        private System.Windows.Forms.Label incomesSeparator;
        private System.Windows.Forms.DateTimePicker incomesEndDate;
        private System.Windows.Forms.Label incomesText;
        private System.Windows.Forms.TextBox incomes;
        private System.Windows.Forms.Button incomesCalculate;
        private System.Windows.Forms.GroupBox expensesData;
        private System.Windows.Forms.Label expensesPeriodText;
        private System.Windows.Forms.DateTimePicker expensesBeginningDate;
        private System.Windows.Forms.Label expensesSeparator;
        private System.Windows.Forms.DateTimePicker expensesEndDate;
        private System.Windows.Forms.Label expensesText;
        private System.Windows.Forms.TextBox expenses;
        private System.Windows.Forms.Button expensesCalculate;
    }
}