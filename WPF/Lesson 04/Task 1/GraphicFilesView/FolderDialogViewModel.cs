using System;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;

namespace GraphicFilesView
{
    public class FolderDialogViewModel : FolderDialogViewModelBase
    {
        private string selectedFolder;
        private bool allTreeDepthSearch;

        public FolderDialogViewModel()
        {
            Folders = new ObservableCollection<DialogFolderViewModel>();
            Environment.GetLogicalDrives().ToList().ForEach(it => Folders.Add(new DialogFolderViewModel { Root = this, FolderName = it, FolderPath = it, FolderIcon = "hard-disk.png" }));
        }

        public string SelectedFolder
        {
            get
            {
                return selectedFolder;
            }
            set
            {
                selectedFolder = value;
                OnPropertyChanged("SelectedFolder");
            }
        }

        public bool AllTreeDepthSearch
        {
            get
            {
                return allTreeDepthSearch;
            }
            set
            {
                allTreeDepthSearch = value;
                OnPropertyChanged("AllTreeDepthSearch");
            }
        }

        public ObservableCollection<DialogFolderViewModel> Folders
        {
            get;
            set;
        }

        public DelegateCommand<object> FolderSelectedCommand
        {
            get
            {
                return new DelegateCommand<object>(it => SelectedFolder = Environment.GetFolderPath((Environment.SpecialFolder)it));
            }
        }
    }
}