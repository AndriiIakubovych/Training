using System;
using System.Xml;

namespace OrdersInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            XmlTextReader reader = null;
            Console.Title = "Чтение XML-документа";
            try
            {
                document.Load("OrdersInformation.xml");
                for (int i = 0; i < document.DocumentElement.ChildNodes.Count; i++)
                {
                    Console.WriteLine("Код заказа: " + document.DocumentElement.ChildNodes[i].Attributes[0].Value.ToString().Replace("order-", ""));
                    Console.WriteLine("Код клиента: " + document.DocumentElement.ChildNodes[i].ChildNodes[0].Attributes[0].Value.ToString().Replace("customer-", ""));
                    Console.WriteLine("ФИО клиента: " + document.DocumentElement.ChildNodes[i].ChildNodes[0].ChildNodes[0].ChildNodes[0].Value);
                    Console.WriteLine("Адрес клиента: " + document.DocumentElement.ChildNodes[i].ChildNodes[0].ChildNodes[1].ChildNodes[0].Value);
                    Console.WriteLine("Телефон клиента: " + document.DocumentElement.ChildNodes[i].ChildNodes[0].ChildNodes[2].ChildNodes[0].Value);
                    Console.WriteLine("Дата заказа: " + document.DocumentElement.ChildNodes[i].ChildNodes[1].ChildNodes[0].Value);
                    Console.Write("Товары: ");
                    for (int j = 0; j < document.DocumentElement.ChildNodes[i].ChildNodes[2].ChildNodes[0].ChildNodes.Count; j++)
                    {
                        Console.Write(document.DocumentElement.ChildNodes[i].ChildNodes[2].ChildNodes[j].Attributes[0].Value.ToString().Replace("product-", "") + " - " + document.DocumentElement.ChildNodes[i].ChildNodes[2].ChildNodes[j].ChildNodes[0].ChildNodes[0].Value + " (" + document.DocumentElement.ChildNodes[i].ChildNodes[2].ChildNodes[j].ChildNodes[1].ChildNodes[0].Value + " грн.)");
                        if (j < document.DocumentElement.ChildNodes[i].ChildNodes[2].ChildNodes[0].ChildNodes.Count - 1)
                            Console.Write(", ");
                    }
                    Console.WriteLine("\nСумма заказа: " + document.DocumentElement.ChildNodes[i].ChildNodes[3].ChildNodes[0].Value + " грн.");
                    if (i < document.DocumentElement.ChildNodes.Count - 1)
                        Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
                reader = new XmlTextReader("OrdersInformation.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    Console.WriteLine("Тип = {0}, имя = {1}, значение = {2}", reader.NodeType, reader.Name.Length > 0 ? reader.Name : "нет", reader.Value.ToString().Length > 0 ? reader.Value : "нет");
                    if (reader.AttributeCount > 0)
                        while (reader.MoveToNextAttribute())
                            Console.WriteLine("Тип = {0}, имя = {1}, значение = {2}", reader.NodeType, reader.Name.Length > 0 ? reader.Name : "нет", reader.Value.ToString().Length > 0 ? reader.Value : "нет");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка чтения файла!");
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            Console.ReadKey();
        }
    }
}