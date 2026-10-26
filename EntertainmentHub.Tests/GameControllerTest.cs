using EntertainmentHub.Api.Controllers;
using EntertainmentHub.Api.Models;
using EntertainmentHub.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EntertainmentHub.Tests
{
    public class GameControllerTest
    {
        [Fact]
        public async Task GetGameAsync_WithValidInput_ReturnsGame()
        {
            //arrange
            const string gameTitle = "Baldur's Gate 3";
            var expectedGame = new Game(gameTitle);
            var mockRepository = new Mock<IGameRepository>();
            mockRepository.Setup(x => x.GetGameAsync(gameTitle)).ReturnsAsync(expectedGame);
            var gameController = new GameController(mockRepository.Object);

            //act
            var result = await gameController.GetGameAsync(gameTitle);

            //assert
            mockRepository.Verify(x => x.GetGameAsync(gameTitle), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedGame, okResult.Value);
        }

        [Fact]
        public async Task GetGameAsync_WithInvalidInput_ReturnsNotFound()
        {
            //arrange
            const string gameTitle = "Diablo VI";
            var mockRepository = new Mock<IGameRepository>();
            mockRepository.Setup(x => x.GetGameAsync(gameTitle)).ReturnsAsync((Game?)null);
            var gameController = new GameController(mockRepository.Object);

            //act
            var result = await gameController.GetGameAsync(gameTitle);

            //assert
            mockRepository.Verify(x => x.GetGameAsync(gameTitle), Times.Once);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetGameAsync_WithException_ThrowsException()
        {
            //arrange
            const string gameTitle = "Goat Simulator 2";
            var mockRepository = new Mock<IGameRepository>();
            mockRepository.Setup(x => x.GetGameAsync(gameTitle)).ThrowsAsync(new Exception("Database error"));
            var gameController = new GameController(mockRepository.Object);

            //act & assert
            mockRepository.Verify(x => x.GetGameAsync(gameTitle), Times.Once);
            await Assert.ThrowsAsync<Exception>(async () => await gameController.GetGameAsync(gameTitle));
        }
    }
}
