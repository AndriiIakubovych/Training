using System.ComponentModel;

namespace Library
{
    class Author : INotifyPropertyChanged
    {
        private int authorId;
        private string authorName;

        public event PropertyChangedEventHandler PropertyChanged;

        public Author(int authorId, string authorName)
        {
            this.authorId = authorId;
            this.authorName = authorName;
        }

        protected virtual void OnIdChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("AuthorId"));
        }

        protected virtual void OnNameChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("AuthorName"));
        }

        public int AuthorId
        {
            get { return authorId; }
            set
            {
                authorId = value;
                OnIdChanged();
            }
        }

        public string AuthorName
        {
            get { return authorName; }
            set
            {
                authorName = value;
                OnNameChanged();
            }
        }
    }
}