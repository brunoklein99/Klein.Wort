using System;

namespace Klein.Wort.Domain.Models
{
    public class WordTranslation
    {
        public string Word { get; private set; }

        public string Translation { get; private set; }

        public WordTranslation(string word, string translation)
        {
            if (word == null) throw new ArgumentNullException(nameof(word));
            if (translation == null) throw new ArgumentNullException(nameof(translation));
            Word = word;
            Translation = translation;
        }
    }
}