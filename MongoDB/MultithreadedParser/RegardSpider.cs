using System.Collections.Generic;
using System.Configuration;
using HtmlAgilityPack;
using MongoDB.Driver;
using ZennoSpider;

namespace MultithreadedParser
{
    class RegardSpider : Spider
    {
        private string site = "http://www.regard.ru";
        private string connection = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private IMongoCollection<Item> collection;

        public RegardSpider(int threadsCount) : base(threadsCount)
        {
            string collectionName = "phones";
            MongoClient client = new MongoClient(connection);
            IMongoDatabase database = client.GetDatabase("catalog");
            database.DropCollection(collectionName);
            collection = database.GetCollection<Item>(collectionName);
        }

        protected override void Initialize()
        {
            AddTask(site + "/catalog/group52000.htm", CategoryParser);
        }

        private void CategoryParser(HtmlDocument document)
        {
            int count;
            var node = document.DocumentNode.SelectSingleNode("//div[@class='pagination']/a[last()]");
            if (node != null)
            {
                count = int.Parse(node.InnerText);
                for (int i = 1; i <= count; i++)
                    AddTask(string.Format(site + "/catalog/group52000/page{0}.htm", i), CategoryPageParser);
            }
        }

        private void CategoryPageParser(HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes("//div[@id='hits']//a[@class='header' and contains(@href, '/catalog/tovar')]");
            foreach (var node in nodes)
                AddTask(site + node.Attributes["href"].Value, ItemParser);
        }

        private void ItemParser(HtmlDocument document)
        {
            string itemHeader = document.DocumentNode.SelectSingleNode("//h1[@id='goods_head']").InnerText;
            string itemPrice = document.DocumentNode.SelectSingleNode("//div[@class='price_block']//meta[@itemprop='price']").Attributes["content"].Value;
            string imgUrl, propertyName, propertyValue;
            Dictionary<string, string> itemProperties;
            HtmlNodeCollection nodes;
            Item itemData;
            HtmlNode imgNode = document.DocumentNode.SelectSingleNode("//img[@id='big_preview_1']");
            if (imgNode != null)
            {
                imgUrl = site + imgNode.Attributes["src"].Value;
                itemProperties = new Dictionary<string, string>();
                nodes = document.DocumentNode.SelectNodes("//div[@id='tabs-1']//tr[not(@class)]");
                foreach (var node in nodes)
                {
                    propertyName = node.SelectSingleNode("./td").InnerText.Trim().Replace(".", " ");
                    propertyValue = node.SelectSingleNode("./td[2]").InnerText.Trim();
                    itemProperties[propertyName] = propertyValue;
                }
                itemData = new Item { ItemHeader = itemHeader, ItemPrice = itemPrice, ItemImage = imgUrl, ItemProperties = itemProperties };
                collection.InsertOneAsync(itemData);
            }
        }

        public List<Item> GetData(string text)
        {
            return collection.Find(f => f.ItemHeader.ToLower().Contains(text.ToLower())).ToList();
        }
    }
}