using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        [ForeignKey("HotelID")]
        public int HotelID { get;set;}
        [MaxLength(50)]
        public string FirstName { get;set;}
        [MaxLength(50)]
        public string LastName { get;set;}
        [MaxLength(50)]
        public string Email { get;set;}
        [MaxLength(50)]
        public string Position { get;set;}

        public decimal Salary { get;set;}
        public DateTime DateOfBirth { get;set;}
        [MaxLength(50)]
        public string Phone { get;set;}
        public DateTime HireDate { get;set;}
    }
}
