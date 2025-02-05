using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class HotelImages
    {
        [ForeignKey("HotelID")]
        public int HotelID { get; set; }
        [Required]
        public string HotelImageUrl { get; set; }
    }
}
