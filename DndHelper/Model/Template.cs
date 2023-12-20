using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Template : PropPropertyChanged
    {
        private string name;
        private string race;

        private bool bardicInspiration;

        private int level;
        private int hitPoints;
        private int currentHitPoints;
        private int currentHitPointDice;
        private int armorClass;
        private int masteryBonus;
        private int speed;
        private int passivePerception;
        private int initiative;

        private Strength strength;
        private Dexterity dexterity;
        private Constitution constitution;
        private Intelligence intelligence;
        private Wisdom wisdom;
        private Charisma charisma;

        private Dice hitPointDice;

        //private List<> attacks;
        private ObservableCollection<string> equipment;
        private ObservableCollection<string> abilities;

                    
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Race
        {
            get { return race; }
            set
            {
                race = value;
                OnPropertyChanged(nameof(Race));
            }
        }

        public bool BardicInspiration
        {
            get { return bardicInspiration; }
            set
            {
                bardicInspiration = value;
                OnPropertyChanged(nameof(BardicInspiration));
            }
        }

        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged(nameof(Level));
                UpdateMasteryBonus();
            }
        }

        public int HitPoints
        {
            get { return hitPoints; }
            set
            {
                hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int CurrentHitPoints
        {
            get { return currentHitPoints; }
            set
            {
                currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
            }
        }
        public int CurrentHitPointDice
        {
            get { return currentHitPointDice; }
            set
            {
                currentHitPointDice = value;
                OnPropertyChanged(nameof(CurrentHitPointDice));
            }
        }

        public int ArmorClass
        {
            get { return armorClass; }
            set
            {
                armorClass = value;
                OnPropertyChanged(nameof(ArmorClass));
            }
        }
        public int MasteryBonus
        {
            get { return masteryBonus; }
            set
            {
                masteryBonus = value;
                OnPropertyChanged(nameof(MasteryBonus));

                OnPropertyChanged(nameof(Strength));
                OnPropertyChanged(nameof(Dexterity));
                OnPropertyChanged(nameof(Constitution));
                OnPropertyChanged(nameof(Intelligence));
                OnPropertyChanged(nameof(Wisdom));
                OnPropertyChanged(nameof(Charisma));
            }
        }
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }
        public int PassivePerception
        {
            get { return passivePerception + Wisdom.Modifier; }
            set
            {
                passivePerception = value;
                OnPropertyChanged(nameof(PassivePerception));
            }
        }
        public int Initiative
        {
            get { return initiative + Dexterity.Modifier; }
            set
            {
                initiative = value;
                OnPropertyChanged(nameof(PassivePerception));
            }
        }

        public Strength Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }
        public Dexterity Dexterity
        {
            get { return dexterity; }
            set
            {
                dexterity = value;
                OnPropertyChanged(nameof(Dexterity));
            }
        }
        public Constitution Constitution
        {
            get { return constitution; }
            set
            {
                constitution = value;
                OnPropertyChanged(nameof(Constitution));
            }
        }
        public Intelligence Intelligence
        {
            get { return intelligence; }
            set
            {
                intelligence = value;
                OnPropertyChanged(nameof(Intelligence));
            }
        }
        public Wisdom Wisdom
        {
            get { return wisdom; }
            set
            {
                wisdom = value;
                OnPropertyChanged(nameof(Wisdom));
            }
        }
        public Charisma Charisma
        {
            get { return charisma; }
            set
            {
                charisma = value;
                OnPropertyChanged(nameof(Charisma));
            }
        }

        public Dice HitPointDice
        {
            get { return hitPointDice; }
            set
            {
                hitPointDice = value;
                OnPropertyChanged(nameof(HitPointDice));
            }
        }

        public ObservableCollection<string> Equipment
        {
            get { return equipment; }
            set
            {
                equipment = value;
                OnPropertyChanged(nameof(Equipment));
            }
        }
        public ObservableCollection<string> Abilities
        {
            get { return abilities; }
            set
            {
                abilities = value;
                OnPropertyChanged(nameof(Abilities));
            }
        }
        public Template()
        {
            Strength = new Strength() { Character = this, Value = 15};
            Dexterity = new Dexterity() { Character = this, Value = 14};
            Constitution = new Constitution() { Character = this, Value = 13 };
            Intelligence = new Intelligence() { Character = this, Value = 12 };
            Wisdom = new Wisdom() { Character = this, Value = 10 };
            Charisma = new Charisma() { Character = this, Value = 8};

            HitPointDice = new Dice() { Count = 1, Type = 8 };

            CurrentHitPoints = 0;
            HitPoints = HitPointDice.Type + Constitution.Modifier;
            CurrentHitPoints = HitPoints;
            CurrentHitPointDice = HitPointDice.Count;
            ArmorClass = 10 + Dexterity.Modifier;
            UpdateMasteryBonus();
            Speed = 30;
            PassivePerception = 10;
            Initiative = 0;

            //HitPointDice = null;
            BardicInspiration = false;

        }
        public void UpdateMasteryBonus()
        {
            if (Level <= 4)
            {
                MasteryBonus = 2;
            }
            else if (Level  <= 8)
            {
                MasteryBonus = 3;
            }
            else if (Level <= 12)
            {
                MasteryBonus = 4;
            }
            else if (Level <= 16)
            {
                MasteryBonus = 5;
            }
            else if (Level <= 20)
            {
                MasteryBonus = 6;
            }
        }
    }
}
