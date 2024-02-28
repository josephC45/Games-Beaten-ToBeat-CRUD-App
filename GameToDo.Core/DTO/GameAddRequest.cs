using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Used as the DTO for inserting a new Game
    /// </summary>
    public class GameAddRequest
    {
        [StringLength(50)]
        public string GameTitle { get; set; }

        [Range(1,300)]
        public int TotalHoursToBeat {  get; set; }

        [Range(1,300)]
        public int RemainingHoursToBeat { get; set; }

        [RegularExpression(@"[ETM]")]
        public char GameRating {  get; set; }

        public bool GameCompleted {  get; set; }

        public Game ToGame()
        {
            return new Game()
            {
                GameTitle = this.GameTitle,
                TotalHoursToBeat = this.TotalHoursToBeat,
                RemainingHoursToBeat = this.RemainingHoursToBeat,
                GameRating = this.GameRating
            };
        }
    }
}
