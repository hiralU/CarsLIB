using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsLIB.Models;

namespace CarsLIB.Controllers
{
    public class CarsInfoController : Controller
    {
        private CarsLibDataBase_NewEntities1 db = new CarsLibDataBase_NewEntities1();
        public ActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Logincheck(TblUser user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.
        //    }
        //}
        [HttpPost]
        public ActionResult Validate(string Name = "")
        {
            
            return View(db.TblUsers.ToList());
        }
        // GET: CarsInfo
        public ActionResult Index()
        {
            return View(db.TblCars.ToList());
        }

        // GET: CarsInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCar tblCar = db.TblCars.Find(id);
            if (tblCar == null)
            {
                return HttpNotFound();
            }
            return View(tblCar);
        }

        // GET: CarsInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Brand,Model,Year,Price,New")] TblCar tblCar)
        {
            if (ModelState.IsValid)
            {
                db.TblCars.Add(tblCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCar);
        }

        // GET: CarsInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCar tblCar = db.TblCars.Find(id);
            if (tblCar == null)
            {
                return HttpNotFound();
            }
            return View(tblCar);
        }

        // POST: CarsInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,Brand,Model,Year,Price,New")] TblCar tblCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCar);
        }

        // GET: CarsInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCar tblCar = db.TblCars.Find(id);
            if (tblCar == null)
            {
                return HttpNotFound();
            }
            return View(tblCar);
        }

        // POST: CarsInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCar tblCar = db.TblCars.Find(id);
            db.TblCars.Remove(tblCar);
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
