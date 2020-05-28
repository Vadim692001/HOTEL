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
    public class SportsHallsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: SportsHalls

        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var sportsHall = db.SportsHall.Include(s => s.Employee).Include(s => s.Goest).Include(s => s.Trenager);
            return View(sportsHall.ToList());
        }

        // GET: SportsHalls/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsHall sportsHall = db.SportsHall.Find(id);
            if (sportsHall == null)
            {
                return HttpNotFound();
            }
            return View(sportsHall);
        }

        // GET: SportsHalls/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.id_Pracivnuca = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac");
            ViewBag.id_Goct = new SelectList(db.Goest, "IdGoest", "SornameGoesst");
            ViewBag.id_Trenegra = new SelectList(db.Trenager, "id_Trenegra", "NazvaTrenegera");
            return View();
        }

        // POST: SportsHalls/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "Код,id_Pracivnuca,id_Trenegra,id_Goct,Data")] SportsHall sportsHall)
        {
            if (ModelState.IsValid)
            {
                db.SportsHall.Add(sportsHall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Pracivnuca = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", sportsHall.id_Pracivnuca);
            ViewBag.id_Goct = new SelectList(db.Goest, "IdGoest", "SornameGoesst", sportsHall.id_Goct);
            ViewBag.id_Trenegra = new SelectList(db.Trenager, "id_Trenegra", "NazvaTrenegera", sportsHall.id_Trenegra);
            return View(sportsHall);
        }

        // GET: SportsHalls/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsHall sportsHall = db.SportsHall.Find(id);
            if (sportsHall == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Pracivnuca = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", sportsHall.id_Pracivnuca);
            ViewBag.id_Goct = new SelectList(db.Goest, "IdGoest", "SornameGoesst", sportsHall.id_Goct);
            ViewBag.id_Trenegra = new SelectList(db.Trenager, "id_Trenegra", "NazvaTrenegera", sportsHall.id_Trenegra);
            return View(sportsHall);
        }

        // POST: SportsHalls/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "Код,id_Pracivnuca,id_Trenegra,id_Goct,Data")] SportsHall sportsHall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sportsHall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Pracivnuca = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", sportsHall.id_Pracivnuca);
            ViewBag.id_Goct = new SelectList(db.Goest, "IdGoest", "SornameGoesst", sportsHall.id_Goct);
            ViewBag.id_Trenegra = new SelectList(db.Trenager, "id_Trenegra", "NazvaTrenegera", sportsHall.id_Trenegra);
            return View(sportsHall);
        }

        // GET: SportsHalls/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsHall sportsHall = db.SportsHall.Find(id);
            if (sportsHall == null)
            {
                return HttpNotFound();
            }
            return View(sportsHall);
        }

        // POST: SportsHalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            SportsHall sportsHall = db.SportsHall.Find(id);
            db.SportsHall.Remove(sportsHall);
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
