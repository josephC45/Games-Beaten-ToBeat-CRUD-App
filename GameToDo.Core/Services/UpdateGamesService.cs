using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services
{
    public class UpdateGamesService : IUpdateGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public UpdateGamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<GameResponse> UpdateGame(GameUpdateRequest gameUpdateRequest)
        {
            ValidationHelper.ModelValidation(gameUpdateRequest);
            Game matchingGame = await _gamesRepository.GetGameByGameID(gameUpdateRequest.GameID);

            matchingGame.GameTitle = gameUpdateRequest.GameTitle;
            matchingGame.TotalHoursToBeat = gameUpdateRequest.TotalHoursToBeat;
            matchingGame.RemainingHoursToBeat = gameUpdateRequest.RemainingHoursToBeat;
            matchingGame.GameRating = gameUpdateRequest.GameRating;
            matchingGame.GameCompleted = gameUpdateRequest.GameCompleted;

            await _gamesRepository.UpdateGame(matchingGame);
            return matchingGame.ToGameResponse();

        }
    }
}
