using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentMangementApp.MVC.Data;

namespace StudentMangementApp.MVC.Controllers
{
    [Authorize]
    public class ClassesController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public ClassesController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var schoolManagementDbContext = _context.Classes.Include(q => q.Course).Include(q => q.Lecturer);
            return View(await schoolManagementDbContext.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var qclass = await _context.Classes
                .Include(q => q.Course)
                .Include(q => q.Lecturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qclass == null)
            {
                return NotFound();
            }

            return View(qclass);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            var courses = _context.Courses.Select(c => new
            {
                CourseName = $"{c.Code} - {c.Name} ({c.Credits} Credits)",
                c.Id
            });
            ViewData["CourseId"] = new SelectList(courses, "Id", "CourseName");
            var lecturers = _context.Lecturers.Select(p => new
            {
                FullName = $"{p.FirstName} {p.LastName}",
                p.Id
            });
            ViewData["LecturerId"] = new SelectList(lecturers, "Id", "FullName");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LecturerId,CourseId,Time")] Class qclass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qclass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", qclass.CourseId);
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "Id", qclass.LecturerId);
            return View(qclass);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var qclass = await _context.Classes.FindAsync(id);
            if (qclass == null)
            {
                return NotFound();
            }
            var courses = _context.Courses.Select(c => new
            {
                CourseName = $"{c.Code} - {c.Name} ({c.Credits} Credits)",
                c.Id
            });
            ViewData["CourseId"] = new SelectList(courses, "Id", "CourseName", qclass.CourseId);
            var lecturers = _context.Lecturers.Select(p => new
            {
                FullName = $"{p.FirstName} {p.LastName}",
                p.Id
            });
            ViewData["LecturerId"] = new SelectList(lecturers, "Id", "FullName", qclass.LecturerId);
            return View(qclass);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LecturerId,CourseId,Time")] Class qclass)
        {
            if (id != qclass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qclass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(qclass.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", qclass.CourseId);
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "Id", qclass.LecturerId);
            return View(qclass);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var qclass = await _context.Classes
                .Include(q => q.Course)
                .Include(q => q.Lecturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qclass == null)
            {
                return NotFound();
            }

            return View(qclass);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'SchoolManagementDbContext.Classes'  is null.");
            }
            var qclass = await _context.Classes.FindAsync(id);
            if (qclass != null)
            {
                _context.Classes.Remove(qclass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
          return (_context.Classes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
