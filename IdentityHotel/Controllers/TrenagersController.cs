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
    public class TrenagersController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Trenagers
    
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View(db.Trenager.ToList());
        }

        // GET: Trenagers/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trenager trenager = db.Trenager.Find(id);
            if (trenager == null)
            {
                return HttpNotFound();
            }
            return View(trenager);
        }

        // GET: Trenagers/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trenagers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "id_Trenegra,NazvaTrenegera,KilcistTrenegera")] Trenager trenager)
        {
            if (ModelState.IsValid)
            {
                db.Trenager.Add(trenager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trenager);
        }

        // GET: Trenagers/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trenager trenager = db.Trenager.Find(id);
            if (trenager == null)
            {
                return HttpNotFound();
            }
            return View(trenager);
        }

        // POST: Trenagers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "id_Trenegra,NazvaTrenegera,KilcistTrenegera")] Trenager trenager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trenager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trenager);
        }

        // GET: Trenagers/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trenager trenager = db.Trenager.Find(id);
            if (trenager == null)
            {
                return HttpNotFound();
            }
            return View(trenager);
        }

        // POST: Trenagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            Trenager trenager = db.Trenager.Find(id);
            db.Trenager.Remove(trenager);
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
