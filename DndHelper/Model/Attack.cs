using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndHelper.Model.Stats;

namespace DndHelper.Model
{
    public class Attack : PropPropertyChanged
    {
        private string name;
        private Character character;
        private Stat associatedStat;
        private string type;
        private int attackBonus;
        private int modifier;
        private Dice damageDice;

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
        public Character Character
        {
            get => character;
            set
            {
                if (character != value)
                {
                    character = value;
                    OnPropertyChanged(nameof(Character));
                }
            }
        }
        public Stat AssociatedStat
        {
            get => associatedStat;
            set
            {
                if (associatedStat != value)
                {
                    associatedStat = value;
                    OnPropertyChanged(nameof(AssociatedStat));
                }
            }
        }
        public string Type
        {
            get => type;
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        public int AttackBonus
        {
            get => attackBonus;
            set
            {
                if (attackBonus != value)
                {
                    attackBonus = value;
                    OnPropertyChanged(nameof(AttackBonus));
                }
            }
        }
        public int Modifier
        {
            get => modifier;
            set
            {
                if (modifier != value)
                {
                    modifier = value;
                    OnPropertyChanged(nameof(Modifier));
                }
            }
        }
        public Dice DamageDice
        {
            get => damageDice;
            set
            {
                if (damageDice != value)
                {
                    damageDice = value;
                    OnPropertyChanged(nameof(DamageDice));
                }
            }
        }
    }
}
