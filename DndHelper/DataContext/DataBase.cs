using DndHelper.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.DataContext
{
    public class DataBase
    {
        public static Dictionary<string, ObservableCollection<Skill>> Skills = new()
        {
            { "Strength", 
                new ObservableCollection<Skill> { 
                new Skill("Athletics",          null, null) 
            } },
            { "Dexterity", 
                new ObservableCollection<Skill> { 
                new Skill("Acrobatics",         null, null), 
                new Skill("Sleight of Hand",    null, null), 
                new Skill("Stealth",            null, null) 
            } },
            { "Constitution", new ObservableCollection<Skill>() },
            { "Intelligence", 
                new ObservableCollection<Skill> { 
                new Skill("Arcana",             null, null), 
                new Skill("History",            null, null), 
                new Skill("Investigation",      null, null), 
                new Skill("Nature",             null, null), 
                new Skill("Religion",           null, null) 
            } },
            { "Wisdom", 
                new ObservableCollection<Skill> { 
                new Skill("Animal Handling",    null, null), 
                new Skill("Insight",            null, null), 
                new Skill("Medicine",           null, null), 
                new Skill("Perception",         null, null), 
                new Skill("Survival",           null, null)
            } },
            { "Charisma", 
                new ObservableCollection<Skill> { 
                new Skill("Deception",          null, null), 
                new Skill("Intimidation",       null, null),
                new Skill("Performance",        null, null), 
                new Skill("Persuasion",         null, null) 
            } }
        };
        public static ObservableCollection<Stat> DefultStats = new()
        {
            new Stat("Strength"),
            new Stat("Dexterity"),
            new Stat("Constitution"),
            new Stat("Intelligence"),
            new Stat("Wisdom"),
            new Stat("Charisma")
        };
        public static ObservableCollection<Character> Characters = new()
        {
            new Character(
                "Character1", 
                "Human", 
                "Fighter"),
            new Character(
                "Character2", 
                "Elf", 
                "Wizard", 
                3, 
                "Archmage"),
        };
    }
}
