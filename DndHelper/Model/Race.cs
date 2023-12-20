using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    class Race : PropPropertyChanged
    {
        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }

        private int dexterity;
        public int Dexterity
        {
            get { return dexterity; }
            set
            {
                dexterity = value;
                OnPropertyChanged(nameof(Dexterity));
            }
        }

        private int constitution;
        public int Constitution
        {
            get { return constitution; }
            set
            {
                constitution = value;
                OnPropertyChanged(nameof(Constitution));
            }
        }

        private int intelligence;
        public int Intelligence
        {
            get { return intelligence; }
            set
            {
                intelligence = value;
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        private int wisdom;
        public int Wisdom
        {
            get { return wisdom; }
            set
            {
                wisdom = value;
                OnPropertyChanged(nameof(Wisdom));
            }
        }

        private int charisma;
        public int Charisma
        {
            get { return charisma; }
            set
            {
                charisma = value;
                OnPropertyChanged(nameof(Charisma));
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

        private Character character = null;
        public Character Character
        {
            get { return character; }
            set
            {
                character = value;
                OnPropertyChanged(nameof(Character));
            }
        }
    }
}
