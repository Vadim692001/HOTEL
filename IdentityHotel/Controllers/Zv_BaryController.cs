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
    public class Zv_BaryController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Zv_Bary
    
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View(db.Zv_Bary.ToList());
        }


        // GET: Zv_Bary/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zv_Bary zv_Bary = db.Zv_Bary.Find(id);
            if (zv_Bary == null)
            {
                return HttpNotFound();
            }
            return View(zv_Bary);
        }

        // GET: Zv_Bary/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zv_Bary/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "id_Bary,Nazva_Bary")] Zv_Bary zv_Bary)
        {
            if (ModelState.IsValid)
            {
                db.Zv_Bary.Add(zv_Bary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zv_Bary);
        }

        // GET: Zv_Bary/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zv_Bary zv_Bary = db.Zv_Bary.Find(id);
            if (zv_Bary == null)
            {
                return HttpNotFound();
            }
            return View(zv_Bary);
        }

        // POST: Zv_Bary/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "id_Bary,Nazva_Bary")] Zv_Bary zv_Bary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zv_Bary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zv_Bary);
        }

        // GET: Zv_Bary/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zv_Bary zv_Bary = db.Zv_Bary.Find(id);
            if (zv_Bary == null)
            {
                return HttpNotFound();
            }
            return View(zv_Bary);
        }

        // POST: Zv_Bary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            Zv_Bary zv_Bary = db.Zv_Bary.Find(id);
            db.Zv_Bary.Remove(zv_Bary);
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
