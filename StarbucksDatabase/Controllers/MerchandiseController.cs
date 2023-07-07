using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarbucksDatabase;
using StarbucksDatabase.Models;

namespace Testing.Controllers
{
    public class MerchandiseController : Controller
    {
        private readonly IMerchandiseRepository repo;

        public MerchandiseController(IMerchandiseRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var merchandise = repo.GetAllMerchandise();
            return View(merchandise);
        }
        public IActionResult ViewMerchandise(int id)
        {
            var merchandise = repo.GetMerchandise(id);
            return View(merchandise);
        }
        public IActionResult UpdateMerchandise(int id)
        {
            var merchandise = repo.GetMerchandise(id);
            if (merchandise == null)
            {
                return View("MerchandiseNotFound");
            }
            return View(merchandise);
        }
        public IActionResult UpdateMerchandiseToDatabase(Merchandise merchandise)
        {
            repo.UpdateMerchandise(merchandise);

            return RedirectToAction("ViewMerchandise", new { id = merchandise.MerchandiseID });
        }
        public IActionResult InsertMerchandise()
        {
            var merchandise = new Merchandise();
            return View(merchandise);
        }
        public IActionResult InsertMerchandiseToDatabase(Merchandise MerchandiseToInsert)
        {
            repo.InsertMerchandise(MerchandiseToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteMerchandise(Merchandise merchandise)
        {
            repo.DeleteMerchandise(merchandise);
            return RedirectToAction("Index");
        }


    }
}

