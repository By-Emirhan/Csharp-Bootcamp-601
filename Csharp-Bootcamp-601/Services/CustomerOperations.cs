﻿using Csharp_Bootcamp_601.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
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

        public List<Customer> GetAllCustomers() 
        {
            var connection = new MongoDBConnection();
            var customerCollection = connection.GetCustomersCollection();
            var customers = customerCollection.Find(new BsonDocument()).ToList();
            List<Customer> customerList = new List<Customer>();
            foreach (var c in customers)
            {
                customerList.Add(new Customer
                {
                    customerID = c["_id"].ToString(),
                    customerName = c["customerName"].ToString(),
                    customerSurname = c["customerSurname"].ToString(),
                    customerCity = c["customerCity"].ToString(),
                    customerBalance = decimal.Parse(c["customerBalance"].ToString()),
                    customerShoppingTotal = int.Parse(c["customerShoppingTotal"].ToString())
                });
            }
            return customerList;
        }

        public void DeleteCustomer(string id)
        {
            var connection = new MongoDBConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            customerCollection.DeleteOne(filter);
        }
        public void UpdateCustomer(Customer customer)
        {
            var connection = new MongoDBConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.customerID));
            var updatedValue = Builders<BsonDocument>.Update
                .Set("customerName", customer.customerName)
                .Set("customerSurname", customer.customerSurname)
                .Set("customerCity", customer.customerCity)
                .Set("customerBalance", customer.customerBalance)
                .Set("customerShoppingTotal", customer.customerShoppingTotal);
            customerCollection.UpdateOne(filter, updatedValue);
        }
        public Customer GetCustomerById(string id)
        {
            var connection = new MongoDBConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = customerCollection.Find(filter).FirstOrDefault();
            return new Customer
            {
                customerID = id,
                customerName = result["customerName"].ToString(),
                customerSurname = result["customerSurname"].ToString(),
                customerCity = result["customerCity"].ToString(),
                customerBalance = int.Parse(result["customerBalance"].ToString()),
                customerShoppingTotal = int.Parse(result["customerShoppingTotal"].ToString())
            };
        }
    }
}