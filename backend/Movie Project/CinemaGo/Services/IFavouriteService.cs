using CinemaGo.Models;

namespace CinemaGo.Services
{
    public interface IFavouriteService
    {
        Task<IEnumerable<FavoritesModel>> GetAllByEmailAsync(string email);
        Task<FavoritesModel> AddAsync(FavoritesModel favorite);
        Task<bool> DeleteByIdAsync(string id, string email);

    }
}
