using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Users : IdentityUser
    {
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        public Roles Role {get;set; }
        [Display(Name = "ProfileImageUrl")]
        public string ProfileImageUrl { get; set; }
        [Display(Name = "Hotels")]
        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public enum Roles { Admin, HotelOwner, Staff,Customer }
    }
}
