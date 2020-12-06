using System;
using System.Collections.Generic;
using SqlKata.Execution;
using System.Web;
using System.IO;
using Dapper;
using CI0126_ExamenFinal_B70866.Models;

namespace CI0126_ExamenFinal_B70866.Handlers
{
    public class ProductHandler : Handler
    {
        private byte[] getBytes(HttpPostedFileBase file)
        {
            byte[] bytes;
            BinaryReader reader = new BinaryReader(file.InputStream);
            bytes = reader.ReadBytes(file.ContentLength);
            return bytes;
        }

        public void addProduct(Product newProduct)
        {
            try
            {
                db.Query("Product").Insert(new
                {
                    productName = newProduct.name,
                    productDescription = newProduct.description,
                    newProduct.discountAmount,
                    newProduct.price,
                    newProduct.discount,
                    productImage = getBytes(newProduct.image),
                    imageType = newProduct.image.ContentType,
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Product> getAllCommunityMembers()
        {
            IEnumerable<Product> products = db.Query("Product").Select(
                "productName as name", 
                "productDescription as description", 
                "discountAmount as discountAmount",
                "price as price",
                "discount as discount"
                ).Get<Product>();
            return products.AsList();
        }
    }
}