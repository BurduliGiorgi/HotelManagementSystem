using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Payment
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "BookingId")]
        public int BookingId { get; set; }
        [Display(Name = "Booking")]
        public Booking Booking { get; set; }
        [Display(Name = "Amount")]

        public decimal Amount { get; set; }
        [Display(Name = "Method")]
        public PaymentMethod Method { get; set; }
        [Display(Name = "Status")]
        public PaymentStatus Status { get; set; }
        [Display(Name = "PaymentDate")]
        public int HotelId { get; set; }
        [Display(Name = "Hotel")]
        public Hotel Hotel { get; set; }



        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public enum PaymentMethod { CreditCard, Cash, PayPal }
        public enum PaymentStatus { Pending, Completed, Failed }

    }

}
