using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class GetGamesService : IGetGamesService
    {
        private readonly IGamesRepository _gamesRepository;
        public GetGamesService(IGamesRepository gamesRepository)
        {  
            _gamesRepository = gamesRepository;
        }

        public async Task<List<GameResponse>> GetAllGames()
        {
            var games = await _gamesRepository.GetAllGames();
            return games.Select(game => game.ToGameResponse()).ToList();
        }

        public Task<List<GameResponse>> GetFilteredGames(string searchBy, string? searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<GameResponse?> GetGameByGameId(Guid gameID)
        {
            var game = await _gamesRepository.GetGameByGameID(gameID);
            if (game == null) return null;
            return game.ToGameResponse();

        }
    }
}
