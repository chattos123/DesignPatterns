using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Builder.Interface
{
    public interface IDocument
    {
        void AddContent(string content);
        void PrintDocument();
    }
}
