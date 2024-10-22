using Movies.Models;
using Movies.Repository;
using Microsoft.Extensions.Logging;
using MoviesApp.Models;

namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository repository;

        public MovieService(IMovieRepository repo)
        {
            this.repository = repo;
        }

        public List<Movie> GetMovies()
        {
            return repository.GetMovies();
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            return repository.GetMoviesByGenre(genre);
        }

        public List<Movie> GetMoviesBySearch(string searchQuery)
        {
            return repository.GetMoviesBySearch(searchQuery);
        }


    }
}
