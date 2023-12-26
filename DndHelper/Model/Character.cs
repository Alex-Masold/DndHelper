using DndHelper.Model.Races;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private int exhaustion = 0;
        public int Exhaustion
        {
            get { return exhaustion; }
            set
            {
                exhaustion = value;
                OnPropertyChanged(nameof(Exhaustion));
            }
        }

        private int level;
        public new int Level
        {
            get { return level; }
            set
            {
                level = value;
                switch (value)
                {
                    case 1:
                        HitPointDice.Count = 1;
                        HitPoints = HitPointDice.Type + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 2:
                        HitPointDice.Count = 2;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 3:
                        HitPointDice.Count = 3;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 4:
                        HitPointDice.Count = 4;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 5:
                        HitPointDice.Count = 5;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 6:
                        HitPointDice.Count = 6;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 7:
                        HitPointDice.Count = 7;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 8:
                        HitPointDice.Count = 8;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 9:
                        HitPointDice.Count = 9;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count; 
                        break;
                    case 10:
                        HitPointDice.Count = 10;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 11:
                        HitPointDice.Count = 11;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 12:
                        HitPointDice.Count = 12;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 13:
                        HitPointDice.Count = 13;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 14:
                        HitPointDice.Count = 14;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 15:
                        HitPointDice.Count = 15;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 16:
                        HitPointDice.Count = 16;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 17:
                        HitPointDice.Count = 17;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 18:
                        HitPointDice.Count = 18;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 19:
                        HitPointDice.Count = 19;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;
                    case 20:
                        HitPointDice.Count = 20;
                        HitPoints = HitPointDice.Cast() + Constitution.Modifier;
                        CurrentHitPoints = HitPoints;
                        CurrentHitPointDice = HitPointDice.Count;
                        break;

                }
                OnPropertyChanged(nameof(Level));
                UpdateMasteryBonus();
            }
        }

        private int hitPoints;
        public new int HitPoints
        {
            get { return hitPoints; }
            set
            {
                hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        private int currentHitPointDice;
        public int CurrentHitPointDice
        {
            get { return currentHitPointDice; }
            set
            {
                currentHitPointDice = value;
                OnPropertyChanged(nameof(CurrentHitPointDice));
            }
        }

        private string classCharacter;
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

        private Race race;
        public new Race Race
        {
            get { return race; }
            set
            {
                race = value;
                OnPropertyChanged(nameof(Race));
            }
        }

        public Character() : base()
        {
            Exhaustion = 0;
        }

    }
}
