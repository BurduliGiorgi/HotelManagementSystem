using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Users : IdentityUser
    {
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        public enum Roles {Admin,Owner,Staff,Customer }
        [Display(Name = "ProfileImageUrl")]
        public string ProfileImageUrl { get; set; }
        [Display(Name = "Hotels")]
        public ICollection<Hotel> Hotels { get; set; }
    }
}
