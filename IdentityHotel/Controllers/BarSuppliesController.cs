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
    public class BarSuppliesController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: BarSupplies
       
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var barSupplies = db.BarSupplies.Include(b => b.DrinksВar).Include(b => b.Supplier);
            return View(barSupplies.ToList());
        }

        // GET: BarSupplies/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarSupplies barSupplies = db.BarSupplies.Find(id);
            if (barSupplies == null)
            {
                return HttpNotFound();
            }
            return View(barSupplies);
        }

        // GET: BarSupplies/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.id_Napo = new SelectList(db.DrinksВar, "id_Napo", "Nazva_Napo");
            ViewBag.id_Postavchuka = new SelectList(db.Supplier, "id_Supplier", "Nazva_Postavchuca");
            return View();
        }

        // POST: BarSupplies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "idCost,id_Postavchuka,id_Napo,Date,Number,Unit,Pric,Sum")] BarSupplies barSupplies)
        {
            if (ModelState.IsValid)
            {
                db.BarSupplies.Add(barSupplies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Napo = new SelectList(db.DrinksВar, "id_Napo", "Nazva_Napo", barSupplies.id_Napo);
            ViewBag.id_Postavchuka = new SelectList(db.Supplier, "id_Supplier", "Nazva_Postavchuca", barSupplies.id_Postavchuka);
            return View(barSupplies);
        }

        // GET: BarSupplies/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarSupplies barSupplies = db.BarSupplies.Find(id);
            if (barSupplies == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Napo = new SelectList(db.DrinksВar, "id_Napo", "Nazva_Napo", barSupplies.id_Napo);
            ViewBag.id_Postavchuka = new SelectList(db.Supplier, "id_Supplier", "Nazva_Postavchuca", barSupplies.id_Postavchuka);
            return View(barSupplies);
        }

        // POST: BarSupplies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "idCost,id_Postavchuka,id_Napo,Date,Number,Unit,Pric,Sum")] BarSupplies barSupplies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barSupplies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Napo = new SelectList(db.DrinksВar, "id_Napo", "Nazva_Napo", barSupplies.id_Napo);
            ViewBag.id_Postavchuka = new SelectList(db.Supplier, "id_Supplier", "Nazva_Postavchuca", barSupplies.id_Postavchuka);
            return View(barSupplies);
        }

        // GET: BarSupplies/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarSupplies barSupplies = db.BarSupplies.Find(id);
            if (barSupplies == null)
            {
                return HttpNotFound();
            }
            return View(barSupplies);
        }

        // POST: BarSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            BarSupplies barSupplies = db.BarSupplies.Find(id);
            db.BarSupplies.Remove(barSupplies);
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
