using Microsoft.EntityFrameworkCore;

namespace CinemaGo.Models
{
    public class FavoriteMovieDataContext : DbContext
    {
        public FavoriteMovieDataContext (DbContextOptions<FavoriteMovieDataContext> options)
        : base(options)
        {

        }
        public DbSet<FavoritesModel> FavMovies { get; set; }
    }
}
