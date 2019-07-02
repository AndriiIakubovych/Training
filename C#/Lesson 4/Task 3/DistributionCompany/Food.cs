using System;

namespace DistributionCompany
{
    class Food : FoodProduct
    {
        private double weight;

        public Food(int id, string name, DateTime manufactureDate, int expiration, int caloricContent, double weight, double price)
        {
            this.id = id;
            this.name = name;
            this.manufactureDate = manufactureDate;
            this.expiration = expiration;
            this.caloricContent = caloricContent;
            this.weight = weight;
            this.price = price;
        }

        public double Weight
        {
            get { return weight; }
        }

        public override void PrintDate(bool printId)
        {
            string days;
            if (printId)
                Console.Write("Код товара: {0}\n", id);
            Console.Write("Название товара: {0}", name);
            Console.Write("\nДата изготовления товара: {0:d}", manufactureDate);
            if (expiration.ToString()[expiration.ToString().Length - 1] == '1')
                days = "день";
            else
                if (expiration.ToString()[expiration.ToString().Length - 1] > '1' && expiration.ToString()[expiration.ToString().Length - 1] < '5')
                days = "дня";
            else
                days = "дней";
            Console.Write("\nСрок годности товара: {0} {1}", expiration, days);
            Console.Write("\nКалорийность продукта: {0} ккал", caloricContent);
            Console.Write("\nВес товара: {0} кг", weight);
            Console.Write("\nЦена товара: {0} грн.", price);
        }
    }
}