using Shipper2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shipper2.Controllers
{
    public class HomeController : Controller
    {
        ShipperContext storeDB = new ShipperContext();

        public ActionResult Index()
        {
            // Get most popular albums
            var products = GetTopSellingAlbums(5);

            return View(products);
        }

        private List<Product> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Products
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}