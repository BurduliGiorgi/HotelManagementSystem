using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        [ForeignKey("BookingID")]
        public int BookingID { get;set;}
        public decimal Amount { get;set;}
        public DateTime PaymentDate { get;set;}
        public string PaymentMethod { get;set;}
    }
}
