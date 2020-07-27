using NatureBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Logic;
using Microsoft.VisualBasic;
using System.IO;
using System.Drawing;

namespace NatureBox.Controllers
{
    public class ShopController : Controller
    { 

        // GET: Shop
        [HttpGet]
        public ActionResult Categories()
        {
            return View();
        }

        private List<ShoppingCart> makeListOfProducts()
        {
            var data = ShoppingCartCheck.LoadProductSC("dbo.ShoppingCart", "NatureBoxDB");
            List<ShoppingCart> products = new List<ShoppingCart>();

            foreach (var product in data)
            {

                var prod = new ShoppingCart()
                {
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    TotalPrice = product.ProductQuantity * product.ProductPrice,
                };
                if (product.ProductType == 1)
                {
                    prod.ProductType = true;
                }
                else prod.ProductType = false;

                products.Add(prod);
            }
            return products;
        }

        public ActionResult ShoppingCart()
        {
            return View(makeListOfProducts());
        }

        public ActionResult BuyAll()
        {
            ShoppingCartCheck.DeleteAll("NatureBoxDB", "ShoppingCart");
            return View("ShoppingCart", makeListOfProducts());
        }


        
        public ActionResult Fruits(Product inputData)
        {

            var data = ProductProccessor.LoadProduct("dbo.Fruits","NatureBoxDB");

            List<Product> products = new List<Product>();
            foreach(var product in data)
            {
                products.Add(new Product
                {
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductBenefits = product.ProductBenefits,
                    ProductAbout = product.ProductAbout,
                    ProductImage=product.ProductImage
                }) ;
               
            }

            return View(products);
        }

      
     
     
        public ActionResult Vegetables(Product inputData)
        {
            if (inputData.ProductQuantity > 0)
            {
                if (ShoppingCartCheck.CheckIfExistInDB(inputData.ProductName, inputData.ProductPrice, inputData.ProductQuantity, 0) == false)
                {

                }
            }
            var data = ProductProccessor.LoadProduct("dbo.Vegetables", "NatureBoxDB");

            List<Product> products = new List<Product>();
            foreach (var product in data)
            {
                products.Add(new Product
                {
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductBenefits = product.ProductBenefits,
                    ProductAbout = product.ProductAbout,
                    ProductImage = product.ProductImage,
                    ProductQuantity=0
                });

            }

            return View(products);
        }


        public ActionResult ToDataBase()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToDataBase(Product product)
        {
            if(ModelState.IsValid)
            {
                if(product.Vegetable == true)
                ProductProccessor.CreateProduct("NatureBoxDB","Vegetables", product.ProductName, product.ProductPrice, product.ProductBenefits, product.ProductAbout,product.ProductImage);
                else
                {
                    ProductProccessor.CreateProduct("NatureBoxDB", "Fruits", product.ProductName, product.ProductPrice, product.ProductBenefits, product.ProductAbout, product.ProductImage);
                }
            }
            return View("Categories");
        }


        public ActionResult Delete(ShoppingCart data)
        {
            ShoppingCartCheck.DeleteProduct("NatureBoxDB", "dbo.ShoppingCart", data.ProductName);
            Session["productsInCart"]=Convert.ToInt32(Session["productsInCart"]);
            return RedirectToAction("ShoppingCart", makeListOfProducts());
        }
    }
}
