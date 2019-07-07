using System.Windows.Input;

namespace TextEditor
{
    class CommandsContainer
    {
        public static RoutedCommand Create { get; set; }
        public static RoutedCommand Open { get; set; }
        public static RoutedCommand Save { get; set; }
        public static RoutedCommand SaveAs { get; set; }
        public static RoutedCommand Print { get; set; }
        public static RoutedCommand Exit { get; set; }
        public static RoutedCommand Find { get; set; }
        public static RoutedCommand SelectAll { get; set; }
        public static RoutedCommand ShowToolBar { get; set; }
        public static RoutedCommand ShowStatusBar { get; set; }
        public static RoutedCommand Font { get; set; }
        public static RoutedCommand FontColor { get; set; }
        public static RoutedCommand Paragraph { get; set; }

        static CommandsContainer()
        {
            Create = new RoutedCommand("Create", typeof(MainWindow));
            Open = new RoutedCommand("Open", typeof(MainWindow));
            Save = new RoutedCommand("Save", typeof(MainWindow));
            SaveAs = new RoutedCommand("SaveAs", typeof(MainWindow));
            Print = new RoutedCommand("Print", typeof(MainWindow));
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
            Find = new RoutedCommand("Find", typeof(MainWindow));
            SelectAll = new RoutedCommand("SelectAll", typeof(MainWindow));
            ShowToolBar = new RoutedCommand("ShowToolBar", typeof(MainWindow));
            ShowStatusBar = new RoutedCommand("ShowStatusBar", typeof(MainWindow));
            Font = new RoutedCommand("Font", typeof(MainWindow));
            FontColor = new RoutedCommand("FontColor", typeof(MainWindow));
            Paragraph = new RoutedCommand("Paragraph", typeof(MainWindow));
        }
    }
}