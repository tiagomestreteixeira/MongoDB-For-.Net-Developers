# Creating Documents

> db.moviesScratch.insertOne({"title":"Rocky","year":"1976","imdb":"tt0075148"})
{
        "acknowledged" : true,
        "insertedId" : ObjectId("57afc075258f77901f409101")
}
> db.moviesScratch.find().pretty()
{
        "_id" : ObjectId("57afc075258f77901f409101"),
        "title" : "Rocky",
        "year" : "1976",
        "imdb" : "tt0075148"
}
> db.moviesScratch.insertOne({"title":"Rocky","year":"1976","_id":"tt0075148"})
{ "acknowledged" : true, "insertedId" : "tt0075148" }
> db.moviesScratch.find().pretty()
{
        "_id" : ObjectId("57afc075258f77901f409101"),
        "title" : "Rocky",
        "year" : "1976",
        "imdb" : "tt0075148"
}
{ "_id" : "tt0075148", "title" : "Rocky", "year" : "1976" }

> db.moviesScratch.insertMany(
...     [
...         {
...     "imdb" : "tt0084726",
...     "title" : "Star Trek II: The Wrath of Khan",
...     "year" : 1982,
...     "type" : "movie"
...         },
...         {
...     "imdb" : "tt0796366",
...     "title" : "Star Trek",
...     "year" : 2009,
...     "type" : "movie"
...         },
...         {
...     "imdb" : "tt1408101",
...     "title" : "Star Trek Into Darkness",
...     "year" : 2013,
...     "type" : "movie"
...         },
...         {
...     "imdb" : "tt0117731",
...     "title" : "Star Trek: First Contact",
...     "year" : 1996,
...     "type" : "movie"
...         }
...     ]
... );
{
        "acknowledged" : true,
        "insertedIds" : [
                ObjectId("57afc639258f77901f409102"),
                ObjectId("57afc639258f77901f409103"),
                ObjectId("57afc639258f77901f409104"),
                ObjectId("57afc639258f77901f409105")
        ]
}

### Duplicate _id error on Many insert
> db.moviesScratch.insertMany(
...     [
...         {
...     "_id" : "tt0084726",
...     "title" : "Star Trek II: The Wrath of Khan",
...     "year" : 1982,
...     "type" : "movie"
...         },
...         {
...     "_id" : "tt0796366",
...     "title" : "Star Trek",
...     "year" : 2009,
...     "type" : "movie"
...         },
...         {
...     "_id" : "tt0084726",
...     "title" : "Star Trek II: The Wrath of Khan",
...     "year" : 1982,
...     "type" : "movie"
...         },
...         {
...     "_id" : "tt1408101",
...     "title" : "Star Trek Into Darkness",
...     "year" : 2013,
...     "type" : "movie"
...         },
...         {
...     "_id" : "tt0117731",
...     "title" : "Star Trek: First Contact",
...     "year" : 1996,
...     "type" : "movie"
...         }
...     ],
...     {
...         "ordered": false
...     }
... );
2016-08-14T02:22:42.780+0100 E QUERY    [thread1] BulkWriteError: write error at item 2 in bulk operation :
BulkWriteError({
        "writeErrors" : [
                {
                        "index" : 2,
                        "code" : 11000,
                        "errmsg" : "E11000 duplicate key error collection: test.moviesScratch index: _id_ dup key: { : \"tt0084726\" }",
                        "op" : {
                                "_id" : "tt0084726",
                                "title" : "Star Trek II: The Wrath of Khan",
                                "year" : 1982,
                                "type" : "movie"
                        }
                }
        ],
        "writeConcernErrors" : [ ],
        "nInserted" : 4,
        "nUpserted" : 0,
        "nMatched" : 0,
        "nModified" : 0,
        "nRemoved" : 0,
        "upserted" : [ ]
})
BulkWriteError@src/mongo/shell/bulk_api.js:371:48
BulkWriteResult/this.toError@src/mongo/shell/bulk_api.js:335:24
Bulk/this.execute@src/mongo/shell/bulk_api.js:1177:1
DBCollection.prototype.insertMany@src/mongo/shell/crud_api.js:281:5
@(shell):1:1

> db.moviesScratch.drop()
true
> db.moviesScratch.insertMany(
...     [
...         {
...     "_id" : "tt0084726",
...     "title" : "Star Trek II: The Wrath of Khan",
...     "year" : 1982,
...     "type" : "movie"
...         },
...         {
...     "_id" : "tt0796366",
...     "title" : "Star Trek",
...     "year" : 2009,
...     "type" : "movie"
...         },
...         {
...     "_id" : "tt0084726",
...     "title" : "Star Trek II: The Wrath of Khan",
...     "year" : 1982,
...     "type" : "movie"
...         },
...         {
...     "_id" : "tt1408101",
...     "title" : "Star Trek Into Darkness",
...     "year" : 2013,
...     "type" : "movie"
...         },
...         {
...     "_id" : "tt0117731",
...     "title" : "Star Trek: First Contact",
...     "year" : 1996,
...     "type" : "movie"
...         }
...     ],
...     {
...         "ordered": false
...     }
... );
2016-08-14T15:11:40.756+0100 E QUERY    [thread1] BulkWriteError: write error at item 2 in bulk operation :
BulkWriteError({
        "writeErrors" : [
                {
                        "index" : 2,
                        "code" : 11000,
                        "errmsg" : "E11000 duplicate key error collection: test.moviesScratch index: _id_ dup key: { : \"tt0084726\" }",
                        "op" : {
                                "_id" : "tt0084726",
                                "title" : "Star Trek II: The Wrath of Khan",
                                "year" : 1982,
                                "type" : "movie"
                        }
                }
        ],
        "writeConcernErrors" : [ ],
        "nInserted" : 4,
        "nUpserted" : 0,
        "nMatched" : 0,
        "nModified" : 0,
        "nRemoved" : 0,
        "upserted" : [ ]
})
BulkWriteError@src/mongo/shell/bulk_api.js:371:48
BulkWriteResult/this.toError@src/mongo/shell/bulk_api.js:335:24
Bulk/this.execute@src/mongo/shell/bulk_api.js:1177:1
DBCollection.prototype.insertMany@src/mongo/shell/crud_api.js:281:5
@(shell):1:1
