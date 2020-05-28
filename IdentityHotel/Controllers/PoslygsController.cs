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
    public class PoslygsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Poslygs
       
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View(db.Poslyg.ToList());
        }

        // GET: Poslygs/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poslyg poslyg = db.Poslyg.Find(id);
            if (poslyg == null)
            {
                return HttpNotFound();
            }
            return View(poslyg);
        }

        // GET: Poslygs/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poslygs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "id_Poslyg,Nazva_Poslyg,Cina_Posleg")] Poslyg poslyg)
        {
            if (ModelState.IsValid)
            {
                db.Poslyg.Add(poslyg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poslyg);
        }

        // GET: Poslygs/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poslyg poslyg = db.Poslyg.Find(id);
            if (poslyg == null)
            {
                return HttpNotFound();
            }
            return View(poslyg);
        }

        // POST: Poslygs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "id_Poslyg,Nazva_Poslyg,Cina_Posleg")] Poslyg poslyg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poslyg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poslyg);
        }

        // GET: Poslygs/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poslyg poslyg = db.Poslyg.Find(id);
            if (poslyg == null)
            {
                return HttpNotFound();
            }
            return View(poslyg);
        }

        // POST: Poslygs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            Poslyg poslyg = db.Poslyg.Find(id);
            db.Poslyg.Remove(poslyg);
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
