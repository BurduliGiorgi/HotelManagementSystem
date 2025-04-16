using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Feedback
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "UserId")]

        public string UserId { get; set; }
        [Display(Name = "User")]
        public Users User { get; set; }
        [Display(Name = "Rating")]

        public int Rating { get; set; }
        [Display(Name = "Comments")]
        public string Comments { get; set; }
        [Display(Name = "CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
