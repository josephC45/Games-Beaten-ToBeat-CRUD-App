using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly ApplicationDbContext _db;
        public GamesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Game> AddGame(Game game)
        {
            _db.Games.Add(game);
            await _db.SaveChangesAsync();
            return game;
        }


        public async Task<List<Game>> GetAllGames()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task<Game?> GetGameByGameID(Guid gameID)
        {
            return await _db.Games.FirstOrDefaultAsync(game => game.GameID == gameID);
        }
       
        public async Task<Game> UpdateGame(Game game)
        {
            Game matchingGame = await _db.Games.FirstAsync(g => g.GameID == game.GameID);
            matchingGame.GameTitle = game.GameTitle;
            matchingGame.TotalHoursToBeat = game.TotalHoursToBeat;
            matchingGame.RemainingHoursToBeat = game.RemainingHoursToBeat;
            matchingGame.GameRating = game.GameRating;
            matchingGame.GameCompleted = game.GameCompleted;
            await _db.SaveChangesAsync();
            return matchingGame;

        }

        public async Task<bool> DeleteGame(Guid gameID)
        {
            Game? gameToDelete = await _db.Games.FirstOrDefaultAsync(g => g.GameID == gameID);
            if (gameToDelete != null)
            {
                _db.Games.Remove(gameToDelete);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
