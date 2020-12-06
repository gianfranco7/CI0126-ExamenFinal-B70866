using System;
using System.Collections.Generic;
using SqlKata.Execution;
using System.Web;
using System.IO;
using Dapper;
using CI0126_ExamenFinal_B70866.Models;
using Helpers;

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

        public Tuple<byte[], string> downloadImage(int productID)
        {
            FileAdapter adapter = db.Query("Product").Select("productImage as fileContent", "imageType as fileType").Where("productID", productID).First<FileAdapter>();
            return new Tuple<byte[], string>(adapter.fileContent, adapter.fileType);
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

        public List<Product> getAllProducts()
        {
            IEnumerable<Product> products = db.Query("Product").Select(
                "productID as id",
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