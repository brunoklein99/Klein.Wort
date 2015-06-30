using System;
using System.Collections.Generic;
using Klein.Wort.Domain.Models;

namespace Klein.Wort.ViewModel
{
    public interface IWordTranslationManager
    {
         event EventHandler<IEnumerable<WordTranslation>> OnNewWords;
    }
}