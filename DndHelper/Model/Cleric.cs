using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Cleric : Character
    {
        public Cleric() 
        {
            HitPointDice = new Dice() { Count = 1, Type = 8 };
            HitPoints = HitPointDice.Type + Constitution.Modifier;
            ClassCharacter = "Cleric";

            Owerships.AddRange(new List<string> { "Щит", "Легкие доспехи", "Средние доспехи", "Простое Оружие" });

        }
    }
}
