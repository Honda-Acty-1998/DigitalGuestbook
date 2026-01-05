using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalGuestbook.Data;
using DigitalGuestbook.Models;

namespace WebApplication1.Controllers
{
    public class GuestbookEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestbookEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GuestbookEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entries.ToListAsync());
        }

        // GET: GuestbookEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbookEntry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestbookEntry == null)
            {
                return NotFound();
            }

            return View(guestbookEntry);
        }

        // GET: GuestbookEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GuestbookEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Message,DatePosted")] GuestbookEntry guestbookEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestbookEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guestbookEntry);
        }

        // GET: GuestbookEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbookEntry = await _context.Entries.FindAsync(id);
            if (guestbookEntry == null)
            {
                return NotFound();
            }
            return View(guestbookEntry);
        }

        // POST: GuestbookEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Message,DatePosted")] GuestbookEntry guestbookEntry)
        {
            if (id != guestbookEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestbookEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestbookEntryExists(guestbookEntry.Id))
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
            return View(guestbookEntry);
        }

        // GET: GuestbookEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbookEntry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestbookEntry == null)
            {
                return NotFound();
            }

            return View(guestbookEntry);
        }

        // POST: GuestbookEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestbookEntry = await _context.Entries.FindAsync(id);
            if (guestbookEntry != null)
            {
                _context.Entries.Remove(guestbookEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestbookEntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
