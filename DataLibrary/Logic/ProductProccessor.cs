using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class ProductProccessor
    {
      public static List<Product> LoadProduct(string table,string DBName)
        {
            string sql = @"select ProductName, ProductPrice, ProductBenefits, ProductAbout, ProductImage
                         from "+table+";";

            return SQLDataAccess.LoadData<Product>(sql,DBName);
        }

        public static int CreateProduct(string DBName,string table, string productName,float productPrice,string productBenefits,string productAbout, string productImage)
        {
            Product data = new Product
            {
                ProductName = productName,
                ProductPrice = productPrice,
                ProductBenefits = productBenefits,
                ProductAbout = productAbout,
                ProductImage = productImage
            };

            string sql = @"insert into dbo."+table+"(ProductName, ProductPrice, ProductBenefits, ProductAbout, ProductImage) values (@ProductName, @ProductPrice, @ProductBenefits, @ProductAbout, @ProductImage);";

            return SQLDataAccess.SaveData(sql, data,DBName);
        }
    }
}
