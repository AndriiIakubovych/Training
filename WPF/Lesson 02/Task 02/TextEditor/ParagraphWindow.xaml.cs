using System;
using System.Windows;

namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для ParagraphWindow.xaml
    /// </summary>
    public partial class ParagraphWindow : Window
    {
        public int AlignType { get; set; }

        public ParagraphWindow()
        {
            InitializeComponent();
            lineHeight.Focus();
            alignTypeChoice.SelectedIndex = 0;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(lineHeight.Text) <= 0)
                {
                    MessageBox.Show("Междустрочный интервал введён неверно!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            AlignType = alignTypeChoice.SelectedIndex;
        }
    }
}