using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace GraphicFilesView
{
    public class ImageFile
    {
        private string fileName;
        BitmapImage fileImage;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string DisplayFileName
        {
            get { return Path.GetFileNameWithoutExtension(fileName).Length <= 22 ? fileName : Path.GetFileNameWithoutExtension(fileName).Substring(0, 22) + "..."; }
        }

        public BitmapImage FileImage
        {
            get { return fileImage; }
            set { fileImage = value; }
        }

        public string ImageSource
        {
            get { return fileImage.UriSource.AbsoluteUri; }
        }

        public string ImageSize
        {
            get { return Math.Round(fileImage.Width) + " × " + Math.Round(fileImage.Height); }
        }

        public int MaxWidth
        {
            get { return Convert.ToInt32(fileImage.Width); }
        }

        public int MaxHeight
        {
            get { return Convert.ToInt32(fileImage.Height); }
        }
    }
}