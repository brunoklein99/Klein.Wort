using System;
using System.Timers;
using System.Windows.Threading;

namespace Klein.Wort.ViewModel
{
    public class DefaultTimer : ITimer
    {
        private readonly DispatcherTimer _timer;

        public DefaultTimer()
        {
            _timer = new DispatcherTimer();
        }

        public void Start(int interval)
        {
            _timer.Interval = new TimeSpan(0,0,0,0, interval);
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public event EventHandler Elapsed
        {
            add { _timer.Tick += value; }
            remove { _timer.Tick -= value; }
        }
    }
}