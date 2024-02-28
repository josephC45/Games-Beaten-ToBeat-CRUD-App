using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IAddGamesService
    {
        Task<GameResponse> AddGame(GameAddRequest? request);
    }
}
