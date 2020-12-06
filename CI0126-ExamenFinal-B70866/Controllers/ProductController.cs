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
            ProductHandler productHandler = new ProductHandler();
            Product newProduct = new Product();
            newProduct.id = productID;
            newProduct.amount = amount;
            productHandler.addProductToCart(newProduct);
            return RedirectToAction("shoppingCart");
        }

        public double getTotalPrice()
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

        public List<int> getOrderedDistinctIDs(List<Product>products) 
        {
            List<int> productIDs = new List<int>();
            foreach (var product in products) 
            {
                if (!productIDs.Exists(id => id == product.id))
                {
                    productIDs.Append(product.id);
                }
            }
            productIDs.OrderByDescending(id => id);
            return productIDs;
        }

        public int[] getAmountOfProductsInCart(List<Product> products) 
        {
            List<int> productIDs = getOrderedDistinctIDs(products);
            int arraySize = productIDs.First();
            int[] amountsArray = new int[arraySize];
            foreach (var id in productIDs)
            {
                foreach (var product in products) 
                {
                    if (id == product.id) 
                    {
                        amountsArray[id] +=product.amount;
                    }
                }           
            }
            return amountsArray;
        }

        public double[] getDiscounts(int[] amountsArray) 
        {
            ProductHandler productHandler = new ProductHandler();
            double[] discountsArray = new double[amountsArray.Length];
            for (int i = 0; i < amountsArray.Length; i++)
            {
                if (amountsArray[i] != 0) 
                {
                    double discount = productHandler.getProductDiscount(i);
                    int discountAmount = productHandler.getProductDiscountAmount(i);
                    int amountOfDiscounts = amountsArray[i] % discountAmount;
                }
            }
            return discountsArray;
        }

        [HandleError]
        public ActionResult shoppingCart()
        {
            ProductHandler productHandler = new ProductHandler();
            ViewBag.productsInCart = productHandler.getAllProductsInCart().ToList();
            ViewBag.totalPrice = getTotalPrice();
            return View();
        }
    }
}