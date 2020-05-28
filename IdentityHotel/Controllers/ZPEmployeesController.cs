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
    public class ZPEmployeesController : Controller
    {
        private Hotel_Restor_DiplomEntities db = new Hotel_Restor_DiplomEntities();

        // GET: ZPEmployees
       
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var zPEmployee = db.ZPEmployee.Include(z => z.Employee).Include(z => z.Employee1).Include(z => z.Employee2);
            return View(zPEmployee.ToList());
        }

        // GET: ZPEmployees/Details/5
        [Authorize(Roles = "hairline")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZPEmployee zPEmployee = db.ZPEmployee.Find(id);
            if (zPEmployee == null)
            {
                return HttpNotFound();
            }
            return View(zPEmployee);
        }

        // GET: ZPEmployees/Create
        [Authorize(Roles = "hairline")]
        public ActionResult Create()
        {
            ViewBag.SornameEmployee = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac");
            ViewBag.CardZP = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac");
            ViewBag.NameEmployee = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac");
            return View();
        }

        // POST: ZPEmployees/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Create([Bind(Include = "idCost,SornameEmployee,NameEmployee,Tariff,TimeWorked,Sum,CardZP")] ZPEmployee zPEmployee)
        {
            if (ModelState.IsValid)
            {
                db.ZPEmployee.Add(zPEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SornameEmployee = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.SornameEmployee);
            ViewBag.CardZP = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.CardZP);
            ViewBag.NameEmployee = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.NameEmployee);
            return View(zPEmployee);
        }

        // GET: ZPEmployees/Edit/5
        [Authorize(Roles = "hairline")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZPEmployee zPEmployee = db.ZPEmployee.Find(id);
            if (zPEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.SornameEmployee = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.SornameEmployee);
            ViewBag.CardZP = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.CardZP);
            ViewBag.NameEmployee = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.NameEmployee);
            return View(zPEmployee);
        }

        // POST: ZPEmployees/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult Edit([Bind(Include = "idCost,SornameEmployee,NameEmployee,Tariff,TimeWorked,Sum,CardZP")] ZPEmployee zPEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zPEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SornameEmployee = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.SornameEmployee);
            ViewBag.CardZP = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.CardZP);
            ViewBag.NameEmployee = new SelectList(db.Employee, "id_Pracivnuca", "Sorname_Prac", zPEmployee.NameEmployee);
            return View(zPEmployee);
        }

        // GET: ZPEmployees/Delete/5
        [Authorize(Roles = "hairline")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZPEmployee zPEmployee = db.ZPEmployee.Find(id);
            if (zPEmployee == null)
            {
                return HttpNotFound();
            }
            return View(zPEmployee);
        }

        // POST: ZPEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "hairline")]
        public ActionResult DeleteConfirmed(int id)
        {
            ZPEmployee zPEmployee = db.ZPEmployee.Find(id);
            db.ZPEmployee.Remove(zPEmployee);
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
