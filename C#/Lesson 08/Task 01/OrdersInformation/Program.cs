using System;
using System.Collections.Generic;
using System.Xml;

namespace OrdersInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int productId = 0, customerId = 0, orderId = 0, customerNumber = 0;
            string name, address, telephone;
            double price;
            DateTime date;
            bool stopEnter = false, stopProductEnter = true, hasId = false;
            List<Product> productsList = new List<Product>();
            List<Customer> customersList = new List<Customer>();
            List<Product> orderProductsList;
            List<Order> ordersList = new List<Order>();
            XmlTextWriter writer = null;
            Console.Title = "Информация о заказах";
            do
            {
                try
                {
                    Console.Write("Введите название товара: ");
                    name = Console.ReadLine();
                    Console.Write("Введите цену товара (грн.): ");
                    price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                    if (price <= 0)
                        throw new WrongValueException();
                    productId++;
                    productsList.Add(new Product(productId, name, price));
                    Console.WriteLine("Информация о товаре успешно добавлена! Код товара: " + productId);
                    Console.Write("Добавить информацию о других товарах (y/n)? ");
                    stopEnter = Console.ReadLine().ToLower().StartsWith("n");
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nОшибка при вводе!\n");
                }
                catch (WrongValueException)
                {
                    Console.WriteLine("\nЦена товара введена неверно!\n");
                }
            }
            while (!stopEnter);
            do
            {
                Console.Write("Введите ФИО клиента: ");
                name = Console.ReadLine();
                Console.Write("Введите адрес клиента: ");
                address = Console.ReadLine();
                Console.Write("Введите телефон клиента: ");
                telephone = Console.ReadLine();
                customerId++;
                customersList.Add(new Customer(customerId, name, address, telephone));
                Console.WriteLine("Информация о клиенте успешно добавлена! Код клиента: " + customerId);
                Console.Write("Добавить информацию о других клиентах (y/n)? ");
                stopEnter = Console.ReadLine().ToLower().StartsWith("n");
                Console.WriteLine();
            }
            while (!stopEnter);
            stopEnter = false;
            do
            {
                try
                {
                    orderProductsList = new List<Product>();
                    Console.Write("Введите код клиента, сделавшего заказ: ");
                    customerId = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < customersList.Count; i++)
                        if (customersList[i].Id == customerId)
                        {
                            hasId = true;
                            customerNumber = i;
                            break;
                        }
                    if (!hasId)
                        throw new DataNotFoundException();
                    Console.Write("Введите дату заказа: ");
                    date = Convert.ToDateTime(Console.ReadLine());
                    do
                    {
                        try
                        {
                            hasId = false;
                            Console.Write("Введите код товара: ");
                            productId = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < productsList.Count; i++)
                                if (productsList[i].Id == productId)
                                {
                                    hasId = true;
                                    orderProductsList.Add(productsList[i]);
                                    break;
                                }
                            if (!hasId)
                                throw new DataNotFoundException();
                            Console.Write("Добавить в заказ ещё товары (y/n)? ");
                            stopProductEnter = Console.ReadLine().ToLower().StartsWith("n");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nОшибка при вводе!\n");
                        }
                        catch (DataNotFoundException)
                        {
                            Console.WriteLine("\nТовар не найден!\n");
                            Console.Write("Добавить в заказ ещё товары (y/n)? ");
                            stopProductEnter = Console.ReadLine().ToLower().StartsWith("n");
                        }
                    }
                    while (!stopProductEnter);
                    if (orderProductsList.Count > 0)
                    {
                        orderId++;
                        ordersList.Add(new Order(orderId, customersList[customerNumber], date, orderProductsList));
                        Console.WriteLine("Информация о заказе успешно добавлена! Код заказа: " + orderId + ", сумма заказа: " + ordersList[ordersList.Count - 1].Sum + " грн.");
                    }
                    else
                        Console.WriteLine("Информация о заказе не добавлена!");
                    Console.Write("Добавить информацию о других заказах (y/n)? ");
                    stopEnter = Console.ReadLine().ToLower().StartsWith("n");
                    if (!stopEnter)
                        Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nОшибка при вводе!\n");
                }
                catch (DataNotFoundException)
                {
                    Console.WriteLine("\nДанные не найдены!\n");
                }
            }
            while (!stopEnter);
            try
            {
                writer = new XmlTextWriter("OrdersInformation.xml", System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("orders");
                foreach (Order o in ordersList)
                {
                    writer.WriteStartElement("order");
                    writer.WriteAttributeString("id", "order-" + o.Id.ToString());
                    writer.WriteStartElement("customer");
                    writer.WriteAttributeString("id", "customer-" + o.CustomerData.Id);
                    writer.WriteElementString("name", o.CustomerData.Name);
                    writer.WriteElementString("address", o.CustomerData.Address);
                    writer.WriteElementString("telephone", o.CustomerData.Telephone);
                    writer.WriteEndElement();
                    writer.WriteElementString("date", o.Date.ToString());
                    writer.WriteStartElement("products");
                    foreach (Product p in o.ProductsList)
                    {
                        writer.WriteStartElement("product");
                        writer.WriteAttributeString("id", "product-" + p.Id);
                        writer.WriteElementString("name", p.Name);
                        writer.WriteStartElement("price");
                        writer.WriteAttributeString("currency", "грн.");
                        writer.WriteString(p.Price.ToString());
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("sum");
                    writer.WriteAttributeString("currency", "грн.");
                    writer.WriteString(o.Sum.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                Console.WriteLine("\nXML-файл с информацией о заказах успешно создан!");
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            Console.ReadKey();
        }
    }
}