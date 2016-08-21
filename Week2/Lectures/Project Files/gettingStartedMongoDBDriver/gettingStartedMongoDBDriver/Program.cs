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
        static string connectionString = "mongodb://localhost:27017";
        static MongoClient client = new MongoClient(connectionString);
        static IMongoDatabase db = client.GetDatabase("test");
        static IMongoCollection<BsonDocument> colBson = db.GetCollection<BsonDocument>("people");
        static IMongoCollection<Person> colPerson = db.GetCollection<Person>("people");

        static void Main(string[] args)
        {
            // MainAsync(args).Wait();
            // InsertOneAsync(args).Wait();
            // findQueryWithBsonDocument(args).Wait();
            //findQueryWithClass(args).Wait();
            //sorting(args).Wait();
            projections(args).Wait();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }

        static async Task projections(string[] args)
        {

        }

        static async Task findQueryWithClass(string[] args)
        {
            // var builder = Builders<Person>.Filter;
            // var filter = builder.Lt(x => x.Age, 30) & !builder.Eq(x =>x.Name, "Smith");
            //var filter = builder.And(builder.Lt("Age", 30), builder.Eq("Name", "Jones"));
            //var list = await colPerson.Find(filter).ToListAsync();
            var list = await colPerson.Find(x => x.Age < 30 && x.Name != "Smith")
                .ToListAsync();
            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }
        }

        static async Task findQueryWithBsonDocument(string[] args)
        {
            /** With cursor :
            using (var cursor = await colBson.Find(new BsonDocument()).ToCursorAsync())
            {
                while(await cursor.MoveNextAsync())
                {
                    foreach(var doc in cursor.Current)
                    {
                        Console.WriteLine(doc);
                    }
                }
            }
            */

            /** With list:
            var list = await colBson.Find(new BsonDocument()).ToListAsync();
            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }
            */

            /** With ForEachAsync:
            await colBson.Find(new BsonDocument())
                .ForEachAsync(doc => Console.WriteLine(doc));
            */

            /** With filter: */
            // var filter = new BsonDocument("Name", "Smith");
            // var filter = new BsonDocument("Age", new BsonDocument("$lt",30));
            // var filter = new BsonDocument("$and", new BsonArray
            // {
            //    new BsonDocument("Age", new BsonDocument("$lt", 30)),
            //    new BsonDocument("Name", "Jones")
            // });
            // var builder = FilterDefinitionBuilder<BsonDocument>();
            var builder = Builders<BsonDocument>.Filter;
            // var filter = builder.Lt("Age", 30);
            // var filter = builder.Lt("Age", 30) & !builder.Eq("Name", "Jones"));
            var filter = builder.And(builder.Lt("Age", 30), builder.Eq("Name","Jones"));
            var list = await colBson.Find(filter).ToListAsync();
            // Or var list = await colBson.Find("{Name:'Smith'}").ToListAsync();
            foreach (var doc in list)
            {
                Console.WriteLine(doc);
            }

        }

        static async Task InsertOneAsync(string[] args)
        {
            var doc = new BsonDocument
            {
                {"Name", "Smith" },
                {"Age", 30 },
                {"Profession", "Hacker" }
            };

            var doc2 = new BsonDocument
            {
                {"SomethingElse", true }
            };

            var person = new Person
            {
                Name = "Jones",
                Age = 24,
                Profession = "Hacker"
            };
            await colPerson.InsertOneAsync(person);
            //await colBson.InsertManyAsync(new[] { doc, doc2 });
            //await colBson.InsertOneAsync(doc);
        }

        static async Task sorting(string[] args)
        {
            //var list = await colBson.Find(new BsonDocument())
            //       .Skip(1)
            //       .Limit(1)
            //       .ToListAsync();

            //var list = await colBson.find(new bsondocument())
            //      .sort("{age:1}")
            //      .tolistasync();

            //var list = await colBson.Find(new BsonDocument())
            //        .Sort(new BsonDocument("Age", 1))
            //        .ToListAsync();

            //var list = await colBson.Find(new BsonDocument())
            //        .Sort(Builders<BsonDocument>.Sort.Ascending("Age").Descending("Name"))
            //        .ToListAsync();

            //var list = await colPerson.Find(new BsonDocument())
            //        .Sort(Builders<Person>.Sort.Ascending(x => x.Age))
            //        .ToListAsync();

            var list = await colPerson.Find(new BsonDocument())
                    .SortBy(x => x.Age)
                    .ThenByDescending(x => x.Name)
                    .ToListAsync();

            foreach (var doc in list)
                Console.WriteLine(doc);
        }

        static async Task MainAsync(string[] args)
        {
            /* Lesson 4 */
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
                                                                    // t => true means apply to all fields
            ConventionRegistry.Register("camelcase", conventionPack, t => true);

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
            public string Profession { get; set; }
            public List<string> Colors { get; set; }
            public List<Pet> Pets { get; set; }
            public BsonDocument ExtraElements { get; set; }

            public override string ToString()
            {
                return string.Format("Id: {0}, Name: \"{1}\", Age: {2}, Profession: \"{3}\"", Id, Name, Age, Profession);
            }
        }
        
        class Pet
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }
    }
}
