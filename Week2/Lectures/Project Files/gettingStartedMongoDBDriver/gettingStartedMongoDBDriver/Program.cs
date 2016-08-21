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
        static IMongoCollection<BsonDocument> colPersonBson = db.GetCollection<BsonDocument>("people");
        static IMongoCollection<Person> colPerson = db.GetCollection<Person>("people");
        static IMongoCollection<BsonDocument> colWidgetsBson = db.GetCollection<BsonDocument>("widgets");
        static IMongoCollection<Widget> colWidgets = db.GetCollection<Widget>("widgets");

        static void printDocs(List<BsonDocument> listBson, List<Person> listPerson)
        {
            if (listBson == null)
            {
                foreach (var doc in listBson)
                    Console.WriteLine(doc);
            }
            else
            {
                foreach (var doc in listPerson)
                    Console.WriteLine(doc);
            }
        }

        static void Main(string[] args)
        {
            // MainAsync(args).Wait();
            // InsertOneAsync(args).Wait();
            // findQueryWithBsonDocument(args).Wait();
            // findQueryWithClass(args).Wait();
            // sorting(args).Wait();
            // projections(args).Wait();
            // update(args).Wait();
            delete(args).Wait();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }

        static async Task delete(string[] args)
        {
            await db.DropCollectionAsync("widgets");
            var docs = Enumerable.Range(0, 10).Select(i => new Widget { Id = i, X = i });
            await colWidgets.InsertManyAsync(docs);

            //var result = await colWidgets.DeleteOneAsync(
            //        x => x.X > 5);

            var result = await colWidgets.DeleteManyAsync(
                    x => x.X > 5);

            await colWidgetsBson.Find(new BsonDocument())
                .ForEachAsync(x => Console.WriteLine(x));
        }

        static async Task update(string[] args)
        {
            
            await db.DropCollectionAsync("widgets");

            // For Bson Documents:
            // var docs = Enumerable.Range(0, 10).Select(i => new BsonDocument("_id", i).Add("x", i));
            // await colWidgetsBson.InsertManyAsync(docs);

            // For Widget Documents:
            var docs = Enumerable.Range(0, 10).Select(i => new Widget { Id = i, X = i });
            await colWidgets.InsertManyAsync(docs);

            // var result = await colWidgetsBson.ReplaceOneAsync(
            //    new BsonDocument("_id", 5), 
            //    new BsonDocument("_id",5).Add("x",30));

            // var result = await colWidgetsBson.ReplaceOneAsync(
            //    new BsonDocument("x", 5),
            //    new BsonDocument("x", 30));

            // var result = await colWidgetsBson.ReplaceOneAsync(
            //    Builders<BsonDocument>.Filter.Eq("x",5),
            //    new BsonDocument("x", 30),
            //    new UpdateOptions { IsUpsert = true });

            //var result = await colWidgetsBson.UpdateOneAsync(
            //    Builders<BsonDocument>.Filter.Eq("x", 5),
            //    new BsonDocument("$inc",new BsonDocument("x",5)));

            //var result = await colWidgetsBson.UpdateOneAsync(
            //    Builders<BsonDocument>.Filter.Eq("x", 5),
            //    Builders<BsonDocument>.Update.Inc("x",10));

            //var result = await colWidgetsBson.UpdateManyAsync(
            //    Builders<BsonDocument>.Filter.Gt("x", 5),
            //    Builders<BsonDocument>.Update.Inc("x", 10));

            //var result = await colWidgets.UpdateManyAsync(
            //    Builders<Widget>.Filter.Gt(x => x.X, 5),
            //    Builders<Widget>.Update.Inc(x => x.X, 10));

            //var result = await colWidgets.UpdateManyAsync(
            //    x => x.X > 5,
            //    Builders<Widget>.Update.Inc(x => x.X, 10));

            var result = await colWidgets.UpdateManyAsync(
                 x => x.X > 5,
                 Builders<Widget>.Update.Inc(x => x.X, 10).Set("J", 20));

            await colWidgetsBson.Find(new BsonDocument())
                .ForEachAsync(x => Console.WriteLine(x));
        }

        static async Task projections(string[] args)
        {
            // var list = await colPerson.Find(new BsonDocument())
            //     .Project("{Name: 1, _id :0}")
            //     .ToListAsync();

            // var list = await colPerson.Find(new BsonDocument())
            //    .Project(new BsonDocument("Name",1).Add("_id",0))
            //    .ToListAsync();

            // var list = await colPerson.Find(new BsonDocument())
            //    .Project(Builders<Person>.Projection.Include("Name").Exclude("_id"))
            //    .ToListAsync();

            // var list = await colPerson.Find(new BsonDocument())
            //    .Project<Person>(Builders<Person>.Projection.Include(x => x.Name).Exclude(x => x.Id))
            //    .ToListAsync();

            // var list = await colPerson.Find(new BsonDocument())
            //    .Project(x => x.Name)
            //    .ToListAsync();

            var list = await colPerson.Find(new BsonDocument())
                .Project(x => new { x.Name, CalcAge = x.Age + 20 })
                .ToListAsync();

            foreach (var doc in list)
                Console.WriteLine(doc);
        }

        static async Task findQueryWithClass(string[] args)
        {
            // var builder = Builders<Person>.Filter;
            // var filter = builder.Lt(x => x.Age, 30) & !builder.Eq(x =>x.Name, "Smith");
            // var filter = builder.And(builder.Lt("Age", 30), builder.Eq("Name", "Jones"));
            // var list = await colPerson.Find(filter).ToListAsync();
            var list = await colPerson.Find(x => x.Age < 30 && x.Name != "Smith")
                .ToListAsync();

            printDocs(null, list);
        }

        static async Task findQueryWithBsonDocument(string[] args)
        {
            /** With cursor :
            using (var cursor = await colPersonBson.Find(new BsonDocument()).ToCursorAsync())
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
            var list = await colPersonBson.Find(new BsonDocument()).ToListAsync();
            printDocs(list,null);
            */

            /** With ForEachAsync:
            await colPersonBson.Find(new BsonDocument())
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
            var filter = builder.And(builder.Lt("Age", 30), builder.Eq("Name", "Jones"));
            var list = await colPersonBson.Find(filter).ToListAsync();
            // Or var list = await colPersonBson.Find("{Name:'Smith'}").ToListAsync();
            printDocs(list, null);
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
            // await colPersonBson.InsertManyAsync(new[] { doc, doc2 });
            // await colPersonBson.InsertOneAsync(doc);
        }

        static async Task sorting(string[] args)
        {
            // var list = await colPersonBson.Find(new BsonDocument())
            //       .Skip(1)
            //       .Limit(1)
            //       .ToListAsync();

            // var list = await colPersonBson.find(new bsondocument())
            //      .sort("{age:1}")
            //      .tolistasync();

            // var list = await colPersonBson.Find(new BsonDocument())
            //        .Sort(new BsonDocument("Age", 1))
            //        .ToListAsync();

            // var list = await colPersonBson.Find(new BsonDocument())
            //        .Sort(Builders<BsonDocument>.Sort.Ascending("Age").Descending("Name"))
            //        .ToListAsync();

            // var list = await colPerson.Find(new BsonDocument())
            //        .Sort(Builders<Person>.Sort.Ascending(x => x.Age))
            //        .ToListAsync();

            var list = await colPerson.Find(new BsonDocument())
                    .SortBy(x => x.Age)
                    .ThenByDescending(x => x.Name)
                    .ToListAsync();

            printDocs(null, list);
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
        private class Person
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

        private class Pet
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }

        private class Widget
        {
            public int Id { get; set; }
            [BsonElement("x")]
            public int X { get; set; }
            public override string ToString()
            {
                return string.Format("Id: {0}, X: \"{1}\", Age: {2}, Profession: \"{3}\"", Id, X);
            }
        }
    }
}
