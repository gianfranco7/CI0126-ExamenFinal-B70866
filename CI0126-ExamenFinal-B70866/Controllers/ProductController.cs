using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI0126_ExamenFinal_B70866.Models;

namespace CI0126_ExamenFinal_B70866.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addProduct() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult addProduct(Product product)
        {
            return View();
        }
    }
}