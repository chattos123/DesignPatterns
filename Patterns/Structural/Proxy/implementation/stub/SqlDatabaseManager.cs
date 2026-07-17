using System;
using System.Collections.Generic;
using Patterns.Structural.Proxy.Interface;

namespace Patterns.Structural.Proxy.implementation.stub
{
    internal class SqlDatabaseManager: IDatabaseManager
    {
        private readonly Dictionary<int, string> _mockDb = new()
    {
        { 101, "System Config: Active" },
        { 102, "User Data: John Doe" }
    };

        public string ReadRecord(int recordId)
        {
            Console.WriteLine($"[SQL Database] Executing SELECT query for Record ID: {recordId}...");
            return _mockDb.TryGetValue(recordId, out var data) ? data : "Record Not Found";
        }

        public void WriteRecord(int recordId, string data)
        {
            Console.WriteLine($"[SQL Database] Executing UPDATE/INSERT query for Record ID: {recordId}...");
            _mockDb[recordId] = data;
            Console.WriteLine("[SQL Database] Transaction committed successfully.");
        }
    }
}
