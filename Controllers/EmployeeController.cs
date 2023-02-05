using EmployeeCRUD.Data;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Return index employee view
        public IActionResult Index()
        {
            IEnumerable<Employee> objCatlist = _context.Employees;
            return View(objCatlist);
        }

        // GET EMPLOYEE INFORMATION
        public IActionResult Create()
        {
            return View();
        }

        // POST(CREATE) EMPLOYEE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();

                    TempData["Result OK"] = "Record Added Succesfully !";
                }
                catch (DbUpdateConcurrencyException){
                    if(employee.ID.ToString() != "")
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET EDIT EMPLOYEE INFORMATION
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var employeeDBreturn = await _context.Employees.FindAsync(id);

            if(employeeDBreturn == null)
            {
                return NotFound();
            }
            return View(employeeDBreturn);
        }

        // POST(EDIT) EMPLOYEE INFORMATION
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Employees.Update(employee);
                    await _context.SaveChangesAsync();

                    TempData["Result OK"] = "Record Updated Succesfully !";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (employee.ID.ToString() != "")
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // DELETE EMPLOYEE INFORMATION
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeDBreturn = await _context.Employees.FindAsync(id);

            if (employeeDBreturn == null)
            {
                return NotFound();
            }
            return View(employeeDBreturn);
        }

        // DELETE EMPLOYEE INFORMATION
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            var deleteRecord = _context.Employees.Find(id);

            if(deleteRecord == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(deleteRecord);
            await _context.SaveChangesAsync();

            TempData["Result OK"] = "Record Deleted Succesfully !";
            return RedirectToAction("Index");
        }



    }
}
