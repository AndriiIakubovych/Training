using System;

namespace DistributionCompany
{
    class Dish : Goods, IFragileGoods
    {
        private string material;
        private string manufacturer;

        public Dish(int id, string name, DateTime manufactureDate, string material, string manufacturer, double price)
        {
            this.id = id;
            this.name = name;
            this.manufactureDate = manufactureDate;
            this.material = material;
            this.manufacturer = manufacturer;
            this.price = price;
        }

        public string Material
        {
            get { return material; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
        }

        public override void PrintDate(bool printId)
        {
            if (printId)
                Console.Write("Код товара: {0}\n", id);
            Console.Write("Название товара: {0}", name);
            Console.Write("\nДата изготовления товара: {0:d}", manufactureDate);
            Console.Write("\nМатериал, из которого изготовлен товар: {0}", material);
            Console.Write("\nПроизводитель товара: {0}", manufacturer);
            Console.Write("\nЦена товара: {0} грн.", price);
        }
    }
}