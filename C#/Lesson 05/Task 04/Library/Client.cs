using System.ComponentModel;

namespace Library
{
    class Client : INotifyPropertyChanged
    {
        private int clientId;
        private string clientName;
        private string address;
        private string telephone;

        public event PropertyChangedEventHandler PropertyChanged;

        public Client(int clientId, string clientName, string address, string telephone)
        {
            this.clientId = clientId;
            this.clientName = clientName;
            this.address = address;
            this.telephone = telephone;
        }

        protected virtual void OnIdChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("ClientId"));
        }

        protected virtual void OnNameChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("ClientName"));
        }

        protected virtual void OnAddressChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Address"));
        }

        protected virtual void OnTelephoneChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Telephone"));
        }

        public int ClientId
        {
            get { return clientId; }
            set
            {
                clientId = value;
                OnIdChanged();
            }
        }

        public string AuthorName
        {
            get { return clientName; }
            set
            {
                clientName = value;
                OnNameChanged();
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnAddressChanged();
            }
        }

        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
                OnTelephoneChanged();
            }
        }
    }
}