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
        private int currenthitPoints;
        private int armorClass;
        private int masteryBonus;
        private int speed;
        private int passivePerception;
        private int initiative;

        private Dice hitPointDice;

        //private List<> attacks;
        private ObservableCollection<string> equipment;
        private ObservableCollection<Stat> states;
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
        public int CurrenthitPoints
        {
            get { return currenthitPoints; }
            set
            {
                currenthitPoints = value;
                OnPropertyChanged(nameof(CurrenthitPoints));
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
            get { return passivePerception; }
            set
            {
                passivePerception = value;
                OnPropertyChanged(nameof(PassivePerception));
            }
        }
        public int Initiative
        {
            get { return initiative; }
            set
            {
                initiative = value;
                OnPropertyChanged(nameof(PassivePerception));
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
        public ObservableCollection<Stat> States
        {
            get { return states; }
            set
            {
                states = value;
                OnPropertyChanged(nameof(States));
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
