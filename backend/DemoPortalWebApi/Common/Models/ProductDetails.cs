using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ProductDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get;
            set;
        }
        [BsonElement("ProductName")]
        public string ProductName
        {
            get;
            set;
        }
        public string ProductDescription
        {
            get;
            set;
        }
        public int ProductPrice
        {
            get;
            set;
        }
        public int ProductStock
        {
            get;
            set;
        }
    }
}

