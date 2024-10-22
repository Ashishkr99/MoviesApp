using CinemaGo.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaGo.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly FavoriteMovieDataContext _context;

        public FavouriteRepository(FavoriteMovieDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FavoritesModel>> GetAllByEmailAsync(string email)
        {
            return await _context.Set<FavoritesModel>().Where(f => f.email == email).ToListAsync();
        }

        public async Task<FavoritesModel> AddAsync(FavoritesModel favorite)
        {
            // Check if favorite already exists by email and title
            bool exists = await IsFavoriteExistsAsync(favorite.email, null, favorite.Title);
            if (exists)
            {
                return null;  // Return null to indicate it's a duplicate
            }

            await _context.Set<FavoritesModel>().AddAsync(favorite);
            await _context.SaveChangesAsync();
            return favorite;
        }

        public async Task<bool> DeleteByIdAsync(string id, string email)
        {
            // Check if the favorite exists by id and email
            var entity = await _context.Set<FavoritesModel>().FirstOrDefaultAsync(f => f.id == id && f.email == email);
            if (entity != null)
            {
                _context.Set<FavoritesModel>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> IsFavoriteExistsAsync(string email, string id = null, string title = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return await _context.Set<FavoritesModel>().AnyAsync(f => f.email == email && f.id == id);
            }

            if (!string.IsNullOrEmpty(title))
            {
                return await _context.Set<FavoritesModel>().AnyAsync(f => f.email == email && f.Title == title);
            }

            return false;
        }
    }
}
