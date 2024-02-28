using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IDeleteGamesService
    {
        Task<bool> DeleteGame(GameUpdateRequest gameRequestToDelete);
    }
}
