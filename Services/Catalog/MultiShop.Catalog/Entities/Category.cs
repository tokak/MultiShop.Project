using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId] // MongoDB'de "_id" alanı olarak kullanılacağını belirtir.
        [BsonRepresentation(BsonType.ObjectId)] //Veritabanında ObjectId olarak saklanacak ama C# tarafında string olarak kullanılabilecek anlamına gelir.
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
