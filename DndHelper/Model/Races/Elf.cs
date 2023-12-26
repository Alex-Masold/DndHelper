using DndHelper.Model.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model.Races
{
    public class Elf : Race
    {

        public Strength Strength
        {
            get { return Character.Strength; }
        }
        public Dexterity Dexterity
        {
            get { return Character.Dexterity; }
        }
        public Constitution Constitution
        {
            get { return Character.Constitution; }
        }
        public Intelligence Intelligence
        {
            get { return Character.Intelligence; }
        }
        public Wisdom Wisdom
        {
            get { return Character.Wisdom; }
        }
        public Charisma Charisma
        {
            get { return Character.Charisma; }
        }

        public Elf()
        {
            Name = "Elf";

            StrengthBonus = 0;
            DexterityBonus = 2;
            ConstitutionBonus = 0;
            IntelligenceBonus = 0;
            WisdomBonus = 0;
            CharismaBonus = 0;

            Speed = 30; 
        }
    }
}
