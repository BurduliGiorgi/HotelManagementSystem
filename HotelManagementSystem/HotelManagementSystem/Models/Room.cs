using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "RoomNumber")]
        public string RoomNumber { get; set; }

        [Required]
        [Display(Name = "Type")]
        public RoomType Type { get; set; }

        [Required]
        [Display(Name = "Status")]
        public RoomStatus Status { get; set; }
        [Display(Name = "Features")]

        public string Features { get; set; }
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; }
        [Display(Name = "HotelId")]

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public enum RoomType { Standard, Deluxe, Suite }
        public enum RoomStatus { Available, Booked, Maintenance }

    }


    public class RoomType : Room
    {
        [Display(Name = "Name")]
        public  string Name   {get;set;}
        [Display(Name = "Description")]
        public  string Description  {get;set;}
        [Display(Name = "PricePerNight")]
        public  decimal  PricePerNight {get;set;}
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }
}
}