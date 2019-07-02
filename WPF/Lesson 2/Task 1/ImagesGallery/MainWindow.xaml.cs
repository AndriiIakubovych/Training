using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Forms;

namespace ImagesGallery
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BitmapImage> bitmapImagesList = new List<BitmapImage>();
        private double imageWidth;
        private double imageHeight;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            FileInfo[] files;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            ProgressWindow progressWindow = new ProgressWindow();
            fbd.Description = "Выберите папку с картинками:";
            fbd.SelectedPath = folder.Text;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folder.Text = fbd.SelectedPath;
                progressWindow.ImagesDirectory = new DirectoryInfo(fbd.SelectedPath);
                if (progressWindow.ShowDialog() == DialogResult.HasValue)
                {
                    imagesList.Items.Clear();
                    picture.Source = null;
                    imageSize.Content = imageFileName.Content = "";
                    files = progressWindow.Files;
                    bitmapImagesList = progressWindow.BitmapImagesList;
                    for (int i = 0; i < bitmapImagesList.Count; i++)
                        imagesList.Items.Add(files[i].Name);
                    if (imagesList.Items.Count > 0)
                        imagesList.SelectedIndex = 0;
                    else
                    {
                        previous.IsEnabled = false;
                        previous.Content = TryFindResource("DisabledPreviousImage");
                        next.Content = TryFindResource("DisabledNextImage");
                        imageWidth = imageHeight = 0;
                    }
                    viewingInformation.IsEnabled = next.IsEnabled = sizeAdjustmentName.IsEnabled = sizeAdjustment.IsEnabled = imagesList.Items.Count > 0;
                    viewingInformation.IsExpanded = imagesList.Items.Count > 0;
                    ChangeImageSize();
                }
            }
        }

        private void ImagesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fileName;
            if (imagesList.SelectedIndex >= 0)
            {
                picture.Source = bitmapImagesList[imagesList.SelectedIndex];
                imageWidth = bitmapImagesList[imagesList.SelectedIndex].Width;
                imageHeight = bitmapImagesList[imagesList.SelectedIndex].Height;
                fileName = imagesList.Items[imagesList.SelectedIndex].ToString();
                fileName = fileName.Insert(fileName.IndexOf('_') + 1, "_");
                imageFileName.Content = "Имя файла: " + fileName;
                if (imagesList.SelectedIndex > 0)
                {
                    previous.IsEnabled = true;
                    previous.Content = TryFindResource("PreviousImage");
                }
                else
                {
                    previous.IsEnabled = false;
                    previous.Content = TryFindResource("DisabledPreviousImage");
                }
                if (imagesList.SelectedIndex < imagesList.Items.Count - 1)
                {
                    next.IsEnabled = true;
                    next.Content = TryFindResource("NextImage");
                }
                else
                {
                    next.IsEnabled = false;
                    next.Content = TryFindResource("DisabledNextImage");
                }
                sizeAdjustment.Value = 50;
                ChangeImageSize();
            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (imagesList.SelectedIndex > 0)
                imagesList.SelectedIndex -= 1;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (imagesList.SelectedIndex <= imagesList.Items.Count - 1)
                imagesList.SelectedIndex += 1;
        }

        private void SizeAdjustment_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ChangeImageSize();
        }

        public void ChangeImageSize()
        {
            picture.Width = imageWidth * sizeAdjustment.Value * 2 / 100;
            picture.Height = imageHeight * sizeAdjustment.Value * 2 / 100;
            imageSize.Content = "Размер изображения: " + Math.Round(picture.Width).ToString() + " × " + Math.Round(picture.Height).ToString() + " Пикс.";
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                Previous_Click(sender, e);
            if (e.Key == Key.Right)
                Next_Click(sender, e);
        }
    }
}