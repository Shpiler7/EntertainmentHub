using EntertainmentHub.Api.Controllers;
using EntertainmentHub.Api.Models;
using EntertainmentHub.Api.Repositories;
using Moq;

namespace EntertainmentHub.Tests
{
    public class GameControllerTest
    {
        [Fact]
        public async Task GetGameAsync_WithValidInput_ReturnsGame()
        {
            //arrange
            var expectedGame = new Game("Baldur's Gate 3");

            var mockRepository = new Mock<IGameRepository>();
            mockRepository.Setup(x => x.GetGameAsync(It.IsAny<string>())).ReturnsAsync(expectedGame);
            var gameController = new GameController(mockRepository.Object);

            //act
            var result = await gameController.GetGameAsync(mockRepository.Object);

            //assert
            mockRepository.Verify(x => x.GetGameAsync(It.IsAny<string>()), Times.Once);
            Assert.Equal(expectedGame, result);
        }
    }
}
