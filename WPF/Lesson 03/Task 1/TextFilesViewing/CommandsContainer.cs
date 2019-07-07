using System.Windows.Input;

namespace TextFilesViewing
{
    class CommandsContainer
    {
        public static RoutedCommand Open { get; set; }
        public static RoutedCommand ShowToolBar { get; set; }
        public static RoutedCommand ShowStatusBar { get; set; }
        public static RoutedCommand Exit { get; set; }

        static CommandsContainer()
        {
            Open = new RoutedCommand("Open", typeof(MainWindow));
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
            ShowToolBar = new RoutedCommand("ShowToolBar", typeof(MainWindow));
            ShowStatusBar = new RoutedCommand("ShowStatusBar", typeof(MainWindow));
        }
    }
}