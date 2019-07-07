namespace DistributionCompany
{
    abstract class Drink : FoodProduct
    {
        protected double capacity;

        public double Capacity
        {
            get { return capacity; }
        }
    }
}