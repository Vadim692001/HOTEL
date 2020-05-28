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
    public class BarsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Bars
        
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var bar = db.Bar.Include(b => b.Employee).Include(b => b.Zv_Bary);
            return View(bar.ToList());
        }

        // GET: Bars/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = db.Bar.Find(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            return View(bar);
        }

        // GET: Bars/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.Sorname_Prac = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac");
            ViewBag.Nazva_Bary = new SelectList(db.Zv_Bary, "id_Bary", "Nazva_Bary");
            return View();
        }

        // POST: Bars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "Код,Nazva_Bary,Sorname_Prac,Data")] Bar bar)
        {
            if (ModelState.IsValid)
            {
                db.Bar.Add(bar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sorname_Prac = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", bar.Sorname_Prac);
            ViewBag.Nazva_Bary = new SelectList(db.Zv_Bary, "id_Bary", "Nazva_Bary", bar.Nazva_Bary);
            return View(bar);
        }

        // GET: Bars/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = db.Bar.Find(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sorname_Prac = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", bar.Sorname_Prac);
            ViewBag.Nazva_Bary = new SelectList(db.Zv_Bary, "id_Bary", "Nazva_Bary", bar.Nazva_Bary);
            return View(bar);
        }

        // POST: Bars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "Код,Nazva_Bary,Sorname_Prac,Data")] Bar bar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sorname_Prac = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", bar.Sorname_Prac);
            ViewBag.Nazva_Bary = new SelectList(db.Zv_Bary, "id_Bary", "Nazva_Bary", bar.Nazva_Bary);
            return View(bar);
        }

        // GET: Bars/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = db.Bar.Find(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            return View(bar);
        }

        // POST: Bars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            Bar bar = db.Bar.Find(id);
            db.Bar.Remove(bar);
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
