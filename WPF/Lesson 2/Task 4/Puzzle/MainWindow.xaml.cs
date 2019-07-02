using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Puzzle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int PARTS_COUNT = 4;
        private static DateTime time;
        private int stepsCount;
        private WrapPanel[,] imageParts;
        private Thread thread = new Thread(new ThreadStart(SetTime));
        private double width;
        private double height;
        private double top;
        private double left;
        private bool loaded = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GameArea_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo picturesDirectoryInfo = new DirectoryInfo("pictures");
            FileInfo[] files;
            Random rand = new Random();
            LinearGradientBrush gradientBrush = new LinearGradientBrush(Color.FromRgb(125, 113, 105), Color.FromRgb(34, 12, 6), new Point(0, 0), new Point(0.5, 1));
            BitmapImage bitmapImage = new BitmapImage();
            ImageBrush imageBrush;
            Border border;
            int id = 1, borderThickness = 1;
            try
            {
                time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                stepsCount = 0;
                imageParts = new WrapPanel[PARTS_COUNT, PARTS_COUNT];
                files = picturesDirectoryInfo.GetFiles("*", SearchOption.AllDirectories);
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(files[rand.Next(0, files.Length)].FullName);
                bitmapImage.EndInit();
                if (!loaded)
                {
                    width = gameArea.RenderSize.Width / PARTS_COUNT;
                    height = gameArea.RenderSize.Height / PARTS_COUNT;
                    top = gameArea.RenderSize.Height / PARTS_COUNT;
                    left = gameArea.RenderSize.Width / PARTS_COUNT;
                    thread.Start();
                }
                for (int i = 0; i < PARTS_COUNT; i++)
                    for (int j = 0; j < PARTS_COUNT; j++)
                    {
                        imageParts[i, j] = new WrapPanel();
                        imageParts[i, j].Uid = id.ToString();
                        imageParts[i, j].Width = width;
                        imageParts[i, j].Height = height;
                        imageParts[i, j].Background = gradientBrush;
                        border = new Border();
                        border.Width = width - borderThickness * 2;
                        border.Height = height - borderThickness * 2;
                        border.BorderThickness = new Thickness(borderThickness);
                        border.CornerRadius = new CornerRadius(3);
                        imageBrush = new ImageBrush();
                        imageBrush.ImageSource = bitmapImage;
                        imageBrush.Viewbox = new Rect(1 / (double)PARTS_COUNT * j, 1 / (double)PARTS_COUNT * i, 1 / (double)PARTS_COUNT, 1 / (double)PARTS_COUNT);
                        border.Background = imageBrush;
                        border.Margin = new Thickness(borderThickness);
                        imageParts[i, j].Children.Add(border);
                        imageParts[i, j].MouseDown += ImagePart_MouseDown;
                        id++;
                    }
                MixPartsArray(imageParts);
                for (int i = 0; i < PARTS_COUNT; i++)
                    for (int j = 0; j < PARTS_COUNT; j++)
                    {
                        RegisterName(imageParts[i, j].Name, imageParts[i, j]);
                        canvas.Children.Add(imageParts[i, j]);
                        Canvas.SetTop(imageParts[i, j], top * i);
                        Canvas.SetLeft(imageParts[i, j], left * j);
                        if (Convert.ToInt32(imageParts[i, j].Uid) == PARTS_COUNT * PARTS_COUNT)
                            imageParts[i, j].Visibility = Visibility.Hidden;
                    }
                if (!loaded)
                {
                    Width += gameArea.BorderThickness.Left + gameArea.BorderThickness.Right;
                    Height += gameArea.BorderThickness.Top + gameArea.BorderThickness.Bottom;
                    loaded = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения изображения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void MixPartsArray(WrapPanel[,] imageParts)
        {
            int r1, r2, c1, c2;
            WrapPanel temp;
            Random rand = new Random();
            for (int i = 0; i < imageParts.Length * 10; i++)
            {
                r1 = rand.Next(0, imageParts.GetLength(0));
                r2 = rand.Next(0, imageParts.GetLength(0));
                c1 = rand.Next(0, imageParts.GetLength(1));
                c2 = rand.Next(0, imageParts.GetLength(1));
                temp = imageParts[r1, c1];
                imageParts[r1, c1] = imageParts[r2, c2];
                imageParts[r2, c2] = temp;
            }
            for (int i = 0; i < PARTS_COUNT; i++)
                for (int j = 0; j < PARTS_COUNT; j++)
                    imageParts[i, j].Name = "part" + imageParts[i, j].Uid;
        }

        private static void SetTime()
        {
            Timer timer = new Timer(new TimerCallback(AddSecond));
            timer.Change(0, 1000);
        }

        private static void AddSecond(object timer)
        {
            time = time.AddSeconds(1);
        }

        private void ImagePart_MouseDown(object sender, RoutedEventArgs e)
        {
            WrapPanel imagePart = (WrapPanel)sender, emptyPart = null;
            Storyboard storyboard;
            DoubleAnimation animation;
            int x0 = 0, y0 = 0, x1 = 0, y1 = 0, k = 0;
            int[] partsValues = new int[PARTS_COUNT * PARTS_COUNT];
            bool isPictureWhole = true;
            for (int i = 0; i < PARTS_COUNT; i++)
                for (int j = 0; j < PARTS_COUNT; j++)
                {
                    if (Convert.ToInt32(imageParts[i, j].Uid) == PARTS_COUNT * PARTS_COUNT)
                    {
                        emptyPart = imageParts[i, j];
                        x0 = j;
                        y0 = i;
                    }
                    if (imageParts[i, j].Uid == imagePart.Uid)
                    {
                        x1 = j;
                        y1 = i;
                    }
                }
            if ((Math.Abs(x0 - x1) == 1 && Math.Abs(y0 - y1) != 1) || (Math.Abs(x0 - x1) != 1 && Math.Abs(y0 - y1) == 1))
            {
                storyboard = new Storyboard();
                animation = new DoubleAnimation();
                animation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
                if (x0 == x1)
                {
                    Canvas.SetTop(emptyPart, Canvas.GetTop(imagePart));
                    Canvas.SetLeft(emptyPart, Canvas.GetLeft(imagePart));
                    if (y0 < y1)
                        animation.By = -imagePart.RenderSize.Height;
                    else
                        animation.By = imagePart.RenderSize.Height;
                    storyboard.Children.Add(animation);
                    Storyboard.SetTargetName(animation, imagePart.Name);
                    Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));
                    storyboard.Begin(this);
                    imageParts[y0, x0] = imagePart;
                    imageParts[y1, x1] = emptyPart;
                    stepsCount++;
                }
                else
                    if (y0 == y1)
                    {
                        Canvas.SetTop(emptyPart, Canvas.GetTop(imagePart));
                        Canvas.SetLeft(emptyPart, Canvas.GetLeft(imagePart));
                        if (x0 < x1)
                            animation.By = -imagePart.RenderSize.Width;
                        else
                            animation.By = imagePart.RenderSize.Width;
                        storyboard.Children.Add(animation);
                        Storyboard.SetTargetName(animation, imagePart.Name);
                        Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));
                        storyboard.Begin(this);
                        imageParts[y0, x0] = imagePart;
                        imageParts[y1, x1] = emptyPart;
                        stepsCount++;
                    }
                for (int i = 0; i < PARTS_COUNT; i++)
                    for (int j = 0; j < PARTS_COUNT; j++)
                    {
                        partsValues[k] = Convert.ToInt32(imageParts[i, j].Uid);
                        k++;
                    }
                for (int i = 0; i < partsValues.Length - 1; i++)
                    if (partsValues[i] + 1 != partsValues[i + 1] || partsValues[partsValues.Length - 1] != PARTS_COUNT * PARTS_COUNT)
                    {
                        isPictureWhole = false;
                        break;
                    }
                if (isPictureWhole)
                {
                    imageParts[PARTS_COUNT - 1, PARTS_COUNT - 1].Visibility = Visibility.Visible;
                    MessageBox.Show("Вы победили!\nЗатраченное время: " + ((DateTime.Now - time).Days < 1 ? time.ToLongTimeString() : "более суток") + "\nКоличество шагов: " + stepsCount, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh_Click(sender, e);
                }
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            for (int i = 0; i < PARTS_COUNT; i++)
                for (int j = 0; j < PARTS_COUNT; j++)
                    UnregisterName(imageParts[i, j].Name);
            GameArea_Loaded(sender, e);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}