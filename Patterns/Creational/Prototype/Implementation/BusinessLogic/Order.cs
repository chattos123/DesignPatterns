
using Patterns.Creational.Prototype.Implementation.DataClass;
using Patterns.Creational.Prototype.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Prototype.Implementation.BusinessLogic
{
    internal class Order: IOrderPrototype
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime CreatedAt { get; set; }

        // References that need different handling based on context
        public List<OrderItem> LineItems { get; set; } = new List<OrderItem>();
        public FlashSaleLogisticsContext? FlashSaleContext { get; set; }

        public Order(string orderId, string customerId, string address)
        {
            OrderId = orderId;
            CustomerId = customerId;
            ShippingAddress = address;
            CreatedAt = DateTime.UtcNow;
        }

        // --- USE CASE 1: SHALLOW CLONE (Flash Sale Strategy) ---
        // Instantly duplicates properties but shares structural/logistics instances
        public IOrderPrototype FlashSaleShallowClone()
        {
            // Value types and string references are copied. 
            // The internal pointers to LineItems and FlashSaleContext are shared.
            return (IOrderPrototype)this.MemberwiseClone();
        }

        // --- USE CASE 2: DEEP CLONE (Customer Reorder Strategy) ---
        // Fully uncouples the order data structures from past history
        public IOrderPrototype ReOrderDeepClone()
        {
            // 1. Bitwise copy handles root values
            Order clonedOrder = (Order)this.MemberwiseClone();

            // 2. Isolate the list array entirely by creating a new collection
            clonedOrder.LineItems = new List<OrderItem>();
            foreach (var item in this.LineItems)
            {
                clonedOrder.LineItems.Add(new OrderItem(item.Sku, item.Quantity, item.UnitPrice));
            }

            // 3. For a normal reorder, flash sale bulk context is stripped/isolated
            clonedOrder.FlashSaleContext = null;

            return (IOrderPrototype)clonedOrder;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"\n[Order ID: {OrderId}] | Customer: {CustomerId} | Created: {CreatedAt.ToLongTimeString()}");
            Console.WriteLine($"  -> Ship To: {ShippingAddress}");
            if (FlashSaleContext != null)
            {
                Console.WriteLine($"  -> [Flash Sale Active] Route: {FlashSaleContext.ShippingCarrierCode} via Warehouse: {FlashSaleContext.BatchWarehouseId}");
            }
            Console.WriteLine("  -> Items:");
            foreach (var item in LineItems)
            {
                Console.WriteLine($"     * {item.Sku} x {item.Quantity} (@ ${item.UnitPrice}/each)");
            }
        }
    }
}
