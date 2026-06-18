using Patterns.Simulator.Interface;
using Patterns.Structural.Bridge.Interface;
using Patterns.Structural.Bridge.Implementation.Devices;
using Patterns.Structural.Bridge.Implementation.RemoteControl;


namespace Patterns.Simulator.Implementation
{
    internal class BridgeSimulator : ISimulator
    {
        public void Simulate()
        {
            IDevice tv = new Television();
            IDevice radio = new Radio();

            IRemoteControl remote = new RemoteControl(radio);
            remote.TogglePower();
            remote.VolumeUp();
            remote.VolumeDown();

            AdvancedRemoteControl advancedRemote = new AdvancedRemoteControl(tv);
            advancedRemote.TogglePower();
            advancedRemote.VolumeUp();
            advancedRemote.VolumeDown();
            advancedRemote.Mute();
        }
    }
}
