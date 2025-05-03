using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        public RoomCategory Category { get; set; }  

        public BedType Bed { get; set; }           

        public ViewType View { get; set; }         

        public string Description { get; set; }

        public decimal PricePerNight { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
    public enum RoomCategory { Standard, Deluxe, Suite, Family, Executive }
    public enum BedType { Single, Double, Queen, King, Twin, Bunk }
    public enum ViewType { None, Garden, City, Pool, Sea, Mountain }


}
