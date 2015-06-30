using System.Collections.Generic;
using Klein.Wort.Domain.Models;

namespace Klein.Wort.ViewModel
{
    public class FakeWordTranslationProvider : IWordTranslationProvider
    {
        private int _counter;

        public WordTranslation Get()
        {
            return new WordTranslation("test", "teste" + _counter);
        }

        public IEnumerable<WordTranslation> Get(int count)
        {
            _counter++;

            for (var i = 0; i < count; i++)
            {
                yield return Get();
            }
        }
    }
}