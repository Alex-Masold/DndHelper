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

        private int deathSaveTrue = 0;
        public int DeathSaveTrue
        {
            get { return deathSaveTrue; }
            set
            {
                deathSaveTrue = value;
                OnPropertyChanged(nameof(DeathSaveTrue));
            }
        }

        private int deathSaveFalse = 0;
        public int DeathSaveFalse
        {
            get { return deathSaveFalse; }
            set
            {
                deathSaveFalse = value;
                OnPropertyChanged(nameof(DeathSaveFalse));
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

        private int currentHitPoints;
        public int CurrentHitPoints
        {
            get { return currentHitPoints; }
            set
            {
                currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
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


        //private bool masteryinspiration = false;
        //public bool MasteryInspiration
        //{
        //    get { return masteryinspiration; }
        //    set
        //    {
        //        masteryinspiration = value;
        //        OnPropertyChanged(nameof(MasteryInspiration));
        //    }
        //}


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

        //private string archetype;
        //public string Archetype
        //{
        //    get { return archetype; }
        //    set
        //    {
        //        archetype = value;
        //        OnPropertyChanged(nameof(Archetype));
        //    }
        //}

        //private ObservableCollection<string> abilities;
        //public ObservableCollection<string> Abilities
        //{
        //    get { return abilities; }
        //    set
        //    {
        //        abilities = value;
        //        OnPropertyChanged(nameof(Abilities));
        //    }
        //}

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
            //MasteryInspiration = false;

            //Equipment = new();
            //Abilities = new();

        }

    }
}
