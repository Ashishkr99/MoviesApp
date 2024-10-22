using CinemaGo.Controllers;
using CinemaGo.Models;
using CinemaGo.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGo.Tests
{
    public class FavouritesControllerTests
    {
        private readonly Mock<IFavouriteService> _mockFavouriteService;
        private readonly FavouritesController _controller;

        public FavouritesControllerTests()
        {
            _mockFavouriteService = new Mock<IFavouriteService>();
            _controller = new FavouritesController(_mockFavouriteService.Object);
        }

        [Fact]
        public async Task GetByEmail_ShouldReturnOk_WhenFavoritesExist()
        {
            // Arrange
            var email = "test@example.com";
            var favourites = new List<FavoritesModel>
            {
                new FavoritesModel { id = "1", Title = "Movie 1", email = email }
            };

            _mockFavouriteService.Setup(service => service.GetAllByEmailAsync(email))
                .ReturnsAsync(favourites);

            // Act
            var result = await _controller.GetByEmail(email);

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(favourites);
        }

        [Fact]
        public async Task AddFavorite_ShouldReturnCreated_WhenFavoriteIsAdded()
        {
            // Arrange
            var favorite = new FavoritesModel { id = "1", Title = "Movie 1", email = "test@example.com" };

            _mockFavouriteService.Setup(service => service.AddAsync(favorite))
                .ReturnsAsync(favorite);

            // Act
            var result = await _controller.AddFavorite(favorite);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenFavoriteIsDeleted()
        {
            // Arrange
            var id = "1";
            var email = "test@example.com";

            _mockFavouriteService.Setup(service => service.DeleteByIdAsync(id, email))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(id, email);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}
