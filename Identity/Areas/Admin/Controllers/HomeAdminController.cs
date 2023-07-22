using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Data;
using Identity.Models;

namespace Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/HomeAdmin
        public async Task<IActionResult> Index()
        {
              return _context.AdminTest1 != null ? 
                          View(await _context.AdminTest1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AdminTest1'  is null.");
        }

        // GET: Admin/HomeAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminTest1 == null)
            {
                return NotFound();
            }

            var adminTest1 = await _context.AdminTest1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminTest1 == null)
            {
                return NotFound();
            }

            return View(adminTest1);
        }

        // GET: Admin/HomeAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HomeAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Email,Phone,Password,UserType")] AdminTest1 adminTest1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminTest1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminTest1);
        }

        // GET: Admin/HomeAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminTest1 == null)
            {
                return NotFound();
            }

            var adminTest1 = await _context.AdminTest1.FindAsync(id);
            if (adminTest1 == null)
            {
                return NotFound();
            }
            return View(adminTest1);
        }

        // POST: Admin/HomeAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Email,Phone,Password,UserType")] AdminTest1 adminTest1)
        {
            if (id != adminTest1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminTest1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminTest1Exists(adminTest1.Id))
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
            return View(adminTest1);
        }

        // GET: Admin/HomeAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminTest1 == null)
            {
                return NotFound();
            }

            var adminTest1 = await _context.AdminTest1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminTest1 == null)
            {
                return NotFound();
            }

            return View(adminTest1);
        }

        // POST: Admin/HomeAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminTest1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AdminTest1'  is null.");
            }
            var adminTest1 = await _context.AdminTest1.FindAsync(id);
            if (adminTest1 != null)
            {
                _context.AdminTest1.Remove(adminTest1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminTest1Exists(int id)
        {
          return (_context.AdminTest1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
