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
    public class DrinksВarController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: DrinksВar
      
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var drinksВar = db.DrinksВar.Include(d => d.Sklad);
            return View(drinksВar.ToList());
        }

        // GET: DrinksВar/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinksВar drinksВar = db.DrinksВar.Find(id);
            if (drinksВar == null)
            {
                return HttpNotFound();
            }
            return View(drinksВar);
        }

        // GET: DrinksВar/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.id_Sklady = new SelectList(db.Sklad, "id_Sklady", "Nam_sk");
            return View();
        }

        // POST: DrinksВar/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "id_Napo,Nazva_Napo,id_Sklady,Kilcist_v_Litrax,Cantri_vurob,Oborot")] DrinksВar drinksВar)
        {
            if (ModelState.IsValid)
            {
                db.DrinksВar.Add(drinksВar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Sklady = new SelectList(db.Sklad, "id_Sklady", "Nam_sk", drinksВar.id_Sklady);
            return View(drinksВar);
        }

        // GET: DrinksВar/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinksВar drinksВar = db.DrinksВar.Find(id);
            if (drinksВar == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Sklady = new SelectList(db.Sklad, "id_Sklady", "Nam_sk", drinksВar.id_Sklady);
            return View(drinksВar);
        }

        // POST: DrinksВar/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "id_Napo,Nazva_Napo,id_Sklady,Kilcist_v_Litrax,Cantri_vurob,Oborot")] DrinksВar drinksВar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drinksВar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Sklady = new SelectList(db.Sklad, "id_Sklady", "Nam_sk", drinksВar.id_Sklady);
            return View(drinksВar);
        }

        // GET: DrinksВar/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinksВar drinksВar = db.DrinksВar.Find(id);
            if (drinksВar == null)
            {
                return HttpNotFound();
            }
            return View(drinksВar);
        }

        // POST: DrinksВar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            DrinksВar drinksВar = db.DrinksВar.Find(id);
            db.DrinksВar.Remove(drinksВar);
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
