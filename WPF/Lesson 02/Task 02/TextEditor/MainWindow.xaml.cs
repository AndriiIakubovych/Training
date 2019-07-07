using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;

namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isListSelected = true;
        private bool showMessage;
        private bool isCanceled = false;
        private bool isExitClicked = false;
        private bool isStrikethrough = false;
        private string fileName = "";
        private FindWindow findWindow;

        public bool IsMainWindowClosing { get; set; }
        public bool IsFindWindowShowed { get; set; }

        private enum AlignType { LEFT, CENTER, RIGHT, JUSTIFY }

        public MainWindow()
        {
            InitializeComponent();
            findWindow = new FindWindow(this);
            IsMainWindowClosing = false;
            IsFindWindowShowed = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const string FONT_FAMILY = "Arial";
            int fontFamilyIndex, fontSizeIndex;
            foreach (System.Drawing.FontFamily f in System.Drawing.FontFamily.Families)
                fontFamilyChoice.Items.Add(f.Name);
            if (fontFamilyChoice.Items.Count > 0)
            {
                fontFamilyIndex = fontFamilyChoice.Items.IndexOf(FONT_FAMILY);
                fontFamilyChoice.SelectedIndex = fontFamilyIndex != -1 ? fontFamilyIndex : 0;
                pageContent.FontFamily = new FontFamily(FONT_FAMILY);
            }
            fontSizeChoice.ItemsSource = new List<int>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            if (fontSizeChoice.Items.Count > 0)
            {
                fontSizeIndex = fontSizeChoice.Items.IndexOf(12);
                fontSizeChoice.SelectedIndex = fontSizeIndex != -1 ? fontSizeIndex : 0;
            }
            leftAlignText.IsChecked = true;
            showMessage = false;
            pageContent.Focus();
        }

        private void Create_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            YesNoCancelWindow yesNoCancelWindow;
            if (showMessage && undoChanges.IsEnabled)
            {
                yesNoCancelWindow = new YesNoCancelWindow();
                if (yesNoCancelWindow.ShowDialog() == DialogResult.HasValue)
                {
                    if (yesNoCancelWindow.Result == 0)
                    {
                        Save();
                        if (!isCanceled)
                        {
                            pageContent.Document.Blocks.Clear();
                            showMessage = false;
                            statusBarText.Text = "Готово";
                        }
                    }
                    if (yesNoCancelWindow.Result == 1)
                    {
                        pageContent.Document.Blocks.Clear();
                        showMessage = false;
                        statusBarText.Text = "Готово";
                    }
                }
            }
            else
            {
                pageContent.Document.Blocks.Clear();
                fileName = "";
                showMessage = false;
                statusBarText.Text = "Готово";
            }
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FileStream fs;
            TextRange range;
            YesNoCancelWindow yesNoCancelWindow;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Открытие";
            ofd.Filter = "Текст в формате RTF (*.rtf)|*.rtf|Обычный текст (*.txt)|*.txt";
            if (showMessage && undoChanges.IsEnabled)
            {
                yesNoCancelWindow = new YesNoCancelWindow();
                if (yesNoCancelWindow.ShowDialog() == DialogResult.HasValue)
                {
                    if (yesNoCancelWindow.Result == 0)
                        Save();
                    showMessage = false;
                }
            }
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fs = new FileStream(ofd.FileName, FileMode.Open);
                range = new TextRange(pageContent.Document.ContentStart, pageContent.Document.ContentEnd);
                fileName = ofd.FileName;
                statusBarText.Text = ofd.FileName;
                if (Path.GetExtension(fileName) == ".rtf")
                    range.Load(fs, System.Windows.DataFormats.Rtf);
                if (Path.GetExtension(fileName) == ".txt")
                    range.Load(fs, System.Windows.DataFormats.Text);
                fs.Dispose();
                showMessage = false;
            }
            else
                isCanceled = true;
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FileStream fs;
            TextRange range;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранение";
            sfd.Filter = "Текст в формате RTF (*.rtf)|*.rtf|Обычный текст (*.txt)|*.txt";
            if (fileName.Length == 0)
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fs = new FileStream(sfd.FileName, FileMode.Create);
                    range = new TextRange(pageContent.Document.ContentStart, pageContent.Document.ContentEnd);
                    fileName = sfd.FileName;
                    statusBarText.Text = sfd.FileName;
                    if (Path.GetExtension(fileName) == ".rtf")
                        range.Save(fs, System.Windows.DataFormats.Rtf);
                    if (Path.GetExtension(fileName) == ".txt")
                        range.Save(fs, System.Windows.DataFormats.Text);
                    fs.Dispose();
                    showMessage = false;
                    isCanceled = false;
                }
                else
                    isCanceled = true;
            }
            else
            {
                fs = new FileStream(fileName, FileMode.Create);
                range = new TextRange(pageContent.Document.ContentStart, pageContent.Document.ContentEnd);
                statusBarText.Text = fileName;
                range.Save(fs, System.Windows.DataFormats.Rtf);
                fs.Dispose();
                showMessage = false;
            }
        }

        public void Save()
        {
            FileStream fs;
            TextRange range;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранение";
            sfd.Filter = "Текст в формате RTF (*.rtf)|*.rtf|Обычный текст (*.txt)|*.txt";
            if (fileName.Length == 0)
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fs = new FileStream(sfd.FileName, FileMode.Create);
                    range = new TextRange(pageContent.Document.ContentStart, pageContent.Document.ContentEnd);
                    fileName = sfd.FileName;
                    statusBarText.Text = sfd.FileName;
                    if (Path.GetExtension(fileName) == ".rtf")
                        range.Save(fs, System.Windows.DataFormats.Rtf);
                    if (Path.GetExtension(fileName) == ".txt")
                        range.Save(fs, System.Windows.DataFormats.Text);
                    fs.Dispose();
                    showMessage = false;
                    isCanceled = false;
                }
                else
                    isCanceled = true;
            }
            else
            {
                fs = new FileStream(fileName, FileMode.Create);
                range = new TextRange(pageContent.Document.ContentStart, pageContent.Document.ContentEnd);
                statusBarText.Text = fileName;
                range.Save(fs, System.Windows.DataFormats.Rtf);
                fs.Dispose();
                showMessage = false;
            }
        }

        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FileStream fs;
            TextRange range;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранение";
            sfd.FileName = Path.GetFileNameWithoutExtension(fileName);
            sfd.Filter = "Текст в формате RTF (*.rtf)|*.rtf|Обычный текст (*.txt)|*.txt";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fs = new FileStream(sfd.FileName, FileMode.Create);
                range = new TextRange(pageContent.Document.ContentStart, pageContent.Document.ContentEnd);
                fileName = sfd.FileName;
                statusBarText.Text = sfd.FileName;
                if (Path.GetExtension(fileName) == ".rtf")
                    range.Save(fs, System.Windows.DataFormats.Rtf);
                if (Path.GetExtension(fileName) == ".txt")
                    range.Save(fs, System.Windows.DataFormats.Text);
                fs.Dispose();
                showMessage = false;
            }
        }

        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(pageContent as Visual, "Печать визуального объекта");
                pd.PrintDocument((((IDocumentPaginatorSource)pageContent.Document).DocumentPaginator), "Печать документа");
            }
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            isExitClicked = true;
            Close(true);
        }

        private void Find_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            findWindow.Topmost = true;
            findWindow.Show();
            IsFindWindowShowed = true;
        }

        private void SelectAll_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            pageContent.SelectAll();
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

        private void Font_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FontDialog fd = new FontDialog();
            TextDecorationCollection tdc = pageContent.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection;
            fd.Font = new System.Drawing.Font(fontFamilyChoice.SelectedItem.ToString(), Convert.ToInt32(fontSizeChoice.SelectedItem), (boldText.IsChecked.Value ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) | (italicText.IsChecked.Value ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular) | (underlineText.IsChecked.Value ? System.Drawing.FontStyle.Underline : System.Drawing.FontStyle.Regular) | (isStrikethrough ? System.Drawing.FontStyle.Strikeout : System.Drawing.FontStyle.Regular));
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pageContent.Selection.ApplyPropertyValue(TextBlock.FontFamilyProperty, fd.Font.FontFamily.Name);
                pageContent.Selection.ApplyPropertyValue(TextBlock.FontSizeProperty, fd.Font.Size.ToString());
                pageContent.Selection.ApplyPropertyValue(TextBlock.FontWeightProperty, fd.Font.Bold ? FontWeights.Bold : FontWeights.Normal);
                pageContent.Selection.ApplyPropertyValue(TextBlock.FontStyleProperty, fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal);
                tdc = new TextDecorationCollection();
                if (fd.Font.Underline)
                    tdc.Add(TextDecorations.Underline);
                if (fd.Font.Strikeout)
                {
                    isStrikethrough = true;
                    tdc.Add(TextDecorations.Strikethrough);
                }
                pageContent.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, tdc);
                pageContent.Focus();
            }
        }

        private void Paragraph_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ParagraphWindow paragraphWindow = new ParagraphWindow();
            paragraphWindow.lineHeight.Text = pageContent.Selection.GetPropertyValue(Block.LineHeightProperty).ToString();
            if (paragraphWindow.ShowDialog() == true)
            {
                pageContent.Selection.ApplyPropertyValue(Block.LineHeightProperty, Convert.ToDouble(paragraphWindow.lineHeight.Text));
                switch (paragraphWindow.AlignType)
                {
                    case (int)AlignType.LEFT:
                        EditingCommands.AlignLeft.Execute(sender, pageContent);
                        break;
                    case (int)AlignType.CENTER:
                        EditingCommands.AlignCenter.Execute(sender, pageContent);
                        break;
                    case (int)AlignType.RIGHT:
                        EditingCommands.AlignRight.Execute(sender, pageContent);
                        break;
                    case (int)AlignType.JUSTIFY:
                        EditingCommands.AlignJustify.Execute(sender, pageContent);
                        break;
                }
                pageContent.Focus();
            }
        }

        private void FontFamilyChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isListSelected)
            {
                pageContent.Selection.ApplyPropertyValue(TextBlock.FontFamilyProperty, fontFamilyChoice.SelectedItem);
                pageContent.Focus();
            }
        }

        private void FontFamilyChoice_GotFocus(object sender, RoutedEventArgs e)
        {
            isListSelected = true;
        }

        private void FontSizeChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (isListSelected)
                {
                    pageContent.Selection.ApplyPropertyValue(TextBlock.FontSizeProperty, fontSizeChoice.SelectedItem.ToString());
                    pageContent.Focus();
                }
            }
            catch (Exception) { }
        }

        private void FontSizeChoice_GotFocus(object sender, RoutedEventArgs e)
        {
            isListSelected = true;
        }

        private void FontColor_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pageContent.Selection.ApplyPropertyValue(FlowDocument.ForegroundProperty, new SolidColorBrush(Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B)));
                pageContent.Focus();
            }
        }

        private void PageContent_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object selectedTextProperty = pageContent.Selection.GetPropertyValue(TextBlock.FontWeightProperty);
            TextDecorationCollection tdc;
            List list;
            isListSelected = false;
            try
            {
                fontFamilyChoice.SelectedItem = pageContent.Selection.GetPropertyValue(FontFamilyProperty).ToString();
                fontSizeChoice.SelectedItem = Convert.ToInt32(pageContent.Selection.GetPropertyValue(FontSizeProperty));
                boldText.IsChecked = (selectedTextProperty != DependencyProperty.UnsetValue) && (selectedTextProperty.Equals(FontWeights.Bold));
                selectedTextProperty = pageContent.Selection.GetPropertyValue(FontStyleProperty);
                italicText.IsChecked = (selectedTextProperty != DependencyProperty.UnsetValue) && (selectedTextProperty.Equals(FontStyles.Italic));
                tdc = pageContent.Selection.GetPropertyValue(TextBlock.TextDecorationsProperty) as TextDecorationCollection;
                underlineText.IsChecked = (selectedTextProperty != DependencyProperty.UnsetValue) && tdc.Contains(TextDecorations.Underline.FirstOrDefault());
                isStrikethrough = (selectedTextProperty != DependencyProperty.UnsetValue) && tdc.Contains(TextDecorations.Strikethrough.FirstOrDefault());
                selectedTextProperty = pageContent.Selection.GetPropertyValue(TextBlock.TextAlignmentProperty);
                leftAlignText.IsChecked = (selectedTextProperty != DependencyProperty.UnsetValue) && (selectedTextProperty.Equals(TextAlignment.Left));
                centerAlignText.IsChecked = (selectedTextProperty != DependencyProperty.UnsetValue) && (selectedTextProperty.Equals(TextAlignment.Center));
                rightAlignText.IsChecked = (selectedTextProperty != DependencyProperty.UnsetValue) && (selectedTextProperty.Equals(TextAlignment.Right));
                justifyAlignText.IsChecked = (selectedTextProperty != DependencyProperty.UnsetValue) && (selectedTextProperty.Equals(TextAlignment.Justify));
                list = FindListAncestor(pageContent.Selection.Start.Parent);
                if (list != null)
                {
                    numbersList.IsChecked = (list.MarkerStyle == TextMarkerStyle.Decimal);
                    bulletsList.IsChecked = (list.MarkerStyle == TextMarkerStyle.Disc);
                }
                else
                    numbersList.IsChecked = bulletsList.IsChecked = false;
            }
            catch (Exception) { }
        }

        private List FindListAncestor(DependencyObject element)
        {
            List list;
            while (element != null)
            {
                list = element as List;
                if (list != null)
                    return list;
                element = LogicalTreeHelper.GetParent(element);
            }
            return null;
        }

        private void PageContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            showMessage = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            findWindow.Hide();
            IsFindWindowShowed = false;
            if (!isExitClicked)
                e.Cancel = Close(false);
        }

        public bool Close(bool flag)
        {
            YesNoCancelWindow yesNoCancelWindow;
            if (showMessage)
            {
                yesNoCancelWindow = new YesNoCancelWindow();
                if (yesNoCancelWindow.ShowDialog() == DialogResult.HasValue)
                {
                    if (yesNoCancelWindow.Result == 0)
                        Save();
                    if (yesNoCancelWindow.Result != 2)
                    {
                        if (flag)
                            Close();
                        isExitClicked = false;
                        IsMainWindowClosing = true;
                        findWindow.Close();
                        return false;
                    }
                }
                isExitClicked = false;
                return true;
            }
            else
            {
                if (flag)
                    Close();
                isExitClicked = false;
                IsMainWindowClosing = true;
                findWindow.Close();
                return false;
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                findWindow.Hide();
            else
                if (IsFindWindowShowed)
                findWindow.Show();
        }
    }
}