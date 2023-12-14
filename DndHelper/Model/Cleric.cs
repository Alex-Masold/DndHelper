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
            HitPoints = HitPointDice.Type + GetStatValue("Constitution");
            ClassCharacter = "Cleric";

            Owerships.AddRange(new List<string> { "Щит", "Легкие доспехи", "Средние доспехи", "Простое Оружие" });
            var ClericSkills = new List<string> { "History", "Medicine  ", "Performance", "Religion", "Persuasion" };

            foreach (Stat x in Stats)
            {
                if (x.Name == "Wisdom" || x.Name == "Charisma")
                {
                    x.SavingThrows.Proficient = true;
                }
            }

        }
    }
}
