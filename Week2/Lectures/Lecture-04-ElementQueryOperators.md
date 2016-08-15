https://docs.mongodb.com/manual/reference/operator/query-element/
> db.movieDetails.find({ "tomato.meter":{$exists:true}}).count()
362
> db.moviesScratch.find({"_id":{$type:"string"}}).pretty()
{
        "_id" : "tt0084726",
        "title" : "Star Trek II: The Wrath of Khan",
        "year" : 1982,
        "type" : "movie"
}
{
        "_id" : "tt0117731",
        "title" : "Star Trek: First Contact",
        "year" : 1996,
        "type" : "movie"
}
{
        "_id" : "tt0796366",
        "title" : "Star Trek",
        "year" : 2009,
        "type" : "movie"
}
{
        "_id" : "tt1408101",
        "title" : "Star Trek Into Darkness",
        "year" : 2013,
        "type" : "movie"
}
