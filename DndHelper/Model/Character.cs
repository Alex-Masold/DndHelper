using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Linq;

namespace DndHelper.Model
{
    public class Character : Template
    {
        private int exhaustion;

        private bool masteryinspiration;

        private string classCharacter;
        private string archetype;

        private List<string> ownerships;

        public int Exhaustion
        {
            get { return exhaustion; }
            set
            {
                exhaustion = value;
                OnPropertyChanged(nameof(Exhaustion));
            }
        }
        public bool MasteryInspiration
        {
            get { return masteryinspiration; }
            set
            {
                masteryinspiration = value;
                OnPropertyChanged(nameof(MasteryInspiration));
            }
        }

        public string ClassCharacter
        {
            get { return classCharacter; }
            set
            {
                classCharacter = value;
                OnPropertyChanged(nameof(ClassCharacter));
            }
        }
        public string Archetype
        {
            get { return archetype; }
            set
            {
                archetype = value;
                OnPropertyChanged(nameof(Archetype));
            }
        }

        public List<string> Owerships
        {
            get { return ownerships; }
            set
            {
                ownerships = value;
                OnPropertyChanged(nameof(Owerships));
            }
        }

        public Character(
            string name,
            string race,
            string classCharacter,
            int level = 1,
            string archetype = default)
        {
            Name = name;
            Race = race;
            ClassCharacter = classCharacter;

            Level  = level;
            HitPoints = 0;
            ArmorClass = 10;
            Exhaustion = 0;
            UpdateMasteryBonus(level);
            Speed = 0;
            PassivePerception = 10;
            Initiative = 0;

            HitPointDice = null;

            MasteryInspiration = false;
            BardicInspiration = false;

            Archetype = archetype;

            States = DataContext.DataBase.DefultStats;

            Equipment = new();
            Owerships = new();
            Abilities = new();
        }

        public void UpdateMasteryBonus(int level)
        {
            if (level <= 4)
            {
                MasteryBonus = 2;
            }
            else if (level  <= 8)
            {
                MasteryBonus = 3;
            }
            else if (level <= 12)
            {
                MasteryBonus = 4;
            }
            else if (level <= 16)
            {
                MasteryBonus = 5;
            }
            else if (level <= 20)
            {
                MasteryBonus = 6;
            }
        }
    }
}
