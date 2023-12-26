using DndHelper.Model.Stats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace DndHelper.Model
{
    public class Template : PropPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string race;
        public string Race
        {
            get { return race; }
            set
            {
                race = value;
                OnPropertyChanged(nameof(Race));
            }
        }

        private bool isFriend;
        public bool IsFriend
        {
            get { return isFriend; }
            set
            {
                isFriend = value;
                OnPropertyChanged(nameof(IsFriend));
            }
        }


        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged(nameof(Level));
                UpdateMasteryBonus();
            }
        }

        private int hitPoints;
        public int HitPoints
        {
            get { return hitPoints; }
            set
            {
                hitPoints = value;
                CurrentHitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        private int currentHitPoints;
        public int CurrentHitPoints
        {
            get { return currentHitPoints; }
            set
            {
                currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
            }
        }


        private int deathSaveTrue = 0;
        public int DeathSaveTrue
        {
            get { return deathSaveTrue; }
            set
            {
                deathSaveTrue = value;
                OnPropertyChanged(nameof(DeathSaveTrue));
            }
        }

        private int deathSaveFalse = 0;
        public int DeathSaveFalse
        {
            get { return deathSaveFalse; }
            set
            {
                deathSaveFalse = value;
                OnPropertyChanged(nameof(DeathSaveFalse));
            }
        }

        private int armorClass;
        public int ArmorClass
        {
            get { return armorClass; }
            set
            {
                armorClass = value;
                OnPropertyChanged(nameof(ArmorClass));
            }
        }

        private int masteryBonus;
        public int MasteryBonus
        {
            get { return masteryBonus; }
            set
            {
                masteryBonus = value;
                OnPropertyChanged(nameof(MasteryBonus));

                OnPropertyChanged(nameof(Strength));
                OnPropertyChanged(nameof(Dexterity));
                OnPropertyChanged(nameof(Constitution));
                OnPropertyChanged(nameof(Intelligence));
                OnPropertyChanged(nameof(Wisdom));
                OnPropertyChanged(nameof(Charisma));
            }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }

        private int passivePerception;
        public int PassivePerception
        {
            get { return passivePerception + Wisdom.Modifier; }
            set
            {
                passivePerception = value;
                OnPropertyChanged(nameof(PassivePerception));
            }
        }

        private int initiative;
        public int Initiative
        {
            get { return initiative + Dexterity.Modifier; }
            set
            {
                initiative = value;
                OnPropertyChanged(nameof(InitiativeCats));
            }
        }

        private int initiativeCast;
        public int InitiativeCats
        {
            get { return initiativeCast + Initiative; }
            set
            {
                initiativeCast = value;
                OnPropertyChanged(nameof(InitiativeCats));
            }
        }

       

        private Strength strength;
        private int strengthValue;
        public int StrengthValue
        {
            get { return strengthValue; }
            set
            {
                strengthValue = value;
                OnPropertyChanged(nameof(StrengthValue));
            }
        }
        public Strength Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                strength.Value = StrengthValue;
                strength.Character = this;
                OnPropertyChanged(nameof(Strength));
            }
        }

        private Dexterity dexterity;
        private int dexterityValue;
        public int DexterityValue
        {
            get { return dexterityValue; }
            set
            {
                dexterityValue = value;
                OnPropertyChanged(nameof(DexterityValue));
            }
        }
        public Dexterity Dexterity
        {
            get { return dexterity; }
            set
            {
                dexterity = value;
                dexterity.Value = DexterityValue;
                dexterity.Character = this;
                OnPropertyChanged(nameof(Dexterity));
            }
        }

        private Constitution constitution;
        private int constitutionValue;
        public int ConstitutionValue
        {
            get { return constitutionValue; }
            set
            {
                constitutionValue = value;
                OnPropertyChanged(nameof(ConstitutionValue));
            }
        }
        public Constitution Constitution
        {
            get { return constitution; }
            set
            {
                constitution = value;
                constitution.Value = ConstitutionValue;
                constitution.Character = this;
                OnPropertyChanged(nameof(Constitution));
            }
        }

        private Intelligence intelligence;
        private int intelligenceValue;
        public int IntelligenceValue
        {
            get { return intelligenceValue; }
            set
            {
                intelligenceValue = value;
                OnPropertyChanged(nameof(IntelligenceValue));
            }
        }
        public Intelligence Intelligence
        {
            get { return intelligence; }
            set
            {
                intelligence = value;
                intelligence.Value = IntelligenceValue;
                intelligence.Character = this;
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        private Wisdom wisdom;
        private int wisdomValue;
        public int WisdomValue
        {
            get { return wisdomValue; }
            set
            {
                wisdomValue = value;
                OnPropertyChanged(nameof(WisdomValue));
            }
        }
        public Wisdom Wisdom
        {
            get { return wisdom; }
            set
            {
                wisdom = value;
                wisdom.Value = WisdomValue;
                wisdom.Character = this;
                OnPropertyChanged(nameof(Wisdom));
            }
        }

        private Charisma charisma;
        private int charismaValue;
        public int CharismaValue
        {
            get { return charismaValue; }
            set
            {
                charismaValue = value;
                OnPropertyChanged(nameof(CharismaValue));
            }
        }
        public Charisma Charisma
        {
            get { return charisma; }
            set
            {
                charisma = value;
                charisma.Value = CharismaValue;
                charisma.Character = this;
                OnPropertyChanged(nameof(Charisma));
            }
        }


        private Dice hitPointDice;
        public Dice HitPointDice
        {
            get { return hitPointDice; }
            set
            {
                hitPointDice = value;
                HitPoints = hitPointDice.Cast();
                OnPropertyChanged(nameof(HitPointDice));
            }
        }

        public Template(
            int strengthValue = 10,
            int dexterityValue = 10,
            int constitutionValue = 10,
            int intelligenceValue = 10,
            int wisdomValue = 10,
            int charismaValue = 10)
        {
            StrengthValue = strengthValue;
            DexterityValue = dexterityValue;
            ConstitutionValue = constitutionValue;
            IntelligenceValue = intelligenceValue;
            WisdomValue = wisdomValue;
            CharismaValue = charismaValue;

            Strength = new Strength();
            Dexterity = new Dexterity();
            Constitution = new Constitution();
            Intelligence = new Intelligence();
            Wisdom = new Wisdom();
            Charisma = new Charisma();

            ArmorClass = 10 + Dexterity.Modifier;
            UpdateMasteryBonus();
            Speed = 30;
            PassivePerception = 10;
            Initiative = 0;

        }
        public void UpdateMasteryBonus()
        {
            if (Level <= 4)
            {
                MasteryBonus = 2;
            }
            else if (Level  <= 8)
            {
                MasteryBonus = 3;
            }
            else if (Level <= 12)
            {
                MasteryBonus = 4;
            }
            else if (Level <= 16)
            {
                MasteryBonus = 5;
            }
            else if (Level <= 20)
            {
                MasteryBonus = 6;
            }
        }
    }
}
