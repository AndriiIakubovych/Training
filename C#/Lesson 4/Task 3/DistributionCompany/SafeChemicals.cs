using System;

namespace DistributionCompany
{
    class SafeChemicals : HouseholdChemicals
    {
        public SafeChemicals(int id, string name, DateTime manufactureDate, string instruction, double price)
        {
            this.id = id;
            this.name = name;
            this.manufactureDate = manufactureDate;
            this.instruction = instruction;
            this.price = price;
        }

        public override void PrintDate(bool printId)
        {
            if (printId)
                Console.Write("Код товара: {0}\n", id);
            Console.Write("Название товара: {0}", name);
            Console.Write("\nДата изготовления товара: {0:d}", manufactureDate);
            Console.Write("\nИнструкция по применению: {0}", instruction);
            Console.Write("\nЦена товара: {0} грн.", price);
        }
    }
}