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

        public Character() : base()
        {
            Exhaustion = 0;
            MasteryInspiration = false;

            Equipment = new();
            Owerships = new();
            Abilities = new();
        }
    }
}
