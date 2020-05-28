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
    public class Vidil_kyxController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Vidil_kyx
       
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View(db.Vidil_kyx.ToList());
        }

        // GET: Vidil_kyx/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vidil_kyx vidil_kyx = db.Vidil_kyx.Find(id);
            if (vidil_kyx == null)
            {
                return HttpNotFound();
            }
            return View(vidil_kyx);
        }

        // GET: Vidil_kyx/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vidil_kyx/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "id_Vidila_kyx,Nazva_vidily")] Vidil_kyx vidil_kyx)
        {
            if (ModelState.IsValid)
            {
                db.Vidil_kyx.Add(vidil_kyx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vidil_kyx);
        }

        // GET: Vidil_kyx/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vidil_kyx vidil_kyx = db.Vidil_kyx.Find(id);
            if (vidil_kyx == null)
            {
                return HttpNotFound();
            }
            return View(vidil_kyx);
        }

        // POST: Vidil_kyx/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "id_Vidila_kyx,Nazva_vidily")] Vidil_kyx vidil_kyx)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vidil_kyx).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vidil_kyx);
        }

        // GET: Vidil_kyx/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vidil_kyx vidil_kyx = db.Vidil_kyx.Find(id);
            if (vidil_kyx == null)
            {
                return HttpNotFound();
            }
            return View(vidil_kyx);
        }

        // POST: Vidil_kyx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vidil_kyx vidil_kyx = db.Vidil_kyx.Find(id);
            db.Vidil_kyx.Remove(vidil_kyx);
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
