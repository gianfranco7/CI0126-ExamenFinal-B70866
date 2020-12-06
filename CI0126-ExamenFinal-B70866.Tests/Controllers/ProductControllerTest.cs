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
        public void getOrderedDistinctIDsTest()
        {
            // Arrange
            List<Product> testProductList = new List<Product>();
            ProductController controller = new ProductController();

            // Act
            List<int>result = controller.getOrderedDistinctIDs(testProductList);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
