using System;

namespace DistributionCompany
{
    class Sold
    {
        private DateTime saleDate;
        private Goods soldGood;

        public Sold(DateTime saleDate, Goods soldGood)
        {
            this.saleDate = saleDate;
            this.soldGood = soldGood;
        }

        public DateTime SaleDate
        {
            get { return saleDate; }
        }

        public Goods SoldGood
        {
            get { return soldGood; }
        }
    }
}