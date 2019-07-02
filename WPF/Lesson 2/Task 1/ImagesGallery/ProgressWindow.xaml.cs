using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using System.Threading;
using System.ComponentModel;

namespace ImagesGallery
{
    /// <summary>
    /// Логика взаимодействия для ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, object value);

        private BackgroundWorker worker;
        private bool isCanceled = false;

        public FileInfo[] Files { get; set; }
        public DirectoryInfo ImagesDirectory { get; set; }
        public List<BitmapImage> BitmapImagesList { get; set; }

        public ProgressWindow()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            BitmapImagesList = new List<BitmapImage>();
            worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Files = ImagesDirectory.GetFiles().Where(f => Path.GetExtension(f.Name) == ".gif" || Path.GetExtension(f.Name) == ".jpg" || Path.GetExtension(f.Name) == ".jpeg" || Path.GetExtension(f.Name) == ".bmp" || Path.GetExtension(f.Name) == ".wmf" || Path.GetExtension(f.Name) == ".png").ToArray();
            progressBar.Maximum = Files.Count();
            progressBar.Value = 0;
            worker.RunWorkerAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateProgressBarDelegate updProgress = new UpdateProgressBarDelegate(progressBar.SetValue);
            BitmapImage bitmapImage;
            Action action;
            double value = 0;
            BitmapImagesList.Clear();
            for (int i = 0; i < Files.Length; i++)
            {
                if (!isCanceled)
                {
                    action = () =>
                    {
                        try
                        {
                            bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.UriSource = new Uri(Files[i].FullName);
                            bitmapImage.EndInit();
                            BitmapImagesList.Add(bitmapImage);
                        }
                        catch (Exception) { }
                    };
                    Dispatcher.Invoke(action);
                    Dispatcher.Invoke(updProgress, new object[] { System.Windows.Controls.Primitives.RangeBase.ValueProperty, ++value });
                }
                else
                    break;
            }
            Thread.Sleep(500);
            action = () => { Close(); };
            Dispatcher.Invoke(action);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            isCanceled = true;
            worker.Dispose();
        }
    }
}