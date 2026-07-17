using Patterns.Simulator.Interface;
using Patterns.Structural.Proxy.implementation.datacontract;
using Patterns.Structural.Proxy.implementation.proxy;
using Patterns.Structural.Proxy.implementation.stub;
using Patterns.Structural.Proxy.Interface;
using System;

namespace Patterns.Simulator.Implementation
{
    internal class ProxySimulator : ISimulator
    {
        public void Simulate()
        {
            

            Console.WriteLine("=== SCENARIO 1: GUEST USER SESSION ===");
            UserSession guestUser = new UserSession("Jhon Doe", UserRole.Guest);

            // Wrap the DB engine in the proxy container for Alice
            IDatabaseManager databaseForAlice = new DatabaseAccessProxy(guestUser);

            try
            {
                // Read should succeed
                string data = databaseForAlice.ReadRecord(101);
                Console.WriteLine($"Result: Received data -> \"{data}\"\n");

                // Write should fail dramatically
                databaseForAlice.WriteRecord(101, "Malicious Overwrite Try");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Application caught security exception: {ex.Message}\n");
            }


            Console.WriteLine("=== SCENARIO 2: ADMIN USER SESSION ===");
            UserSession adminUser = new UserSession("bob_admin", UserRole.Admin);

            // Wrap the same DB engine in the proxy container for Bob
            IDatabaseManager databaseForBob = new DatabaseAccessProxy(adminUser);

            try
            {
                // Read should succeed
                string data = databaseForBob.ReadRecord(101);
                Console.WriteLine($"Result: Received data -> \"{data}\"\n");

                // Write should succeed seamlessly
                databaseForBob.WriteRecord(101, "System Config: Maintenance Mode");

                // Verify write operation
                string updatedData = databaseForBob.ReadRecord(101);
                Console.WriteLine($"Result: Verified updated data -> \"{updatedData}\"\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
        }
    }
}
