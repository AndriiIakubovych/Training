using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphicFilesView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationViewModel applicationViewModel = new ApplicationViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = applicationViewModel;
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowToolBar_Click(object sender, RoutedEventArgs e)
        {
            if (showToolBar.IsChecked)
            {
                toolBar.Visibility = Visibility.Visible;
                mainDockPanel.Children.Clear();
                mainDockPanel.Children.Add(mainMenu);
                DockPanel.SetDock(mainMenu, Dock.Top);
                mainDockPanel.Children.Add(toolBar);
                DockPanel.SetDock(toolBar, Dock.Top);
                mainDockPanel.Children.Add(statusBar);
                DockPanel.SetDock(statusBar, Dock.Bottom);
                mainDockPanel.Children.Add(mainGrid);
            }
            else
            {
                toolBar.Visibility = Visibility.Hidden;
                mainDockPanel.Children.Remove(toolBar);
            }
        }

        private void ShowFoldersList_Click(object sender, RoutedEventArgs e)
        {
            foldersColumn.Width = showFoldersList.IsChecked ? new GridLength(0.3, GridUnitType.Star) : new GridLength(0);
        }

        private void ShowSettings_Click(object sender, RoutedEventArgs e)
        {
            settingsColumn.Width = showSettings.IsChecked ? new GridLength(0.3, GridUnitType.Star) : new GridLength(0);
        }

        private void ShowStatusBar_Click(object sender, RoutedEventArgs e)
        {
            if (showStatusBar.IsChecked)
            {
                statusBar.Visibility = Visibility.Visible;
                mainDockPanel.Children.Clear();
                mainDockPanel.Children.Add(mainMenu);
                DockPanel.SetDock(mainMenu, Dock.Top);
                mainDockPanel.Children.Add(toolBar);
                DockPanel.SetDock(toolBar, Dock.Top);
                mainDockPanel.Children.Add(statusBar);
                DockPanel.SetDock(statusBar, Dock.Bottom);
                mainDockPanel.Children.Add(mainGrid);
            }
            else
            {
                statusBar.Visibility = Visibility.Hidden;
                mainDockPanel.Children.Remove(statusBar);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            statusBarText.Text = applicationViewModel.SelectedFolder != null ? applicationViewModel.SelectedFolder.FolderWay : "Готово";
        }

        private void FileChoiceItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            applicationViewModel.PreviewImageCommand.Execute(applicationViewModel.SelectedFolder);
        }

        private void CloseFoldersList_Click(object sender, RoutedEventArgs e)
        {
            showFoldersList.IsChecked = false;
            ShowFoldersList_Click(sender, e);
        }

        private void CloseSettings_Click(object sender, RoutedEventArgs e)
        {
            showSettings.IsChecked = false;
            ShowSettings_Click(sender, e);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ImageChangeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (imageChangingTimeText != null && imageChangingTime != null)
                imageChangingTimeText.IsEnabled = imageChangingTime.IsEnabled = imageChangeType.SelectedIndex == 0;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                applicationViewModel.DeleteCommand.Execute(applicationViewModel.SelectedFolder);
        }
    }
}