using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace DndHelper.Model.Races
{
    public class HalfOrc : Race
    {
        public HalfOrc()
        {
            Name = "Half-Orc";

            StrengthBonus = 2;
            DexterityBonus = 0;
            ConstitutionBonus = 1;
            IntelligenceBonus = 0;
            WisdomBonus = 0;
            CharismaBonus = 0;

            Speed = 30;
            
        }
    }
}
