using EntertainmentHub.Api.Models;

namespace EntertainmentHub.Api.Repositories
{
    public interface IGameRepository
    {
        Task<Game?> GetGameAsync(string gameTitle);
    }
}
