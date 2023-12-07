
using DndHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.ViewModel
{
    public class ApplicationViewModel : PropPropertyChanged
    {
        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                selectedCharacter = value;
                OnPropertyChanged(nameof(selectedCharacter));
            }
        }

        private string searchCharacterString;
        public string SearchCharacterString
        {
            get { return searchCharacterString; }
            set
            {
                searchCharacterString = value;
                OnPropertyChanged(nameof(searchCharacterString));
                Search();
            }
        }

        private ObservableCollection<Character> filteredCharacters;
        public ObservableCollection<Character> FilteredCharacters
        {
            get { return filteredCharacters; }
            set
            {
                filteredCharacters = value;
                OnPropertyChanged(nameof(FilteredCharacters));
            }
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(SearchCharacterString))
            {
                FilteredCharacters = Characters;
            }
            else
            {
                FilteredCharacters = new ObservableCollection<Character>(
                    from character in Characters
                    where
                    character.Name.Contains(SearchCharacterString, StringComparison.OrdinalIgnoreCase) ||
                    character.Race.Contains(SearchCharacterString, StringComparison.OrdinalIgnoreCase)
                    orderby character.Name
                    select character
                    );
            }
        }

        public ObservableCollection<Character> Characters { get; set; }
        public ApplicationViewModel()
        {
            Characters = new ObservableCollection<Character>(DataContext.DataBase.Characters);
            FilteredCharacters = Characters;

            SelectedCharacter = Characters.First();
        }
    }
}
