using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Fighter : Character
    {
        public Fighter() : base()
        {
            HitPointDice = new() { Count = 1, Type = 10 };
            HitPoints = HitPointDice.Type + GetStatValue("Constitution");
            ClassCharacter = "Fighter";

            Owerships.AddRange(new List<string> { "Shield", "Light armor", "Medium armor", "Heavy armor", "Простое Оружие", "Воинское оружие" });
        }
    }
}
