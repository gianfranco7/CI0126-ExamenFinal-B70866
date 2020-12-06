using System;
using System.Collections.Generic;
using SqlKata.Execution;
using System.Web;
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
    }
}