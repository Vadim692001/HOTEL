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
    public class CookingsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: Cookings
       
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var cooking = db.Cooking.Include(c => c.Dishes).Include(c => c.Goods).Include(c => c.Vidil_kyx);
            return View(cooking.ToList());
        }

        // GET: Cookings/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooking cooking = db.Cooking.Find(id);
            if (cooking == null)
            {
                return HttpNotFound();
            }
            return View(cooking);
        }

        // GET: Cookings/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.id_Strav = new SelectList(db.Dishes, "id_Strav", "Nazva_Strav");
            ViewBag.id_Tovary = new SelectList(db.Goods, "id_Goods", "Tovar");
            ViewBag.id_Vidila_kyx = new SelectList(db.Vidil_kyx, "id_Vidila_kyx", "Nazva_vidily");
            return View();
        }

        // POST: Cookings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "Код,id_Strav,id_Tovary,masa,Odun_vumiry,id_Vidila_kyx,Data")] Cooking cooking)
        {
            if (ModelState.IsValid)
            {
                db.Cooking.Add(cooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Strav = new SelectList(db.Dishes, "id_Strav", "Nazva_Strav", cooking.id_Strav);
            ViewBag.id_Tovary = new SelectList(db.Goods, "id_Goods", "Tovar", cooking.id_Tovary);
            ViewBag.id_Vidila_kyx = new SelectList(db.Vidil_kyx, "id_Vidila_kyx", "Nazva_vidily", cooking.id_Vidila_kyx);
            return View(cooking);
        }

        // GET: Cookings/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooking cooking = db.Cooking.Find(id);
            if (cooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Strav = new SelectList(db.Dishes, "id_Strav", "Nazva_Strav", cooking.id_Strav);
            ViewBag.id_Tovary = new SelectList(db.Goods, "id_Goods", "Tovar", cooking.id_Tovary);
            ViewBag.id_Vidila_kyx = new SelectList(db.Vidil_kyx, "id_Vidila_kyx", "Nazva_vidily", cooking.id_Vidila_kyx);
            return View(cooking);
        }

        // POST: Cookings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "Код,id_Strav,id_Tovary,masa,Odun_vumiry,id_Vidila_kyx,Data")] Cooking cooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Strav = new SelectList(db.Dishes, "id_Strav", "Nazva_Strav", cooking.id_Strav);
            ViewBag.id_Tovary = new SelectList(db.Goods, "id_Goods", "Tovar", cooking.id_Tovary);
            ViewBag.id_Vidila_kyx = new SelectList(db.Vidil_kyx, "id_Vidila_kyx", "Nazva_vidily", cooking.id_Vidila_kyx);
            return View(cooking);
        }

        // GET: Cookings/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooking cooking = db.Cooking.Find(id);
            if (cooking == null)
            {
                return HttpNotFound();
            }
            return View(cooking);
        }

        // POST: Cookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cooking cooking = db.Cooking.Find(id);
            db.Cooking.Remove(cooking);
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
