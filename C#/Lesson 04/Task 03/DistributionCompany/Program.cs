using System;
using System.Collections.Generic;

namespace DistributionCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemNumber = 0, type = 0, id = 0, lastId, expiration, caloricContent, alcoholContent, ageLimit, count;
            string name = null, firstDescription, secondDescription;
            DateTime firstDate = new DateTime(), secondDate = new DateTime();
            double weight, price;
            bool dyesExistence, available;
            List<Arrived> arrivedList = new List<Arrived>();
            List<Arrived> availableList = new List<Arrived>();
            List<Sold> soldList = new List<Sold>();
            List<ChargedOff> chargedOffList = new List<ChargedOff>();
            List<Transfered> transferedList = new List<Transfered>();
            Console.Title = "Дистрибьюторская компания";
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Г Л А В Н О Е   М Е Н Ю");
                    Console.WriteLine("\n1 - Приход товаров");
                    Console.WriteLine("2 - Реализация товаров");
                    Console.WriteLine("3 - Списание товаров");
                    Console.WriteLine("4 - Передача товаров");
                    Console.WriteLine("5 - Информация о товарах");
                    Console.WriteLine("6 - Выход");
                    Console.Write("\nВаш выбор: ");
                    itemNumber = Convert.ToInt32(Console.ReadLine());
                    available = false;
                    Console.Clear();
                    switch (itemNumber)
                    {
                        case 1:
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("К А Т Е Г О Р И И   Т О В А Р О В");
                                    Console.WriteLine("\n1 - Еда");
                                    Console.WriteLine("2 - Безалкогольные напитки и соки");
                                    Console.WriteLine("3 - Алкоголь");
                                    Console.WriteLine("4 - Бытовая химия (безопасная)");
                                    Console.WriteLine("5 - Бытовая химия (легковоспламеняющаяся)");
                                    Console.WriteLine("6 - Товары для дома");
                                    Console.WriteLine("7 - Посуда");
                                    Console.WriteLine("8 - Табачные изделия");
                                    Console.WriteLine("9 - Выход в главное меню");
                                    Console.Write("\nВаш выбор: ");
                                    type = Convert.ToInt32(Console.ReadLine());
                                    if (type != 9)
                                        Console.Clear();
                                    if (type >= 1 & type <= 8)
                                    {
                                        lastId = 0;
                                        foreach (Arrived a in arrivedList)
                                            if (a.ArrivedGood.Id.ToString()[0] == Convert.ToChar(type.ToString()))
                                                lastId = a.ArrivedGood.Id;
                                        if (lastId == 0)
                                            id = type * 10000 + 1;
                                        else
                                            id = lastId + 1;
                                        Console.Write("Введите дату поступления товара: ");
                                        firstDate = Convert.ToDateTime(Console.ReadLine());
                                        Console.Write("Введите название товара: ");
                                        name = Console.ReadLine();
                                        Console.Write("Введите дату изготовления товара: ");
                                        secondDate = Convert.ToDateTime(Console.ReadLine());
                                    }
                                    switch (type)
                                    {
                                        case 1:
                                            Console.Write("Введите срок годности (количество дней): ");
                                            expiration = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите калорийность продукта (ккал): ");
                                            caloricContent = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите вес товара (кг): ");
                                            weight = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (secondDate > firstDate || expiration <= 0 || caloricContent <= 0 || weight <= 0 || price <= 0)
                                                throw new WrongValueException();
                                            if ((firstDate - secondDate).Days > expiration)
                                                throw new ExpiredGoodsException();
                                            arrivedList.Add(new Arrived(firstDate, new Food(id, name, secondDate, expiration, caloricContent, weight, price)));
                                            Console.WriteLine("\nДанные о поступлении успешно добавлены! Код товара: " + id);
                                            availableList.Add(arrivedList[arrivedList.Count - 1]);
                                            Console.ReadKey();
                                            break;
                                        case 2:
                                            Console.Write("Введите срок годности (количество дней): ");
                                            expiration = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите калорийность продукта (ккал): ");
                                            caloricContent = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите ёмкость (л): ");
                                            weight = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("Укажите наличие красителей (y/n): ");
                                            dyesExistence = Console.ReadLine().ToLower().StartsWith("y");
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (secondDate > firstDate || expiration <= 0 || caloricContent <= 0 || weight <= 0 || price <= 0)
                                                throw new WrongValueException();
                                            if ((firstDate - secondDate).Days > expiration)
                                                throw new ExpiredGoodsException();
                                            arrivedList.Add(new Arrived(firstDate, new NonalcoholicDrinks(id, name, secondDate, expiration, caloricContent, weight, dyesExistence, price)));
                                            Console.WriteLine("\nДанные о поступлении успешно добавлены! Код товара: " + id);
                                            availableList.Add(arrivedList[arrivedList.Count - 1]);
                                            Console.ReadKey();
                                            break;
                                        case 3:
                                            Console.Write("Введите срок годности (количество дней): ");
                                            expiration = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите калорийность продукта (ккал): ");
                                            caloricContent = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите ёмкость (л): ");
                                            weight = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("Введите содержание спирта (% об.): ");
                                            alcoholContent = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите ограничение на возраст (лет): ");
                                            ageLimit = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (secondDate > firstDate || expiration <= 0 || caloricContent <= 0 || weight <= 0 || alcoholContent <= 0 || ageLimit < 18 || ageLimit > 22 || price <= 0)
                                                throw new WrongValueException();
                                            if ((firstDate - secondDate).Days > expiration)
                                                throw new ExpiredGoodsException();
                                            arrivedList.Add(new Arrived(firstDate, new AlcoholicDrink(id, name, secondDate, expiration, caloricContent, weight, alcoholContent, ageLimit, price)));
                                            Console.WriteLine("\nДанные о поступлении успешно добавлены! Код товара: " + id);
                                            availableList.Add(arrivedList[arrivedList.Count - 1]);
                                            Console.ReadKey();
                                            break;
                                        case 4:
                                            Console.Write("Введите инструкцию по применению товара: ");
                                            firstDescription = Console.ReadLine();
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (secondDate > firstDate || price <= 0)
                                                throw new WrongValueException();
                                            arrivedList.Add(new Arrived(firstDate, new SafeChemicals(id, name, secondDate, firstDescription, price)));
                                            Console.WriteLine("\nДанные о поступлении успешно добавлены! Код товара: " + id);
                                            availableList.Add(arrivedList[arrivedList.Count - 1]);
                                            Console.ReadKey();
                                            break;
                                        case 5:
                                            Console.Write("Введите инструкцию по применению товара: ");
                                            firstDescription = Console.ReadLine();
                                            Console.Write("Введите условия хранения товара: ");
                                            secondDescription = Console.ReadLine();
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (secondDate > firstDate || price <= 0)
                                                throw new WrongValueException();
                                            arrivedList.Add(new Arrived(firstDate, new FlammableChemicals(id, name, secondDate, firstDescription, secondDescription, price)));
                                            Console.WriteLine("\nДанные о поступлении успешно добавлены! Код товара: " + id);
                                            availableList.Add(arrivedList[arrivedList.Count - 1]);
                                            Console.ReadKey();
                                            break;
                                        case 6:
                                            Console.Write("Введите инструкцию по применению товара: ");
                                            firstDescription = Console.ReadLine();
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (secondDate > firstDate || price <= 0)
                                                throw new WrongValueException();
                                            arrivedList.Add(new Arrived(firstDate, new HouseGoods(id, name, secondDate, firstDescription, price)));
                                            Console.WriteLine("\nДанные о поступлении успешно добавлены! Код товара: " + id);
                                            availableList.Add(arrivedList[arrivedList.Count - 1]);
                                            Console.ReadKey();
                                            break;
                                        case 7:
                                            Console.Write("Введите материал, из которого изготовлен товар: ");
                                            firstDescription = Console.ReadLine();
                                            Console.Write("Введите производителя товара: ");
                                            secondDescription = Console.ReadLine();
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (secondDate > firstDate || price <= 0)
                                                throw new WrongValueException();
                                            arrivedList.Add(new Arrived(firstDate, new Dish(id, name, secondDate, firstDescription, secondDescription, price)));
                                            Console.WriteLine("\nДанные о поступлении успешно добавлены! Код товара: " + id);
                                            availableList.Add(arrivedList[arrivedList.Count - 1]);
                                            Console.ReadKey();
                                            break;
                                        case 8:
                                            Console.Write("Введите ограничение на возраст (лет): ");
                                            ageLimit = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите количество сигарет в пачке (шт.): ");
                                            count = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (secondDate > firstDate || ageLimit < 18 || ageLimit > 22 || count <= 1 || price <= 0)
                                                throw new WrongValueException();
                                            arrivedList.Add(new Arrived(firstDate, new TobaccoProduct(id, name, secondDate, ageLimit, count, price)));
                                            Console.WriteLine("\nДанные о поступлении успешно добавлены! Код товара: " + id);
                                            availableList.Add(arrivedList[arrivedList.Count - 1]);
                                            Console.ReadKey();
                                            break;
                                        case 9:
                                            break;
                                        default:
                                            Console.WriteLine("Нет такого пункта меню!");
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("\nОшибка при вводе!");
                                    Console.ReadKey();
                                }
                                catch (WrongValueException)
                                {
                                    Console.WriteLine("\nВведены неверные значения!");
                                    Console.ReadKey();
                                }
                                catch (ExpiredGoodsException)
                                {
                                    Console.WriteLine("\nИстёк срок годности!");
                                    Console.ReadKey();
                                }
                            }
                            while (type != 9);
                            availableList.Sort((a, b) => a.ArrivedGood.Id.CompareTo(b.ArrivedGood.Id));
                            break;
                        case 2:
                            Console.Write("Введите дату реализации товара: ");
                            firstDate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Введите код товара: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < availableList.Count; i++)
                                if (availableList[i].ArrivedGood.Id == id)
                                {
                                    if (firstDate < availableList[i].ArrivalDate)
                                        throw new WrongValueException();
                                    available = true;
                                    soldList.Add(new Sold(firstDate, availableList[i].ArrivedGood));
                                    availableList.RemoveAt(i);
                                }
                            if (!available)
                            {
                                foreach (ChargedOff c in chargedOffList)
                                    if (c.ChargedOffGood.Id == id)
                                    {
                                        if (c.ChargeOffReason == 1)
                                            throw new ExpiredGoodsException();
                                        else
                                            throw new DefectiveGoodsException();
                                    }
                                throw new NotAvailableException();
                            }
                            Console.WriteLine("\nДанные о реализации успешно добавлены!");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Write("Введите дату списания товара: ");
                            firstDate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Введите код товара: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Укажите причину списания (1 - истёк срок годности, 2 - бракованный товар): ");
                            type = Convert.ToInt32(Console.ReadLine());
                            if (type < 1 || type > 2)
                                throw new WrongValueException();
                            for (int i = 0; i < availableList.Count; i++)
                                if (availableList[i].ArrivedGood.Id == id)
                                {
                                    if (firstDate < availableList[i].ArrivalDate)
                                        throw new WrongValueException();
                                    available = true;
                                    chargedOffList.Add(new ChargedOff(firstDate, availableList[i].ArrivedGood, type));
                                    availableList.RemoveAt(i);
                                }
                            if (!available)
                            {
                                foreach (ChargedOff c in chargedOffList)
                                    if (c.ChargedOffGood.Id == id)
                                    {
                                        if (c.ChargeOffReason == 1)
                                            throw new ExpiredGoodsException();
                                        else
                                            throw new DefectiveGoodsException();
                                    }
                                throw new NotAvailableException();
                            }
                            Console.WriteLine("\nДанные о списании успешно добавлены!");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Write("Введите дату передачи товара: ");
                            firstDate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Введите код товара: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < availableList.Count; i++)
                                if (availableList[i].ArrivedGood.Id == id)
                                {
                                    if (firstDate < availableList[i].ArrivalDate)
                                        throw new WrongValueException();
                                    available = true;
                                    transferedList.Add(new Transfered(firstDate, availableList[i].ArrivedGood));
                                    availableList.RemoveAt(i);
                                }
                            if (!available)
                            {
                                foreach (ChargedOff c in chargedOffList)
                                    if (c.ChargedOffGood.Id == id)
                                    {
                                        if (c.ChargeOffReason == 1)
                                            throw new ExpiredGoodsException();
                                        else
                                            throw new DefectiveGoodsException();
                                    }
                                throw new NotAvailableException();
                            }
                            Console.WriteLine("\nДанные о передаче успешно добавлены!");
                            Console.ReadKey();
                            break;
                        case 5:
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Т И П Ы   О Т О Б Р А Ж Е Н И Я");
                                    Console.WriteLine("\n1 - Конкретный товар, имеющийся в наличии");
                                    Console.WriteLine("2 - Все товары, имеющиеся в наличии");
                                    Console.WriteLine("3 - Пришло за период");
                                    Console.WriteLine("4 - Реализовано за период");
                                    Console.WriteLine("5 - Списано за период");
                                    Console.WriteLine("6 - Передано за период");
                                    Console.WriteLine("7 - Выход в главное меню");
                                    Console.Write("\nВаш выбор: ");
                                    type = Convert.ToInt32(Console.ReadLine());
                                    available = false;
                                    Console.Clear();
                                    switch (type)
                                    {
                                        case 1:
                                            Console.Write("Введите код товара: ");
                                            id = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine();
                                            foreach (Arrived a in availableList)
                                                if (a.ArrivedGood.Id == id)
                                                {
                                                    available = true;
                                                    a.ArrivedGood.PrintDate(false);
                                                }
                                            if (!available)
                                                throw new NotAvailableException();
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            break;
                                        case 2:
                                            if (availableList.Count > 0)
                                                for (int i = 0; i < availableList.Count; i++)
                                                {
                                                    if (i != 0)
                                                        Console.WriteLine("\n");
                                                    availableList[i].ArrivedGood.PrintDate(true);
                                                }
                                            else
                                                throw new NotAvailableException();
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            break;
                                        case 3:
                                            Console.Write("Введите дату начала периода: ");
                                            firstDate = Convert.ToDateTime(Console.ReadLine());
                                            Console.Write("Введите дату окончания периода: ");
                                            secondDate = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine();
                                            if (firstDate > secondDate)
                                                throw new WrongValueException();
                                            for (int i = 0; i < arrivedList.Count; i++)
                                                if (arrivedList[i].ArrivalDate >= firstDate && arrivedList[i].ArrivalDate <= secondDate)
                                                {
                                                    if (available)
                                                        Console.WriteLine("\n");
                                                    available = true;
                                                    arrivedList[i].ArrivedGood.PrintDate(true);
                                                }
                                            if (!available)
                                                throw new NotAvailableException();
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            break;
                                        case 4:
                                            Console.Write("Введите дату начала периода: ");
                                            firstDate = Convert.ToDateTime(Console.ReadLine());
                                            Console.Write("Введите дату окончания периода: ");
                                            secondDate = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine();
                                            if (firstDate > secondDate)
                                                throw new WrongValueException();
                                            for (int i = 0; i < soldList.Count; i++)
                                                if (soldList[i].SaleDate >= firstDate && soldList[i].SaleDate <= secondDate)
                                                {
                                                    if (available)
                                                        Console.WriteLine("\n");
                                                    available = true;
                                                    soldList[i].SoldGood.PrintDate(true);
                                                }
                                            if (!available)
                                                throw new NotAvailableException();
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            break;
                                        case 5:
                                            Console.Write("Введите дату начала периода: ");
                                            firstDate = Convert.ToDateTime(Console.ReadLine());
                                            Console.Write("Введите дату окончания периода: ");
                                            secondDate = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine();
                                            if (firstDate > secondDate)
                                                throw new WrongValueException();
                                            for (int i = 0; i < chargedOffList.Count; i++)
                                                if (chargedOffList[i].ChargeOffDate >= firstDate && chargedOffList[i].ChargeOffDate <= secondDate)
                                                {
                                                    if (available)
                                                        Console.WriteLine("\n");
                                                    available = true;
                                                    chargedOffList[i].ChargedOffGood.PrintDate(true);
                                                }
                                            if (!available)
                                                throw new NotAvailableException();
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            break;
                                        case 6:
                                            Console.Write("Введите дату начала периода: ");
                                            firstDate = Convert.ToDateTime(Console.ReadLine());
                                            Console.Write("Введите дату окончания периода: ");
                                            secondDate = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine();
                                            if (firstDate > secondDate)
                                                throw new WrongValueException();
                                            for (int i = 0; i < transferedList.Count; i++)
                                                if (transferedList[i].TransferDate >= firstDate && transferedList[i].TransferDate <= secondDate)
                                                {
                                                    if (available)
                                                        Console.WriteLine("\n");
                                                    available = true;
                                                    transferedList[i].TransferedGood.PrintDate(true);
                                                }
                                            if (!available)
                                                throw new NotAvailableException();
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            break;
                                        case 7:
                                            break;
                                        default:
                                            Console.WriteLine("Нет такого пункта меню!");
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("\nОшибка при вводе!");
                                    Console.ReadKey();
                                }
                                catch (WrongValueException)
                                {
                                    Console.WriteLine("Введены неверные значения!");
                                    Console.ReadKey();
                                }
                                catch (NotAvailableException)
                                {
                                    Console.WriteLine("Нет в наличии!");
                                    Console.ReadKey();
                                }
                            }
                            while (type != 7);
                            break;
                        case 6:
                            Console.WriteLine("Работа завершена!");
                            break;
                        default:
                            Console.WriteLine("Нет такого пункта меню!");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nОшибка при вводе!");
                    Console.ReadKey();
                }
                catch (WrongValueException)
                {
                    Console.WriteLine("\nВведены неверные значения!");
                    Console.ReadKey();
                }
                catch (NotAvailableException)
                {
                    Console.WriteLine("\nНет в наличии данных!");
                    Console.ReadKey();
                }
                catch (ExpiredGoodsException)
                {
                    Console.WriteLine("\nИстёк срок годности!");
                    Console.ReadKey();
                }
                catch (DefectiveGoodsException)
                {
                    Console.WriteLine("\nБракованный товар!");
                    Console.ReadKey();
                }
            }
            while (itemNumber != 6);
            Console.ReadKey();
        }
    }
}