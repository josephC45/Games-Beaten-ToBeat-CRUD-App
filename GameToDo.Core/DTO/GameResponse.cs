using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents DTO class that is used as a return type of most methods of the Games Service. It is what we are returning to the view.
    /// </summary>
    public class GameResponse
    {
        public Guid GameID { get; set; }
        [StringLength(50)]
        public string GameTitle { get; set; }

        [Range(1,300)]
        public int TotalHoursToBeat {  get; set; }

        [Range(1,300)]
        public int RemainingHoursToBeat { get; set; }

        [RegularExpression(@"[ETM]")]
        public char GameRating {  get; set; }
        public bool GameCompleted {  get; set; }


        public GameUpdateRequest ToGameUpdateRequest()
        {
            return new GameUpdateRequest()
            {
                GameID = GameID,
                GameTitle = GameTitle,
                TotalHoursToBeat = TotalHoursToBeat,
                RemainingHoursToBeat = RemainingHoursToBeat,
                GameRating = GameRating,
                GameCompleted = GameCompleted
            };
        } 
    }

    public static class GameExtension
    {
        public static GameResponse ToGameResponse(this Game game)
        {
            return new GameResponse()
            {
                GameID = game.GameID,
                GameTitle = game.GameTitle,
                TotalHoursToBeat = game.TotalHoursToBeat,
                RemainingHoursToBeat = game.RemainingHoursToBeat,
                GameRating = game.GameRating,
                GameCompleted = game.GameCompleted
            };
        }
    }
}
