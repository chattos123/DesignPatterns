using System;

namespace Patterns.Structural.Proxy.Interface
{
    internal interface IDatabaseManager
    {
        string ReadRecord(int recordId);
        void WriteRecord(int recordId, string data);
    }
}
