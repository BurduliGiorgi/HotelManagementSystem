using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Staff
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Role")]
        public string Role { get; set; }
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }
        [Display(Name = "Shift")]
        public ShiftType Shift { get; set; }
        [Display(Name = "HotelId")]
        public int HotelId { get; set; }
        [Display(Name = "Hotel")]
        public Hotel Hotel { get; set; }
        public string UserId { get; set; }  
        public Users User { get; set; }
        public enum ShiftType { Morning, Evening, Night }
    }

}