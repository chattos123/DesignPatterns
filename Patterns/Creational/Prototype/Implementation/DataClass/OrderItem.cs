using System;
using System.Collections.Generic;

namespace Patterns.Creational.Prototype.Implementation.DataClass
{
    internal class OrderItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderItem(string sku, int quantity, decimal price)
        {
            Sku = sku;
            Quantity = quantity;
            UnitPrice = price;
        }
    }
}
