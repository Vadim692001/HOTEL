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
    public class CPAsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: CPAs
   
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var cPA = db.CPA.Include(c => c.Employee).Include(c => c.Goest).Include(c => c.Poslyg);
            return View(cPA.ToList());
        }

        // GET: CPAs/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPA cPA = db.CPA.Find(id);
            if (cPA == null)
            {
                return HttpNotFound();
            }
            return View(cPA);
        }

        // GET: CPAs/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.id_Pracivnuca = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac");
            ViewBag.id_Goct = new SelectList(db.Goest, "IdGoest", "SornameGoesst");
            ViewBag.id_Poslyg = new SelectList(db.Poslyg, "id_Poslyg", "Nazva_Poslyg");
            return View();
        }

        // POST: CPAs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "Код,id_Pracivnuca,id_Goct,NameGoct,id_Poslyg,TeamPochatky,TeamKin")] CPA cPA)
        {
            if (ModelState.IsValid)
            {
                db.CPA.Add(cPA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Pracivnuca = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", cPA.id_Pracivnuca);
            ViewBag.id_Goct = new SelectList(db.Goest, "IdGoest", "SornameGoesst", cPA.id_Goct);
            ViewBag.id_Poslyg = new SelectList(db.Poslyg, "id_Poslyg", "Nazva_Poslyg", cPA.id_Poslyg);
            return View(cPA);
        }

        // GET: CPAs/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPA cPA = db.CPA.Find(id);
            if (cPA == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Pracivnuca = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", cPA.id_Pracivnuca);
            ViewBag.id_Goct = new SelectList(db.Goest, "IdGoest", "SornameGoesst", cPA.id_Goct);
            ViewBag.id_Poslyg = new SelectList(db.Poslyg, "id_Poslyg", "Nazva_Poslyg", cPA.id_Poslyg);
            return View(cPA);
        }

        // POST: CPAs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "Код,id_Pracivnuca,id_Goct,NameGoct,id_Poslyg,TeamPochatky,TeamKin")] CPA cPA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cPA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Pracivnuca = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", cPA.id_Pracivnuca);
            ViewBag.id_Goct = new SelectList(db.Goest, "IdGoest", "SornameGoesst", cPA.id_Goct);
            ViewBag.id_Poslyg = new SelectList(db.Poslyg, "id_Poslyg", "Nazva_Poslyg", cPA.id_Poslyg);
            return View(cPA);
        }

        // GET: CPAs/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPA cPA = db.CPA.Find(id);
            if (cPA == null)
            {
                return HttpNotFound();
            }
            return View(cPA);
        }

        // POST: CPAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            CPA cPA = db.CPA.Find(id);
            db.CPA.Remove(cPA);
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
