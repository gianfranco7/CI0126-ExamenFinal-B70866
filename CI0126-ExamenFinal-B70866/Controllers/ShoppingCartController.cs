using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CI0126_ExamenFinal_B70866.Controllers
{
    public class ShoppingCartController : Controller
    {
        [HandleError]
        public ActionResult shoppingCart()
        {
            ShoppingCartHandler shoppingCartHandler = new ShoppingCartHandler();
            ViewBag.productsInCart = shoppingCartHandler.getAllProductsInCart().ToList<Product>();
            return View(ViewBag.productsInCart);
        }
    }
}