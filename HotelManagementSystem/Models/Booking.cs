using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        [ForeignKey("GuestID")]
        public int GuestID { get; set; }
        [ForeignKey("RoomNumber")]
        public int RoomNumber { get; set; }
        public DateTime CheckinDate { get; set;}
        public DateTime CheckoutDate { get; set;}
        public decimal TotalPrice { get; set;}

    } }
