using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Game 
    {
        [Key]
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
    }
}
