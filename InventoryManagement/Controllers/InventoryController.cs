using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
namespace InventoryManagement.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryDBContext db = new InventoryDBContext();
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetInventory()
        {
            var ViewModel = new InventoriesViewModel();
            ViewModel.Inventories = db.Inventories.ToList();
            return View(ViewModel);
        }
        public ActionResult GetInventoryById(int id)
        {
            if (id > 0)
            {
                var inventory = db.Inventories.ToList().FirstOrDefault(el => el.Id == id);
                return View(inventory);
            }
            else
            {
                return RedirectToAction("Error", "Inventory");
            }
        }
        public ActionResult DeleteInventoryById(int id)
        {
            if (id > 0)
            {
                var inventory = db.Inventories.ToList().FirstOrDefault(el => el.Id == id);
                db.Inventories.Remove(inventory);
                db.SaveChanges();
                return RedirectToAction("GetInventory", "Inventory");
            }
            else
            {
                return RedirectToAction("Error", "Inventory");
            }

        }

        public ActionResult UpdateInventory(int id)
        {
            if (id > 0)
            {
                var inventoryToUpdate = db.Inventories.Find(id);
                return View(inventoryToUpdate);
            }
            else
            {
                return RedirectToAction("Error", "Inventory");
            }
        }

        [HttpPost]
        public ActionResult UpdateInventory(Inventory inventory)
        {
            if (ModelState.IsValid)
            { 
                var inventoryToUpdate = db.Inventories.Find(inventory.Id);
                TryUpdateModel(inventoryToUpdate);
                db.SaveChanges();
                return RedirectToAction("GetInventory", "Inventory");
            }
            else
            {
                return View();
            }
        }

        public ActionResult CreateInventory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateInventory(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
            db.Inventories.Add(inventory);
            db.SaveChanges();
            return RedirectToAction("GetInventory", "Inventory");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}