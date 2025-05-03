using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

        [Required]
        public RoomStatus Status { get; set; } = RoomStatus.Available;

        public bool IsActive { get; set; } = true;

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public enum RoomStatus { Available, Booked, Maintenance }
    }
}