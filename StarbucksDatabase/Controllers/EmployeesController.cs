using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarbucksDatabase;
using StarbucksDatabase.Models;

namespace Testing.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository repo;

        public EmployeesController(IEmployeesRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var employees = repo.GetAllEmployees();
            return View(employees);
        }
        public IActionResult ViewEmployee(int id)
        {
            var employee = repo.GetEmployee(id);
            return View(employee);
        }
        public IActionResult UpdateEmployees(int id)
        {
            var employee = repo.GetEmployee(id);

            return View(employee);

        }

        public IActionResult UpdateEmployeeToDatabase(Employees employee)
        {
            repo.UpdateEmployees(employee);
            return RedirectToAction("ViewEmployee", new { id = employee.EmployeeID});
        }
        public IActionResult InsertEmployees()
        {
            var employee = new Employees();
            return View(employee);
        }
        public IActionResult InsertEmployeesToDatabase(Employees EmployeesToInsert)
        {
            repo.InsertEmployees(EmployeesToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(Employees employees)
        {
            repo.DeleteEmployees(employees);
            return RedirectToAction("Index");
        }
    }
}