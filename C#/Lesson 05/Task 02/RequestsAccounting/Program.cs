using System;
using System.Collections.Generic;

namespace RequestsAccounting
{
    struct Article
    {
        private int articleId;
        private string articleName;
        private double articlePrice;
        private ArticleType articleType;
        public enum ArticleType { FOODS, CHEMICALS, APPLIANCES, DISHES }

        public Article(int articleId, string articleName, double articlePrice, ArticleType articleType)
        {
            this.articleId = articleId;
            this.articleName = articleName;
            this.articlePrice = articlePrice;
            this.articleType = articleType;
        }

        public int ArticleId
        {
            get { return articleId; }
        }

        public string ArticleName
        {
            get { return articleName; }
        }

        public double ArticlePrice
        {
            get { return articlePrice; }
        }

        public ArticleType ArticleTypeData
        {
            get { return articleType; }
        }
    }

    struct Client
    {
        private int clientId;
        private string clientName;
        private string clientAddress;
        private string clientTelephone;
        private int requestsCount;
        private double requestsSum;
        private ClientType clientType;

        public enum ClientType { high, middle, low }

        public Client(int clientId, string clientName, string clientAddress, string clientTelephone, ClientType clientType)
        {
            this.clientId = clientId;
            this.clientName = clientName;
            this.clientAddress = clientAddress;
            this.clientTelephone = clientTelephone;
            this.clientType = clientType;
            requestsCount = 0;
            requestsSum = 0;
        }

        public int ClientId
        {
            get { return clientId; }
        }

        public string ClientName
        {
            get { return clientName; }
        }

        public string ClientAddress
        {
            get { return clientAddress; }
        }

        public string ClientTelephone
        {
            get { return clientTelephone; }
        }

        public ClientType ClientTypeData
        {
            get { return clientType; }
        }

        public int GetRequestsCount(List<Request> request)
        {
            requestsCount = 0;
            foreach (Request r in request)
                if (r.ClientData.clientId == clientId)
                    requestsCount++;
            return requestsCount;
        }

        public double GetRequestsSum(List<Request> request)
        {
            requestsSum = 0;
            foreach (Request r in request)
                if (r.ClientData.clientId == clientId)
                    requestsSum += r.RequestSum;
            return requestsSum;
        }
    }

    struct RequestItem
    {
        private Article article;
        private int articleCount;

        public RequestItem(Article article, int articleCount)
        {
            this.article = article;
            this.articleCount = articleCount;
        }

        public Article ArticleData
        {
            get { return article; }
        }

        public int ArticleCount
        {
            get { return articleCount; }
        }
    }

    struct Request
    {
        private int requestId;
        private Client client;
        private DateTime requestDate;
        private List<RequestItem> requestItemsList;
        private double requestSum;
        private PayType payType;

        public enum PayType { cash, card }

        public Request(int requestId, Client client, DateTime requestDate, List<RequestItem> requestItemsList, PayType payType)
        {
            this.requestId = requestId;
            this.client = client;
            this.requestDate = requestDate;
            this.requestItemsList = requestItemsList;
            this.payType = payType;
            requestSum = 0;
        }

        public int RequestId
        {
            get { return requestId; }
        }

        public Client ClientData
        {
            get { return client; }
        }

        public DateTime RequestDate
        {
            get { return requestDate; }
        }

        public List<RequestItem> RequestItemsList
        {
            get { return requestItemsList; }
        }

        public PayType PayTypeData
        {
            get { return payType; }
        }

