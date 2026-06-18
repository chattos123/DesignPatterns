using Patterns.Structural.Bridge.Interface;

namespace Patterns.Structural.Bridge.Implementation.RemoteControl
{
    internal class AdvancedRemoteControl : RemoteControl, IAdvancedRemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public void Mute()
        {
            Console.WriteLine("AdvancedRemoteControl: Muting the device.");
            _device.SetVolume(0);
        }
    }
}
