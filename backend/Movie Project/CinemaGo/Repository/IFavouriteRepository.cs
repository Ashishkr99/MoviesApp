using CinemaGo.Models;

namespace CinemaGo.Repository
{
    public interface IFavouriteRepository
    {
        Task<IEnumerable<FavoritesModel>> GetAllByEmailAsync(string email);
        Task<FavoritesModel> AddAsync(FavoritesModel favorite);
        Task<bool> DeleteByIdAsync(string id, string email);
        Task<bool> IsFavoriteExistsAsync(string email, string id = null, string title = null);
    }
}
