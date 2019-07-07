using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;

namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        private MainWindow mainWindow;
        private string findString;
        private int counter = 0;
        private List<TextRange> rangesList = new List<TextRange>();

        public FindWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            findText.Focus();
            findString = findText.Text;
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            Regex regex;
            TextPointer position;
            MatchCollection matches;
            TextRange range;
            try
            {
                if (!findText.Text.Equals(findString))
                {
                    findString = findText.Text;
                    counter = 0;
                    regex = new Regex(findText.Text.Trim(), RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    position = mainWindow.pageContent.Document.ContentStart;
                    rangesList.Clear();
                    while (position != null)
                    {
                        if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                        {
                            matches = regex.Matches(position.GetTextInRun(LogicalDirection.Forward));
                            foreach (Match match in matches)
                                rangesList.Add(new TextRange(position.GetPositionAtOffset(match.Index), position.GetPositionAtOffset(match.Index).GetPositionAtOffset(findText.Text.Trim().Length)));
                        }
                        position = position.GetNextContextPosition(LogicalDirection.Forward);
                    }
                }
                if (counter == rangesList.Count)
                    counter = 0;
                range = rangesList[counter];
                mainWindow.pageContent.Focus();
                mainWindow.pageContent.Selection.Select(range.Start, range.End);
                counter++;
            }
            catch (Exception) { }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            mainWindow.IsFindWindowShowed = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !mainWindow.IsMainWindowClosing;
            Hide();
            mainWindow.IsFindWindowShowed = false;
        }
    }
}