using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarbucksDatabase;
using StarbucksDatabase.Models;

namespace Testing.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoresRepository repo;

        public StoresController(IStoresRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var stores = repo.GetAllStores();
            return View(stores);
        }
        public IActionResult ViewStores(int id)
        {
            var stores = repo.GetStores(id);
            return View(stores);
        }
        public IActionResult UpdateStores(int id)
        {
            var stores = repo.GetStores(id);

            return View(stores);

        }

        public IActionResult UpdateStoresToDatabase(Stores stores)
        {
            repo.UpdateStores(stores);
            return RedirectToAction("ViewStores", new { id = stores.StoreID });
        }
        public IActionResult InsertStores()
        {
            var stores = new Stores();
            return View(stores);
        }
        public IActionResult InsertStoresToDatabase(Stores StoresToInsert)
        {
            repo.InsertStores(StoresToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteStores(Stores stores)
        {
            repo.DeleteStores(stores);
            return RedirectToAction("Index");
        }
    }
}

