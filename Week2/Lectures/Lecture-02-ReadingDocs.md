> mongorestore dump

> db.movieDetails.find({rated:"PG-13"}).limit(1).pretty()
{
        "_id" : ObjectId("569190ca24de1e0ce2dfcd4f"),
        "title" : "Once Upon a Time in the West",
        "year" : 1968,
        "rated" : "PG-13",
        "released" : ISODate("1968-12-21T05:00:00Z"),
        "runtime" : 175,
        "countries" : [
                "Italy",
                "USA",
                "Spain"
        ],
        "genres" : [
                "Western"
        ],
        "director" : "Sergio Leone",
        "writers" : [
                "Sergio Donati",
                "Sergio Leone",
                "Dario Argento",
                "Bernardo Bertolucci",
                "Sergio Leone"
        ],
        "actors" : [
                "Claudia Cardinale",
                "Henry Fonda",
                "Jason Robards",
                "Charles Bronson"
        ],
        "plot" : "Epic story of a mysterious stranger with a harmonica who joins forces with a notorious desperado to protect a beautiful widow from a ruthless assassin working for the railroad.",
        "poster" : "http://ia.media-imdb.com/images/M/MV5BMTEyODQzNDkzNjVeQTJeQWpwZ15BbWU4MDgyODk1NDEx._V1_SX300.jpg",
        "imdb" : {
                "id" : "tt0064116",
                "rating" : 8.6,
                "votes" : 201283
        },
        "tomato" : {
                "meter" : 98,
                "image" : "certified",
                "rating" : 9,
                "reviews" : 54,
                "fresh" : 53,
                "consensus" : "A landmark Sergio Leone spaghetti western masterpiece featuring a classic Morricone score.",
                "userMeter" : 95,
                "userRating" : 4.3,
                "userReviews" : 64006
        },
        "metacritic" : 80,
        "awards" : {
                "wins" : 4,
                "nominations" : 5,
                "text" : "4 wins & 5 nominations."
        },
        "type" : "movie"
}

> db.movieDetails.find({rated:"PG-13"}).pretty()

> db.movieDetails.find({rated:"PG-13"}).count()
153

> db.movieDetails.find({"tomato.meter":100}).count()
8
> db.movieDetails.find({"tomato.meter":100})


> db.movieDetails.find({"writers": ["Ethan Coen","Joel Coen"]}).count()
1
> db.movieDetails.find({"writers": ["Ethan Coen","Joel Coen"]}).pretty()
{
        "_id" : ObjectId("5692a14f24de1e0ce2dfcf60"),
        "title" : "The Big Lebowski",
        "year" : 1998,
        "rated" : "R",
        "released" : ISODate("1998-03-06T05:00:00Z"),
        "runtime" : 117,
        "countries" : [
                "USA",
                "UK"
        ],
        "genres" : [
                "Comedy",
                "Crime"
        ],
        "director" : "Joel Coen, Ethan Coen",
        "writers" : [
                "Ethan Coen",
                "Joel Coen"
        ],
        "actors" : [
                "Jeff Bridges",
                "John Goodman",
                "Julianne Moore",
                "Steve Buscemi"
        ],
        "plot" : "\"The Dude\" Lebowski, mistaken for a millionaire Lebowski, seeks restitution for his ruined rug and enlists his bowling buddies to help get it.",
        "poster" : "http://ia.media-imdb.com/images/M/MV5BMTQ0NjUzMDMyOF5BMl5BanBnXkFtZTgwODA1OTU0MDE@._V1_SX300.jpg",
        "imdb" : {
                "id" : "tt0118715",
                "rating" : 8.2,
                "votes" : 498368
        },
        "tomato" : {
                "meter" : 80,
                "image" : "certified",
                "rating" : 7.2,
                "reviews" : 87,
                "fresh" : 70,
                "consensus" : "Typically stunning visuals and sharp dialogue from the Coen Brothers, brought to life with strong performances from Goodman and Bridges.",
                "userMeter" : 94,
                "userRating" : 4,
                "userReviews" : 352473
        },
        "metacritic" : 69,
        "awards" : {
                "wins" : 3,
                "nominations" : 15,
                "text" : "3 wins & 15 nominations."
        },
        "type" : "movie"
}
> db.movieDetails.find({"writers": ["Joel Coen","Ethan Coen"]}).count()
0


