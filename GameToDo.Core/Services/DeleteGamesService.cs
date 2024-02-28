using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class DeleteGamesService : IDeleteGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public DeleteGamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;

        }

        public async Task<bool> DeleteGame(GameUpdateRequest gameRequestToDelete)
        {
            Game game = gameRequestToDelete.ToGame();
            bool wasDeleted = await _gamesRepository.DeleteGame(game.GameID);
            return wasDeleted;
        }
    }
}
