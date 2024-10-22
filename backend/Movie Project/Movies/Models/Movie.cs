using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesApp.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id")]
        public string MovieId { get; set; }

        [BsonElement("rank")]
        public int Rank { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }

        [BsonElement("big_image")]
        public string BigImage { get; set; }

        [BsonElement("genre")]
        public List<string> Genre { get; set; }

        [BsonElement("thumbnail")]
        public string Thumbnail { get; set; }

        [BsonElement("rating")]
        public double Rating { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("trailer_embed_link")]
        public string TrailerLink { get; set; }

    }
}
