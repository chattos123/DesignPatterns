using Patterns.Structural.Bridge.Interface;

namespace Patterns.Structural.Bridge.Implementation.Devices
{
    internal class Television: IDevice
    {
        private bool _on = false;
        private int _volume = 30;

        public bool IsEnabled() => _on;
        public void Enable() => _on = true;
        public void Disable() => _on = false;
        public int GetVolume() => _volume;
        public void SetVolume(int percent) => _volume = percent;
    }
}
