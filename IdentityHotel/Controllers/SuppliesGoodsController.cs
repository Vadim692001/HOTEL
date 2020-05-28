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
    public class SuppliesGoodsController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: SuppliesGoods

        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var suppliesGoods = db.SuppliesGoods.Include(s => s.Goods).Include(s => s.Supplier);
            return View(suppliesGoods.ToList());
        }

        // GET: SuppliesGoods/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppliesGoods suppliesGoods = db.SuppliesGoods.Find(id);
            if (suppliesGoods == null)
            {
                return HttpNotFound();
            }
            return View(suppliesGoods);
        }

        // GET: SuppliesGoods/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.id_Tovary = new SelectList(db.Goods, "id_Goods", "Tovar");
            ViewBag.id_Postavchuka = new SelectList(db.Supplier, "id_Supplier", "Nazva_Postavchuca");
            return View();
        }

        // POST: SuppliesGoods/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "idCosts,id_Postavchuka,id_Tovary,Kilkist,Cina_za_odin,Odin_vumiry,Data,Sum")] SuppliesGoods suppliesGoods)
        {
            if (ModelState.IsValid)
            {
                db.SuppliesGoods.Add(suppliesGoods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Tovary = new SelectList(db.Goods, "id_Goods", "Tovar", suppliesGoods.id_Tovary);
            ViewBag.id_Postavchuka = new SelectList(db.Supplier, "id_Supplier", "Nazva_Postavchuca", suppliesGoods.id_Postavchuka);
            return View(suppliesGoods);
        }

        // GET: SuppliesGoods/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppliesGoods suppliesGoods = db.SuppliesGoods.Find(id);
            if (suppliesGoods == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Tovary = new SelectList(db.Goods, "id_Goods", "Tovar", suppliesGoods.id_Tovary);
            ViewBag.id_Postavchuka = new SelectList(db.Supplier, "id_Supplier", "Nazva_Postavchuca", suppliesGoods.id_Postavchuka);
            return View(suppliesGoods);
        }

        // POST: SuppliesGoods/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "idCosts,id_Postavchuka,id_Tovary,Kilkist,Cina_za_odin,Odin_vumiry,Data,Sum")] SuppliesGoods suppliesGoods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suppliesGoods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Tovary = new SelectList(db.Goods, "id_Goods", "Tovar", suppliesGoods.id_Tovary);
            ViewBag.id_Postavchuka = new SelectList(db.Supplier, "id_Supplier", "Nazva_Postavchuca", suppliesGoods.id_Postavchuka);
            return View(suppliesGoods);
        }

        // GET: SuppliesGoods/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuppliesGoods suppliesGoods = db.SuppliesGoods.Find(id);
            if (suppliesGoods == null)
            {
                return HttpNotFound();
            }
            return View(suppliesGoods);
        }

        // POST: SuppliesGoods/Delete/5
        [Authorize(Roles = "hairline")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuppliesGoods suppliesGoods = db.SuppliesGoods.Find(id);
            db.SuppliesGoods.Remove(suppliesGoods);
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
