using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityHotel.Models;

namespace IdentityHotel.Controllers
{
    public class NameRestaurantsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: NameRestaurants
      
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var nameRestaurant = db.NameRestaurant.Include(n => n.Restaurant);
            return View(nameRestaurant.ToList());
        }

        // GET: NameRestaurants/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NameRestaurant nameRestaurant = db.NameRestaurant.Find(id);
            if (nameRestaurant == null)
            {
                return HttpNotFound();
            }
            return View(nameRestaurant);
        }

        // GET: NameRestaurants/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.id_Restaurant = new SelectList(db.Restaurant, "idRestaurant", "EatingTime");
            return View();
        }

        // POST: NameRestaurants/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "id_Restaurant,NameRestaurant1")] NameRestaurant nameRestaurant)
        {
            if (ModelState.IsValid)
            {
                db.NameRestaurant.Add(nameRestaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Restaurant = new SelectList(db.Restaurant, "idRestaurant", "EatingTime", nameRestaurant.id_Restaurant);
            return View(nameRestaurant);
        }

        // GET: NameRestaurants/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NameRestaurant nameRestaurant = db.NameRestaurant.Find(id);
            if (nameRestaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Restaurant = new SelectList(db.Restaurant, "idRestaurant", "EatingTime", nameRestaurant.id_Restaurant);
            return View(nameRestaurant);
        }

        // POST: NameRestaurants/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "id_Restaurant,NameRestaurant1")] NameRestaurant nameRestaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nameRestaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Restaurant = new SelectList(db.Restaurant, "idRestaurant", "EatingTime", nameRestaurant.id_Restaurant);
            return View(nameRestaurant);
        }

        // GET: NameRestaurants/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NameRestaurant nameRestaurant = db.NameRestaurant.Find(id);
            if (nameRestaurant == null)
            {
                return HttpNotFound();
            }
            return View(nameRestaurant);
        }

        // POST: NameRestaurants/Delete/5
        [Authorize(Roles = "hairline")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NameRestaurant nameRestaurant = db.NameRestaurant.Find(id);
            db.NameRestaurant.Remove(nameRestaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
