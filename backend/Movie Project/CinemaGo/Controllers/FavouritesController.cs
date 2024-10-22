using CinemaGo.Models;
using CinemaGo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;

        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        // GET api/favourites/email/{email}
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var favorites = await _favouriteService.GetAllByEmailAsync(email);
            if (favorites == null || !favorites.Any())
                return Ok();

            return Ok(favorites);
        }

        // POST api/favourites
        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] FavoritesModel favorite)
        {
            if (favorite == null)
                return BadRequest("Invalid favorite data.");

            var createdFavorite = await _favouriteService.AddAsync(favorite);

            if (createdFavorite == null)
            {
                return Conflict("This movie is already in your favorites.");
            }

            return CreatedAtAction(nameof(GetByEmail), new { email = favorite.email }, createdFavorite);
        }

        // DELETE api/favourites/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, [FromQuery] string email)
        {
            var result = await _favouriteService.DeleteByIdAsync(id, email);
            if (!result)
                return NotFound("Favorite not found with the provided email and ID.");

            return NoContent();
        }
    }
}
