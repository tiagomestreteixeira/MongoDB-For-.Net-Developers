> db.movieDetails.find({},{"awards.text": 1, _id:0}).pretty()

> db.movieDetails.find({"awards.text":{$regex: /^Won\s.*/}}).pretty()

> db.movieDetails.find({"awards.text":{$regex: /^Won\s.*/}}).count()
83
