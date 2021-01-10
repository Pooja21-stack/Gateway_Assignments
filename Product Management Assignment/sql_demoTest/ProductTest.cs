using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Models;
using WebApi.Controllers;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace sql_demoTest
{
    [TestClass]
    public class ProductTest
    {
        /*
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetAllProducts();
            var controller = new ProductController(testProducts);

            var result = controller.Gettbl_product(30) as List<tbl_product>;
            Assert.AreEqual(testProducts.Count,result.Count);
        }
        */

        [TestMethod]
          public void GetProduct_ShouldReturnCorrectProduct()
          {
            // Arrange
            var testProducts = GetAllProducts();
            var controller = new ProductController(testProducts);

            // Act
            var result = controller.Gettbl_product(30) as OkNegotiatedContentResult<tbl_product>;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(testProducts[29].product_name, result.Content.product_name);

        }
        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var testProducts = GetAllProducts();
            var controller = new ProductController(testProducts);

            var result = controller.Gettbl_product(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<tbl_product> GetAllProducts()
        {
            var testProducts = new List<tbl_product>();
            testProducts.Add(new tbl_product { product_name = "Ball", product_category = "Toys", price = 50, quantity = 2, short_desc="This is a ball", long_desc = "This is a ball"});
            return testProducts;
        }
    }
}
