namespace NinjaFactory.Imports
{
    using System;
    using System.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class MongoDBImport
    {
        //================================================================================================
        //                                      HOW TO USE EXAMPLE
        //================================================================================================

        //var db = GetMongoDatabase(ConfigurationManager.ConnectionStrings["NinjaFactoryMongoDB"].ConnectionString);

        //var ninjaJobsCollection = db.GetCollection("jobs");
            
        ////Get all the records in the collection
        //GetAllRecordsInCollection(ninjaJobsCollection);

        ////Adding new entity to the collection
        //AddNewEntityToCollection(ninjaJobsCollection, new Job { Description = "Kill your boss", Score = 43 });

        ////Editing a entity
        //var topPersonQuery = Query<Job>.EQ(e => e.Score, 100);
        //var updateTopPerson = Update<Job>.Set(e => e.Score, 43);
        //ninjaJobsCollection.Update(topPersonQuery, updateTopPerson);

        ////Removing entity
        ////var query = Query<Entity>.EQ(e => e.Id, id);
        ////personsCollection.Remove(query);

        ////Export the collection to MSSQL
        //ExportCollectionToMSSQLServer(ninjaJobsCollection);

        //================================================================================================
        //                                      HOW TO USE EXAMPLE
        //================================================================================================

        private static void AddNewEntityToCollection(MongoCollection<BsonDocument> collection, Job newEntity)
        {
            var entity = newEntity;
            collection.Insert(entity);

            //Edit the entity
            //newJob.Description = "Kill yourself";
            //collection.Save(newJob);
        }
  
        private static void GetAllRecordsInCollection(MongoCollection<BsonDocument> collection)
        {
            var jobs = collection.FindAll();

            foreach (var job in jobs)
            {
                Console.WriteLine(job["Description"]);
            }
        }

        static MongoDatabase GetMongoDatabase(string connectionString)
        {
            return new MongoClient(connectionString).GetServer().GetDatabase("NinjasFactoryDB");
        }

        private static void ExportCollectionToMSSQLServer(MongoCollection<BsonDocument> collection)
        {
            throw new NotImplementedException();
        }
    }
}
