using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NatureBox.Models
{
    public class ShoppingCart
    {
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }

        public bool ProductType { get; set; }

        public float ProductQuantity { get; set; }

        public float TotalPrice { get; set; }

    }
}