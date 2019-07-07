using System.Drawing.Printing;

namespace EditorTemplate
{
    abstract class Editor
    {
        public string FileName { get; set; }
        public bool ShowMessage { get; set; }
        public PrintDocument PrintDocument { get; set; }
        public object Obj { get; set; }

        public Editor()
        {
            FileName = "";
            ShowMessage = false;
            PrintDocument = new PrintDocument();
            PrintDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        public abstract void Create();
        public abstract void Open();
        public abstract void Save();
        public abstract void SaveAs();
        protected abstract void PrintDocument_PrintPage(object sender, PrintPageEventArgs e);
        public abstract void Print();
        public abstract bool Close(bool flag);
    }
}