namespace TextEditorProject
{
    class EditorFactory
    {
        public Editor CreateEditor(string type)
        {
            Editor editor = null;
            if (type == "Text")
                editor = new TextEditor();
            if (type == "Graphic")
                editor = new GraphicEditor();
            return editor;
        }
    }
}