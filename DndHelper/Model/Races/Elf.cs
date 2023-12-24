using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model.Races
{
    public class Elf : Race
    {
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
                    Name = "Fey Ancestry",
                    Description = "Вы совершаете с преимуществом спасброски от очарования, и вас невозможно магически усыпить."
                },
                new Trait()
                {
                    Name = "Trance",
                    Description = "Эльфы не спят. Вместо этого они погружаются в глубокую медитацию, находясь в полубессознательном состоянии до 4 часов в сутки (обычно такую медитацию называют трансом). Во время этой медитации вы можете грезить о разных вещах. Некоторые из этих грёз являются ментальными упражнениями, выработанными за годы тренировок. После такого отдыха вы получаете все преимущества, которые получает человек после 8 часов сна."
                }
            };
        }
    }
}
