using System;
using System.Timers;

namespace Klein.Wort.ViewModel
{
    public interface ITimer
    {
        void Start(int interval);

        void Stop();

        event EventHandler Elapsed;
    }
}