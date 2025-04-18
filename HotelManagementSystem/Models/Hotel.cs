using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Hotel
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "ContactNumber")]
        public string ContactNumber { get; set; }
        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; } = "";

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Staff> StaffMembers { get; set; }
    }

}
