https://docs.mongodb.com/manual/reference/operator/query-array/

>  db.movieDetails.find({genres : { $all: ["Comedy","Crime","Drama"]}}).count()
8

> db.movieDetails.find({countries:{$size:1}}).pretty()

> db.movieDetails.find({boxOffice: {country:"UK",revenue:{$gt:15}}}).pretty()
> db.movieDetails.find({boxOffice: {$elemMatch : {country:"UK",revenue:{$gt:15}}}}).pretty()
