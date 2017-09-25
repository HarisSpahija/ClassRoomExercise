using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly AdContext _context;

        public AdvertisementController(AdContext context)
        {
            _context = context;
        }

        // GET: test2
        public async Task<IActionResult> Index()
        {
            var adContext = _context.Ads.Include(a => a.Category);
            return View(await adContext.ToListAsync());
        }

        // GET: test2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Ads
                .Include(a => a.Category)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // GET: test2/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name");
            return View();
        }

        // POST: test2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Price,CategoryId")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertisement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name", advertisement.CategoryId);
            return View(advertisement);
        }

        // GET: test2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Ads.SingleOrDefaultAsync(m => m.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name", advertisement.CategoryId);
            return View(advertisement);
        }

        // POST: test2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Price,CategoryId")] Advertisement advertisement)
        {
            if (id != advertisement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertisement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisementExists(advertisement.ID))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name", advertisement.CategoryId);
            return View(advertisement);
        }

        // GET: test2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Ads
                .Include(a => a.Category)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: test2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisement = await _context.Ads.SingleOrDefaultAsync(m => m.ID == id);
            _context.Ads.Remove(advertisement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(int id)
        {
            return _context.Ads.Any(e => e.ID == id);
        }
    }
}
