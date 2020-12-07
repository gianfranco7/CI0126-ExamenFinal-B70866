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
            testProduct.id = 0;
            ProductController controller = new ProductController();

            // Act
            ActionResult result = controller.addProduct(testProduct);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