        public double RequestSum
        {
            get
            {
                requestSum = 0;
                foreach (RequestItem r in requestItemsList)
                    requestSum += r.ArticleData.ArticlePrice * r.ArticleCount;
                return requestSum;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int itemNumber = 0, type, articleId = 0, clientId = 0, requestId = 0, requiredFirstId, requiredSecondId, requiredThirdId, enumInt, articleCount;
            string name = null, address, telephone;
            double price;
            bool stopEnter = true;
            Article.ArticleType articleType;
            Client.ClientType clientType;
            Request.PayType payType;
            DateTime requestDate;
            List<Article> articlesList = new List<Article>();
            List<Client> clientsList = new List<Client>();
            List<RequestItem> requestItemsList;
            List<Request> requestsList = new List<Request>();
            bool hasFirstId, hasSecondId;
            Console.Title = "Учёт заказов клиентов";
            Console.BufferWidth = 125;
            Console.SetWindowSize(125, 40);
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Г Л А В Н О Е   М Е Н Ю");
                    Console.WriteLine("\n1 - Добавить");
                    Console.WriteLine("2 - Редактировать");
                    Console.WriteLine("3 - Удалить");
                    Console.WriteLine("4 - Распечатать");
                    Console.WriteLine("5 - Выход");
                    Console.Write("\nВаш выбор: ");
                    itemNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (itemNumber)
                    {
                        case 1:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Т И П Ы   Д А Н Н Ы Х");
                                Console.WriteLine("\n1 - Товары");
                                Console.WriteLine("2 - Клиенты");
                                Console.WriteLine("3 - Заказы");
                                Console.WriteLine("4 - Выход в главное меню");
                                Console.Write("\nВаш выбор: ");
                                type = Convert.ToInt32(Console.ReadLine());
                                if (type != 4)
                                    Console.Clear();
                                switch (type)
                                {
                                    case 1:
                                        try
                                        {
                                            Console.Write("Введите название товара: ");
                                            name = Console.ReadLine();
                                            if (name.Length > 25)
                                                name = name.Remove(25);
                                            Console.Write("Введите цену товара (грн.): ");
                                            price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                            if (price <= 0 || price.ToString().Length > 10)
                                                throw new WrongValueException();
                                            Console.Write("Укажите тип товара (1 - продукты питания, 2 - бытовая химия, 3 - бытовая техника, 4 - посуда): ");
                                            enumInt = Convert.ToInt32(Console.ReadLine());
                                            switch (enumInt)
                                            {
                                                case 1:
                                                    articleType = Article.ArticleType.FOODS;
                                                    break;
                                                case 2:
                                                    articleType = Article.ArticleType.CHEMICALS;
                                                    break;
                                                case 3:
                                                    articleType = Article.ArticleType.APPLIANCES;
                                                    break;
                                                case 4:
                                                    articleType = Article.ArticleType.DISHES;
                                                    break;
                                                default:
                                                    throw new WrongValueException();
                                            }
                                            articleId++;
                                            articlesList.Add(new Article(articleId, name, price, articleType));
                                            Console.WriteLine("\nДанные о наличии товара успешно добавлены! Код товара: " + articleId);
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (WrongValueException)
                                        {
                                            Console.WriteLine("\nДанные введены неверно!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        try
                                        {
                                            Console.Write("Введите ФИО клиента: ");
                                            name = Console.ReadLine();
                                            if (name.Length > 30)
                                                name = name.Remove(30);
                                            Console.Write("Введите адрес клиента: ");
                                            address = Console.ReadLine();
                                            if (address.Length > 30)
                                                address = address.Remove(30);
                                            Console.Write("Введите телефон клиента: ");
                                            telephone = Console.ReadLine();
                                            Console.Write("Укажите важность клиента (1 - высокая, 2 - средняя, 3 - низкая): ");
                                            enumInt = Convert.ToInt32(Console.ReadLine());
                                            if (enumInt == 1)
                                                clientType = Client.ClientType.high;
                                            else
                                                if (enumInt == 2)
                                                clientType = Client.ClientType.middle;
                                            else
                                                    if (enumInt == 3)
                                                clientType = Client.ClientType.low;
                                            else
                                                throw new WrongValueException();
                                            if (telephone.Length > 15)
                                                telephone = telephone.Remove(15);
                                            clientId++;
                                            clientsList.Add(new Client(clientId, name, address, telephone, clientType));
                                            Console.WriteLine("\nДанные о новом клиенте успешно добавлены! Код клиента: " + clientId);
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (WrongValueException)
                                        {
                                            Console.WriteLine("\nВажность клиента указана неверно!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        try
                                        {
                                            hasFirstId = false;
                                            requestItemsList = new List<RequestItem>();
                                            Console.Write("Введите код клиента: ");
                                            requiredFirstId = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < clientsList.Count; i++)
                                                if (clientsList[i].ClientId == requiredFirstId)
                                                {
                                                    hasFirstId = true;
                                                    requiredFirstId = i;
                                                    break;
                                                }
                                            if (!hasFirstId)
                                                throw new DataNotFoundException();
                                            Console.Write("Введите дату заказа: ");
                                            requestDate = Convert.ToDateTime(Console.ReadLine());
                                            do
                                            {
                                                try
                                                {
                                                    hasFirstId = false;
                                                    Console.Write("\nВведите код товара: ");
                                                    requiredSecondId = Convert.ToInt32(Console.ReadLine());
                                                    for (int i = 0; i < articlesList.Count; i++)
                                                        if (articlesList[i].ArticleId == requiredSecondId)
                                                        {
                                                            hasFirstId = true;
                                                            requiredSecondId = i;
                                                            break;
                                                        }
                                                    if (!hasFirstId)
                                                        throw new DataNotFoundException();
                                                    Console.Write("Введите количество единиц товара: ");
                                                    articleCount = Convert.ToInt32(Console.ReadLine());
                                                    if (articleCount < 0 || articleCount > 1000)
                                                        throw new WrongValueException();
                                                    requestItemsList.Add(new RequestItem(articlesList[requiredSecondId], articleCount));
                                                    Console.Write("Добавить в заказ ещё товары (y/n)? ");
                                                    stopEnter = Console.ReadLine().ToLower().StartsWith("n");
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("\nОшибка при вводе!");
                                                }
                                                catch (DataNotFoundException)
                                                {
                                                    Console.WriteLine("\nТовар не найден!");
                                                    Console.Write("Добавить в заказ ещё товары (y/n)? ");
                                                    stopEnter = Console.ReadLine().ToLower().StartsWith("n");
                                                }
                                                catch (WrongValueException)
                                                {
                                                    Console.WriteLine("\nКоличество товара введено неверно!");
                                                }
                                            }
                                            while (!stopEnter);
                                            if (requestItemsList.Count > 0)
                                            {
                                                Console.Write("\nУкажите форму оплаты клиентом заказа (1 - наличными, 2 - по карте): ");
                                                enumInt = Convert.ToInt32(Console.ReadLine());
                                                if (enumInt == 1)
                                                    payType = Request.PayType.cash;
                                                else
                                                    if (enumInt == 2)
                                                    payType = Request.PayType.card;
                                                else
                                                    throw new WrongValueException();
                                                requestId++;
                                                requestsList.Add(new Request(requestId, clientsList[requiredFirstId], requestDate, requestItemsList, payType));
                                                Console.WriteLine("\nЗаказ успешно сформирован! Код заказа: " + requestId);
                                            }
                                            else
                                                Console.WriteLine("\nЗаказ не сформирован!");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (DataNotFoundException)
                                        {
                                            Console.WriteLine("\nКлиент не найден!");
                                        }
                                        catch (WrongValueException)
                                        {
                                            Console.WriteLine("\nФорма оплаты указана неверно!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("Нет такого пункта меню!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            while (type != 4);
                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Т И П Ы   Д А Н Н Ы Х");
                                Console.WriteLine("\n1 - Товары");
                                Console.WriteLine("2 - Клиенты");
                                Console.WriteLine("3 - Заказы");
                                Console.WriteLine("4 - Выход в главное меню");
                                Console.Write("\nВаш выбор: ");
                                type = Convert.ToInt32(Console.ReadLine());
                                if (type != 4)
                                    Console.Clear();
                                switch (type)
                                {
                                    case 1:
                                        try
                                        {
                                            hasFirstId = false;
                                            Console.Write("Введите код товара: ");
                                            requiredFirstId = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < articlesList.Count; i++)
                                                if (articlesList[i].ArticleId == requiredFirstId)
                                                {
                                                    hasFirstId = true;
                                                    Console.Write("\nВведите название товара: ");
                                                    name = Console.ReadLine();
                                                    if (name.Length > 25)
                                                        name = name.Remove(25);
                                                    Console.Write("Введите цену товара (грн.): ");
                                                    price = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                                    if (price <= 0 || price.ToString().Length > 10)
                                                        throw new WrongValueException();
                                                    Console.Write("Укажите тип товара (1 - продукты питания, 2 - бытовая химия, 3 - бытовая техника, 4 - посуда): ");
                                                    enumInt = Convert.ToInt32(Console.ReadLine());
                                                    switch (enumInt)
                                                    {
                                                        case 1:
                                                            articleType = Article.ArticleType.FOODS;
                                                            break;
                                                        case 2:
                                                            articleType = Article.ArticleType.CHEMICALS;
                                                            break;
                                                        case 3:
                                                            articleType = Article.ArticleType.APPLIANCES;
                                                            break;
                                                        case 4:
                                                            articleType = Article.ArticleType.DISHES;
                                                            break;
                                                        default:
                                                            throw new WrongValueException();
                                                    }
                                                    articlesList[i] = new Article(articlesList[i].ArticleId, name, price, articleType);
                                                }
                                            if (!hasFirstId)
                                                throw new DataNotFoundException();
                                            Console.WriteLine("\nДанные о товаре успешно изменены!");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (DataNotFoundException)
                                        {
                                            Console.WriteLine("\nТовар не найден!");
                                        }
                                        catch (WrongValueException)
                                        {
                                            Console.WriteLine("\nЦена товара введена неверно!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        try
                                        {
                                            hasFirstId = false;
                                            Console.Write("Введите код клиента: ");
                                            requiredFirstId = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < clientsList.Count; i++)
                                                if (clientsList[i].ClientId == requiredFirstId)
                                                {
                                                    hasFirstId = true;
                                                    Console.Write("\nВведите ФИО клиента: ");
                                                    name = Console.ReadLine();
                                                    if (name.Length > 30)
                                                        name = name.Remove(30);
                                                    Console.Write("Введите адрес клиента: ");
                                                    address = Console.ReadLine();
                                                    if (address.Length > 30)
                                                        address = address.Remove(30);
                                                    Console.Write("Введите телефон клиента: ");
                                                    telephone = Console.ReadLine();
                                                    Console.Write("Укажите важность клиента (1 - высокая, 2 - средняя, 3 - низкая): ");
                                                    enumInt = Convert.ToInt32(Console.ReadLine());
                                                    if (enumInt == 1)
                                                        clientType = Client.ClientType.high;
                                                    else
                                                        if (enumInt == 2)
                                                        clientType = Client.ClientType.middle;
                                                    else
                                                            if (enumInt == 3)
                                                        clientType = Client.ClientType.low;
                                                    else
                                                        throw new WrongValueException();
                                                    if (telephone.Length > 15)
                                                        telephone = telephone.Remove(15);
                                                    clientsList[i] = new Client(clientsList[i].ClientId, name, address, telephone, clientType);
                                                }
                                            if (!hasFirstId)
                                                throw new DataNotFoundException();
                                            Console.WriteLine("\nДанные о клиента успешно изменены!");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (DataNotFoundException)
                                        {
                                            Console.WriteLine("\nКлиент не найден!");
                                        }
                                        catch (WrongValueException)
                                        {
                                            Console.WriteLine("\nВажность клиента указана неверно!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        try
                                        {
                                            hasFirstId = false;
                                            Console.Write("Введите код заказа: ");
                                            requiredFirstId = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < requestsList.Count; i++)
                                                if (requestsList[i].RequestId == requiredFirstId)
                                                {
                                                    hasFirstId = true;
                                                    hasSecondId = false;
                                                    requestItemsList = new List<RequestItem>();
                                                    Console.Write("\nВведите код клиента: ");
                                                    requiredSecondId = Convert.ToInt32(Console.ReadLine());
                                                    for (int j = 0; j < clientsList.Count; j++)
                                                        if (clientsList[j].ClientId == requiredSecondId)
                                                        {
                                                            hasSecondId = true;
                                                            requiredSecondId = j;
                                                            break;
                                                        }
                                                    if (!hasSecondId)
                                                        throw new DataNotFoundException();
                                                    Console.Write("Введите дату заказа: ");
                                                    requestDate = Convert.ToDateTime(Console.ReadLine());
                                                    do
                                                    {
                                                        try
                                                        {
                                                            hasSecondId = false;
                                                            Console.Write("\nВведите код товара: ");
                                                            requiredThirdId = Convert.ToInt32(Console.ReadLine());
                                                            for (int j = 0; j < articlesList.Count; j++)
                                                                if (articlesList[j].ArticleId == requiredThirdId)
                                                                {
                                                                    hasSecondId = true;
                                                                    requiredThirdId = j;
                                                                    break;
                                                                }
                                                            if (!hasSecondId)
                                                                throw new DataNotFoundException();
                                                            Console.Write("Введите количество единиц товара: ");
                                                            articleCount = Convert.ToInt32(Console.ReadLine());
                                                            if (articleCount < 0 || articleCount > 1000)
                                                                throw new WrongValueException();
                                                            requestItemsList.Add(new RequestItem(articlesList[requiredThirdId], articleCount));
                                                            Console.Write("Добавить в заказ ещё товары (y/n)? ");
                                                            stopEnter = Console.ReadLine().ToLower().StartsWith("n");
                                                        }
                                                        catch (FormatException)
                                                        {
                                                            Console.WriteLine("\nОшибка при вводе!");
                                                        }
                                                        catch (DataNotFoundException)
                                                        {
                                                            Console.WriteLine("\nТовар не найден!");
                                                            Console.Write("Добавить в заказ ещё товары (y/n)? ");
                                                            stopEnter = Console.ReadLine().ToLower().StartsWith("n");
                                                        }
                                                        catch (WrongValueException)
                                                        {
                                                            Console.WriteLine("\nКоличество товара введено неверно!");
                                                        }
                                                    }
                                                    while (!stopEnter);
                                                    if (requestItemsList.Count > 0)
                                                    {
                                                        Console.Write("\nУкажите форму оплаты клиентом заказа (1 - наличными, 2 - по карте): ");
                                                        enumInt = Convert.ToInt32(Console.ReadLine());
                                                        if (enumInt == 1)
                                                            payType = Request.PayType.cash;
                                                        else
                                                            if (enumInt == 2)
                                                            payType = Request.PayType.card;
                                                        else
                                                            throw new WrongValueException();
                                                        requestsList[i] = new Request(requestId, clientsList[requiredSecondId], requestDate, requestItemsList, payType);
                                                        Console.WriteLine("\nДанные о заказе успешно изменены!");
                                                    }
                                                    else
                                                        Console.WriteLine("\nЗаказ не изменён!");
                                                }
                                            if (!hasFirstId)
                                                throw new DataNotFoundException();
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (DataNotFoundException)
                                        {
                                            Console.WriteLine("\nДанные не найдены!");
                                        }
                                        catch (WrongValueException)
                                        {
                                            Console.WriteLine("\nФорма оплаты указана неверно!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("Нет такого пункта меню!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            while (type != 4);
                            break;
                        case 3:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Т И П Ы   Д А Н Н Ы Х");
                                Console.WriteLine("\n1 - Товары");
                                Console.WriteLine("2 - Клиенты");
                                Console.WriteLine("3 - Заказы");
                                Console.WriteLine("4 - Выход в главное меню");
                                Console.Write("\nВаш выбор: ");
                                type = Convert.ToInt32(Console.ReadLine());
                                if (type != 4)
                                    Console.Clear();
                                switch (type)
                                {
                                    case 1:
                                        try
                                        {
                                            hasFirstId = false;
                                            Console.Write("Введите код товара: ");
                                            requiredFirstId = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < articlesList.Count; i++)
                                                if (articlesList[i].ArticleId == requiredFirstId)
                                                {
                                                    hasFirstId = true;
                                                    articlesList.RemoveAt(i);
                                                    break;
                                                }
                                            if (!hasFirstId)
                                                throw new DataNotFoundException();
                                            Console.WriteLine("\nТовар успешно удалён!");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (DataNotFoundException)
                                        {
                                            Console.WriteLine("\nТовар не найден!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        try
                                        {
                                            hasFirstId = false;
                                            Console.Write("Введите код клиента: ");
                                            requiredFirstId = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < clientsList.Count; i++)
                                                if (clientsList[i].ClientId == requiredFirstId)
                                                {
                                                    hasFirstId = true;
                                                    clientsList.RemoveAt(i);
                                                    break;
                                                }
                                            if (!hasFirstId)
                                                throw new DataNotFoundException();
                                            Console.WriteLine("\nКлиент успешно удалён!");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (DataNotFoundException)
                                        {
                                            Console.WriteLine("\nКлиент не найден!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        try
                                        {
                                            hasFirstId = false;
                                            Console.Write("Введите код заказа: ");
                                            requiredFirstId = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < requestsList.Count; i++)
                                                if (requestsList[i].RequestId == requiredFirstId)
                                                {
                                                    hasFirstId = true;
                                                    requestsList.RemoveAt(i);
                                                    break;
                                                }
                                            if (!hasFirstId)
                                                throw new DataNotFoundException();
                                            Console.WriteLine("\nЗаказ успешно удалён!");
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\nОшибка при вводе!");
                                        }
                                        catch (DataNotFoundException)
                                        {
                                            Console.WriteLine("\nЗаказ не найден!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("Нет такого пункта меню!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            while (type != 4);
                            break;
                        case 4:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Т И П Ы   Д А Н Н Ы Х");
                                Console.WriteLine("\n1 - Товары");
                                Console.WriteLine("2 - Клиенты");
                                Console.WriteLine("3 - Заказы");
                                Console.WriteLine("4 - Выход в главное меню");
                                Console.Write("\nВаш выбор: ");
                                type = Convert.ToInt32(Console.ReadLine());
                                if (type != 4)
                                    Console.Clear();
                                switch (type)
                                {
                                    case 1:
                                        if (articlesList.Count > 0)
                                        {
                                            Console.Write("\u250C");
                                            for (int i = 0; i < 10; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 25; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 18; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 16; i++) Console.Write("\u2500");
                                                Console.Write("\u2510\n");
                                            Console.WriteLine("\u2502Код товара\u2502     Название товара     \u2502Цена товара (грн.)\u2502   Тип товара   \u2502");
                                            foreach (Article a in articlesList)
                                            {
                                                Console.Write("\u251C");
                                                for (int i = 0; i < 10; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 25; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 18; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 16; i++) Console.Write("\u2500");
                                                    Console.Write("\u2524\n");
                                                switch (a.ArticleTypeData)
                                                {
                                                    case Article.ArticleType.FOODS:
                                                        name = "Продукты питания";
                                                        break;
                                                    case Article.ArticleType.CHEMICALS:
                                                        name = "Бытовая химия";
                                                        break;
                                                    case Article.ArticleType.APPLIANCES:
                                                        name = "Бытовая техника";
                                                        break;
                                                    case Article.ArticleType.DISHES:
                                                        name = "Посуда";
                                                        break;
                                                }
                                                Console.WriteLine("\u2502{0, 10}\u2502{1, -25}\u2502{2, 18}\u2502{3, -16}\u2502", a.ArticleId, a.ArticleName, a.ArticlePrice, name);
                                            }
                                            Console.Write("\u2514");
                                            for (int i = 0; i < 10; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 25; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 18; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 16; i++) Console.Write("\u2500");
                                                Console.Write("\u2518\n");
                                        }
                                        else
                                            Console.WriteLine("Данных нет!");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        if (clientsList.Count > 0)
                                        {
                                            Console.Write("\u250C");
                                            for (int i = 0; i < 7; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 15; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 10; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 14; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 8; i++) Console.Write("\u2500");
                                                Console.Write("\u2510\n");
                                            Console.WriteLine("\u2502  Код  \u2502         ФИО клиента          \u2502         Адрес клиента        \u2502Телефон клиента\u2502Количество\u2502 Общая сумма  \u2502Важность\u2502");
                                            Console.WriteLine("\u2502клиента\u2502                              \u2502                              \u2502               \u2502  заказов \u2502заказов (грн.)\u2502клиента \u2502");
                                            foreach (Client c in clientsList)
                                            {
                                                Console.Write("\u251C");
                                                for (int i = 0; i < 7; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 15; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 10; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 14; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 8; i++) Console.Write("\u2500");
                                                    Console.Write("\u2524\n");
                                                if (c.ClientTypeData == Client.ClientType.high)
                                                    name = "Высокая";
                                                else
                                                    if (c.ClientTypeData == Client.ClientType.middle)
                                                    name = "Средняя";
                                                else
                                                    name = "Низкая";
                                                Console.WriteLine("\u2502{0, 7}\u2502{1, -30}\u2502{2, -30}\u2502{3, -15}\u2502{4, 10}\u2502{5, 14}\u2502{6, -8}\u2502", c.ClientId, c.ClientName, c.ClientAddress, c.ClientTelephone, c.GetRequestsCount(requestsList), c.GetRequestsSum(requestsList), name);
                                            }
                                            Console.Write("\u2514");
                                            for (int i = 0; i < 7; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 15; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 10; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 14; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 8; i++) Console.Write("\u2500");
                                                Console.Write("\u2518\n");
                                        }
                                        else
                                            Console.WriteLine("Данных нет!");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        if (requestsList.Count > 0)
                                        {
                                            Console.Write("\u250C");
                                            for (int i = 0; i < 6; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 11; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 25; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 17; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 12; i++) Console.Write("\u2500");
                                                Console.Write("\u252C");
                                            for (int i = 0; i < 12; i++) Console.Write("\u2500");
                                                Console.Write("\u2510\n");
                                            Console.WriteLine("\u2502 Код  \u2502         ФИО клиента          \u2502Дата заказа\u2502   Перечень заказанных   \u2502Количество единиц\u2502Сумма заказа\u2502Форма оплаты\u2502");
                                            Console.WriteLine("\u2502заказа\u2502                              \u2502           \u2502         товаров         \u2502     товара      \u2502   (грн.)   \u2502            \u2502");
                                            foreach (Request r in requestsList)
                                            {
                                                Console.Write("\u251C");
                                                for (int i = 0; i < 6; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 11; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 25; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 17; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 12; i++) Console.Write("\u2500");
                                                    Console.Write("\u253C");
                                                for (int i = 0; i < 12; i++) Console.Write("\u2500");
                                                    Console.Write("\u2524\n");
                                                if (r.PayTypeData == Request.PayType.cash)
                                                    name = "Наличными";
                                                else
                                                    name = "По карте";
                                                for (int i = 0; i < r.RequestItemsList.Count; i++)
                                                    if (i == 0)
                                                        Console.WriteLine("\u2502{0, 6}\u2502{1, -30}\u2502 {2:d}\u2502{3, -25}\u2502{4, 17}\u2502{5, 12}\u2502{6, -12}\u2502", r.RequestId, r.ClientData.ClientName, r.RequestDate, r.RequestItemsList[i].ArticleData.ArticleName, r.RequestItemsList[i].ArticleCount, r.RequestSum, name);
                                                    else
                                                        Console.WriteLine("\u2502      \u2502                              \u2502           \u2502{0, -25}\u2502{1, 17}\u2502            \u2502            \u2502", r.RequestItemsList[i].ArticleData.ArticleName, r.RequestItemsList[i].ArticleCount);
                                            }
                                            Console.Write("\u2514");
                                            for (int i = 0; i < 6; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 30; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 11; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 25; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 17; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 12; i++) Console.Write("\u2500");
                                                Console.Write("\u2534");
                                            for (int i = 0; i < 12; i++) Console.Write("\u2500");
                                                Console.Write("\u2518\n");
                                        }
                                        else
                                            Console.WriteLine("Данных нет!");
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("Нет такого пункта меню!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            while (type != 4);
                            break;
                        case 5:
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
            }
            while (itemNumber != 5);
            Console.ReadKey();
        }
    }
}