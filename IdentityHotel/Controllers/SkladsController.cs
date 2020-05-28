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
    public class SkladsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Sklads
 
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View(db.Sklad.ToList());
        }

        // GET: Sklads/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklad sklad = db.Sklad.Find(id);
            if (sklad == null)
            {
                return HttpNotFound();
            }
            return View(sklad);
        }

        // GET: Sklads/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sklads/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "id_Sklady,Nam_sk,Tip_zber")] Sklad sklad)
        {
            if (ModelState.IsValid)
            {
                db.Sklad.Add(sklad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sklad);
        }

        // GET: Sklads/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklad sklad = db.Sklad.Find(id);
            if (sklad == null)
            {
                return HttpNotFound();
            }
            return View(sklad);
        }

        // POST: Sklads/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "id_Sklady,Nam_sk,Tip_zber")] Sklad sklad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sklad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sklad);
        }

        // GET: Sklads/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklad sklad = db.Sklad.Find(id);
            if (sklad == null)
            {
                return HttpNotFound();
            }
            return View(sklad);
        }

        // POST: Sklads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sklad sklad = db.Sklad.Find(id);
            db.Sklad.Remove(sklad);
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
