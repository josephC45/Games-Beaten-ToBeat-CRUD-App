using Entities;

namespace RepositoryContracts
{
    public interface IGamesRepository
    {
        Task<Game> AddGame(Game game);
        Task<List<Game>> GetAllGames();
        Task<Game> GetGameByGameID(Guid gameID);

        Task<Game> UpdateGame(Game game);
        Task<bool> DeleteGame(Guid gameID);

    }
}
