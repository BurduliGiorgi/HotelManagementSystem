using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "UserId")]
        public string UserId { get; set; }
        [Display(Name = "User")]
        public Users User { get; set; }

        [Display(Name = "RoomId")]
        public int RoomId { get; set; }
        [Display(Name = "Room")]
        public Room Room { get; set; }
        [Display(Name = "CheckInDate")]

        public DateTime CheckInDate { get; set; }
        [Display(Name = "CheckOutDate")]
        public DateTime CheckOutDate { get; set; }

        [Display(Name = "Status")]
        public BookingStatus Status { get; set; }
        [Display(Name = "PaymentStatus")]
        public string PaymentStatus { get; set; }
        [Display(Name = "TotalPrice")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public enum BookingStatus { Pending, Confirmed, CheckedIn, CheckedOut, Canceled }

    }

}