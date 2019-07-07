using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Library
{
    class LibraryCard : INotifyPropertyChanged
    {
        private int cardId;
        private Client client;
        private List<Book> booksList;
        private DateTime inDate;
        private DateTime outDate;

        public event PropertyChangedEventHandler PropertyChanged;

        public LibraryCard(int cardId, Client client, List<Book> booksList, DateTime inDate, DateTime outDate)
        {
            this.cardId = cardId;
            this.client = client;
            this.booksList = booksList;
            this.inDate = inDate;
            this.outDate = outDate;
        }

        protected virtual void OnIdChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("CardId"));
        }

        protected virtual void OnClientChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Client"));
        }

        protected virtual void OnBooksListChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("BooksList"));
        }

        protected virtual void OnInDateChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("InDate"));
        }

        protected virtual void OnOutDateChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("OutDate"));
        }

        public int CardId
        {
            get { return cardId; }
            set
            {
                cardId = value;
                OnIdChanged();
            }
        }

        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                OnClientChanged();
            }
        }

        public List<Book> BooksList
        {
            get { return booksList; }
            set
            {
                booksList = value;
                OnBooksListChanged();
            }
        }

        public DateTime InDate
        {
            get { return inDate; }
            set
            {
                inDate = value;
                OnInDateChanged();
            }
        }

        public DateTime OutDate
        {
            get { return outDate; }
            set
            {
                outDate = value;
                OnInDateChanged();
            }
        }
    }
}