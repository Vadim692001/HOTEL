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
    public class DishesController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Dishes
      
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View(db.Dishes.ToList());
        }

        // GET: Dishes/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = db.Dishes.Find(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // GET: Dishes/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dishes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "id_Strav,Nazva_Strav,Vud_Strav")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                db.Dishes.Add(dishes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dishes);
        }

        // GET: Dishes/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = db.Dishes.Find(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // POST: Dishes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "id_Strav,Nazva_Strav,Vud_Strav")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dishes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dishes);
        }

        // GET: Dishes/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = db.Dishes.Find(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            Dishes dishes = db.Dishes.Find(id);
            db.Dishes.Remove(dishes);
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
