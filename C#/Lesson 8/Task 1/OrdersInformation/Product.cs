namespace OrdersInformation
{
    class Product
    {
        private int id;
        private string name;
        private double price;

        public Product(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public double Price
        {
            get { return price; }
        }
    }
}