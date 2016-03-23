using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS411HW8.Models;

namespace CIS411HW8.Controllers
{
    public class PetsController : Controller
    {
        private PetsContext db = new PetsContext();

        //
        // GET: /Pets/

        public ActionResult Index()
        {
            return View(db.Pets.ToList());
        }

        public ActionResult PetsView()
        {
            return View(db.Pets.ToList());
        }

        //
        // GET: /Pets/Details/5

        public ActionResult Details(int id = 0)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        //
        // GET: /Pets/Create
        //[Authorize(Roles = "Administrators")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pets/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pet);
        }

        //
        // GET: /Pets/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        //
        // POST: /Pets/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        //
        // GET: /Pets/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        //
        // POST: /Pets/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}