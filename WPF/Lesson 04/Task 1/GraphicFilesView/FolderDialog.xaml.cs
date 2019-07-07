using System.Windows;

namespace GraphicFilesView
{
    /// <summary>
    /// Логика взаимодействия для FolderDialog.xaml
    /// </summary>
    public partial class FolderDialog : Window
    {
        private FolderDialogViewModel viewModel;

        public FolderDialog()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public FolderDialogViewModel ViewModel
        {
            get
            {
                return viewModel = viewModel ?? new FolderDialogViewModel();
            }
        }

        public string SelectedFolder
        {
            get
            {
                return ViewModel.SelectedFolder;
            }
        }

        public bool AllTreeDepthSearch
        {
            get
            {
                return ViewModel.AllTreeDepthSearch;
            }
        }
    }
}