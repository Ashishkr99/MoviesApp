using CinemaGo.Models;
using CinemaGo.Repository;

namespace CinemaGo.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;

        public FavouriteService(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }

        public async Task<IEnumerable<FavoritesModel>> GetAllByEmailAsync(string email)
        {
            return await _favouriteRepository.GetAllByEmailAsync(email);
        }

        public async Task<FavoritesModel> AddAsync(FavoritesModel favorite)
        {
            // Check if the movie already exists for this email and title
            var existingFavorite = await _favouriteRepository.IsFavoriteExistsAsync(favorite.email, null, favorite.Title);
            if (existingFavorite)
            {
                return null;  // Indicate a duplicate exists
            }

            return await _favouriteRepository.AddAsync(favorite);
        }

        public async Task<bool> DeleteByIdAsync(string id, string email)
        {
            // Ensure the favorite exists for the given id and email before deleting
            var exists = await _favouriteRepository.IsFavoriteExistsAsync(email, id);
            if (!exists)
            {
                return false;  // Not found
            }

            return await _favouriteRepository.DeleteByIdAsync(id, email);
        }
    }
}
