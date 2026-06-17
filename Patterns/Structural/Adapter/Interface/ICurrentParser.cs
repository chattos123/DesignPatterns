using System;


namespace Patterns.Structural.Adapter.Interface
{
    // 1. THE TARGET INTERFACE
    internal interface ICurrentParser
    {
        void ParseJson(string jsonAndMetadata);
    }
}
