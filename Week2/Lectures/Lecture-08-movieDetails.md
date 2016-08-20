https://docs.mongodb.com/manual/reference/operator/update/

> use video
switched to db video

> show collections
movieDetails
movies
moviesScratch
reviews

> db.movieDetails.find({"title":"The Martian"})

> db.movieDetails.updateOne({"title":"The Martian"},{$set : {poster:"HTTPS"}})
{ "acknowledged" : true, "matchedCount" : 1, "modifiedCount" : 1 }

> db.movieDetails.find({"title":"The Martian"}).pretty()

> db.movieDetails.updateOne({title: "The Martian"},
...                           { $set: { "awards" : {"wins" : 8,
...                               "nominations" : 14,
...                                 "text" : "Nominated for 3 Golden Globes. Another 8 wins & 14 nominations." } } });
{ "acknowledged" : true, "matchedCount" : 1, "modifiedCount" : 0 }

> db.movieDetails.updateOne({title: "The Martian"},{$inc: {"tomato.reviews":3, "tomato.userReviews" : 25}})
{ "acknowledged" : true, "matchedCount" : 1, "modifiedCount" : 1 }

> db.reviews.find()

> db.movieDetails.updateOne({title: "The Martian"},
                          {$push: { reviews: { rating: 4.5,
                                               date: ISODate("2016-01-12T09:00:00Z"),
                                               reviewer: "Spencer H.",
                                               text: "The Martian could have been a sad drama film, instead it was a hilarious film with a little bit of drama added to it. The Martian is what everybody wants from a space adventure. Ridley Scott can still make great movies and this is one of his best."} } })

{ "acknowledged" : true, "matchedCount" : 1, "modifiedCount" : 1 }

> db.movieDetails.updateOne({title: "The Martian"},
                          {$push: { reviews:
                                    { $each: [
                                        { rating: 0.5,
                                          date: ISODate("2016-01-12T07:00:00Z"),
                                          reviewer: "Yabo A.",
                                          text: "i believe its ranked high due to its slogan 'Bring him Home' there is nothing in the movie, nothing at all ! Story telling for fiction story !"},
                                        { rating: 5,
                                          date: ISODate("2016-01-12T09:00:00Z"),
                                          reviewer: "Kristina Z.",
                                          text: "This is a masterpiece. The ending is quite different from the book - the movie provides a resolution whilst a book doesn't."},
                                        { rating: 2.5,
                                          date: ISODate("2015-10-26T04:00:00Z"),
                                          reviewer: "Matthew Samuel",
                                          text: "There have been better movies made about space, and there are elements of the film that are borderline amateur, such as weak dialogue, an uneven tone, and film cliches."},
                                        { rating: 4.5,
                                          date: ISODate("2015-12-13T03:00:00Z"),
                                          reviewer: "Eugene B",
                                          text: "This novel-adaptation is humorous, intelligent and captivating in all its visual-grandeur. The Martian highlights an impeccable Matt Damon, power-stacked ensemble and Ridley Scott's masterful direction, which is back in full form."},
                                        { rating: 4.5,
                                          date: ISODate("2015-10-22T00:00:00Z"),
                                          reviewer: "Jens S",
                                          text: "A declaration of love for the potato, science and the indestructible will to survive. While it clearly is the Matt Damon show (and he is excellent), the supporting cast may be among the strongest seen on film in the last 10 years. An engaging, exciting, funny and beautifully filmed adventure thriller no one should miss."},

                                        { rating: 4.5,
                                          date: ISODate("2016-01-12T09:00:00Z"),
                                          reviewer: "Spencer H.",
                                          text: "The Martian could have been a sad drama film, instead it was a hilarious film with a little bit of drama added to it. The Martian is what everybody wants from a space adventure. Ridley Scott can still make great movies and this is one of his best."} ] } } } )
{ "acknowledged" : true, "matchedCount" : 1, "modifiedCount" : 1 }

> db.movieDetails.updateOne({ title: "The Martian" },
                          {$push: { reviews:
                                    { $each: [
                                        { rating: 0.5,
                                          date: ISODate("2016-01-13T07:00:00Z"),
                                          reviewer: "Shannon B.",
                                          text: "Enjoyed watching with my kids!" } ],
                                      $position: 0,
                                      $slice: 5 } } } )

{ "acknowledged" : true, "matchedCount" : 1, "modifiedCount" : 1 }

> db.movieDetails.find({ rated: "UNRATED" }).count()
32

> db.movieDetails.updateMany({ rated: null },{$set:{rated:"UNRATED"}})

> db.movieDetails.updateMany({ rated: null},{$unset : {rated:""}})



