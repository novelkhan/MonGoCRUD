using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonGoCRUD.Interfaces;
using MonGoCRUD.Models;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace MonGoCRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: StudentController
        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAll();

            return View(students);
        }

        // GET: StudentController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var student = await _studentRepository.Get(ObjectId.Parse(id));
            return View(student);
        }




        // GET: StudentController/DetailsByName/name
        public async Task<IActionResult> DetailsByName(string name)
        {
            var students = await _studentRepository.GetByName(name);
            return View(students);
        }



        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _studentRepository.Create(student);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var student = await _studentRepository.Get(ObjectId.Parse(id));
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _studentRepository.Update(ObjectId.Parse(id), student);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: StudentController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var student = await _studentRepository.Get(ObjectId.Parse(id));
            return View(student);
        }

        // POST: StudentController/Delete/item
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var result = await _studentRepository.Delete(ObjectId.Parse(id));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception("An error occurred.");
            }
            catch
            {
                return View();
            }
        }
    }
}
