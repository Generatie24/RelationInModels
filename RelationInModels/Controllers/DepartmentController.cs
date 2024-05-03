using Microsoft.AspNetCore.Mvc;
using RelationInModels.Models;

namespace RelationInModels.Controllers
{
    public class DepartmentController : Controller
    {

        static List<Department> departmentsFirstTime = DataInitializer.SeedDepartment();
        public IActionResult Index()
        {
            var departments = departmentsFirstTime;
            return View(departments);
        }

        public IActionResult Details(int id)
        {
            var department = departmentsFirstTime.Find(d => d.Id == id);
            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = departmentsFirstTime.Find(d => d.Id == id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var existingItem = departmentsFirstTime.FirstOrDefault(i => i.Id == department.Id);
            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Name = department.Name;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var found = departmentsFirstTime.Find(d => d.Id == id);
            if (found == null)
            {
                return NotFound();
            }
            departmentsFirstTime.Remove(found);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var NextId = departmentsFirstTime.Capacity;
            ViewBag.Id = NextId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            var NextId = departmentsFirstTime.Capacity;
            department.Id = NextId;

            departmentsFirstTime.Add(department);
            return RedirectToAction("Index");
        }

    }
}
