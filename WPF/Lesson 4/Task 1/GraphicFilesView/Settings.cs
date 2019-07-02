using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraphicFilesView
{
    public class Settings : INotifyPropertyChanged
    {
        private List<string> previewTypesList;
        private string selectedPreviewType;
        private List<string> slideImageChangeEffectsList;
        private string selectedSlideImageChangeEffect;
        private List<string> slideImageChangeTypesList;
        private string selectedSlideImageChangeType;
        private int slideImageChangeTime = 5000;

        public event PropertyChangedEventHandler PropertyChanged;

        public Settings()
        {
            previewTypesList = new List<string>() { "Последовательный", "Случайный" };
            selectedPreviewType = previewTypesList[0];
            slideImageChangeEffectsList = new List<string>() { "Проявление", "Панорама", "Сдвиг", "Падение", "Смешанный" };
            selectedSlideImageChangeEffect = slideImageChangeEffectsList[0];
            slideImageChangeTypesList = new List<string>() { "Автоматический", "Клавиатура", "Мышь" };
            selectedSlideImageChangeType = slideImageChangeTypesList[0];
        }

        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public List<string> PreviewTypesList
        {
            get { return previewTypesList; }
            set
            {
                previewTypesList = value;
                OnPropertyChanged("PreviewTypesList");
            }
        }

        public string SelectedPreviewType
        {
            get { return selectedPreviewType; }
            set
            {
                selectedPreviewType = value;
                OnPropertyChanged("SelectedPreviewType");
            }
        }

        public List<string> SlideImageChangeEffectsList
        {
            get { return slideImageChangeEffectsList; }
            set
            {
                slideImageChangeEffectsList = value;
                OnPropertyChanged("SlideImageChangeEffectsList");
            }
        }

        public string SelectedSlideImageChangeEffect
        {
            get { return selectedSlideImageChangeEffect; }
            set
            {
                selectedSlideImageChangeEffect = value;
                OnPropertyChanged("SelectedSlideImageChangeEffect");
            }
        }

        public List<string> SlideImageChangeTypesList
        {
            get { return slideImageChangeTypesList; }
            set
            {
                slideImageChangeTypesList = value;
                OnPropertyChanged("SlideImageChangeTypesList");
            }
        }

        public string SelectedSlideImageChangeType
        {
            get { return selectedSlideImageChangeType; }
            set
            {
                selectedSlideImageChangeType = value;
                OnPropertyChanged("SelectedSlideImageChangeType");
            }
        }

        public int SlideImageChangeTime
        {
            get { return slideImageChangeTime; }
            set
            {
                slideImageChangeTime = value;
                OnPropertyChanged("SlideImageChangeTime");
            }
        }
    }
}