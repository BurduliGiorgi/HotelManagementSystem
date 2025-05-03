using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using HotelManagementSystem.IRepositories;

namespace HotelManagementSystem.Controllers
{
    public class HotelController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHotelRepository _hotelRepository;

        public HotelController(AppDbContext context, IHotelRepository hotelIRepository)
        {
            _context = context;
            _hotelRepository = hotelIRepository;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();
            return View(hotels);
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                   .Include(h => h.StaffMembers)
                   .Include(h => h.Rooms)
                   .FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            await _hotelRepository.AddHotelAsync(hotel);
            return RedirectToAction("Index");
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Hotel hotel)
        {
            await _hotelRepository.UpdateHotelAsync(hotel);
            return RedirectToAction("Index");
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _hotelRepository.DeleteHotelAsync(id);
            return RedirectToAction("Index");
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
