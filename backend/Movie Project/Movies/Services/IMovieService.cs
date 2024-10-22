using System.Collections.Generic;
using Movies.Models;
using MoviesApp.Models;

namespace Movies.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovies();

        List<Movie> GetMoviesByGenre(string genre);

        List<Movie> GetMoviesBySearch(string searchQuery);

    }
}
