using System;
using System.Collections.Generic;

namespace OrdersInformation
{
    class Order
    {
        private int id;
        private Customer customer;
        private DateTime date;
        private List<Product> productsList;
        private double sum;

        public Order(int id, Customer customer, DateTime date, List<Product> productsList)
        {
            this.id = id;
            this.customer = customer;
            this.date = date;
            this.productsList = productsList;
            sum = 0;
        }

        public int Id
        {
            get { return id; }
        }

        public Customer CustomerData
        {
            get { return customer; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public List<Product> ProductsList
        {
            get { return productsList; }
        }

        public double Sum
        {
            get
            {
                sum = 0;
                foreach (Product p in productsList)
                    sum += p.Price;
                return sum;
            }
        }
    }
}