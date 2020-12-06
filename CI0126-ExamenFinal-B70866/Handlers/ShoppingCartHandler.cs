using System;
using System.Collections.Generic;
using SqlKata.Execution;
using Dapper;
using CI0126_ExamenFinal_B70866.Models;

namespace CI0126_ExamenFinal_B70866.Handlers
{
    public class ShoppingCartHandler : Handler
    {
        public void addProductToCart(Product product)
        {
            try
            {
                db.Query("ShoppingCart").Insert(new
                {
                    productID = product.id,
                    amount = product.amount
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Product> getAllProductsInCart()
        {
            IEnumerable<Product> products = db.Query("ShoppingCart").Select(
                "productID as id",
                "productAmount as amount"
                ).Get<Product>();
            return products.AsList();
        }
    }
}