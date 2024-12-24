using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Bootcamp_601.Services
{
    public class MongoDBConnection
    {
        private IMongoDatabase _database;
        public MongoDBConnection()
        {
            var client = new MongoClient("");
        }
    }
}
