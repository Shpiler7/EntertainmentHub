using EntertainmentHub.Api.Models;
using EntertainmentHub.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentHub.Api.Controllers
{
    public class GameController(IGameRepository gameRepository) : ControllerBase
    {
        public async Task<Game> GetGameAsync(IGameRepository mockRepositoryObject)
        {
            throw new NotImplementedException();
        }
    }
}
