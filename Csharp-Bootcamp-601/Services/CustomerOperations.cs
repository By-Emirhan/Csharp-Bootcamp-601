using Csharp_Bootcamp_601.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Bootcamp_601.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            var connection = new MongoDBConnection();
            var customerCollection = connection.GetCustomersCollection();

            var document = new BsonDocument
            {
                {"customerName",customer.customerName },
                {"customerSurname",customer.customerSurname },
                {"customerCity",customer.customerCity },
                {"customerBalance",customer.customerBalance },
                {"customerShoppingTotal",customer.customerShoppingTotal }
            };

            customerCollection.InsertOne(document);
        }
    }
}
