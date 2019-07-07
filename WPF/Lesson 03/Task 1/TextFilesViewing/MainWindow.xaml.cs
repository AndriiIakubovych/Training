using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;

namespace TextFilesViewing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string keywordsPlaceholder;

        public MainWindow()
        {
            InitializeComponent();
            keywordsPlaceholder = keywords.Text;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FileStream fs;
            TextRange range;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Открытие";
            ofd.Filter = "Обычный текст (*.txt)|*.txt";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fs = new FileStream(ofd.FileName, FileMode.Open);
                range = new TextRange(documentReader.Document.ContentStart, documentReader.Document.ContentEnd);
                statusBarText.Text = ofd.FileName;
                range.Load(fs, System.Windows.DataFormats.Text);
                fs.Dispose();
                if (showKeywordsItem.IsChecked)
                    HighlightKeywords();
                if (showHyperlinksItem.IsChecked)
                    HighlightHyperlinks();
            }
        }

        private void HighlightKeywords()
        {
            string pattern = "";
            string[] keywordsArray = null;
            TextPointer position = documentReader.Document.ContentStart;
            MatchCollection matches;
            List<TextRange> rangesList = new List<TextRange>();
            Regex regex;
            if (keywords.Text != keywordsPlaceholder)
                keywordsArray = keywords.Text.Split(' ');
            if (keywordsArray != null)
            {
                for (int i = 0; i < keywordsArray.Length; i++)
                {
                    pattern += "(" + keywordsArray[i] + ")";
                    if (i != keywordsArray.Length - 1)
                        pattern += "|";
                }
                regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                while (position != null)
                {
                    if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                    {
                        matches = regex.Matches(position.GetTextInRun(LogicalDirection.Forward));
                        foreach (Match match in matches)
                            rangesList.Add(new TextRange(position.GetPositionAtOffset(match.Index), position.GetPositionAtOffset(match.Index).GetPositionAtOffset(match.Value.Length)));
                    }
                    position = position.GetNextContextPosition(LogicalDirection.Forward);
                }
                foreach (TextRange tr in rangesList)
                {
                    tr.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Red));
                }
            }
        }

        private void HighlightHyperlinks()
        {
            string pattern = @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)";
            TextPointer position = documentReader.Document.ContentStart;
            MatchCollection matches;
            List<TextRange> rangesList = new List<TextRange>();
            Regex regex;
            regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            while (position != null)
            {
                if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    matches = regex.Matches(position.GetTextInRun(LogicalDirection.Forward));
                    foreach (Match match in matches)
                        rangesList.Add(new TextRange(position.GetPositionAtOffset(match.Index), position.GetPositionAtOffset(match.Index).GetPositionAtOffset(match.Value.Length)));
                }
                position = position.GetNextContextPosition(LogicalDirection.Forward);
            }
            foreach (TextRange tr in rangesList)
            {
                tr.ApplyPropertyValue(TextBlock.TextDecorationsProperty, TextDecorations.Underline);
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Blue));
            }
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void Keywords_GotFocus(object sender, RoutedEventArgs e)
        {
            if (keywords.Text == keywordsPlaceholder)
            {
                keywords.Foreground = new SolidColorBrush(Colors.Black);
                keywords.Text = "";
            }
        }

        private void Keywords_LostFocus(object sender, RoutedEventArgs e)
        {
            if (keywords.Text == "")
            {
                keywords.Foreground = new SolidColorBrush(Colors.Gray);
                keywords.Text = keywordsPlaceholder;
            }
        }

        private void ShowToolBar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (showToolBar.IsChecked)
                toolBar.Visibility = Visibility.Visible;
            else
                toolBar.Visibility = Visibility.Collapsed;
        }

        private void ShowStatusBar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (showStatusBar.IsChecked)
                statusBar.Visibility = Visibility.Visible;
            else
                statusBar.Visibility = Visibility.Collapsed;
        }
    }
}