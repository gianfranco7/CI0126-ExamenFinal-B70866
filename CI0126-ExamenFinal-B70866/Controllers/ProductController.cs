using System.Linq;
using System.Web.Mvc;
using CI0126_ExamenFinal_B70866.Models;
using CI0126_ExamenFinal_B70866.Handlers;
using System.Collections.Generic;

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
            ViewBag.success = false;
            try
            {
                handler.addProduct(product);
                ViewBag.success = true;
                if (ViewBag.success)
                {
                    ViewBag.message = "El producto fue agregado satisfactoriamente";
                }
            }
            catch {
                ViewBag.message = "No se logró añadir el producto por alguna razón";
            }
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
            ProductHandler productHandler = new ProductHandler();
            Product newProduct = new Product();
            newProduct.id = productID;
            newProduct.amount = amount;
            productHandler.addProductToCart(newProduct);
            return RedirectToAction("shoppingCart");
        }

        public double getSubTotalPrice()
        {
            double totalPrice = 0;
            ProductHandler productHandler = new ProductHandler();
            List<Product> productList = productHandler.getAllProductsInCart().ToList();
            foreach (var product in productList)
            {
               product.price = productHandler.getProductPrice(product.id);
               totalPrice += product.price;
            }
            return totalPrice;
        }

        public List<Product> getPackageDiscounts(List<Product> products) 
        {
            ProductHandler productHandler = new ProductHandler();
            foreach (var product in products) 
            {
                if (product.amount == productHandler.getProductDiscountAmount(product.id))
                {
                    product.appliedDiscount = productHandler.getProductDiscount(product.id);
                }
            }
            return products;
        }

        public List<Product> getProductNames(List<Product> products) 
        {
            ProductHandler productHandler = new ProductHandler();
            foreach (var product in products) 
            {
                product.name = productHandler.getProductName(product.id);   
            }
            return products;
        }

        public List<Product> getProductPrices(List<Product> products) 
        {
            ProductHandler productHandler = new ProductHandler();
            foreach (var product in products)
            {
                product.price = productHandler.getProductPrice(product.id);
            }
            return products;
        }

        public double getTotalDiscount(List<Product> products) 
        {
            double totalDiscount = 0;
            foreach (var product in products) 
            {
                totalDiscount += product.appliedDiscount;
            }
            return totalDiscount;
        }

        public double getTotalPrice(double subTotal, double discount) 
        {
            return subTotal - discount;
        }

        public List<Product> getProductsData(List<Product> products) 
        {
            products = getProductNames(products);
            products = getProductPrices(products);
            products = getPackageDiscounts(products);
            return products;
        }

        public ActionResult shoppingCart()
        {
            ProductHandler productHandler = new ProductHandler();
            List<Product> productsInCart = productHandler.getAllProductsInCart().ToList();
            double subTotal = getSubTotalPrice();
            productsInCart = getProductsData(productsInCart);
            double discount = getTotalDiscount(productsInCart);
            ViewBag.productsInCart = productsInCart;
            ViewBag.subTotalPrice = subTotal;
            ViewBag.totalDiscount = discount;
            ViewBag.totalPrice = getTotalPrice(subTotal, discount);
            return View();
        }

        public ActionResult buyProducts() 
        {
            ViewBag.Message = "Sus productos serán enviados a su domicilio en un momento";
            return View();
        }
    }
}