using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SE1616_Group5_Ass3.Models;

namespace SE1616_Group5_Ass3.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CinemaContext _context;

        public BookingsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index(int? id)
        {
            var cinemaContext = _context.Bookings.Where(b => b.ShowId == id);
            HttpContext.Session.SetInt32("id", (int)id);
            List<Booking> list = await cinemaContext.ToListAsync();
            List<int> ints = new List<int>();
            foreach (Booking booking in list)
            {
                for(int i = 0; i < booking.SeatStatus.Length; i++)
                {
                    if (booking.SeatStatus[i].ToString().Equals("1"))
                    {
                        ints.Add(i);
                    }
                }
            }
            ViewBag.id = id;
            ViewBag.list = ints;
            return View(await cinemaContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Booking book = _context.Bookings.Find(id);
            ViewBag.Name = book.Name;
            ViewBag.Amount = book.Amount;
            List<int> list = new List<int>();
            ViewBag.SeatStatus = book.SeatStatus;
            return View(book);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create()
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            var cinemaContext = _context.Bookings.Where(b => b.ShowId == id);
            List<Booking> list = await cinemaContext.ToListAsync();
            List<int> ints = new List<int>();
            foreach (Booking booking in list)
            {
                for (int i = 0; i < booking.SeatStatus.Length; i++)
                {
                    if (booking.SeatStatus[i].ToString().Equals("1"))
                    {
                        ints.Add(i);
                    }
                }
            }
            ViewBag.id = id;
            ViewBag.list = ints;
            HttpContext.Session.SetInt32("Amount", 0);
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,ShowId,Name,SeatStatus,Amount")] Booking booking, int? check)
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            var cinemaContext = _context.Bookings.Where(b => b.ShowId == id);
            List<Booking> list = await cinemaContext.ToListAsync();
            List<int> ints = new List<int>();
            int Amount = (int)HttpContext.Session.GetInt32("Amount");
            HttpContext.Session.SetInt32("Amount", Amount+10);
            foreach (Booking book in list)
            {
                for (int i = 0; i < book.SeatStatus.Length; i++)
                {
                    if (book.SeatStatus[i].ToString().Equals("1"))
                    {
                        ints.Add(i);
                    }
                }
            }
            ViewBag.id = id;
            ViewBag.list = ints;
            if (ModelState.IsValid && check == 1)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "ShowId", "ShowId", booking.ShowId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Booking book = _context.Bookings.Find(id);
            ViewBag.Name = book.Name;
            ViewBag.Amount = book.Amount;
            List<int> list = new List<int>();
            ViewBag.SeatStatus = book.SeatStatus;
            
            if (book == null)
            {
                return NotFound();
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "ShowId", "ShowId", book.ShowId);
            return View(book);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,ShowId,Name,SeatStatus,Amount")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "ShowId", "ShowId", booking.ShowId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Booking book = _context.Bookings.Find(id);
            ViewBag.Name = book.Name;
            ViewBag.Amount = book.Amount;
            List<int> list = new List<int>();
            ViewBag.SeatStatus = book.SeatStatus;
            
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
