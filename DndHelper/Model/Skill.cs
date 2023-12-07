using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Skill : PropPropertyChanged
    {
        private string name;
        private bool proficient;
        private int modifier;
        private int value;
        private int masteryBonus;
        private Stat stat;
        private Character character;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public bool Proficient
        {
            get => proficient;
            set
            {
                if (proficient != value)
                {
                    proficient = value;
                    OnPropertyChanged(nameof(Proficient));
                }
            }
        }
        public int Modifier
        {
            get { return modifier; }
            set
            {
                if (modifier != value)
                {
                    modifier = value;
                    OnPropertyChanged(nameof(Modifier));
                }
            }
        }
        public int Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }
        public int MasteryBonus
        {
            get => masteryBonus;
            set
            {
                if (masteryBonus != value)
                {
                    masteryBonus = value;
                    OnPropertyChanged(nameof(MasteryBonus));
                }
            }
        }
        public Stat Stat
        {
            get { return stat; }
            set
            {
                stat = value;
                OnPropertyChanged(nameof(Stat));
            }
        }
        public Character Character
        {
            get { return character; }
            set
            {
                character = value;
                OnPropertyChanged(nameof(Character));
                InitModifier();
            }
        }

        public Skill(string name, Stat stat, Character character)
        {
            Name = name;
            Stat = stat;
            Character = character;
        }
        public void InitModifier()
        {
            Modifier = (Value-10)/2;
        }
    }
}
