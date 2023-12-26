using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model.Races
{
    public class Goblin : Race
    {
        public Goblin()
        {
            Name = "Goblin";

            StrengthBonus = 0;
            DexterityBonus = 2;
            ConstitutionBonus = 1;
            IntelligenceBonus = 0;
            WisdomBonus = 0;
            CharismaBonus = 0;

            Speed = 30;
    
        }
    }
}
