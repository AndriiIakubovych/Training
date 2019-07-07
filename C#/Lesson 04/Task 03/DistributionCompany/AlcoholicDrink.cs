using System;

namespace DistributionCompany
{
    class AlcoholicDrink : Drink, IExciseProduct
    {
        private int alcoholContent;
        private int ageLimit;

        public AlcoholicDrink(int id, string name, DateTime manufactureDate, int expiration, int caloricContent, double capacity, int alcoholContent, int ageLimit, double price)
        {
            this.id = id;
            this.name = name;
            this.manufactureDate = manufactureDate;
            this.expiration = expiration;
            this.caloricContent = caloricContent;
            this.capacity = capacity;
            this.alcoholContent = alcoholContent;
            this.ageLimit = ageLimit;
            this.price = price;
        }

        public int AlcoholContent
        {
            get { return alcoholContent; }
        }

        public int AgeLimit
        {
            get { return ageLimit; }
        }

        public override void PrintDate(bool printId)
        {
            string days, years;
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
            if (ageLimit.ToString()[ageLimit.ToString().Length - 1] == '1')
                years = "год";
            else
                if (ageLimit.ToString()[ageLimit.ToString().Length - 1] > '0' && ageLimit.ToString()[ageLimit.ToString().Length - 1] < '5')
                years = "года";
            else
                years = "лет";
            Console.Write("\nСрок годности товара: {0} {1}", expiration, days);
            Console.Write("\nКалорийность продукта: {0} ккал", caloricContent);
            Console.Write("\nЁмкость: {0} л", capacity);
            Console.Write("\nСодержание алкоголя: {0}% об.", alcoholContent);
            Console.Write("\nОграничение на возраст: {0} {1}", ageLimit, years);
            Console.Write("\nЦена товара: {0} грн.", price);
        }
    }
}