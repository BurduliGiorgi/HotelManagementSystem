using HotelManagementSystem.Models;

namespace HotelManagementSystem.IRepositories
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int? id);
        Task AddHotelAsync(Hotel hotel);
        Task UpdateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(int id);

    }
}
