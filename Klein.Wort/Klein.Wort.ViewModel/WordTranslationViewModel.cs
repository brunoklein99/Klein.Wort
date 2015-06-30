using System;
using System.Windows.Threading;
using Klein.Wort.Domain.Models;

namespace Klein.Wort.ViewModel
{
    public class WordTranslationViewModel : ViewModelBase
    {
        private bool _removing;

        private readonly DispatcherTimer _timer;

        public event EventHandler OnRemovingCompleted;

        public bool Removing
        {
            get { return _removing; }
            set
            {
                _removing = value;
                _timer.Start();
                OnPropertyChanged();
            }
        }

        public WordTranslation WordTranslation { get; private set; }

        public WordTranslationViewModel(WordTranslation wordTranslation)
        {
            if (wordTranslation == null) throw new ArgumentNullException(nameof(wordTranslation));
            WordTranslation = wordTranslation;

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Tick += TimerOnTick;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            var timer = (DispatcherTimer) sender;

            timer.Stop();

            OnRemovingCompleted?.Invoke(this, new EventArgs());
        }
    }
}