using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CI0126_ExamenFinal_B70866.Handlers;
using CI0126_ExamenFinal_B70866.Models;

namespace CI0126_ExamenFinal_B70866.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult addProductToCart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addProductToCart(Product newProduct, int amount)
        {
            ShoppingCartHandler shoppingCartHandler = new ShoppingCartHandler();
            newProduct.amount = amount;
            shoppingCartHandler.addProductToCart(newProduct);
            return View();
        }

        [HandleError]
        public ActionResult shoppingCart()
        {
            ShoppingCartHandler shoppingCartHandler = new ShoppingCartHandler();
            ViewBag.productsInCart = shoppingCartHandler.getAllProductsInCart().ToList<Product>();
            return View(ViewBag.productsInCart);
        }
    }
}