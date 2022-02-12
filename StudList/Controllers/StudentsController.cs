#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudList.Models;

namespace StudList.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplContext _context;

        public StudentsController(ApplContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            //var applContext = _context.Subjects.Include(s => s.Subject;
            //return View(await applContext.ToListAsync());
            return View(_context.Subjects.ToList());
        }


        // GET: Students/Create
        public IActionResult Create()
        {
            ViewBag.SubjectName = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public async Task<IActionResult> Create([Bind("Id,Name,Surname,MidName,Grade,SubjectId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/
        public IActionResult Create(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.SubjectName = new SelectList(_context.Subjects, "Id", "Name");
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            ViewBag.SubjectName = new SelectList(_context.Subjects, "Id", "Name");
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {

            return _context.Students.Any(e => e.Id == id);

        }
        public IActionResult Show(int id)
        {
            if (id != 0)
            {
                var students = (from student in _context.Students.Include(p => p.Subject)
                                where student.SubjectId == id
                                select student).ToList();
                return View(students);
            }
            else
                return RedirectToAction(nameof(allstud));
        }

        public IActionResult allstud()
        {
            StudentViewModel studentViewModel = new StudentViewModel
            {
                Students = _context.Students.ToList(),
                Subjects = _context.Subjects.ToList()
            };
            return View(studentViewModel);
        }
    }
}