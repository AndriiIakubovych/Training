namespace OrdersInformation
{
    class Customer
    {
        private int id;
        private string name;
        private string address;
        private string telephone;

        public Customer(int id, string name, string address, string telephone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.telephone = telephone;
        }

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Address
        {
            get { return address; }
        }

        public string Telephone
        {
            get { return telephone; }
        }
    }
}