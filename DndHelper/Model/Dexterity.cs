using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DndHelper.Model
{
    public class Dexterity : Stat
    {
        private Skill acrobatics;
        private Skill sleightOfHand;
        private Skill stealth;

        public Skill Acrobatics
        {
            get { return acrobatics; }
            set 
            { 
                acrobatics = value;
                OnPropertyChanged(nameof(Acrobatics));
            }
        }
        public Skill SleightOfHand
        {
            get { return sleightOfHand; }
            set
            {
                sleightOfHand = value;
                OnPropertyChanged(nameof(SleightOfHand));
            }
        }
        public Skill Stealth
        {
            get { return stealth; }
            set
            {
                stealth = value;
                OnPropertyChanged(nameof(Stealth));
            }
        }

        public Dexterity()
        {
            Name = "Dexterity";

            SavingThrows = new("Dexterity", this);

            Acrobatics = new("Acrobatics", this);
            SleightOfHand = new("Sleight of Hand", this);
            Stealth = new("Stealth", this);
        }
    }
}
