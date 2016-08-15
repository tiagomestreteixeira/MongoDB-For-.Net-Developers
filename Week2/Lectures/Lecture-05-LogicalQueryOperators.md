https://docs.mongodb.com/manual/reference/operator/query-logical/

> db.movieDetails.find({$or : [{"tomato.meter":{$gt:95}},{"metacritic":{$gt:88}}]}).count()
39
> db.movieDetails.find({$and : [{"tomato.meter":{$gt:95}},{"metacritic":{$gt:95}}]}).count()
5
> db.movieDetails.find({"tomato.meter":{$gt:95},"metacritic":{$gt:95}}).count()
5
> db.movieDetails.find({$and : [{"metacritic": {$ne:null}}, {"metacritic":{$exists: true}}]}).count()
376
