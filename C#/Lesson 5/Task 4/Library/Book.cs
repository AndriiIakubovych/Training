using System.ComponentModel;

namespace Library
{
    class Book : INotifyPropertyChanged
    {
        private int bookId;
        private string bookName;
        private string genre;
        private int year;

        public event PropertyChangedEventHandler PropertyChanged;

        public Book(int bookId, string bookName, string genre, int year)
        {
            this.bookId = bookId;
            this.bookName = bookName;
            this.genre = genre;
            this.year = year;
        }

        protected virtual void OnIdChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("BookId"));
        }

        protected virtual void OnNameChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("BookName"));
        }

        protected virtual void OnGenreChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Genre"));
        }

        protected virtual void OnYearChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Year"));
        }

        public int BookId
        {
            get { return bookId; }
            set
            {
                bookId = value;
                OnIdChanged();
            }
        }

        public string BookName
        {
            get { return bookName; }
            set
            {
                bookName = value;
                OnNameChanged();
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnGenreChanged();
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnYearChanged();
            }
        }
    }
}