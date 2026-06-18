using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural.Bridge.Interface
{
    internal interface IDevice
    {
        bool IsEnabled();
        void Enable();
        void Disable();
        int GetVolume();
        void SetVolume(int percent);
    }
}
