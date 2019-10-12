using System.Collections.Generic;
using MongoDB.Bson;

namespace MultithreadedParser
{
    class Item
    {
        public ObjectId Id { get; set; }
        public string ItemHeader { get; set; }
        public string ItemImage { get; set; }
        public string ItemPrice { get; set; }
        public Dictionary<string, string> ItemProperties { get; set; }
    }
}