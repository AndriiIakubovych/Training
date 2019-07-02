using System;

namespace DistributionCompany
{
    class FlammableChemicals : HouseholdChemicals, IFlammableGoods
    {
        private string storageConditions;

        public FlammableChemicals(int id, string name, DateTime manufactureDate, string instruction, string storageConditions, double price)
        {
            this.id = id;
            this.name = name;
            this.manufactureDate = manufactureDate;
            this.instruction = instruction;
            this.storageConditions = storageConditions;
            this.price = price;
        }

        public string StorageConditions
        {
            get { return storageConditions; }
        }

        public override void PrintDate(bool printId)
        {
            if (printId)
                Console.Write("Код товара: {0}\n", id);
            Console.Write("Название товара: {0}", name);
            Console.Write("\nДата изготовления товара: {0:d}", manufactureDate);
            Console.Write("\nИнструкция по применению: {0}", instruction);
            Console.Write("\nУсловия хранения товара: {0}", storageConditions);
            Console.Write("\nЦена товара: {0} грн.", price);
        }
    }
}