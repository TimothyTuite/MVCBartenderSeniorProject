using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBartender.Models;

namespace MVCBartender.Controllers
{
    public class barProductsController : Controller
    {
        private barItemContext db = new barItemContext();

        // GET: barProducts
        public ActionResult Index()
        {
            return View(db.barProduct.ToList());
        }

        // GET: barProducts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            barProduct barProduct = db.barProduct.Find(id);
            if (barProduct == null)
            {
                return HttpNotFound();
            }
            return View(barProduct);
        }

        // GET: barProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: barProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,name,price")] barProduct barProduct)
        {
            if (ModelState.IsValid)
            {
                db.barProduct.Add(barProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barProduct);
        }

        // GET: barProducts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            barProduct barProduct = db.barProduct.Find(id);
            if (barProduct == null)
            {
                return HttpNotFound();
            }
            return View(barProduct);
        }

        // POST: barProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,name,price")] barProduct barProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barProduct);
        }

        // GET: barProducts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            barProduct barProduct = db.barProduct.Find(id);
            if (barProduct == null)
            {
                return HttpNotFound();
            }
            return View(barProduct);
        }

        // POST: barProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            barProduct barProduct = db.barProduct.Find(id);
            db.barProduct.Remove(barProduct);
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
