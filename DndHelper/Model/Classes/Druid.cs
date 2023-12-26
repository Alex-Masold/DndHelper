using DndHelper.Model.Races;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model.Classes
{
    public class Druid : Character
    {
        private Random random = new Random();

        private ObservableCollection<Skill> ClassSkills;

        private Race race;
        public new Race Race
        {
            get { return race; }
            set
            {
                race = value;
                if (value != null)
                {
                    RaceStrengthBonus = race.StrengthBonus;
                    RaceDexterityBonus = race.DexterityBonus;
                    RaceConstitutionBonus = race.ConstitutionBonus;
                    RaceIntelligenceBonus = race.IntelligenceBonus;
                    RaceWisdomBonus = race.WisdomBonus;
                    RaceCharismaBonus = race.CharismaBonus;
                }


                OnPropertyChanged(nameof(Race));
            }
        }

        private int raceStrengthBonus;
        public int RaceStrengthBonus
        {
            get { return raceStrengthBonus; }
            set
            {
                raceStrengthBonus = value;
                OnPropertyChanged(nameof(RaceStrengthBonus));
            }
        }
        private int raceDexterityBonus;
        public int RaceDexterityBonus
        {
            get { return raceDexterityBonus; }
            set
            {
                raceDexterityBonus = value;
                OnPropertyChanged(nameof(RaceDexterityBonus));
            }
        }
        private int raceConstitutionBonus;
        public int RaceConstitutionBonus
        {
            get { return raceConstitutionBonus; }
            set
            {
                raceConstitutionBonus = value;
                OnPropertyChanged(nameof(RaceConstitutionBonus));
            }
        }
        private int raceIntelligenceBonus;
        public int RaceIntelligenceBonus
        {
            get { return raceIntelligenceBonus; }
            set
            {
                raceIntelligenceBonus = value;
                OnPropertyChanged(nameof(RaceIntelligenceBonus));
            }
        }
        private int raceWisdomBonus;
        public int RaceWisdomBonus
        {
            get { return raceWisdomBonus; }
            set
            {
                raceWisdomBonus = value;
                OnPropertyChanged(nameof(RaceWisdomBonus));
            }
        }
        private int raceCharismaBonus;
        public int RaceCharismaBonus
        {
            get { return raceCharismaBonus; }
            set
            {
                raceCharismaBonus = value;
                OnPropertyChanged(nameof(RaceCharismaBonus));
            }
        }


        public Druid(
            Race race = null,
            int strengthValue = 10,
            int dexterityValue = 10,
            int constitutionValue = 10,
            int intelligenceValue = 10,
            int wisdomValue = 10,
            int charismaValue = 10) : base()
        {
            Race = race;
            Race.Character = this;

            StrengthValue = strengthValue;
            DexterityValue = dexterityValue;
            ConstitutionValue = constitutionValue;
            IntelligenceValue = intelligenceValue;
            WisdomValue = wisdomValue;
            CharismaValue = charismaValue;

            Strength.Value = StrengthValue + RaceStrengthBonus;
            Dexterity.Value = DexterityValue + RaceDexterityBonus;
            Constitution.Value = ConstitutionValue + RaceConstitutionBonus;
            Intelligence.Value = IntelligenceValue + RaceIntelligenceBonus;
            Wisdom.Value = WisdomValue + RaceWisdomBonus;
            Charisma.Value = CharismaValue + RaceCharismaBonus;

            HitPointDice = new() { Count = 1, Type = 8 };
            HitPoints = HitPointDice.Type + Constitution.Modifier;
            CurrentHitPoints = HitPoints;
            CurrentHitPointDice = HitPointDice.Count;

            Strength.SavingThrows.Proficient = true;
            Constitution.SavingThrows.Proficient = true;

            ClassCharacter = "Druid";

            // Случайные навыки
            ClassSkills = new ObservableCollection<Skill>()
                {
                    Wisdom.Perception, Wisdom.Survival, Intelligence.Arcana, Wisdom.Medicine, Wisdom.AnimalHandling, Intelligence.Nature, Wisdom.Insight, Intelligence.Religion
                };

            ClassSkills[random.Next(0, ClassSkills.Count)].Proficient = true;
            ClassSkills[random.Next(0, ClassSkills.Count)].Proficient = true;
        }
       
    }
}
