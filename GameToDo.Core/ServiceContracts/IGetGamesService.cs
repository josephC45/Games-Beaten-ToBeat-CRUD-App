using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IGetGamesService
    {
        Task<List<GameResponse>> GetAllGames();
        Task<List<GameResponse>> GetFilteredGames(string searchBy, string? searchString);
        Task<GameResponse> GetGameByGameId(Guid gameID);
    }
}
