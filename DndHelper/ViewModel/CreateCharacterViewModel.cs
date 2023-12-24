using DndHelper.Model;
using DndHelper.Model.Classes;
using DndHelper.Model.Races;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.ViewModel
{
    public class CreateCharacterViewModel : PropPropertyChanged
    {
        private Character character;

        private ObservableCollection<string> races;
        private ObservableCollection<Character> classes;

        public Character Character
        {
            get { return character; }
            set
            {
                character = value;
                OnPropertyChanged(nameof(Character));
            }
        }
        private Character selectedClass;
        public Character SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                Character = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        private Race selectedRace;
        public Race SelectedRace
        {
            get { return selectedRace; }
            set
            {
                selectedRace = value;
                OnPropertyChanged(nameof(SelectedRace));
                UpdateSelectedClassRace();
            }
        }
        public ObservableCollection<Race> Races { get; set; }
        public ObservableCollection<Character> Classes { get; set; }

        public CreateCharacterViewModel()
        {
            Character = new Character();
            Races = new()
            {
                new HalfOrc() {Character = SelectedClass},
                new WoodElf() {Character = SelectedClass},
                new HighElf() {Character = SelectedClass},
                new Goblin()  {Character = SelectedClass}
            };

            SelectedRace = Races.First();

            Classes = new ObservableCollection<Character>
            {
                new Fighter(SelectedRace),
                new Cleric(SelectedRace)
                // Добавьте другие классы по мере необходимости
            };

            SelectedClass = Classes.First();
        }
        private void UpdateSelectedClassRace()
        {
            if(SelectedClass != null)
    {
                SelectedClass.Race = SelectedRace;
                OnPropertyChanged(nameof(Classes));
            }
        }
    }
}
