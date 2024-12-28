﻿using Microsoft.AspNetCore.Mvc;
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
        
        // public IActionResult Index()
        //{
        //    return View();
        //}
         
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
                
                return RedirectToAction("Show");
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
            var st = await dbcontext.students.FirstOrDefaultAsync(Name => Name.Id == id);
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
                    stud.Fees = st.Fees;
                    await dbcontext.SaveChangesAsync();

                }
                return RedirectToAction("Show", "Student");

            }
            else
            {
                return View(st);
            }
        }
<<<<<<< HEAD
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Show"); 
            }

            var student = await dbcontext.students.FindAsync(id); 

            if (student != null)
            {
                dbcontext.students.Remove(student); 
                await dbcontext.SaveChangesAsync(); 
=======
        public IActionResult DeleteStudent(int? id)
        {


            var hall = dbcontext.students.Find(id); // Find the Student by its ID

            if (hall != null)
            {
                dbcontext.students.Remove(hall);
                dbcontext.SaveChanges();
                return RedirectToAction("Show");
>>>>>>> eb05e15 (Initial commit)
            }

            return RedirectToAction("Show");
        }
<<<<<<< HEAD

=======
>>>>>>> eb05e15 (Initial commit)
    }

}
