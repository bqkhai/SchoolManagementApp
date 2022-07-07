using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Controllers
{
    public class SchoolsController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public SchoolsController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: Schools
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
              return _context.schools != null ? 
                          View(await _context.schools.ToListAsync()) :
                          Problem("Entity set 'SchoolManagementDbContext.schools'  is null.");
        }

        // GET: Schools/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.schools == null)
            {
                return NotFound();
            }

            var school = await _context.schools
                .FirstOrDefaultAsync(m => m.SchoolID == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: Schools/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("SchoolID,SchoolName,FoundedTime,Capacity,Address")] School school)
        {
            if (ModelState.IsValid)
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }

        // GET: Schools/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.schools == null)
            {
                return NotFound();
            }

            var school = await _context.schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("SchoolID,SchoolName,FoundedTime,Capacity,Address")] School school)
        {
            if (id != school.SchoolID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolExists(school.SchoolID))
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
            return View(school);
        }

        // GET: Schools/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.schools == null)
            {
                return NotFound();
            }

            var school = await _context.schools
                .FirstOrDefaultAsync(m => m.SchoolID == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.schools == null)
            {
                return Problem("Entity set 'SchoolManagementDbContext.schools'  is null.");
            }
            var school = await _context.schools.FindAsync(id);
            if (school != null)
            {
                _context.schools.Remove(school);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolExists(int id)
        {
          return (_context.schools?.Any(e => e.SchoolID == id)).GetValueOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> IsAlreadyExist(string SchoolName)
        {
            //check the school name is exists in the database.
            if (_context.schools.Any(x => x.SchoolName == SchoolName))
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
