using System;

namespace Phonebook
{
    [Serializable]
    class Directory
    {
        private int id;
        private string name;
        private string address;
        private string telephone;

        public Directory(int id, string name, string address, string telephone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.telephone = telephone;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
    }
}