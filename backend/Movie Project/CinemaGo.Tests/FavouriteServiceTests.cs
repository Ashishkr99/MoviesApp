using CinemaGo.Models;
using CinemaGo.Repository;
using CinemaGo.Services;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGo.Tests
{
    public class FavouriteServiceTests
    {
        private readonly Mock<IFavouriteRepository> _mockFavouriteRepository;
        private readonly FavouriteService _favouriteService;

        public FavouriteServiceTests()
        {
            _mockFavouriteRepository = new Mock<IFavouriteRepository>();
            _favouriteService = new FavouriteService(_mockFavouriteRepository.Object);
        }

        [Fact]
        public async Task GetAllByEmail_ShouldReturnFavorites()
        {
            // Arrange
            var email = "test@example.com";
            var favourites = new List<FavoritesModel>
            {
                new FavoritesModel { id = "1", Title = "Movie 1", email = email }
            };

            _mockFavouriteRepository.Setup(repo => repo.GetAllByEmailAsync(email))
                .ReturnsAsync(favourites);

            // Act
            var result = await _favouriteService.GetAllByEmailAsync(email);

            // Assert
            result.Should().BeEquivalentTo(favourites);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnFavorite_WhenNotDuplicate()
        {
            // Arrange
            var favorite = new FavoritesModel { id = "1", Title = "Movie 1", email = "test@example.com" };

            _mockFavouriteRepository.Setup(repo => repo.IsFavoriteExistsAsync(favorite.email, It.IsAny<string>(), favorite.Title))
     .ReturnsAsync(false);

            _mockFavouriteRepository.Setup(repo => repo.AddAsync(favorite))
                .ReturnsAsync(favorite);

            // Act
            var result = await _favouriteService.AddAsync(favorite);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(favorite);
        }

        [Fact]
        public async Task DeleteByIdAsync_ShouldReturnTrue_WhenFavoriteIsDeleted()
        {
            // Arrange
            var id = "1";
            var email = "test@example.com";

            _mockFavouriteRepository.Setup(repo => repo.IsFavoriteExistsAsync(email, id ,null))
               .ReturnsAsync(true);

            _mockFavouriteRepository.Setup(repo => repo.DeleteByIdAsync(id, email))
                .ReturnsAsync(true);

            // Act
            var result = await _favouriteService.DeleteByIdAsync(id, email);

            // Assert
            result.Should().BeTrue();
        }
    }
}
