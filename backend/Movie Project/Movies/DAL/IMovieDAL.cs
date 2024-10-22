using System.Collections.Generic;
using Movies.Models;
using MoviesApp.Models;

namespace Movies.DAL
{
    public interface IMovieDAL
    {
        List<Movie> GetMovies();

        List<Movie> GetMoviesByGenre(string genre);

        List<Movie> GetMoviesBySearch(string searchQuery);

    }
}
