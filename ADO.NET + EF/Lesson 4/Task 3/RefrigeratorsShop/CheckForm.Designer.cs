namespace RefrigeratorsShop
{
    partial class CheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForm));
            this.checkViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // checkViewer
            // 
            this.checkViewer.ActiveViewIndex = -1;
            this.checkViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkViewer.DisplayStatusBar = false;
            resources.ApplyResources(this.checkViewer, "checkViewer");
            this.checkViewer.Name = "checkViewer";
            // 
            // CheckForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkViewer);
            this.Name = "CheckForm";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CheckForm_FormClosed);
            this.Load += new System.EventHandler(this.CheckForm_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer checkViewer;
    }
}