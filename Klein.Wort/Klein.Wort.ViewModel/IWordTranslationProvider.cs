using System.Collections.Generic;
using Klein.Wort.Domain.Models;

namespace Klein.Wort.ViewModel
{
    public interface IWordTranslationProvider
    {
        WordTranslation Get();

        IEnumerable<WordTranslation> Get(int count);
    }
}