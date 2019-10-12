using System;
using System.Collections.Generic;
using System.Text;

namespace MultithreadedParser
{
    class Program
    {      
        static void Main(string[] args)
        {
            int maxThreads = 50;
            string text;
            List<Item> itemsList;
            RegardSpider spider;
            Console.Title = "Многопоточный парсер";
            Console.WriteLine("Идёт получение и обработка данных...");
            try
            {
                spider = new RegardSpider(maxThreads);
                spider.Encoding = Encoding.GetEncoding(1251);
                spider.Start();
                Console.WriteLine("\nИнформация успешно занесена в БД!");
                while (true)
                {
                    Console.Write("\nВведите название или часть названия товара: ");
                    text = Console.ReadLine();
                    itemsList = spider.GetData(text);
                    if (itemsList.Count > 0)
                        foreach (Item item in itemsList)
                        {
                            Console.WriteLine("\nНазвание: " + item.ItemHeader);
                            Console.WriteLine("Фото: " + item.ItemImage);
                            Console.WriteLine("Цена: " + item.ItemPrice + " руб.");
                            foreach (KeyValuePair<string, string> property in item.ItemProperties)
                                Console.WriteLine(property.Key + ": " + property.Value);
                        }
                    else
                        Console.WriteLine("\nДанные отсутствуют!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nОшибка обработки данных!");
            }
            Console.ReadKey();
        }
    }
}