> db.movieDetails.find({"actors": "Jeff Bridges"}).count()
4
> db.movieDetails.find({"actors": "Jeff Bridges"}).pretty()
{
        "_id" : ObjectId("569190d124de1e0ce2dfcd86"),
        "title" : "The Last Picture Show",
        "year" : 1971,
        "rated" : "R",
        "released" : ISODate("1971-10-22T04:00:00Z"),
        "runtime" : 118,
        "countries" : [
                "USA"
        ],
        "genres" : [
                "Drama"
        ],
        "director" : "Peter Bogdanovich",
        "writers" : [
                "Larry McMurtry",
                "Peter Bogdanovich",
                "Larry McMurtry"
        ],
        "actors" : [
                "Timothy Bottoms",
                "Jeff Bridges",
                "Cybill Shepherd",
                "Ben Johnson"
        ],
        "plot" : "A group of 1950s high schoolers come of age in a bleak, isolated, atrophied West Texas town that is slowly dying, both economically and culturally.",
        "poster" : "http://ia.media-imdb.com/images/M/MV5BNDkyNzQ1NzYzN15BMl5BanBnXkFtZTcwNjE5MDEwNw@@._V1._CR73.19999694824219,89.69999694824219,1196,1865.2000274658203_SX89_AL_.jpg_V1_SX300.jpg",
        "imdb" : {
                "id" : "tt0067328",
                "rating" : 8.1,
                "votes" : 29830
        },
        "awards" : {
                "wins" : 16,
                "nominations" : 22,
                "text" : "Won 2 Oscars. Another 16 wins & 22 nominations."
        },
        "type" : "movie"
}
{
        "_id" : ObjectId("5692a14e24de1e0ce2dfcf56"),
        "title" : "Crazy Heart",
        "year" : 2009,
        "rated" : "R",
        "released" : ISODate("2010-02-05T05:00:00Z"),
        "runtime" : 112,
        "countries" : [
                "USA"
        ],
        "genres" : [
                "Drama",
                "Music",
                "Romance"
        ],
        "director" : "Scott Cooper",
        "writers" : [
                "Scott Cooper",
                "Thomas Cobb"
        ],
        "actors" : [
                "Jeff Bridges",
                "James Keane",
                "Anna Felix",
                "Paul Herman"
        ],
        "plot" : "A faded country music musician is forced to reassess his dysfunctional life during a doomed romance that also inspires him.",
        "poster" : "http://ia.media-imdb.com/images/M/MV5BMTU0NDc5NjgzNl5BMl5BanBnXkFtZTcwNzc0NDIzMw@@._V1_SX300.jpg",
        "imdb" : {
                "id" : "tt1263670",
                "rating" : 7.3,
                "votes" : 63771
        },
        "tomato" : {
                "meter" : 91,
                "image" : "certified",
                "rating" : 7.4,
                "reviews" : 199,
                "fresh" : 181,
                "consensus" : "Thanks to a captivating performance from Jeff Bridges, Crazy Heart transcends its overly familiar origins and finds new meaning in an old story.",
                "userMeter" : 76,
                "userRating" : 3.6,
                "userReviews" : 124175
        },
        "metacritic" : 83,
        "awards" : {
                "wins" : 32,
                "nominations" : 26,
                "text" : "Won 2 Oscars. Another 32 wins & 26 nominations."
        },
        "type" : "movie"
}
{
        "_id" : ObjectId("5692a14f24de1e0ce2dfcf60"),
        "title" : "The Big Lebowski",
        "year" : 1998,
        "rated" : "R",
        "released" : ISODate("1998-03-06T05:00:00Z"),
        "runtime" : 117,
        "countries" : [
                "USA",
                "UK"
        ],
        "genres" : [
                "Comedy",
                "Crime"
        ],
        "director" : "Joel Coen, Ethan Coen",
        "writers" : [
                "Ethan Coen",
                "Joel Coen"
        ],
        "actors" : [
                "Jeff Bridges",
                "John Goodman",
                "Julianne Moore",
                "Steve Buscemi"
        ],
        "plot" : "\"The Dude\" Lebowski, mistaken for a millionaire Lebowski, seeks restitution for his ruined rug and enlists his bowling buddies to help get it.",
        "poster" : "http://ia.media-imdb.com/images/M/MV5BMTQ0NjUzMDMyOF5BMl5BanBnXkFtZTgwODA1OTU0MDE@._V1_SX300.jpg",
        "imdb" : {
                "id" : "tt0118715",
                "rating" : 8.2,
                "votes" : 498368
        },
        "tomato" : {
                "meter" : 80,
                "image" : "certified",
                "rating" : 7.2,
                "reviews" : 87,
                "fresh" : 70,
                "consensus" : "Typically stunning visuals and sharp dialogue from the Coen Brothers, brought to life with strong performances from Goodman and Bridges.",
                "userMeter" : 94,
                "userRating" : 4,
                "userReviews" : 352473
        },
        "metacritic" : 69,
        "awards" : {
                "wins" : 3,
                "nominations" : 15,
                "text" : "3 wins & 15 nominations."
        },
        "type" : "movie"
}
{
        "_id" : ObjectId("5692a15424de1e0ce2dfcf98"),
        "title" : "Iron Man",
        "year" : 2008,
        "rated" : "PG-13",
        "released" : ISODate("2008-05-02T04:00:00Z"),
        "Don Heck",
        "runtime" : 126,
        "countries" : [
                "USA"
        ],
        "genres" : [
                "Action",
                "Adventure",
                "Sci-Fi"
        ],
        "director" : "Jon Favreau",
        "writers" : [
                "Mark Fergus",
                "Hawk Ostby",
                "Art Marcum",
                "Matt Holloway",
                "Stan Lee",
                "Larry Lieber",
                "Jack Kirby"
        ],
        "actors" : [
                "Robert Downey Jr.",
                "Terrence Howard",
                "Jeff Bridges",
                "Gwyneth Paltrow"
        ],
        "plot" : "After being held captive in an Afghan cave, an industrialist creates a unique weaponized suit of armor to fight evil.",
        "poster" : "http://ia.media-imdb.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_SX300.jpg",
        "imdb" : {
                "id" : "tt0371746",
                "rating" : 7.9,
                "votes" : 641369
        },
        "tomato" : {
                "meter" : 94,
                "image" : "certified",
                "rating" : 7.7,
                "reviews" : 266,
                "fresh" : 249,
                "consensus" : "Director Jon Favreau and star Robert Downey Jr. make this smart, high impact superhero movie one that even non-comics fans can enjoy.",
                "userMeter" : 91,
                "userRating" : 4.2,
                "userReviews" : 1072887
        },
        "metacritic" : 79,
        "awards" : {
                "wins" : 19,
                "nominations" : 58,
                "text" : "Nominated for 2 Oscars. Another 19 wins & 58 nominations."
        },
        "type" : "movie"
}

> db.movieDetails.find({"actors.0": "Jeff Bridges"}).count()
2

> var c = db.movieDetails.find();
> var doc = function() { return c.hasNext() ? c.next() : null;}
> c.objsLeftInBatch()
101
> doc()
> doc()
> doc()
> doc()
> c.objsLeftInBatch()
97

> db.movieDetails.find({rated:"PG"},{"title":1}).pretty()
> db.movieDetails.find({rated:"PG"},{"authors":0,"writers":0,_id:0}).pretty()
