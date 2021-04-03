using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace isMerkeziSistemi.Entities
{
    public class Category
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("categoryName")]
        public string CategoryName { get; set; }

        [BsonElement("aciklama")]
        public string Aciklama { get; set; }
    }
}