https://docs.mongodb.com/manual/reference/operator/query-comparison/

Name	Description
$eq	Matches values that are equal to a specified value.
$gt	Matches values that are greater than a specified value.
$gte	Matches values that are greater than or equal to a specified value.
$lt	Matches values that are less than a specified value.
$lte	Matches values that are less than or equal to a specified value.
$ne	Matches all values that are not equal to a specified value.
$in	Matches any of the values specified in an array.
$nin	Matches none of the values specified in an array.

> db.movieDetails.find({runtime : {$gt:120}}).count()
262
> db.movieDetails.find({runtime : {$gt:220}}).count()
8
> db.movieDetails.find({runtime : {$gt:220}},{"title":1})
{ "_id" : ObjectId("5692a15024de1e0ce2dfcf6b"), "title" : "Once Upon a Time in America" }
{ "_id" : ObjectId("5692a15024de1e0ce2dfcf71"), "title" : "Lagaan: Once Upon a Time in India" }
{ "_id" : ObjectId("5692a24624de1e0ce2dfd69e"), "title" : "AC/DC: Plug Me In" }
{ "_id" : ObjectId("5692a34f24de1e0ce2dfd8ef"), "title" : "Heremias: Unang aklat - Ang alamat ng prinsesang bayawak" }
{ "_id" : ObjectId("5692a49d24de1e0ce2dfdb95"), "title" : "Tie Xi Qu: West of the Tracks" }
{ "_id" : ObjectId("5692a4a924de1e0ce2dfdba3"), "title" : "Tie Xi Qu: West of the Tracks" }
{ "_id" : ObjectId("5692a4ab24de1e0ce2dfdba6"), "title" : "Tie Xi Qu: West of the Tracks" }
{ "_id" : ObjectId("5692c8fa24de1e0ce2dfe271"), "title" : "The Question of God: Sigmund Freud & C.S. Lewis" }

> db.movieDetails.find({runtime : { $gt:90, $lt:120}},{"title":1})
{ "_id" : ObjectId("569190cb24de1e0ce2dfcd50"), "title" : "A Million Ways to Die in the West" }
{ "_id" : ObjectId("569190cb24de1e0ce2dfcd51"), "title" : "Wild Wild West" }
{ "_id" : ObjectId("569190cc24de1e0ce2dfcd55"), "title" : "Red Rock West" }
{ "_id" : ObjectId("569190cc24de1e0ce2dfcd57"), "title" : "Journey to the West" }
{ "_id" : ObjectId("569190cd24de1e0ce2dfcd61"), "title" : "Star Trek: First Contact" }
{ "_id" : ObjectId("569190cd24de1e0ce2dfcd62"), "title" : "Star Trek II: The Wrath of Khan" }
{ "_id" : ObjectId("569190cd24de1e0ce2dfcd63"), "title" : "Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb" }
{ "_id" : ObjectId("569190cd24de1e0ce2dfcd66"), "title" : "I Love You, Man" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd68"), "title" : "Love & Other Drugs" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd69"), "title" : "Punch-Drunk Love" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd6a"), "title" : "From Paris with Love" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd6b"), "title" : "From Russia with Love" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd6c"), "title" : "I Love You Phillip Morris" }
{ "_id" : ObjectId("569190cf24de1e0ce2dfcd6f"), "title" : "Zathura: A Space Adventure" }
{ "_id" : ObjectId("569190cf24de1e0ce2dfcd74"), "title" : "Turks in Space" }
{ "_id" : ObjectId("569190cf24de1e0ce2dfcd75"), "title" : "2001: A Space Travesty" }
{ "_id" : ObjectId("569190d024de1e0ce2dfcd77"), "title" : "The Adventures of Tintin" }
{ "_id" : ObjectId("569190d024de1e0ce2dfcd79"), "title" : "The Adventures of Robin Hood" }
{ "_id" : ObjectId("569190d024de1e0ce2dfcd7a"), "title" : "The Adventures of Priscilla, Queen of the Desert" }
{ "_id" : ObjectId("569190d024de1e0ce2dfcd7b"), "title" : "Adventures in Babysitting" }
Type "it" for more
> db.movieDetails.find({runtime : { $gte:90, $lte:120}},{"title":1})
{ "_id" : ObjectId("569190cb24de1e0ce2dfcd50"), "title" : "A Million Ways to Die in the West" }
{ "_id" : ObjectId("569190cb24de1e0ce2dfcd51"), "title" : "Wild Wild West" }
{ "_id" : ObjectId("569190cc24de1e0ce2dfcd55"), "title" : "Red Rock West" }
{ "_id" : ObjectId("569190cc24de1e0ce2dfcd57"), "title" : "Journey to the West" }
{ "_id" : ObjectId("569190cd24de1e0ce2dfcd61"), "title" : "Star Trek: First Contact" }
{ "_id" : ObjectId("569190cd24de1e0ce2dfcd62"), "title" : "Star Trek II: The Wrath of Khan" }
{ "_id" : ObjectId("569190cd24de1e0ce2dfcd63"), "title" : "Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb" }
{ "_id" : ObjectId("569190cd24de1e0ce2dfcd66"), "title" : "I Love You, Man" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd68"), "title" : "Love & Other Drugs" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd69"), "title" : "Punch-Drunk Love" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd6a"), "title" : "From Paris with Love" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd6b"), "title" : "From Russia with Love" }
{ "_id" : ObjectId("569190ce24de1e0ce2dfcd6c"), "title" : "I Love You Phillip Morris" }
{ "_id" : ObjectId("569190cf24de1e0ce2dfcd6f"), "title" : "Zathura: A Space Adventure" }
{ "_id" : ObjectId("569190cf24de1e0ce2dfcd74"), "title" : "Turks in Space" }
{ "_id" : ObjectId("569190cf24de1e0ce2dfcd75"), "title" : "2001: A Space Travesty" }
{ "_id" : ObjectId("569190d024de1e0ce2dfcd77"), "title" : "The Adventures of Tintin" }
{ "_id" : ObjectId("569190d024de1e0ce2dfcd79"), "title" : "The Adventures of Robin Hood" }
{ "_id" : ObjectId("569190d024de1e0ce2dfcd7a"), "title" : "The Adventures of Priscilla, Queen of the Desert" }
{ "_id" : ObjectId("569190d024de1e0ce2dfcd7b"), "title" : "Adventures in Babysitting" }
Type "it" for more
> db.movieDetails.find({runtime : { $gte:90, $lte:120}},{"title":1}).count()
829
> db.movieDetails.find({runtime : { $gt:90, $lt:120}},{"title":1}).count()
714

> db.movieDetails.find({ "tomato.meter" : {$gte:95} , runtime : { $gt:180 }},{"title":1,"runtime":1,_id:0}).pretty()
{ "title" : "Lagaan: Once Upon a Time in India", "runtime" : 224 }
{ "title" : "The Godfather: Part II", "runtime" : 202 }

> db.movieDetails.find({ rated : { $ne:"UNRATED"}}).count()
2263

> db.movieDetails.find({ rated : { $in:["G","PG"]}}).count()
139
