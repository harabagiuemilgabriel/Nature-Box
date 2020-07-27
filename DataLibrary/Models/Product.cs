using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.Models
{
   public  class Product
    {
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public string ProductBenefits { get; set; }
        public string ProductAbout { get; set; }
        public string ProductImage { get; set; }
        public int ProductType { get; set; }
        public float ProductQuantity { get; set; }
    }
}
