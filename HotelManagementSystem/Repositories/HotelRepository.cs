using HotelManagementSystem.Data;
using HotelManagementSystem.IRepositories;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Repositories
{
    public class HotelRepository: IHotelRepository
    {
        private readonly AppDbContext _context;
        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var hotel = await _context.Hotels
                   //.Include(h => h.StaffMembers)
                   //.Include(h => h.Rooms)
                   .FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return null;
            }

            return hotel;
        }
        
        public async Task AddHotelAsync(Hotel hotel)
        {
                _context.Hotels.Add(hotel);
                await _context.SaveChangesAsync();
        }            
        public async Task UpdateHotelAsync(Hotel hotel)
        {
           _context.Update(hotel);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteHotelAsync(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            _context.Remove(hotel);
        }


        public Task<List<Hotel>> GetTopThreeHotel()
        {
            throw new NotImplementedException();

        }


    }
    
    }

