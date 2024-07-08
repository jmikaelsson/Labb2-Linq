using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb2_Linq.Data;
using Labb2_Linq.Models;

namespace Labb2_Linq.Controllers
{
    public class TeacherCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherCourses.Include(t => t.Course).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: TeacherCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName");
            return View();
        }

        // POST: TeacherCourses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,CourseId")] TeacherCourse teacherCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", teacherCourse.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName", teacherCourse.TeacherId);
            return View(teacherCourse);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int teacherId, int courseId)
        {
            if (teacherId == 0 || courseId == 0)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses.FindAsync(teacherId, courseId);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", teacherCourse.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName", teacherCourse.TeacherId);
            return View(teacherCourse);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int teacherId, int courseId, [Bind("TeacherId,CourseId")] TeacherCourse teacherCourse)
        {
            if (teacherId != teacherCourse.TeacherId || courseId != teacherCourse.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherCourseExists(teacherCourse.TeacherId, teacherCourse.CourseId))
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

            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", teacherCourse.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherFirstName", teacherCourse.TeacherId);
            return View(teacherCourse);
        }



        // GET: TeacherCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherCourse = await _context.TeacherCourses
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherId == id);

            if (teacherCourse == null)
            {
                return NotFound();
            }

            return View(teacherCourse);
        }

        // POST: TeacherCourses/Delete/5
        [HttpPost("TeacherCourses/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherCourse = await _context.TeacherCourses.FindAsync(id);
            if (teacherCourse != null)
            {
                _context.TeacherCourses.Remove(teacherCourse);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherCourseExists(int teacherId, int courseId)
        {
            return _context.TeacherCourses.Any(e => e.TeacherId == teacherId && e.CourseId == courseId);
        }

    }
}
