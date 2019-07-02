using System;

namespace DistributionCompany
{
    abstract class Goods
    {
        protected int id;
        protected string name;
        protected DateTime manufactureDate;
        protected DateTime arrivalDate;
        protected double price;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public DateTime ManufactureDate
        {
            get { return manufactureDate; }
        }

        public double Price
        {
            get { return price; }
        }

        public virtual void PrintDate(bool printId) { }
    }
}