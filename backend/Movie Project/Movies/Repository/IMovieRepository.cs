using Movies.Models;
using MoviesApp.Models;
using System.Collections.Generic;

namespace Movies.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();

        List<Movie> GetMoviesByGenre(string genre);

        List<Movie> GetMoviesBySearch(string searchQuery);
    }
}
