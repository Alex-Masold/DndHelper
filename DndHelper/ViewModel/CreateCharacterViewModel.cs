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
using System.Windows.Media.TextFormatting;

namespace DndHelper.ViewModel
{
    public class CreateCharacterViewModel : PropPropertyChanged
    {
        private Character character;

        private ObservableCollection<string> races;
        private ObservableCollection<Character> classes;

        private Character selectedClass;
        
        private Race selectedRace;
        public Race SelectedRace
        {
            get { return selectedRace; }
            set
            {
                selectedRace = value;
                UpdateSelectedClassRace();
                OnPropertyChanged(nameof(SelectedRace));
            }
        }
        public Character SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                UpdateSelectedClassRace();
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        public ObservableCollection<Race> Races { get; set; }
        public ObservableCollection<Character> Classes { get; set; }

        private RelayCommand dialogTrueCommand;
        //public RelayCommand DialogTrueCommand
        //{
        //    get
        //    {
        //        return dialogTrueCommand ?? (dialogTrueCommand = new RelayCommand(obj =>
        //        {

        //        }));
        //    }
        //}

        public CreateCharacterViewModel()
        {

            Races = new()
            {
                new HalfOrc(),
                new WoodElf(),
                new HighElf(),
                new Goblin()
            };

            Classes = new ObservableCollection<Character>
            {
                new Fighter(),
                new Cleric()
                // Добавьте другие классы по мере необходимости
            };
        }

        private void UpdateSelectedClassRace()
        {
            if (SelectedClass != null && SelectedRace != null)
            {
                SelectedClass.Race = SelectedRace;
                UpdateCharacterAttributes();
                OnPropertyChanged(nameof(Classes));
            }
        }

        private void UpdateCharacterAttributes()
        {
            SelectedClass.Strength.Value = SelectedClass.StrengthValue + SelectedRace.StrengthBonus;
            SelectedClass.Dexterity.Value = SelectedClass.DexterityValue + SelectedRace.DexterityBonus;
            SelectedClass.Constitution.Value = SelectedClass.ConstitutionValue + SelectedRace.ConstitutionBonus;
            SelectedClass.Intelligence.Value = SelectedClass.IntelligenceValue + SelectedRace.IntelligenceBonus;
            SelectedClass.Wisdom.Value = SelectedClass.WisdomValue + SelectedRace.WisdomBonus;
            SelectedClass.Charisma.Value = SelectedClass.CharismaValue + SelectedRace.CharismaBonus;

            SelectedClass.Speed = SelectedRace.Speed;

        }
        
        public Character CreateCharacter()
        {
            return SelectedClass;
        }
    }
}
