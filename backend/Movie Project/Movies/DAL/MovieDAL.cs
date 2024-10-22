using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Movies.Models;
using MoviesApp.Models;

namespace Movies.DAL
{
    public class MovieDAL : IMovieDAL
    {
        private readonly MovieDbContext _dbContext;

        // Constructor to inject both MovieDbContext and FavMovieDbContext
        public MovieDAL(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Method to get all movies
        public List<Movie> GetMovies()
        {
            return _dbContext.Movies.Find(_ => true).ToList(); // Fetch all movies from the Movies collection
        }


        public List<Movie> GetMoviesByGenre(string genre)
        {
            return _dbContext.Movies.Find(movie => movie.Genre.Contains(genre)).ToList();

        }

        public List<Movie> GetMoviesBySearch(string searchQuery)
        {
            var filter = Builders<Movie>.Filter.Regex("Title", new MongoDB.Bson.BsonRegularExpression(searchQuery, "i"));

            return _dbContext.Movies.Find(filter).ToList();
        }








    }
}
