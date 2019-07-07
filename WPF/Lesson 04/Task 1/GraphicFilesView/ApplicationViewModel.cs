using System;
using System.Windows;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraphicFilesView
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private ImagesFilesFolder selectedFolder;
        private RelayCommand addCommand;
        private RelayCommand deleteCommand;
        private RelayCommand previewImageCommand;
        private RelayCommand fullScreenPreviewCommand;
        private RelayCommand sortFoldersListCommand;
        private RelayCommand sortFilesListCommand;

        public ObservableCollection<ImagesFilesFolder> ImagesFilesFoldersList { get; set; }
        public Settings Settings { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ApplicationViewModel()
        {
            ImagesFilesFoldersList = new ObservableCollection<ImagesFilesFolder>();
            Settings = new Settings();
        }

        public RelayCommand AddCommand
        {
            get
            {
                ImagesFilesFolder imagesFilesFolder;
                FileInfo[] files;
                DirectoryInfo imagesFilesDirectory;
                BitmapImage image;
                FolderDialog fd;
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    fd = new FolderDialog();
                    if (fd.ShowDialog().Value == true)
                    {
                        try
                        {
                            imagesFilesFolder = new ImagesFilesFolder() { FolderWay = fd.SelectedFolder };
                            imagesFilesDirectory = new DirectoryInfo(fd.SelectedFolder);
                            files = imagesFilesDirectory.GetFiles("*", fd.AllTreeDepthSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(f => Path.GetExtension(f.Name) == ".gif" || Path.GetExtension(f.Name) == ".jpg" || Path.GetExtension(f.Name) == ".jpeg" || Path.GetExtension(f.Name) == ".bmp" || Path.GetExtension(f.Name) == ".wmf" || Path.GetExtension(f.Name) == ".png").ToArray();
                            if (files.Length > 0)
                            {
                                imagesFilesFolder.ImagesFilesList = new ObservableCollection<ImageFile>();
                                imagesFilesFolder.SelectedFile = new ImageFile();
                                for (int i = 0; i < files.Length; i++)
                                {
                                    image = new BitmapImage();
                                    image.BeginInit();
                                    image.UriSource = new Uri(files[i].FullName);
                                    image.EndInit();
                                    imagesFilesFolder.ImagesFilesList.Add(new ImageFile() { FileName = files[i].Name, FileImage = image });
                                }
                                ImagesFilesFoldersList.Add(imagesFilesFolder);
                                SelectedFolder = imagesFilesFolder;
                            }
                            else
                                MessageBox.Show("Выбранная папка не содержит графических файлов!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка добавления папки!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                ImagesFilesFolder imagesFilesFolder;
                int index;
                return deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
                {
                    imagesFilesFolder = obj as ImagesFilesFolder;
                    if (imagesFilesFolder != null)
                    {
                        index = ImagesFilesFoldersList.IndexOf(imagesFilesFolder);
                        ImagesFilesFoldersList.Remove(imagesFilesFolder);
                        if (ImagesFilesFoldersList.Count > 0)
                        {
                            index = index > 0 ? index - 1 : 0;
                            SelectedFolder = ImagesFilesFoldersList[index];
                        }
                    }
                }, (obj) => ImagesFilesFoldersList.Count > 0));
            }
        }

        public RelayCommand PreviewImageCommand
        {
            get
            {
                ImagesFilesFolder imagesFilesFolder;
                ImagePreviewWindow imagePreviewWindow;
                return previewImageCommand ?? (previewImageCommand = new RelayCommand(obj =>
                {
                    imagesFilesFolder = obj as ImagesFilesFolder;
                    if (imagesFilesFolder != null && imagesFilesFolder.SelectedFile.FileName != null)
                    {
                        imagePreviewWindow = new ImagePreviewWindow(imagesFilesFolder, Settings);
                        imagePreviewWindow.ShowDialog();
                    }
                }, (obj) => ImagesFilesFoldersList.Count > 0 && SelectedFolder.ImagesFilesList.Count > 0 && SelectedFolder.SelectedFile.FileName != null));
            }
        }

        public RelayCommand FullScreenPreviewCommand
        {
            get
            {
                ImagesFilesFolder imagesFilesFolder;
                FullScreenPreviewWindow fullScreenPreviewWindow;
                return fullScreenPreviewCommand ?? (fullScreenPreviewCommand = new RelayCommand(obj =>
                {
                    imagesFilesFolder = obj as ImagesFilesFolder;
                    if (imagesFilesFolder != null)
                    {
                        fullScreenPreviewWindow = new FullScreenPreviewWindow(imagesFilesFolder, Settings);
                        fullScreenPreviewWindow.ShowDialog();
                    }
                }, (obj) => ImagesFilesFoldersList.Count > 0));
            }
        }

        public RelayCommand SortFoldersListCommand
        {
            get
            {
                ObservableCollection<ImagesFilesFolder> tempList = new ObservableCollection<ImagesFilesFolder>();
                return sortFoldersListCommand ?? (sortFoldersListCommand = new RelayCommand(obj =>
                {
                    if (ImagesFilesFoldersList.Count > 0)
                    {
                        tempList.Clear();
                        foreach (ImagesFilesFolder iff in ImagesFilesFoldersList.OrderBy(iffe => iffe.FolderName))
                            tempList.Add(iff);
                        ImagesFilesFoldersList.Clear();
                        foreach (ImagesFilesFolder iff in tempList)
                            ImagesFilesFoldersList.Add(iff);
                        SelectedFolder = ImagesFilesFoldersList[0];
                    }
                }));
            }
        }

        public RelayCommand SortFilesListCommand
        {
            get
            {
                ObservableCollection<ImageFile> tempList = new ObservableCollection<ImageFile>();
                return sortFilesListCommand ?? (sortFilesListCommand = new RelayCommand(obj =>
                {
                    if (ImagesFilesFoldersList.Count > 0 && SelectedFolder.SelectedFile != null)
                    {
                        tempList.Clear();
                        foreach (ImageFile ife in SelectedFolder.ImagesFilesList.OrderBy(ifoe => ifoe.FileName))
                            tempList.Add(ife);
                        SelectedFolder.ImagesFilesList.Clear();
                        foreach (ImageFile ife in tempList)
                            SelectedFolder.ImagesFilesList.Add(ife);
                        SelectedFolder.SelectedFile = SelectedFolder.ImagesFilesList[0];
                    }
                }));
            }
        }

        public ImagesFilesFolder SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;
                OnPropertyChanged("SelectedFolder");
            }
        }

        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}