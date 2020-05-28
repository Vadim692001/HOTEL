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
    public class GoestsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Goests
      
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var goest = db.Goest.Include(g => g.Number);
            return View(goest.ToList());
        }

        // GET: Goests/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goest goest = db.Goest.Find(id);
            if (goest == null)
            {
                return HttpNotFound();
            }
            return View(goest);
        }

        // GET: Goests/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.IdNumber = new SelectList(db.Number, "id_Number", "Komplektaci_nomera");
            return View();
        }

        // POST: Goests/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "IdGoest,IdNumber,SornameGoesst,NameGoest,SurnameGoest,Age,DateArrival,DateExit,Sum")] Goest goest)
        {
            if (ModelState.IsValid)
            {
                db.Goest.Add(goest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdNumber = new SelectList(db.Number, "id_Number", "Komplektaci_nomera", goest.IdNumber);
            return View(goest);
        }

        // GET: Goests/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goest goest = db.Goest.Find(id);
            if (goest == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNumber = new SelectList(db.Number, "id_Number", "Komplektaci_nomera", goest.IdNumber);
            return View(goest);
        }

        // POST: Goests/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "IdGoest,IdNumber,SornameGoesst,NameGoest,SurnameGoest,Age,DateArrival,DateExit,Sum")] Goest goest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdNumber = new SelectList(db.Number, "id_Number", "Komplektaci_nomera", goest.IdNumber);
            return View(goest);
        }

        // GET: Goests/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goest goest = db.Goest.Find(id);
            if (goest == null)
            {
                return HttpNotFound();
            }
            return View(goest);
        }

        // POST: Goests/Delete/5
        [Authorize(Roles = "hairline")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goest goest = db.Goest.Find(id);
            db.Goest.Remove(goest);
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
