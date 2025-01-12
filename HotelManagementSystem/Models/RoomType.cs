using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace HotelManagementSystem.Models
{
    public class RoomType
    {
        [Key]
        public int TypeID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }

    }
}
