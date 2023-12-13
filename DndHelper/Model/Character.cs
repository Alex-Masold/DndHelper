using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                UpdateMasteryBonus();
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
        public int GetStatValue(string statName)
        {
            Stat targetStat = States.FirstOrDefault(stat => stat.Name == statName);

            if (targetStat != null)
            {
                return targetStat.Modifier;
            }
            else
            {
                // Если характеристика не найдена, можно вернуть значение по умолчанию или выбрать другую логику
                return 0;
            }
        }

        public Character()
        {
            CurrenthitPoints = 0;
            HitPoints = 0;
            ArmorClass = 10;
            Exhaustion = 0;
            UpdateMasteryBonus();
            Speed = 30;
            PassivePerception = 10;
            Initiative = 0;

            HitPointDice = null;

            MasteryInspiration = false;
            BardicInspiration = false;

            States = new ObservableCollection<Stat>
            {
                new Stat("Strength", this, 15),
                new Stat("Dexterity", this, 14),
                new Stat("Constitution", this, 13),
                new Stat("Intelligence", this, 12),
                new Stat("Wisdom", this, 10),
                new Stat("Charisma", this, 8)     
            };

            Equipment = new();
            Owerships = new();
            Abilities = new();
        }
    }
}
