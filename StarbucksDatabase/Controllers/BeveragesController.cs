using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarbucksDatabase;
using StarbucksDatabase.Models;

namespace Testing.Controllers
{
    public class BeveragesController : Controller
    {
        private readonly IBeveragesRepository repo;

        public BeveragesController(IBeveragesRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var Beverages = repo.GetAllBeverages();
            return View(Beverages);
        }
        public IActionResult ViewBeverages(int id)
        {
            var Beverages = repo.GetBeverages(id);
            return View(Beverages);
        }
        public IActionResult UpdateBeverages(int id)
        {
            Beverages prod = repo.GetBeverages(id);
            if (prod == null)
            {
                return View("BeverageNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateBeveragesToDatabase(Beverages beverages)
        {
            repo.UpdateBeverages(beverages);

            return RedirectToAction("Index");
        }
        public IActionResult InsertBeverages()
        {
            var beverage = new Beverages();
            return View(beverage);
        }
        public IActionResult InsertBeveragesToDatabase(Beverages beveragesToInsert)
        {
            repo.InsertBeverages(beveragesToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBeverages(Beverages beverages)
        {
            repo.DeleteBeverages(beverages);
            return RedirectToAction("Index");
        }


    }
}

