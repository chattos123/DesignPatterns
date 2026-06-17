using Patterns.Creational.Prototype.Implementation;
using Patterns.Creational.Prototype.Implementation.BusinessLogic;
using Patterns.Creational.Prototype.Implementation.DataClass;
using Patterns.Creational.Prototype.Interface;
using Patterns.Simulator.Interface;


namespace Patterns.Simulator.Implementation
{
    internal class PrototypeSimulator : ISimulator
    {
        public void Simulate()
        {
            // =========================================================================
            // SCENARIO A: The Customer "Reorder" Flow (Requires DEEP Copy)
            // =========================================================================
            Console.WriteLine("=== SCENARIO A: CUSTOMER REORDER (DEEP COPY) ===");

            // 1. Setup a past order archive
            Order historicalOrder = new Order("ORD-2025-X", "CUST-99", "101 Base Road");
            historicalOrder.LineItems.Add(new OrderItem("PHONE-14", 1, 799.99m));
            historicalOrder.CreatedAt = DateTime.Parse("2025-05-12");

            Console.WriteLine("Original Historical Order:");
            historicalOrder.PrintDetails();

            // 2. User clicks "Reorder items from last year", updating details safely
            Order customerNewOrder = (Order)historicalOrder.ReOrderDeepClone();
            customerNewOrder.OrderId = "ORD-2026-NEW-01";
            customerNewOrder.CreatedAt = DateTime.UtcNow;

            // Alice changed her mind, she wants 3 phones now for her family, and moved house
            customerNewOrder.ShippingAddress = "202 Upgraded Blvd";
            customerNewOrder.LineItems[0].Quantity = 3;

            Console.WriteLine("\nModified New Order:");
            customerNewOrder.PrintDetails();

            Console.WriteLine("\nVerifying Historical Integrity (Should remain uncorrupted):");
            historicalOrder.PrintDetails(); // Quantity stays 1, address stays "101 Base Road"


            // =========================================================================
            // SCENARIO B: The Lightning Flash Sale Flow (Requires SHALLOW Copy)
            // =========================================================================
            Console.WriteLine("\n\n=========================================================================");
            Console.WriteLine("=== SCENARIO B: MASSIVE FLASH SALE DROPS (SHALLOW COPY) ===");
            Console.WriteLine("=========================================================================");

            // 1. Setup global configurations for this specific sale window
            FlashSaleLogisticsContext sharedSaleContext = new FlashSaleLogisticsContext("WH-MEGA-EAST", "FEDEX-PRIORITY", "DROP-2026");

            // Create the Master Prototype blueprint order for a special bundle drop
            Order flashSaleBlueprint = new Order("BLUEPRINT", "PENDING", "PENDING");
            flashSaleBlueprint.LineItems.Add(new OrderItem("LIMIT-ED-SHOES", 1, 150.00m));
            flashSaleBlueprint.FlashSaleContext = sharedSaleContext;

            // 2. Simulate 2 customers purchasing at exactly the same microsecond
            // We use cheap shallow clones to avoid generating new internal lists in CPU memory loop
            Order buyerOrder1 = (Order)flashSaleBlueprint.FlashSaleShallowClone();
            buyerOrder1.OrderId = "SALE-ORD-001";
            buyerOrder1.CustomerId = "USER-ALICE";
            buyerOrder1.ShippingAddress = "777 Winner Lane";

            Order buyerOrder2 = (Order)flashSaleBlueprint.FlashSaleShallowClone();
            buyerOrder2.OrderId = "SALE-ORD-002";
            buyerOrder2.CustomerId = "USER-BOB";
            buyerOrder2.ShippingAddress = "888 Lucky Street";

            Console.WriteLine("\nFlash Sale Order Batch Dispatched:");
            buyerOrder1.PrintDetails();
            buyerOrder2.PrintDetails();

            // 3. Operational Change Impact:
            // A major weather event happens. The warehouse manager dynamically reroutes ALL 
            // orders in this drop from FedEx to DHL instantly via the single shared pointer.
            sharedSaleContext.ShippingCarrierCode = "DHL-EXPRESS-AIR";

            Console.WriteLine("\n--- SYSTEM EMERGENCY WARNING: Logistics Provider Adjusted Real-Time ---");
            Console.WriteLine("Both concurrent checkouts adapt immediately due to shared shallow reference architecture:");
            buyerOrder1.PrintDetails();
            buyerOrder2.PrintDetails();
        }
    }
}
