using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Micraft_Task;

namespace Micraft_Task.Controllers
{
    public class OrdersController : Controller
    {
        private MicraftTaskDBEntities db = new MicraftTaskDBEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var tblOrders = db.tblOrders.Include(t => t.Customer);
            return View(tblOrders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrders.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            return View(tblOrder);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderDate,CustomerId,TotalQty,TotalAmount")] tblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                db.tblOrders.Add(tblOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", tblOrder.CustomerId);
            return View(tblOrder);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrders.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", tblOrder.CustomerId);
            return View(tblOrder);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderDate,CustomerId,TotalQty,TotalAmount")] tblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", tblOrder.CustomerId);
            return View(tblOrder);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrders.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            return View(tblOrder);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOrder tblOrder = db.tblOrders.Find(id);
            db.tblOrders.Remove(tblOrder);
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
