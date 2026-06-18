using Patterns.Structural.Bridge.Interface;


// The Base Abstraction implementing the Remote control interface and holding a reference to the Device interface.
// This class will delegate the work to the device implementation.
namespace Patterns.Structural.Bridge.Implementation.RemoteControl
{
    internal class RemoteControl : IRemoteControl
    {
        protected readonly IDevice _device;

        public RemoteControl(IDevice device)
        {
            _device = device;
        }

        public virtual void TogglePower()
        {
            if (_device.IsEnabled())
            {
                Console.WriteLine("{0}: is Enabled so toggeling to Disabled", this._device.GetType().Name);
                _device.Disable();
            }
            else
            {
                Console.WriteLine("{0}: is Disabled so toggeling to Enabled", this._device.GetType().Name);
                _device.Enable();
            }
        }

        public virtual void VolumeDown()
        {
            Console.WriteLine("{0}: Remote is lowering the volume of {1} from {2} by 10", this.GetType().Name,this._device.GetType().Name, _device.GetVolume());
            _device.SetVolume(_device.GetVolume() - 10);
        }
        public virtual void VolumeUp()
        {
            Console.WriteLine("{0}: Remote is powering the volume of {1} from {2} by 10", this.GetType().Name, this._device.GetType().Name, _device.GetVolume());
            _device.SetVolume(_device.GetVolume() + 10);
        }
    }

}
