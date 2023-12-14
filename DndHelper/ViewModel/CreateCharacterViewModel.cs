using DndHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.ViewModel
{
    public class CreateCharacterViewModel : PropPropertyChanged
    {
        private Character character;

        private string searchString;

        private ObservableCollection<string> races;
        private ObservableCollection<Character> classes;
        private ObservableCollection<string> filteredRaces;
        private ObservableCollection<string> filteredClasses;

        
        
        public Character Character
        {
            get { return character; }
            set
            {
                character = value;
                OnPropertyChanged(nameof(Character));
            }
        }
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                OnPropertyChanged(nameof(SearchString));
                SearchRaces();
            }
        }
        private Character selectedClass;
        public Character SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        public ObservableCollection<string> Races { get; set; }
        public ObservableCollection<Character> Classes { get; set; }
        public ObservableCollection<string> FilteredRaces
        {
            get { return filteredRaces; }
            set
            {
                filteredRaces = value;
                OnPropertyChanged(nameof(FilteredRaces));
            }
        }
        public ObservableCollection<string> FilteredClasses
        {
            get { return filteredClasses; }
            set
            {
                filteredClasses = value;
                OnPropertyChanged(nameof(FilteredClasses));
            }
        }
        private void SearchRaces()
        {
            if (string.IsNullOrEmpty(SearchString))
            {
                FilteredRaces = Races;
            }
            else
            {
                FilteredRaces = new ObservableCollection<string>(
                    from race in Races
                    where race.Contains(SearchString, StringComparison.OrdinalIgnoreCase)
                    orderby race
                    select race
                );
            }
        }
        public CreateCharacterViewModel()
        {
            Character = new Character();
            Races = new ObservableCollection<string>(DataContext.DataBase.Races);
            Classes = new ObservableCollection<Character>
            {
                new Fighter(),
                new Cleric()
                // Добавьте другие классы по мере необходимости
            };
        }
    }
}
