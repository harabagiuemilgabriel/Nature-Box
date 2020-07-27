using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class ShoppingCartCheck
    {
        public static bool CheckIfExistInDB(string ProductName, float ProductPrice, float ProductQuantity,int ProductType)
        {
                if (Validate("NatureBoxDB", "ShoppingCart",ProductName) == true)
                {
                    ShoppingCartProccessor.Add("NatureBoxDB", "ShoppingCart", ProductName, ProductQuantity);
                    return true;
                }
                else
                {
                    ShoppingCartProccessor.CreateProductSC("NatureBoxDB", "ShoppingCart", ProductName, ProductPrice, ProductQuantity, ProductType);
                    return false;
                }
            
        }


        public static List<Product> LoadProductSC(string table, string DBName)
        {
            string sql = @"select ProductName, ProductPrice, ProductType, ProductQuantity from " + table + ";";

            return SQLDataAccess.LoadData<Product>(sql, DBName);
        }

        public static bool Validate(string DBName, string table, string name)
        {
            string sql = "SELECT * FROM " + table + " WHERE ProductName ='" + name + "'";

            return SQLDataAccess.CheckUser(sql, DBName, name);
        }

        public static void DeleteProduct(string DBName, string table, string name)
        {
            string sql="DELETE FROM "+table+" WHERE ProductName='"+name+"';";

            SQLDataAccess.Update(sql, DBName);
        }

        public static void DeleteAll(string DBName, string table)
        {
            string sql = "DELETE FROM " + table + ";";
            SQLDataAccess.Update(sql, DBName);
        }
    }
    
}
