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
    public class ClassesController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public ClassesController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: Classes
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var schoolManagementDbContext = _context.classes.Include(c => c.Department);
            return View(await schoolManagementDbContext.ToListAsync());
        }

        // GET: Classes/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.classes == null)
            {
                return NotFound();
            }

            var @class = await _context.classes
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: Classes/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("ClassId,DepartmentID,ClassName,Capacity,CreatedDate")] Class @class)
        {
            var qr = from c in _context.classes
                     select c.Capacity;
            var sum_diff_class_capacity = qr.Sum();

            var qr2 = from c in _context.classes
                      join d in _context.departments
                      on c.DepartmentID equals d.DepartmentId
                      select d.Capacity;
            var max_capacity = qr2.FirstOrDefault();

            var empty_capacity = max_capacity - sum_diff_class_capacity;

            if (@class.Capacity <= empty_capacity)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(@class);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["DepartmentID"] = new SelectList(_context.departments, "DepartmentId", "DepartmentId", @class.DepartmentID);
                return View(@class);
            }
            else
            {
                ModelState.AddModelError("Capacity", "Sức chứa không hợp lệ");
                return View(@class);
            }
        }

        // GET: Classes/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.classes == null)
            {
                return NotFound();
            }

            var @class = await _context.classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.departments, "DepartmentId", "DepartmentName", @class.DepartmentID);
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,DepartmentID,ClassName,Capacity,CreatedDate")] Class @class)
        {
            if (id != @class.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.ClassId))
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
            ViewData["DepartmentID"] = new SelectList(_context.departments, "DepartmentId", "DepartmentId", @class.DepartmentID);
            return View(@class);
        }

        // GET: Classes/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.classes == null)
            {
                return NotFound();
            }

            var @class = await _context.classes
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.classes == null)
            {
                return Problem("Entity set 'SchoolManagementDbContext.classes'  is null.");
            }
            var @class = await _context.classes.FindAsync(id);
            if (@class != null)
            {
                _context.classes.Remove(@class);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
          return (_context.classes?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> IsAlreadyExist(string ClassName)
        {
            //check the class name is exists in the database.
            if (_context.classes.Any(x => x.ClassName == ClassName))
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
