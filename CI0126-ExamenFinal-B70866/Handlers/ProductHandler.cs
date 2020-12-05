using System;
using System.Collections.Generic;
using SqlKata.Execution;
using System.Web;
using System.IO;
using Dapper;
using CI0126_ExamenFinal_B70866.Models;
using CI0126_ExamenFinal_B70866.Handlers;

namespace comunidad_practica.Handlers
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
                    newProduct.name,
                    newProduct.description,
                    newProduct.discountAmount,
                    newProduct.price,
                    newProduct.discount,
                    eventImage = getBytes(newProduct.image),
                    fileType = newProduct.image.ContentType,
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}