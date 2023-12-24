using DndHelper.Model;
using DndHelper.Model.Classes;
using DndHelper.Model.Races;
using DndHelper.Model.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DndHelper.DataContext
{
    public class DataBase
    {
        public static List<int> DefultValue = new() { 15, 14, 13, 12, 10, 8 };
        //public static ObservableCollection<string> Classes = new()
        //{
        //    "Bard",
        //    "Barbarian",
        //    "Fighter",
        //    "Wizard",
        //    "Druid",
        //    "Cleric",
        //    "Artificer",
        //    "Warlock",
        //    "Monk",
        //    "Paladin",
        //    "Rogue",
        //    "Ranger",
        //    "Sorcerer"
        //};

        //public static ObservableCollection<string> Races = new()
        //{
        //    "Aarakocra",
        //    "Aasimar",
        //    "Autognome",
        //    "Astral elf",
        //    "Bugbear",
        //    "Verdan",
        //    "Simic hybrid",
        //    "Gith",
        //    "Giff",
        //    "Gnome",
        //    "Goblin",
        //    "Goliath",
        //    "Grung",
        //    "Dwarf",
        //    "Air Genasi",
        //    "Earth Genasi",
        //    "Fire Genasi",
        //    "Water Genasi",
        //    "Dragonborn",
        //    "Harengon",
        //    "Kalashtar",
        //    "Kender",
        //    "Kenku",
        //    "Centaur",
        //    "Kobold",
        //    "Warforged",
        //    "Leonin",
        //    "Locathah",
        //    "Loxodon",
        //    "Lizardfolk",
        //    "Minotaur",
        //    "Orc",
        //    "Plasmoid",
        //    "Half-orc",
        //    "Halfling",
        //    "Half-elf",
        //    "Satyr",
        //    "Owlin",
        //    "Tabaxi",
        //    "Tiefling (Asmodeus)",
        //    "Tiefling (Baalzebul)",
        //    "Tiefling (Dispater)",
        //    "Tiefling (Fierna)",
        //    "Tiefling (Glasya)",
        //    "Tiefling (Levistus)",
        //    "Tiefling (Mammon)",
        //    "Tiefling (Mephistopheles)",
        //    "Tiefling (Zariel)",
        //    "Tiefling (Mammon)",
        //    "Tiefling (Faerun)",
        //    "Tortle",
        //    "Thri-kreen",
        //    "Triton",
        //    "Firbolg",
        //    "Fairy",
        //    "Hadozee",
        //    "Hobgoblin",
        //    "Changeling",
        //    "Human",
        //    "Shifter (Beasthide)",
        //    "Shifter (Longtooth)",
        //    "Shifter (Wildhunt)",
        //    "Shifter (Swiftstride)",
        //    "High Elf",
        //    "Wood Elf",
        //    "Drow",
        //    "Sea Elf",
        //    "Shadar-kai",
        //    "Eladrin",
        //    "Yuan-ti"
        //};

        public static ObservableCollection<Character> Characters = new()
        {
            new Fighter(new Goblin(), 15, 16, 15, 8, 8, 10)
            {
                Name = "Биба",
                Level = 1,

            },
            new Cleric(new WoodElf(), 10, 12, 15, 15, 18, 10)
            {
                Name = "Мех",
                Level = 1
            },
             new Cleric(new HalfOrc())
            {
                Name = "Мого",
                Level = 1,

            },
        };
        public static ObservableCollection<Template> Enemies = new()
        {
            new Template()
            {
                Name = "Goblin",
                Level = 0,
                ArmorClass = 15,
                HitPointDice = new Dice() {Type = 6, Count = 2},

                Strength = new Strength { Value = 8 },
                Dexterity = new Dexterity { Value = 14 },
                Constitution = new Constitution { Value = 10 },
                Intelligence = new Intelligence { Value = 10 },
                Wisdom = new Wisdom { Value = 8 },
                Charisma = new Charisma { Value = 8 },

            },
        };


    }
}

