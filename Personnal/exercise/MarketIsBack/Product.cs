
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIsBack
{
    internal class Product
    {
        private int location;
        public int Location { get { return location; } set { location = value; } }

        private string producer;
        public string Producer { get { return producer; } set { producer = value; } }

        private string productName;
        public string ProductName { get {  return productName; } set {  productName = value; } }

        private int quantity;
        public int Quantity { get { return quantity; } set { quantity = value; } }

        private string unit;
        public string Unit { get { return unit; } set { unit = value; } }

        private double pricePerUnit;
        public double PricePerUnit { get {  return pricePerUnit; } set {  pricePerUnit = value; } } 
    }
}
