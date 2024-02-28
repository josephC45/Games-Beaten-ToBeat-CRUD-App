using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class GameUpdateRequest
    {
        [Required]
        public Guid GameID { get; set; }

        public string GameTitle { get; set; }

        public int TotalHoursToBeat {  get; set; }
        public int RemainingHoursToBeat { get; set; }

        public char GameRating {  get; set; }

        public bool GameCompleted {  get; set; }


        public Game ToGame()
        {
            return new Game()
            {
                GameID = GameID,
                GameTitle = this.GameTitle,
                TotalHoursToBeat = this.TotalHoursToBeat,
                RemainingHoursToBeat = this.RemainingHoursToBeat,
                GameRating = this.GameRating,
                GameCompleted = this.GameCompleted
            };
        }

    }
}
