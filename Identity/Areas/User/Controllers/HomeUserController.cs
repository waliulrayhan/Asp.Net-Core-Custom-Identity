using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Data;
using Identity.Models;

namespace Identity.Areas.User.Controllers
{
    [Area("User")]
    public class HomeUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/HomeUser
        public async Task<IActionResult> Index()
        {
              return _context.UserTest1 != null ? 
                          View(await _context.UserTest1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserTest1'  is null.");
        }

        // GET: User/HomeUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserTest1 == null)
            {
                return NotFound();
            }

            var userTest1 = await _context.UserTest1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTest1 == null)
            {
                return NotFound();
            }

            return View(userTest1);
        }

        // GET: User/HomeUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/HomeUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Phone,Subject,Description,Reference")] UserTest1 userTest1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTest1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTest1);
        }

        // GET: User/HomeUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserTest1 == null)
            {
                return NotFound();
            }

            var userTest1 = await _context.UserTest1.FindAsync(id);
            if (userTest1 == null)
            {
                return NotFound();
            }
            return View(userTest1);
        }

        // POST: User/HomeUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Phone,Subject,Description,Reference")] UserTest1 userTest1)
        {
            if (id != userTest1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTest1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTest1Exists(userTest1.Id))
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
            return View(userTest1);
        }

        // GET: User/HomeUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserTest1 == null)
            {
                return NotFound();
            }

            var userTest1 = await _context.UserTest1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTest1 == null)
            {
                return NotFound();
            }

            return View(userTest1);
        }

        // POST: User/HomeUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserTest1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserTest1'  is null.");
            }
            var userTest1 = await _context.UserTest1.FindAsync(id);
            if (userTest1 != null)
            {
                _context.UserTest1.Remove(userTest1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTest1Exists(int id)
        {
          return (_context.UserTest1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
