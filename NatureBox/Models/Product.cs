using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NatureBox.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public string ProductBenefits { get; set; }
        public string ProductAbout { get; set; }
        public string Image { get; set; }

        public string ProductImage { get; set; }

        public float ProductQuantity { get; set; }

        public bool Vegetable { get; set; }
    }
}