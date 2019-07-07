using System;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraphicFilesView
{
    public class ImagesFilesFolder : INotifyPropertyChanged
    {
        private string folderWay;
        private ObservableCollection<ImageFile> imagesFilesList;
        private ImageFile selectedFile;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public string FolderWay
        {
            get { return folderWay; }
            set
            {
                folderWay = value;
                OnPropertyChanged("FolderWay");
            }
        }

        public string FolderName
        {
            get { return folderWay.Length > 3 ? Path.GetFileNameWithoutExtension(folderWay) : folderWay; }
        }

        public string FolderIcon
        {
            get
            {
                string folderIcon = "folder-item.png";
                if (folderWay == Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                    folderIcon = "desktop.png";
                else
                    if (folderWay == Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) || folderWay == Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86))
                        folderIcon = "program-files.png";
                    else
                        if (folderWay == Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                            folderIcon = "my-documents.png";
                        else
                            if (folderWay == Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
                                folderIcon = "my-pictures.png";
                            else
                                if (folderWay == Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
                                    folderIcon = "my-videos.png";
                if (folderWay.Length <= 3)
                    folderIcon = "hard-disk.png";
                return folderIcon;
            }
        }

        public ObservableCollection<ImageFile> ImagesFilesList
        {
            get { return imagesFilesList; }
            set
            {
                imagesFilesList = value;
                OnPropertyChanged("ImagesFilesList");
            }
        }

        public ImageFile SelectedFile
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                OnPropertyChanged("SelectedFile");
            }
        }
    }
}