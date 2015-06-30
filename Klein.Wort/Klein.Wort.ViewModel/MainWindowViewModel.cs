using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Klein.Wort.Domain.Models;

namespace Klein.Wort.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<WordTranslationViewModel> Items { get; }

        public List<WordTranslationViewModel> NewItems { get; } 

        public MainWindowViewModel(IWordTranslationManager manager)
        {
            manager.OnNewWords += ManagerOnNewWords;

            Items = new ObservableCollection<WordTranslationViewModel>();
            NewItems = new List<WordTranslationViewModel>();
        }

        private void ManagerOnNewWords(object sender, IEnumerable<WordTranslation> wordTranslations)
        {
            if (Items.Count == 0)
            {
                foreach (var word in wordTranslations)
                {
                    Items.Add(new WordTranslationViewModel(word));
                }
            }
            else
            {
                NewItems.Clear();
                NewItems.AddRange(wordTranslations.Select(x => new WordTranslationViewModel(x)));

                foreach (var item in Items)
                {
                    item.OnRemovingCompleted += ItemOnRemovingCompleted;
                    item.Removing = true;
                }
            }
        }

        private void ItemOnRemovingCompleted(object sender, EventArgs eventArgs)
        {
            Items.Remove((WordTranslationViewModel) sender);

            var item = NewItems.FirstOrDefault();

            if (item != null)
            {
                Items.Add(item);
                NewItems.Remove(item);
            }
        }
    }
}