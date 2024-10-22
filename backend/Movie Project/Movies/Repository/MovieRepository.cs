using Movies.DAL;
using Movies.Models;
using MoviesApp.Models;

namespace Movies.Repository
{
    public class MovieRepository:IMovieRepository
    {
        private readonly IMovieDAL _dal;
        public MovieRepository(IMovieDAL dal)
        {
            this._dal = dal;
        }


        public List<Movie> GetMovies()
        {
            return  _dal.GetMovies();
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            return _dal.GetMoviesByGenre(genre);
        }

        public List<Movie> GetMoviesBySearch(string searchQuery)
        {
            return _dal.GetMoviesBySearch(searchQuery);
        }




    }
}
