using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Bootcamp_601.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string customerID { get; set; }
        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public string customerCity { get; set; }
        public decimal customerBalance { get; set; }
        public int customerShoppingTotal { get; set; }
    }
}
