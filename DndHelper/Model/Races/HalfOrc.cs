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
            //Character.Charisma.Intimidation.Proficient = true;
            Traits = new()
            {
                new Trait()
                {
                    Name = "Dark vision",
                    Description = "Благодаря орочьей крови, вы обладаете превосходным зрением в темноте и при тусклом освещении. На расстоянии в 60 футов вы при тусклом освещении можете видеть так, как будто это яркое освещение, и в темноте так, как будто это тусклое освещение. В темноте вы не можете различать цвета, только оттенки серого."
                },
                new Trait()
                {
                    Name = "Relentless Endurance",
                    Description = "Если ваши хиты опустились до нуля, но вы при этом не убиты, ваши хиты вместо этого опускаются до 1. Вы не можете использовать эту способность снова, пока не завершите длительный отдых."
                },
                new Trait()
                {
                    Name = "Savage Attacks",
                    Description = "Если вы совершили критическое попадание рукопашной атакой оружием, вы можете добавить к урону ещё одну кость урона оружия."
                }
            };
        }
    }
}
