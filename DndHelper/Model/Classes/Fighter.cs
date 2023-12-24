using DndHelper.Model.Races;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model.Classes
{

    public class Fighter : Character
    {
        public Fighter(
            Race race = null, 
            int StrengthValue = 10,
            int DexterityValue = 10,
            int ConstitutionValue = 10,
            int IntelligenceValue = 10,
            int WisdomValue = 10,
            int CharismaValue = 10) : base()
        {
            Race = race;
            

            Strength.Value = StrengthValue + Race.StrengthBonus;
            Dexterity.Value = DexterityValue + Race.DexterityBonus;
            Constitution.Value = ConstitutionValue + Race.ConstitutionBonus;
            Intelligence.Value = IntelligenceValue + Race.IntelligenceBonus;
            Wisdom.Value = WisdomValue + Race.WisdomBonus;
            Charisma.Value = CharismaValue + Race.CharismaBonus;

            HitPointDice = new() { Count = 1, Type = 10 };
            HitPoints = HitPointDice.Type + Constitution.Modifier;
            CurrentHitPoints = HitPoints;
            CurrentHitPointDice = HitPointDice.Count;
            ClassCharacter = "Fighter";

            

            

            Traits = new ObservableCollection<Trait>(Race.Traits);

            Abilities = new ObservableCollection<string> { "Shield", "Light armor", "Medium armor", "Heavy armor", "Простое Оружие", "Воинское оружие" };
        }
    }
}
