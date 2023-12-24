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
                    Name = "Angry little people",
                    Description = "Когда вы наносите существу урон атакой или заклинанием, и размер существа больше чем ваш, вы можете этой атакой или заклинанием нанести существу дополнительный урон, равный вашему уровню. Использовав это свойство, Вы не можете использовать его повторно, пока не завершите короткий или продолжительный отдых."
                },
                new Trait()
                {
                    Name = "A nimble escape",
                    Description = "Вы можете использовать действие Отход или Засада в качестве бонусного действия в каждый ваш ход."
                }
            };
        }
    }
}
