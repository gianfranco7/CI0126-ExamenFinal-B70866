using System.Linq;
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

        [HttpGet]
        public ActionResult fileAccess(int productID)
        {
            ProductHandler productHandler = new ProductHandler();
            var tuple = productHandler.downloadImage(productID);
            return File(tuple.Item1, tuple.Item2);
        }

        [HttpGet]
        public ActionResult addProductToCart(int productID, int amount)
        {
            ShoppingCartHandler shoppingCartHandler = new ShoppingCartHandler();
            Product newProduct = new Product();
            newProduct.id = productID;
            newProduct.amount = amount;
            shoppingCartHandler.addProductToCart(newProduct);
            return RedirectToAction("shoppingCart");
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