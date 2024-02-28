using Entities; 
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services
{
    public class AddGamesService : IAddGamesService 
    {
        private readonly IGamesRepository _gamesRepository;
        public AddGamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<GameResponse> AddGame(GameAddRequest? gameAddRequest)
        {
            if (gameAddRequest == null) throw new ArgumentNullException(nameof(gameAddRequest));

            //Model validation
            ValidationHelper.ModelValidation(gameAddRequest);

            //Convert gameaddrequest to game type
            Game game = gameAddRequest.ToGame();
            //generate gameID
            game.GameID = Guid.NewGuid();

            //Add game to db
            //make call to repository(repository connects to db) to add game to db
            await _gamesRepository.AddGame(game);

            //Convert game to gameresponse 
            return game.ToGameResponse();
        }

    }
}
