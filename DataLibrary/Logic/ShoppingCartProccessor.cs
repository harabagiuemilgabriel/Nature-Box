using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
         public static class ShoppingCartProccessor
         {
                public static List<Product> LoadProductSC(string table, string DBName)
                {
                    string sql = @"select ProductName, ProductPrice, ProductBenefits, ProductAbout, ProductImage
                                 from " + table + ";";

                    return SQLDataAccess.LoadData<Product>(sql, DBName);
                }

                public static int CreateProductSC(string DBName, string table, string productName, float productPrice,float productQuantity, int productType)
                {
                    Product data = new Product
                    {
                        ProductName = productName,
                        ProductPrice = productPrice,
                        ProductType=productType,
                        ProductQuantity=productQuantity
                    };

                    string sql = @"insert into dbo." + table + "(ProductName, ProductPrice, ProductType, ProductQuantity) values (@ProductName, @ProductPrice, @ProductType, @ProductQuantity);";

                    return SQLDataAccess.SaveData(sql, data, DBName);
                }
            

                public static void Add(string DBName, string table, string name, float quantity)
                {
                    string sql = "UPDATE " + table + " SET ProductQuantity = ProductQuantity +" + quantity + " WHERE ProductName = '" + name+"'";
                    SQLDataAccess.Update(sql, DBName);
                }
    }
}

