using System;

namespace DistributionCompany
{
    class NonalcoholicDrinks : Drink
    {
        private bool dyesExistence;

        public NonalcoholicDrinks(int id, string name, DateTime manufactureDate, int expiration, int caloricContent, double capacity, bool dyesExistence, double price)
        {
            this.id = id;
            this.name = name;
            this.manufactureDate = manufactureDate;
            this.expiration = expiration;
            this.caloricContent = caloricContent;
            this.capacity = capacity;
            this.dyesExistence = dyesExistence;
            this.price = price;
        }

        public bool DyesExistence
        {
            get { return dyesExistence; }
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
            Console.Write("\nЁмкость: {0} л", capacity);
            Console.Write("\nНаличие красителей: {0}", (dyesExistence ? "есть" : "нет"));
            Console.Write("\nЦена товара: {0} грн.", price);
        }
    }
}