using Microsoft.VisualStudio.TestTools.UnitTesting;
using CI0126_ExamenFinal_B70866.Controllers;
using System.Web.Mvc;
using CI0126_ExamenFinal_B70866.Models;
using System.Collections.Generic;

namespace CI0126_ExamenFinal_B70866.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void buyProductsTest()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            ViewResult result = controller.buyProducts() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void addProductTest()
        {
            // Arrange
            Product testProduct = new Product();
            ProductController controller = new ProductController();

            // Act
            ActionResult result = controller.addProduct(testProduct);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void fileAccessTest()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            ActionResult result = controller.fileAccess(3);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void addProductToCartTest()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            ActionResult result = controller.addProductToCart(5,5);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void getPackageDiscountsTest()
        {
            // Arrange
            Product testProduct = new Product();
            testProduct.discount = 1;
            testProduct.discountAmount = 1;
            testProduct.amount = 1;
            List<Product> testProducts = new List<Product>();
            ProductController controller = new ProductController();

            // Act
            List<Product> result = controller.getPackageDiscounts(testProducts);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
