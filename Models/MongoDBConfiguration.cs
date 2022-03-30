using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace kcms_challenge_dev_backend.Models
{
    public class MongoDBConfiguration
    {
        public IMongoDatabase DB { get; }
        private string DBUsername;
        private string DBPassword;
        private string DBName;

        public MongoDBConfiguration(IConfiguration configuration)
        {
            try
            {
                DBUsername = configuration["DBUsername"];
                DBPassword = configuration["DBPassword"];
                DBName = configuration["DBName"];

                var connectionString = $"mongodb+srv://{DBUsername}:{DBPassword}@dev-challenge.guviu.mongodb.net/{DBName}?retryWrites=true&w=majority";
                var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(DBName);
            }
            catch (Exception ex)
            {
                throw new MongoException("An error ocurred while trying to connect to MongoDB", ex);
            }
        }
    }
}
