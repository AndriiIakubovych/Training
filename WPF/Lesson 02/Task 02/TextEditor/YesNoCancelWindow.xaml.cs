using System.Windows;

namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для YesNoCancelWindow.xaml
    /// </summary>
    public partial class YesNoCancelWindow : Window
    {
        public int Result { get; set; }

        public YesNoCancelWindow()
        {
            InitializeComponent();
            Result = -1;
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            Result = 0;
            Close();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            Result = 1;
            Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Result = 2;
            Close();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Result = Result == -1 ? 2 : Result;
        }
    }
}