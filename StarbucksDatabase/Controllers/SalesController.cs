using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarbucksDatabase;
using StarbucksDatabase.Models;

namespace Testing.Controllers
{

    public class SalesController : Controller
    {
        private readonly ISalesRepository repo;

        public SalesController(ISalesRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var sales = repo.GetAllSales();
            return View(sales);
        }
        public IActionResult ViewSales(int id)
        {
            var sales = repo.GetSales(id);
            return View(sales);
        }
        public IActionResult UpdateSales(int id)
        {
            var sales = repo.GetSales(id);
            if (sales == null)
            {
                return View("SalesNotFound");
            }
            return View(sales);
        }
        public IActionResult UpdateSalesToDatabase(Sales sales)
        {
            repo.UpdateSales(sales);

            return RedirectToAction("ViewSales", new { id = sales.SalesID });
        }
        public IActionResult InsertSales()
        {
            var sales = new Sales();
            return View(sales);
        }
        public IActionResult InsertSalesToDatabase(Sales SalesToInsert)
        {
            repo.InsertSales(SalesToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSales(Sales sales)
        {
            repo.DeleteSales(sales);
            return RedirectToAction("Index");
        }
    }
}
