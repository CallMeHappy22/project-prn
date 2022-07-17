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
    public class ShowsController : Controller
    {
        private readonly CinemaContext _context;

        public ShowsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.Shows.Include(s => s.Film).Include(s => s.Room);
            ViewData["shows"] = await cinemaContext.ToListAsync();
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name");
            HttpContext.Session.SetString("showDate", DateTime.Now.ToString());
            HttpContext.Session.SetInt32("roomId", 1);
            Show show = new Show();
            show.ShowDate = DateTime.Now;
            
            return View(show);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Show show)
        {
            var cinemaContext = _context.Shows.Include(s => s.Film).Include(s => s.Room);
            ViewData["shows"] = await cinemaContext
                .Where(s => s.ShowDate == show.ShowDate
                && s.RoomId == show.RoomId
                && s.FilmId == show.FilmId)
                .ToListAsync();
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);
            HttpContext.Session.SetString("showDate", show.ShowDate.ToString());
            HttpContext.Session.SetInt32("roomId", show.RoomId);
            return View(show);
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Film)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public async Task<IActionResult> Create()
        {
            string date = HttpContext.Session.GetString("showDate");
            int id = (int)HttpContext.Session.GetInt32("roomId");
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title");
            ViewData["slot"] = await _context.Shows
                .Where(s => s.ShowDate == DateTime.Parse(date)
                && s.RoomId ==  id)
                .ToListAsync();
            Show show = new Show();
            show.ShowDate = DateTime.Parse(date);
            show.RoomId = id;
            return View(show);
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,RoomId,FilmId,ShowDate,Price,Status,Slot")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);
            
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            ViewData["slot"] = await _context.Shows
                .Where(s => s.ShowDate == show.ShowDate
                && s.RoomId == show.RoomId
                && s.FilmId == show.FilmId
                && s.Slot != show.Slot).ToListAsync();

            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);

            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowId,RoomId,FilmId,ShowDate,Price,Status,Slot")] Show show)
        {
            if (id != show.ShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowId))
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
            ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Title", show.FilmId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", show.RoomId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Film)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.ShowId == id);
        }
    }
}
