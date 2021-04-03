using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace isMerkeziSistemi.Entities
{
    public class Users
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }
        [BsonElement("username")]
        public string  Username
        {
            get;
            set;
        }

        [BsonElement("password")]
        public string Password
        {
            get;
            set;
        }

        [BsonElement("age")]
        public string Age
        {
            get;
            set;
        }

        [BsonElement("email")]
        public string Email
        {
            get;
            set;
        }


    }
}