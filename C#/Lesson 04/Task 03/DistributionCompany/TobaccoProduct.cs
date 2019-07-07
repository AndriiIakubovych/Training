using System;

namespace DistributionCompany
{
    class TobaccoProduct : Goods, IExciseProduct
    {
        private int ageLimit;
        private int count;

        public TobaccoProduct(int id, string name, DateTime manufactureDate, int ageLimit, int count, double price)
        {
            this.id = id;
            this.name = name;
            this.manufactureDate = manufactureDate;
            this.ageLimit = ageLimit;
            this.count = count;
            this.price = price;
        }

        public int AgeLimit
        {
            get { return ageLimit; }
        }

        public int Count
        {
            get { return count; }
        }

        public override void PrintDate(bool printId)
        {
            string years;
            if (printId)
                Console.Write("Код товара: {0}\n", id);
            Console.Write("Название товара: {0}", name);
            Console.Write("\nДата изготовления товара: {0:d}", manufactureDate);
            if (ageLimit.ToString()[ageLimit.ToString().Length - 1] == '1')
                years = "год";
            else
                if (ageLimit.ToString()[ageLimit.ToString().Length - 1] > '0' && ageLimit.ToString()[ageLimit.ToString().Length - 1] < '5')
                years = "года";
            else
                years = "лет";
            Console.Write("\nОграничение на возраст: {0} {1}", ageLimit, years);
            Console.Write("\nКоличество сигарет в пачке: {0}", count);
            Console.Write("\nЦена товара: {0} грн.", price);
        }
    }
}