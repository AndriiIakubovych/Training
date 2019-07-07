using System;
using System.IO;
using System.Collections.ObjectModel;

namespace GraphicFilesView
{
    public class DialogFolderViewModel : FolderDialogViewModelBase
    {
        private bool isSelected;
        private bool isExpanded;
        private string folderIcon;

        public DialogFolderViewModel()
        {
            Folders = new ObservableCollection<DialogFolderViewModel>();
        }

        private void LoadFolders()
        {
            try
            {
                string[] directories = null;
                string fullPath;
                if (Folders.Count > 0)
                    return;
                fullPath = Path.Combine(FolderPath, FolderName);
                if (FolderName.Contains(":"))
                    fullPath = string.Concat(FolderName, "\\");
                else
                    fullPath = FolderPath;
                directories = Directory.GetDirectories(fullPath);
                Folders.Clear();
                foreach (string d in directories)
                    Folders.Add(new DialogFolderViewModel { Root = Root, FolderName = Path.GetFileName(d), FolderPath = Path.GetFullPath(d), FolderIcon = "folder-close.png" });
                if (FolderName.Contains(":"))
                    FolderIcon = "hard-disk.png";
                Root.SelectedFolder = FolderPath;
            }
            catch (Exception) { }
        }

        public FolderDialogViewModel Root
        {
            get;
            set;
        }

        public string FolderName
        {
            get;
            set;
        }

        public string FolderPath
        {
            get;
            set;
        }

        public string FolderIcon
        {
            get
            {
                return folderIcon;
            }
            set
            {
                folderIcon = value;
                OnPropertyChanged("FolderIcon");
            }
        }

        public ObservableCollection<DialogFolderViewModel> Folders
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                    IsExpanded = true;
                }
            }
        }

        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                if (isExpanded != value)
                {
                    isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                    if (!FolderName.Contains(":"))
                    {
                        if (isExpanded)
                            FolderIcon = "folder-open.png";
                        else
                            FolderIcon = "folder-close.png";
                    }
                    LoadFolders();
                }
            }
        }
    }
}