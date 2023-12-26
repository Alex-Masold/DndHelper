using DndHelper.Model.Stats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media.TextFormatting;

namespace DndHelper.Model.Races
{
    public class Race : PropPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }

        private Character character;
        public Character Character
        {
            get { return character; }
            set
            {
                character = value;
                OnPropertyChanged(nameof(Character));
            }
        }

        private ObservableCollection<Trait> traits;
        public ObservableCollection<Trait> Traits
        {
            get { return traits; }
            set
            {
                traits = value;
                OnPropertyChanged(nameof(Trait));
            }
        }

        private ObservableCollection<string> abilities;
        public ObservableCollection<string> Abilities
        {
            get { return abilities; }
            set
            {
                abilities = value;
                OnPropertyChanged(nameof(Abilities));
            }
        }

        private int strengthBonus;
        public int StrengthBonus
        {
            get { return strengthBonus; }
            set
            {
                strengthBonus = value;
                OnPropertyChanged(nameof(StrengthBonus));
            }
        }

        private int dexterityBonus;
        public int DexterityBonus
        {
            get { return dexterityBonus; }
            set
            {
                dexterityBonus = value;
                OnPropertyChanged(nameof(DexterityBonus));
            }
        }

        private int constitutionBonus;
        public int ConstitutionBonus
        {
            get { return constitutionBonus; }
            set
            {
                constitutionBonus = value;
                OnPropertyChanged(nameof(ConstitutionBonus));
            }
        }

        private int intelligenceBonus;
        public int IntelligenceBonus
        {
            get { return intelligenceBonus; }
            set
            {
                intelligenceBonus = value;
                OnPropertyChanged(nameof(IntelligenceBonus));
            }
        }

        private int wisdomBonus;
        public int WisdomBonus
        {
            get { return wisdomBonus; }
            set
            {
                wisdomBonus = value;
                OnPropertyChanged(nameof(WisdomBonus));
            }
        }

        private int charismaBonus;
        public int CharismaBonus
        {
            get { return charismaBonus; }
            set
            {
                charismaBonus = value;
                OnPropertyChanged(nameof(CharismaBonus));
            }
        }
       
    }
}
