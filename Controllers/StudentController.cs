using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbcontext;
        public StudentController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (ModelState.IsValid)
            {

                var st= new Student
                {
                    Name = student.Name,
                     department=student.department,
                     semester = student.semester,
                     Age = student.Age,
                     Fees = student.Fees,
                };
                await dbcontext.students.AddAsync(student);
                await dbcontext.SaveChangesAsync();
                return RedirectToAction("Add", "Student");
            }
            else
            {
                return View(student);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Show()
        {
            var student = await dbcontext.students.ToListAsync();
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var st = await dbcontext.students.FirstOrDefaultAsync(kamal => kamal.Id == id);
            return View(st);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(Student st)
        {
            if (ModelState.IsValid)
            {
                var stud = await dbcontext.students.FindAsync(st.Id);
                if (stud is not null)
                {
                    stud.Name = st.Name;
                    stud.department = st.department;
                    stud.Age = st.Age;
                    stud.semester= st.semester;
                    await dbcontext.SaveChangesAsync();

                }
                return RedirectToAction("Show", "Student");

            }
            else
            {
                return View(st);
            }
        }
    }
}
