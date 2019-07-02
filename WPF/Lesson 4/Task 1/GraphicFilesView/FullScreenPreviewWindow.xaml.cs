using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace GraphicFilesView
{
    /// <summary>
    /// Логика взаимодействия для FullScreenPreviewWindow.xaml
    /// </summary>
    public partial class FullScreenPreviewWindow : Window
    {
        private ObservableCollection<ImageFile> NewImagesFilesList = new ObservableCollection<ImageFile>();
        private List<Image> imagesList = new List<Image>();
        private List<double> imagesWidthsList = new List<double>();
        private int slideImageChangeEffect;
        private int index;
        private bool next;
        private bool animationCompleted = true;
        private Timer timer;
        private DoubleAnimation opacityAnimation;
        private DoubleAnimation widthAnimation;
        private ThicknessAnimation leftMarginAnimation;
        private ThicknessAnimation topMarginAnimation;

        private enum SlideImageChangeEffects { PROCESSING, PANORAMA, SHIFT, FALLING, COMBINATION }

        public ImagesFilesFolder ImagesFilesFolder { get; set; }
        public Settings Settings { get; set; }

        public FullScreenPreviewWindow(ImagesFilesFolder imagesFilesFolder, Settings settings)
        {
            int j;
            Random random = new Random();
            Image image;
            BitmapImage bitmapImage;
            ImageFile temp;
            InitializeComponent();
            ImagesFilesFolder = imagesFilesFolder;
            Settings = settings;
            if (Settings != null)
            {
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
                index = NewImagesFilesList.IndexOf(ImagesFilesFolder.SelectedFile);
                if (index < 0)
                    index = 0;
                for (int i = 0; i < NewImagesFilesList.Count; i++)
                {
                    image = new Image();
                    image.MaxWidth = NewImagesFilesList[i].MaxWidth;
                    image.MaxHeight = NewImagesFilesList[i].MaxHeight;
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(NewImagesFilesList[i].ImageSource);
                    bitmapImage.EndInit();
                    image.Source = bitmapImage;
                    imagesList.Add(image);
                    grid.Children.Add(image);
                }
                timer = new Timer(new TimerCallback(ChangeSlide));
                if (Settings.SelectedSlideImageChangeType == "Автоматический")
                    timer.Change(Settings.SlideImageChangeTime, Settings.SlideImageChangeTime);
                switch (Settings.SelectedSlideImageChangeEffect)
                {
                    case "Проявление":
                        slideImageChangeEffect = (int)SlideImageChangeEffects.PROCESSING;
                        break;
                    case "Панорама":
                        slideImageChangeEffect = (int)SlideImageChangeEffects.PANORAMA;
                        break;
                    case "Сдвиг":
                        slideImageChangeEffect = (int)SlideImageChangeEffects.SHIFT;
                        break;
                    case "Падение":
                        slideImageChangeEffect = (int)SlideImageChangeEffects.FALLING;
                        break;
                    case "Смешанный":
                        slideImageChangeEffect = (int)SlideImageChangeEffects.COMBINATION;
                        break;
                }
            }
            else
            {
                foreach (ImageFile ife in ImagesFilesFolder.ImagesFilesList)
                    NewImagesFilesList.Add(ife);
                index = NewImagesFilesList.IndexOf(ImagesFilesFolder.SelectedFile);
                DataContext = ImagesFilesFolder.SelectedFile;
                image = new Image();
                image.MaxWidth = NewImagesFilesList[index].MaxWidth;
                image.MaxHeight = NewImagesFilesList[index].MaxHeight;
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(NewImagesFilesList[index].ImageSource);
                bitmapImage.EndInit();
                image.Source = bitmapImage;
                imagesList.Add(image);
                grid.Children.Add(image);
            }
        }

        public void ChangeImage()
        {
            Random rand = new Random();
            int effectNumber = slideImageChangeEffect != (int)SlideImageChangeEffects.COMBINATION ? slideImageChangeEffect : rand.Next(4);
            animationCompleted = false;
            switch (effectNumber)
            {
                case (int)SlideImageChangeEffects.PROCESSING:
                    opacityAnimation = new DoubleAnimation();
                    opacityAnimation.From = 1;
                    opacityAnimation.To = 0;
                    opacityAnimation.Duration = TimeSpan.FromSeconds(1);
                    opacityAnimation.Completed += FirstOpacityAnimation_Completed;
                    imagesList[index].BeginAnimation(OpacityProperty, opacityAnimation);
                    break;
                case (int)SlideImageChangeEffects.PANORAMA:
                    widthAnimation = new DoubleAnimation();
                    widthAnimation.From = imagesWidthsList[index];
                    widthAnimation.To = 0;
                    widthAnimation.Duration = TimeSpan.FromSeconds(1);
                    widthAnimation.Completed += FirstWidthAnimation_Completed;
                    imagesList[index].BeginAnimation(WidthProperty, widthAnimation);
                    break;
                case (int)SlideImageChangeEffects.SHIFT:
                    leftMarginAnimation = new ThicknessAnimation();
                    leftMarginAnimation.From = new Thickness(0, 0, 0, 0);
                    leftMarginAnimation.To = new Thickness(-ActualWidth * 3, 0, 0, 0);
                    leftMarginAnimation.Duration = TimeSpan.FromSeconds(1);
                    leftMarginAnimation.Completed += FirstLeftMarginAnimation_Completed;
                    imagesList[index].BeginAnimation(MarginProperty, leftMarginAnimation);
                    break;
                case (int)SlideImageChangeEffects.FALLING:
                    topMarginAnimation = new ThicknessAnimation();
                    topMarginAnimation.From = new Thickness(0, 0, 0, 0);
                    topMarginAnimation.To = new Thickness(0, -ActualHeight * 3, 0, 0);
                    topMarginAnimation.Duration = TimeSpan.FromSeconds(1);
                    topMarginAnimation.Completed += FirstTopMarginAnimation_Completed;
                    imagesList[index].BeginAnimation(MarginProperty, topMarginAnimation);
                    break;
            }
        }

        private void ChangeSlide(object timer)
        {
            next = true;
            Action action = () => { ChangeImage(); };
            Dispatcher.Invoke(action);
        }

        private void FullScreenPreviewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings != null)
                for (int i = 0; i < imagesList.Count; i++)
                {
                    imagesWidthsList.Add(imagesList[i].ActualWidth);
                    if (i != index)
                    {
                        imagesList[i].Width = 0;
                        imagesList[i].Opacity = 0;
                        imagesList[i].Margin = new Thickness(-ActualWidth * 3, -ActualHeight * 3, 0, 0);
                    }
                }
        }

        private void FirstOpacityAnimation_Completed(object sender, EventArgs e)
        {
            imagesList[index].BeginAnimation(OpacityProperty, null);
            opacityAnimation = new DoubleAnimation();
            imagesList[index].Width = 0;
            imagesList[index].Margin = new Thickness(-ActualWidth * 3, 0, 0, 0);
            if (next)
                index = index < imagesList.Count - 1 ? index + 1 : 0;
            else
                index = index > 0 ? index - 1 : imagesList.Count - 1;
            imagesList[index].Width = imagesWidthsList[index];
            imagesList[index].Margin = new Thickness(0, 0, 0, 0);
            opacityAnimation.From = 0;
            opacityAnimation.To = 1;
            opacityAnimation.Duration = TimeSpan.FromSeconds(1);
            opacityAnimation.Completed += SecondOpacityAnimation_Completed;
            imagesList[index].BeginAnimation(OpacityProperty, opacityAnimation);
        }

        private void SecondOpacityAnimation_Completed(object sender, EventArgs e)
        {
            imagesList[index].BeginAnimation(OpacityProperty, null);
            opacityAnimation = new DoubleAnimation();
            imagesList[index].Width = imagesWidthsList[index];
            imagesList[index].Opacity = 1;
            imagesList[index].Margin = new Thickness(0, 0, 0, 0);
            animationCompleted = true;
        }

        private void FirstWidthAnimation_Completed(object sender, EventArgs e)
        {
            imagesList[index].BeginAnimation(WidthProperty, null);
            widthAnimation = new DoubleAnimation();
            imagesList[index].Opacity = 0;
            imagesList[index].Margin = new Thickness(-ActualWidth * 3, 0, 0, 0);
            if (next)
                index = index < imagesList.Count - 1 ? index + 1 : 0;
            else
                index = index > 0 ? index - 1 : imagesList.Count - 1;
            imagesList[index].Opacity = 1;
            imagesList[index].Margin = new Thickness(0, 0, 0, 0);
            widthAnimation.From = 0;
            widthAnimation.To = imagesWidthsList[index];
            widthAnimation.Duration = TimeSpan.FromSeconds(1);
            widthAnimation.Completed += SecondWidthAnimation_Completed;
            imagesList[index].BeginAnimation(WidthProperty, widthAnimation);
        }

        private void SecondWidthAnimation_Completed(object sender, EventArgs e)
        {
            imagesList[index].BeginAnimation(WidthProperty, null);
            widthAnimation = new DoubleAnimation();
            imagesList[index].Width = imagesWidthsList[index];
            imagesList[index].Opacity = 1;
            imagesList[index].Margin = new Thickness(0, 0, 0, 0);
            animationCompleted = true;
        }

        private void FirstLeftMarginAnimation_Completed(object sender, EventArgs e)
        {
            imagesList[index].BeginAnimation(MarginProperty, null);
            leftMarginAnimation = new ThicknessAnimation();
            imagesList[index].Width = 0;
            imagesList[index].Opacity = 0;
            if (next)
                index = index < imagesList.Count - 1 ? index + 1 : 0;
            else
                index = index > 0 ? index - 1 : imagesList.Count - 1;
            imagesList[index].Width = imagesWidthsList[index];
            imagesList[index].Opacity = 1;
            leftMarginAnimation.From = new Thickness(-ActualWidth * 3, 0, 0, 0);
            leftMarginAnimation.To = new Thickness(0, 0, 0, 0);
            leftMarginAnimation.Duration = TimeSpan.FromSeconds(1);
            leftMarginAnimation.Completed += SecondLeftMarginAnimation_Completed;
            imagesList[index].BeginAnimation(MarginProperty, leftMarginAnimation);
        }

        private void SecondLeftMarginAnimation_Completed(object sender, EventArgs e)
        {
            imagesList[index].BeginAnimation(MarginProperty, null);
            leftMarginAnimation = new ThicknessAnimation();
            imagesList[index].Width = imagesWidthsList[index];
            imagesList[index].Opacity = 1;
            imagesList[index].Margin = new Thickness(0, 0, 0, 0);
            animationCompleted = true;
        }

        private void FirstTopMarginAnimation_Completed(object sender, EventArgs e)
        {
            imagesList[index].BeginAnimation(MarginProperty, null);
            topMarginAnimation = new ThicknessAnimation();
            imagesList[index].Width = 0;
            imagesList[index].Opacity = 0;
            if (next)
                index = index < imagesList.Count - 1 ? index + 1 : 0;
            else
                index = index > 0 ? index - 1 : imagesList.Count - 1;
            imagesList[index].Width = imagesWidthsList[index];
            imagesList[index].Opacity = 1;
            topMarginAnimation.From = new Thickness(0, -ActualHeight * 3, 0, 0);
            topMarginAnimation.To = new Thickness(0, 0, 0, 0);
            topMarginAnimation.Duration = TimeSpan.FromSeconds(1);
            topMarginAnimation.Completed += SecondTopMarginAnimation_Completed;
            imagesList[index].BeginAnimation(MarginProperty, topMarginAnimation);
        }

        private void SecondTopMarginAnimation_Completed(object sender, EventArgs e)
        {
            imagesList[index].BeginAnimation(MarginProperty, null);
            topMarginAnimation = new ThicknessAnimation();
            imagesList[index].Width = imagesWidthsList[index];
            imagesList[index].Opacity = 1;
            imagesList[index].Margin = new Thickness(0, 0, 0, 0);
            animationCompleted = true;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (Settings != null && Settings.SelectedSlideImageChangeType == "Клавиатура")
            {
                if (e.Key == Key.Left && animationCompleted)
                {
                    next = false;
                    ChangeImage();
                }
                if (e.Key == Key.Right && animationCompleted)
                {
                    next = true;
                    ChangeImage();
                }
            }
            if (e.Key == Key.Escape)
            {
                if (Settings != null)
                    timer.Dispose();
                Close();
            }
        }

        private void FullScreenPreviewWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Settings != null && Settings.SelectedSlideImageChangeType == "Мышь" && animationCompleted)
            {
                next = true;
                ChangeImage();
            }
        }
    }
}