using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using autoshopbiz.Models;

namespace autoshopbiz.Controllers
{
    public class CusomerVehiclesController : Controller
    {
        private RepairShopContext db = new RepairShopContext();

        // GET: CusomerVehicles
        public ActionResult Index()
        {
            var customer_vehicles = db.customer_vehicles.Include(c => c.customer);
            return View(customer_vehicles.ToList());
        }

        // GET: CusomerVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_vehicles customer_vehicles = db.customer_vehicles.Find(id);
            if (customer_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(customer_vehicles);
        }

        // GET: CusomerVehicles/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.customers, "customerid", "external_key");
            return View();
        }

        // POST: CusomerVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicle_id,customer_id,vin,year,make,model,active,create_date,created_by")] customer_vehicles customer_vehicles)
        {
            if (ModelState.IsValid)
            {
                db.customer_vehicles.Add(customer_vehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.customers, "customerid", "external_key", customer_vehicles.customer_id);
            return View(customer_vehicles);
        }

        // GET: CusomerVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_vehicles customer_vehicles = db.customer_vehicles.Find(id);
            if (customer_vehicles == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.customers, "customerid", "external_key", customer_vehicles.customer_id);
            return View(customer_vehicles);
        }

        // POST: CusomerVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicle_id,customer_id,vin,year,make,model,active,create_date,created_by")] customer_vehicles customer_vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_vehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.customers, "customerid", "external_key", customer_vehicles.customer_id);
            return View(customer_vehicles);
        }

        // GET: CusomerVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_vehicles customer_vehicles = db.customer_vehicles.Find(id);
            if (customer_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(customer_vehicles);
        }

        // POST: CusomerVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customer_vehicles customer_vehicles = db.customer_vehicles.Find(id);
            db.customer_vehicles.Remove(customer_vehicles);
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
