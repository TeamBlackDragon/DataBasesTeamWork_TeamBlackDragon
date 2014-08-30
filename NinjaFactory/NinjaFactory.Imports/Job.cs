namespace NinjaFactory.Imports
{
    using System;
    using MongoDB.Bson;

    public class Job
    {
        public ObjectId Id { get; set; }

        public string Description { get; set; }

        public int Score { get; set; }
    }
}
