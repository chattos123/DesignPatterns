using Patterns.Structural.Proxy.implementation.datacontract;
using Patterns.Structural.Proxy.implementation.stub;
using Patterns.Structural.Proxy.Interface;
using System;


namespace Patterns.Structural.Proxy.implementation.proxy
{
    internal class DatabaseAccessProxy: IDatabaseManager
    {
        private readonly IDatabaseManager _realDatabase;
        private readonly UserSession _currentUser;

        // The real database is passed in (Aggregation), alongside the active user session
        public DatabaseAccessProxy(UserSession currentUser, IDatabaseManager? realDatabase = null)
        {
            if(null == realDatabase)
            {
                _realDatabase = new SqlDatabaseManager();
            }
            else
            {
                _realDatabase = realDatabase;
            }
            
            _currentUser = currentUser;
        }

        public string ReadRecord(int recordId)
        {
            // Audit log
            Console.WriteLine($"[Proxy Log] User '{_currentUser.Username}' ({_currentUser.Role}) requested READ access to ID {recordId}.");

            // Both Guests and Admins are allowed to read
            return _realDatabase.ReadRecord(recordId);
        }

        public void WriteRecord(int recordId, string data)
        {
            // Audit log
            Console.WriteLine($"[Proxy Log] User '{_currentUser.Username}' ({_currentUser.Role}) requested WRITE access to ID {recordId}.");

            // Protection Logic: Enforce Role-Based Access Control (RBAC)
            if (_currentUser.Role != UserRole.Admin)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Proxy Blocked] Access Denied! Role '{_currentUser.Role}' does not have write permissions.");
                Console.ResetColor();

                //throw new UnauthorizedAccessException($"User '{_currentUser.Username}' is unauthorized to modify database records.");
            }
            else
            {                 Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[Proxy Allowed] Access Granted! Role '{_currentUser.Role}' has write permissions.");
                // If validation passes, delegate the work to the real database
                _realDatabase.WriteRecord(recordId, data);
                Console.ResetColor();
            }

           
        }
    }
}
