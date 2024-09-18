using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTask.Models;

namespace MVCTask.Controllers
{
    public class EmployeesController:Controller
    {
        private readonly Day6MvcdbContext _db;
        public EmployeesController(Day6MvcdbContext db)=>_db = db;

        public IActionResult Index()
        {
            return View(_db.Employees.Include(e=>e.Depart));
        }
        [HttpGet]
        public IActionResult Create() {
            ViewBag.Departments=new SelectList( _db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("EmployeeName,Job,Salary,Address,Email,DepartId")] Employee emp) {
            _db.Employees.Add(emp);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]   
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            try {
                if (!Exists(id))
                    return NotFound();
                Employee emp = _db.Employees.FirstOrDefault(emp => emp.EmployeeId == id);
                ViewData["Departments"]=_db.Departments;
                return View(emp);
            }
            catch { 
                return NotFound();
            }   
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee emp) {
            if (id == 0 || id!=emp.EmployeeId)
            {
                return BadRequest();
            }
                _db.Employees.Update(emp);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id) {
            if(id == 0)
            {
                return BadRequest();
            }
            try
            {
                if (!Exists(id))
                    return NotFound();
                var emp = _db.Employees.FirstOrDefault(e => e.EmployeeId == id);
                _db.Remove(emp);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch { 
                return BadRequest();
            }
        }
        public IActionResult Details(int id) {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                if (!Exists(id))
                    throw new Exception();
                Employee emp = _db.Employees.Include(e=>e.Depart).FirstOrDefault(emp => emp.EmployeeId == id);
                return View(emp);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        [NonAction]
        private bool Exists(int id) =>_db.Employees.Any(e => e.EmployeeId == id);
    }
}
