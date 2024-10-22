using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Services;
using MoviesApp.Models;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        
        [HttpGet]
        public ActionResult<List<Movie>> GetMovies()
        {
            try
            {
                var movies = _movieService.GetMovies();
                if (movies == null || movies.Count == 0)
                {
                    return NotFound(new { Message = "No movies found." });
                }

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "An error occurred while retrieving movies.", Details = ex.Message });
            }
        }




        [HttpGet("genre/{genre}")]
        public ActionResult<List<Movie>> GetMoviesByGenre(string genre)
        {
            try
            {
                var movies = _movieService.GetMoviesByGenre(genre);
                if (movies == null || movies.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Status = 500,
                        message = $"No movies found for genre: {genre}.",
       
                    });
                    //return NotFound(new { Message = $"No movies found for genre: {genre}." });
                }

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "An error occurred while retrieving movies by genre.", Details = ex.Message });
            }
        }




        [HttpGet("search/{searchQuery}")]
        public ActionResult<List<Movie>> GetMoviesBySearch(string searchQuery)
        {
            try
            {
                var movies = _movieService.GetMoviesBySearch(searchQuery);

                // Check if the search result is null or contains no items
                if (movies == null || movies.Count == 0)
                {
                    return NotFound(new
                    {
                        Status = 404,
                        Message = $"No movies found for search query: '{searchQuery}'."
                    });
                }

                // Return the list of movies if found
                return Ok(new
                {
                    Status = 200,
                    Message = "Movies found",
                    Movies = movies
                });
            }
            catch (Exception ex)
            {
                // Return a 500 error with exception details
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    Status = 500,
                    Message = "An error occurred while searching for movies.",
                    Error = ex.Message
                });
            }
        }




    }

    
}
