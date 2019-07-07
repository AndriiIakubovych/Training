using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace GraphicFilesView
{
    /// <summary>
    /// Логика взаимодействия для ImagePreviewWindow.xaml
    /// </summary>
    public partial class ImagePreviewWindow : Window
    {
        private ObservableCollection<ImageFile> NewImagesFilesList = new ObservableCollection<ImageFile>();
        private int angle = 0;
        private double initialImageWidth;
        private double initialImageHeight;
        private double imageWidth;
        private double imageHeight;
        private double initialSizeAdjustment;

        public ImagesFilesFolder ImagesFilesFolder { get; set; }
        public Settings Settings { get; set; }

        public ImagePreviewWindow(ImagesFilesFolder imagesFilesFolder, Settings settings)
        {
            int j, index;
            Random random = new Random();
            ImageFile temp;
            InitializeComponent();
            ImagesFilesFolder = imagesFilesFolder;
            Settings = settings;
            foreach (ImageFile ife in ImagesFilesFolder.ImagesFilesList)
                NewImagesFilesList.Add(ife);
            if (Settings.SelectedPreviewType == "Случайный")
                for (int i = NewImagesFilesList.Count - 1; i >= 1; i--)
                {
                    j = random.Next(i + 1);
                    temp = NewImagesFilesList[j];
                    NewImagesFilesList[j] = NewImagesFilesList[i];
                    NewImagesFilesList[i] = temp;
                }
            DataContext = ImagesFilesFolder.SelectedFile;
            contextPanel.DataContext = imagePreviewWindow;
            index = NewImagesFilesList.IndexOf(ImagesFilesFolder.SelectedFile);
            previous.IsEnabled = index > 0;
            next.IsEnabled = index < NewImagesFilesList.Count - 1;
            initialSizeAdjustment = sizeAdjustment.Value;
        }

        public void UpdateInitialStyles()
        {
            sizeAdjustment.Value = initialSizeAdjustment;
            image.Width = double.NaN;
            image.Height = double.NaN;
            image.MaxWidth = ImagesFilesFolder.SelectedFile.MaxWidth;
            image.MaxHeight = ImagesFilesFolder.SelectedFile.MaxHeight;
            UpdateLayout();
            initialImageWidth = imageWidth;
            initialImageHeight = imageHeight;
        }

        private void ImagePreviewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            initialImageWidth = image.ActualWidth;
            initialImageHeight = image.ActualHeight;
        }

        private void ImagePreviewWindow_LayoutUpdated(object sender, System.EventArgs e)
        {
            imageWidth = image.ActualWidth;
            imageHeight = image.ActualHeight;
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            initialImageWidth = image.ActualWidth;
            initialImageHeight = image.ActualHeight;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ImagePreviewWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateInitialStyles();
        }

        private void LeftTurn_Click(object sender, RoutedEventArgs e)
        {
            RotateTransform rotateTransform;
            angle -= 90;
            rotateTransform = new RotateTransform(angle);
            image.LayoutTransform = rotateTransform;
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            int index = NewImagesFilesList.IndexOf(ImagesFilesFolder.SelectedFile);
            if (index > 0)
            {
                ImagesFilesFolder.SelectedFile = NewImagesFilesList[index - 1];
                DataContext = ImagesFilesFolder.SelectedFile;
                previous.IsEnabled = index > 1;
                next.IsEnabled = true;
                angle = 0;
                image.LayoutTransform = null;
                UpdateInitialStyles();
            }
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            FullScreenPreviewWindow fullScreenPreviewWindow = new FullScreenPreviewWindow(ImagesFilesFolder, null);
            fullScreenPreviewWindow.ShowDialog();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            int index = NewImagesFilesList.IndexOf(ImagesFilesFolder.SelectedFile);
            if (index < NewImagesFilesList.Count - 1)
            {
                ImagesFilesFolder.SelectedFile = NewImagesFilesList[index + 1];
                DataContext = ImagesFilesFolder.SelectedFile;
                previous.IsEnabled = true;
                next.IsEnabled = index < ImagesFilesFolder.ImagesFilesList.Count - 2;
                angle = 0;
                image.LayoutTransform = null;
                UpdateInitialStyles();
            }
        }

        private void RightTurn_Click(object sender, RoutedEventArgs e)
        {
            RotateTransform rotateTransform;
            angle += 90;
            rotateTransform = new RotateTransform(angle);
            image.LayoutTransform = rotateTransform;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                Previous_Click(sender, e);
            if (e.Key == Key.Right)
                Next_Click(sender, e);
        }

        private void SizeAdjustment_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ImagesFilesFolder != null)
            {
                image.MaxWidth = image.Width = initialImageWidth * sizeAdjustment.Value * 2 / 100;
                image.MaxHeight = image.Height = initialImageHeight * sizeAdjustment.Value * 2 / 100;
            }
        }
    }
}