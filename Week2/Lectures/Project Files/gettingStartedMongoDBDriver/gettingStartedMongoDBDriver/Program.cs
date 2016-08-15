using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gettingStartedMongoDBDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();

        }

        static async Task MainAsync(string[] args)
        {

            // Map Bson Elements method 1:
            /* BsonClassMap.RegisterClassMap<Person>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(x => x.Name).SetElementName("name");
            });
            */
            // Map Bson Elements method 2:
            var conventionPack = new ConventionPack();
            conventionPack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camelcase", conventionPack, t => true);
            /* Lesson 1 */
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var col = db.GetCollection<BsonDocument>("people");
            /* Lesson 2 */
            var doc = new BsonDocument
            {
                { "name","Jones" }
            };
            doc.Add("age", 30);
            doc["profession"] = "hacker";
            
            var nestedArray = new BsonArray();
            nestedArray.Add(new BsonDocument("color", "red"));
            doc.Add("array", nestedArray);

            Console.WriteLine(doc["array"][0]["color"]);

            /* Lesson 3 */
            var person = new Person
            {
                Name = "Jones",
                Age = 30,
                Colors = new List<string> { "red", "blue" },
                Pets = new List<Pet> { new Pet { Name = "Fluffy", Type = "Pig" } },
                ExtraElements = new BsonDocument("anotherName", "anotherValue")
            };

            using (var writer = new JsonWriter(Console.Out))
            {
                BsonSerializer.Serialize(writer, person);
            }
            Console.WriteLine(doc);
        }

        /* In Lesson 3 - POCO Representation */
        class Person
        {
            public ObjectId Id { get; set; }
            //[BsonElement("name")] -> alternative to conventions
            public string Name { get; set; }
            //[BsonRepresentation(BsonType.String)] -> alternative to conventions
            public int Age { get; set; }
            public List<string> Colors { get; set; }
            public List<Pet> Pets { get; set; }
            public BsonDocument ExtraElements { get; set; }
        }
        
        class Pet
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }
    }
}
