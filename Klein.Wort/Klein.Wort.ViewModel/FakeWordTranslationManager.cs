using System;
using System.Collections.Generic;
using System.Timers;
using Klein.Wort.Domain.Models;

namespace Klein.Wort.ViewModel
{
    public class FakeWordTranslationManager : IWordTranslationManager
    {
        private readonly IWordTranslationProvider _provider;

        private readonly ITimer _timer;

        public FakeWordTranslationManager(IWordTranslationProvider provider, ITimer timer)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (timer == null) throw new ArgumentNullException(nameof(timer));
            _provider = provider;
            _timer = timer;

            _timer.Elapsed += (sender, args) => OnNewWords?.Invoke(this, _provider.Get(10));
            _timer.Start(5000);
        }

        public event EventHandler<IEnumerable<WordTranslation>> OnNewWords;
    }
}