using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI0126_ExamenFinal_B70866.Models;
using CI0126_ExamenFinal_B70866.Handlers;

namespace CI0126_ExamenFinal_B70866.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult addProduct() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult addProduct(Product product)
        {
            ProductHandler handler = new ProductHandler();
            handler.addProduct(product);
            return View();
        }

        [HandleError]
        public ActionResult productList()
        {
            ProductHandler productHandler = new ProductHandler();
            ViewBag.products = productHandler.getAllProducts().ToList<Product>();
            return View(ViewBag.products);
        }
    }
}