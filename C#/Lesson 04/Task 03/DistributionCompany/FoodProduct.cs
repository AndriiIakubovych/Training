namespace DistributionCompany
{
    abstract class FoodProduct : Goods, IPerishableProduct
    {
        protected int expiration;
        protected int caloricContent;

        public int CaloricContent
        {
            get { return caloricContent; }
        }

        public int Expiration
        {
            get { return expiration; }
        }
    }
}