using Microsoft.AspNetCore.StaticFiles;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Logo_Url {  get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
        [Required]

        public int Stars { get; set; }

        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime{ get; set; }

        public List<Staff> Staffs { get; set; } = [];
    }
}