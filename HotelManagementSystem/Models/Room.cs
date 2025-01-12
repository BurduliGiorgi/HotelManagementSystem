using System.Security.Cryptography.Xml;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }
        [ForeignKey("HotelID")]
        public int HotelID { get; set; }
        [ForeignKey("TypeID")]
        public int TypeID { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }

    }
}
