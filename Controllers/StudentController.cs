using app.web.Models;
using app.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext context;

        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var students = context.Students.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentDto studentDto)
        {
            if(!ModelState.IsValid)
            {
                return View(studentDto);
            }

            Student student = new Student()
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
            };

            context.Students.Add(student);

            context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        public IActionResult Edit(Guid id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index", "Student");
            }

            var studentDto = new StudentDto()
            {
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
            };

            ViewData["StudentId"] = student.Id;

            return View(studentDto);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, StudentDto studentDto)
        {

            var student = context.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index", "Student");
            }

            if(!ModelState.IsValid) {
                ViewData["StudentId"] = student.Id;
                return View(studentDto);
            }

            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.Phone = studentDto.Phone;

            context.SaveChanges();

            return RedirectToAction("Index", "Student");

        }

        public IActionResult Delete(Guid id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index", "Student");
            }

            context.Students.Remove(student);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Student");
        }

    }
}
