using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using isMerkeziSistemi.Entities;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace isMerkeziSistemi.Models
{
    public class UsersModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Users> usersCollection;

        public UsersModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            usersCollection = db.GetCollection<Users>("users");

        }
        public List<Users> findAll()
        {
            return usersCollection.AsQueryable<Users>().ToList();

        }

        public Users find(string id)
        {
            var usersId = new ObjectId(id);
            return usersCollection.AsQueryable<Users>().SingleOrDefault(a => a.Id ==
            usersId);



        }

        public void create(Users users)
        {
            usersCollection.InsertOne(users);

        }

        public void update(Users users)
        {
            usersCollection.UpdateOne(
                Builders<Users>.Filter.Eq("_id", users.Id),
                Builders<Users>.Update
                .Set("username", users.Username)
                .Set("password", users.Password)
                .Set("email", users.Email)
                .Set("age", users.Age)


                );

        }

        public void delete(string id)
        {
            usersCollection.DeleteOne(Builders<Users>.Filter.Eq("_id",
                ObjectId.Parse(id)));
        }
    }
}