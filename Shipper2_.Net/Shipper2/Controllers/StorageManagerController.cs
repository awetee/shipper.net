using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shipper2.Models;

namespace Shipper2.Controllers
{
    //[Authorize]//(Roles = "Administrator")]
    public class StorageManagerController : Controller
    {
        private ShipperContext db = new ShipperContext();

        // GET: StorageManager
        public ActionResult Index()
        {
            var products = db.Products.Include(a => a.Retailer).Include(a => a.ProductCategory);
            return View(products.ToList());
        }

        // GET: StorageManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: StorageManager/Create
        public ActionResult Create()
        {
            ViewBag.RetailerId = new SelectList(db.Retailers, "RetailerId", "Name");
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "ProductCategoryId", "Name");
            return View();
        }

        // POST: StorageManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductCategoryId,RetailerId,Title,Price,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RetailerId = new SelectList(db.Retailers, "RetailerId", "Name", product.RetailerId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "ProductCategoryId", "Name", product.ProductCategoryId);
            return View(product);
        }

        // GET: StorageManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.RetailerId = new SelectList(db.Retailers, "RetailerId", "Name", product.RetailerId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "ProductCategoryId", "Name", product.ProductCategoryId);
            return View(product);
        }

        // POST: StorageManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductCategoryId,RetailerId,Title,Price,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RetailerId = new SelectList(db.Retailers, "RetailerId", "Name", product.RetailerId);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "ProductCategoryId", "Name", product.ProductCategoryId);
            return View(product);
        }

        // GET: StorageManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: StorageManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
