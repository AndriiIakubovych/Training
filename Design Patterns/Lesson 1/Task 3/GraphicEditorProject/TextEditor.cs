﻿using System.Drawing.Printing;

namespace GraphicEditorProject
{
    class TextEditor : Editor
    {
        public override void Create() { }

        public override void Open() { }

        public override void Save() { }

        public override void SaveAs() { }

        protected override void PrintDocument_PrintPage(object sender, PrintPageEventArgs e) { }

        public override void Print() { }

        public override bool Close(bool flag) { return true; }
    }
}