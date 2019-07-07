using System.Collections.Generic;
using System.ComponentModel;

namespace Library
{
    class Catalogue : INotifyPropertyChanged
    {
        private int catalogueId;
        private Book book;
        private List<Author> authorsList;

        public event PropertyChangedEventHandler PropertyChanged;

        public Catalogue(int catalogueId, Book book, List<Author> authorsList)
        {
            this.catalogueId = catalogueId;
            this.book = book;
            this.authorsList = authorsList;
        }

        protected virtual void OnIdChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("CatalogueId"));
        }

        protected virtual void OnBookChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Book"));
        }

        protected virtual void OnAuthorsListChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("AuthorsList"));
        }

        public int CatalogueId
        {
            get { return catalogueId; }
            set
            {
                catalogueId = value;
                OnIdChanged();
            }
        }

        public Book Book
        {
            get { return book; }
            set
            {
                book = value;
                OnBookChanged();
            }
        }

        public List<Author> AuthorsList
        {
            get { return authorsList; }
            set
            {
                authorsList = value;
                OnBookChanged();
            }
        }
    }
}