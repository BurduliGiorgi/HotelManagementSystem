using Microsoft.AspNetCore.Identity;

namespace HotelManagementSystem.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
