using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.Arm;

namespace MVCTask.Controllers
{
    public class DepartmentsController:Controller
    {
        private readonly Day6MvcdbContext _db;
        public DepartmentsController(Day6MvcdbContext db)=>_db = db;
        public IActionResult Index()
        {
            return View(_db.Departments);
        }
        public IActionResult Details(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            if (!Exists(id))
            {
                return NotFound();
            }
            return View(_db.Departments.FirstOrDefault(d=>d.DepartmentId==id));
        }
        public IActionResult Edit(int id) {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!Exists(id))
            {
                return NotFound();
            }
            return View(_db.Departments.FirstOrDefault(d => d.DepartmentId == id));
        }
        [HttpPost]
        public IActionResult Edit(int id,Department dep) {
            if (id == 0||dep.DepartmentId!=id)
            {
                return BadRequest();
            }
            if (!Exists(id))
            {
                return NotFound();
            }
            _db.Departments.Update(dep);
            _db.SaveChanges();
            TempData["Toast_Action"] = "Edit";
            TempData["Toast_Message"] = $"Department {dep.DepartmentName} has been edited";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id) {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!Exists(id))
            {
                return NotFound();
            }
            var dep = _db.Departments.FirstOrDefault(d => d.DepartmentId == id);
            _db.Departments.Remove(dep);
            _db.SaveChanges();
            TempData["Toast_Action"] = "Delete";
            TempData["Toast_Message"] = $"Department {dep.DepartmentName} has been deleted";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create( Department dep) {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(dep);
                _db.SaveChanges();
                TempData["Toast_Action"] = "Add";
                TempData["Toast_Message"] = $"Department {dep.DepartmentName} has been added";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [NonAction]
         private bool Exists(int id) => _db.Departments.Any(d => d.DepartmentId == id);
    }
}
