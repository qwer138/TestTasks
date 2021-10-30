using System;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class AsyncCaller
    {
        private EventHandler _eventHandler;

        public AsyncCaller(EventHandler eventHandler)
        {
            _eventHandler = eventHandler ?? throw new ArgumentNullException($"{nameof(eventHandler)} is null");
        }

        public bool Invoke(int milliseconds, object sender, EventArgs eventArgs)
        {
            return Task.Run(() => _eventHandler.Invoke(sender, eventArgs)).Wait(milliseconds);
        }
    }
}
