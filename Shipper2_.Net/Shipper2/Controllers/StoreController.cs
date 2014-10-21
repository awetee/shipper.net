using Shipper2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore2.Controllers
{
    public class StoreController : Controller
    {
        ShipperContext storeDB = new ShipperContext();
        // GET: Store
        public ActionResult Index()
        {
            // Get most popular albums
            var products = GetTopSellingProducts(5);

            return View(products);
        }

        private List<Product> GetTopSellingProducts(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Products
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public ActionResult Browse(string productCategory)
        {
            var productCategoryModel = storeDB.ProductCategories.Include("Products")
        .Single(g => g.Name == productCategory);

            return View(productCategoryModel);
        }

        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Find(id);
            return View(product);
        }

        // GET: /Store/ProductCategoryMenu
        [ChildActionOnly]
        public ActionResult ProductCategoryMenu()
        {
            var productCategories = storeDB.ProductCategories.ToList();
            return PartialView(productCategories);
        }
    }
}