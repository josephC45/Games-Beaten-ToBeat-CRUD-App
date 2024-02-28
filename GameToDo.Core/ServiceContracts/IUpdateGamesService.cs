using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IUpdateGamesService
    {
        Task<GameResponse> UpdateGame(GameUpdateRequest request);
    }
}
