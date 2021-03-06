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
    public class DepartmentsController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public DepartmentsController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var schoolManagementDbContext = _context.departments.Include(d => d.School);
            return View(await schoolManagementDbContext.ToListAsync());
        }

        // GET: Departments/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.departments == null)
            {
                return NotFound();
            }

            var department = await _context.departments
                .Include(d => d.School)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["SchoolID"] = new SelectList(_context.schools, "SchoolID", "SchoolName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("DepartmentId,SchoolID,DepartmentName,Capacity,CreatedDate")] Department department)
        {
            var qr = from d in _context.departments
                     select d.Capacity;
            var sum_diff_department_capacity = qr.Sum();

            var qr2 = from d in _context.departments
                               join s in _context.schools
                               on d.SchoolID equals s.SchoolID
                               select s.Capacity;
            var max_capacity = qr2.FirstOrDefault();

            var empty_capacity = max_capacity - sum_diff_department_capacity;
            if(department.Capacity <= empty_capacity)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(department);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["SchoolID"] = new SelectList(_context.schools, "SchoolID", "SchoolID", department.SchoolID);
                return View(department);
            }
            else
            {
                ModelState.AddModelError("Capacity", "Sức chứa không hợp lệ");
                return View(department);
            }
        }

        // GET: Departments/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.departments == null)
            {
                return NotFound();
            }

            var department = await _context.departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["SchoolID"] = new SelectList(_context.schools, "SchoolID", "SchoolName", department.SchoolID);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,SchoolID,DepartmentName,Capacity,CreatedDate")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentId))
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
            ViewData["SchoolID"] = new SelectList(_context.schools, "SchoolID", "SchoolID", department.SchoolID);
            return View(department);
        }

        // GET: Departments/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.departments == null)
            {
                return NotFound();
            }

            var department = await _context.departments
                .Include(d => d.School)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.departments == null)
            {
                return Problem("Entity set 'SchoolManagementDbContext.departments'  is null.");
            }
            var department = await _context.departments.FindAsync(id);
            if (department != null)
            {
                _context.departments.Remove(department);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
          return (_context.departments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> IsAlreadyExist(string DepartmentName)
        {
            //check the department name is exists in the database.
            if (_context.departments.Any(x => x.DepartmentName.ToString() == DepartmentName))
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
