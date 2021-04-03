using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using isMerkeziSistemi.Entities;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
namespace isMerkeziSistemi.Models
{
    public class CategoryModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Category> categoryCollection;

        public CategoryModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            categoryCollection = db.GetCollection<Category>("category");

        }

        public List<Category> findAll()
        {
            return categoryCollection.AsQueryable<Category>().ToList();

        }

        public Category find(string id)
        {
            var categoryId = new ObjectId(id);
            return categoryCollection.AsQueryable<Category>().SingleOrDefault(a => a.Id ==categoryId);



        }

        public void create(Category category)
        {
            categoryCollection.InsertOne(category);

        }

        public void update(Category category)
        {
            categoryCollection.UpdateOne(
                Builders<Category>.Filter.Eq("_id", category.Id),
                Builders<Category>.Update
                .Set("categoryName", category.CategoryName)
                .Set("aciklama", category.Aciklama)
                );

        }

        public void delete(string id)
        {
            categoryCollection.DeleteOne(Builders<Category>.Filter.Eq("_id",
                ObjectId.Parse(id)));
        }
    }
}