var detail = {
    "title" : "The Martian",
    "year" : 2015,
    "rated" : "PG-13",
    "released" : ISODate("2015-10-02T04:00:00Z"),
    "runtime" : 144,
    "countries" : [
	"USA",
	"UK"
    ],
    "genres" : [
	"Adventure",
	"Drama",
	"Sci-Fi"
    ],
    "director" : "Ridley Scott",
    "writers" : [
	"Drew Goddard",
	"Andy Weir"
    ],
    "actors" : [
	"Matt Damon",
	"Jessica Chastain",
	"Kristen Wiig",
	"Jeff Daniels"
    ],
    "plot" : "During a manned mission to Mars, Astronaut Mark Watney is presumed dead after a fierce storm and left behind by his crew. But Watney has survived and finds himself stranded and alone on the hostile planet. With only meager supplies, he must draw upon his ingenuity, wit and spirit to subsist and find a way to signal to Earth that he is alive.",
    "poster" : "http://ia.media-imdb.com/images/M/MV5BMTc2MTQ3MDA1Nl5BMl5BanBnXkFtZTgwODA3OTI4NjE@._V1_SX300.jpg",
    "imdb" : {
	"id" : "tt3659388",
	"rating" : 8.2,
	"votes" : 187881
    },
    "tomato" : {
	"meter" : 93,
	"image" : "certified",
	"rating" : 7.9,
	"reviews" : 280,
	"fresh" : 261,
	"consensus" : "Smart, thrilling, and surprisingly funny, The Martian offers a faithful adaptation of the bestselling book that brings out the best in leading man Matt Damon and director Ridley Scott.",
	"userMeter" : 92,
	"userRating" : 4.3,
	"userReviews" : 104999
    },
    "metacritic" : 80,
    "awards" : {
	"wins" : 8,
	"nominations" : 14,
	"text" : "Nominated for 3 Golden Globes. Another 8 wins & 14 nominations."
    },
    "type" : "movie"
};


> db.movieDetails.updateOne(
    {"imdb.id": detail.imdb.id},
    {$set: detail},
    {upsert: true});


> db.movies.find()
    { "_id" : ObjectId("57a6785d9345b7151c918093"), "title" : "Jaws", "year" : 1975, "imdb" : "tt0073195" }
    { "_id" : ObjectId("57a6799c9345b7151c918094"), "title" : "Mad Max 2: The Road Warrior", "year" : 1981, "imdb" : "tt0082694" }
    { "_id" : ObjectId("57a6799c9345b7151c918095"), "title" : "Raiders of the Lost Ark", "year" : 1981, "imdb" : "tt0082971" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccc3"), "title" : "Once Upon a Time in the West", "year" : 1968, "imdb" : "tt0064116", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccc4"), "title" : "A Million Ways to Die in the West", "year" : 2014, "imdb" : "tt2557490", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccc5"), "title" : "Wild Wild West", "year" : 1999, "imdb" : "tt0120891", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccc6"), "title" : "West Side Story", "year" : 1961, "imdb" : "tt0055614", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccc7"), "title" : "Slow West", "year" : 2015, "imdb" : "tt3205376", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccc8"), "title" : "An American Tail: Fievel Goes West", "year" : 1991, "imdb" : "tt0101329", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccc9"), "title" : "Red Rock West", "year" : 1993, "imdb" : "tt0105226", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccca"), "title" : "How the West Was Won", "year" : 1962, "imdb" : "tt0056085", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfcccb"), "title" : "Journey to the West", "year" : 2013, "imdb" : "tt2017561", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfcccc"), "title" : "West of Memphis", "year" : 2012, "imdb" : "tt2130321", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfcccd"), "title" : "Star Wars: Episode IV - A New Hope", "year" : 1977, "imdb" : "tt0076759", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccce"), "title" : "Star Wars: Episode V - The Empire Strikes Back", "year" : 1980, "imdb" : "tt0080684", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfcccf"), "title" : "Star Wars: Episode VI - Return of the Jedi", "year" : 1983, "imdb" : "tt0086190", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccd0"), "title" : "Star Wars: Episode I - The Phantom Menace", "year" : 1999, "imdb" : "tt0120915", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccd1"), "title" : "Star Wars: Episode III - Revenge of the Sith", "year" : 2005, "imdb" : "tt0121766", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccd2"), "title" : "Star Trek", "year" : 2009, "imdb" : "tt0796366", "type" : "movie" }
    { "_id" : ObjectId("56918f5e24de1e0ce2dfccd3"), "title" : "Star Wars: Episode II - Attack of the Clones", "year" : 2002, "imdb" : "tt0121765", "type" : "movie" }
    Type "it" for more


> db.movies.replaceOne(
        {"imdb": detail.imdb.id},
        detail);
