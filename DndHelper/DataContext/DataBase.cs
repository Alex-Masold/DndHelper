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
        private static Random Random = new();

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
            new Fighter(new WoodElf(), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1))
            {
                Name = "Биба",
                Level = Random.Next(1, 21),
                IsFriend = true

            },
            new Cleric(new HighElf(), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1))
            {
                Name = "мех",
                IsFriend = true,
                Level = Random.Next(1, 21)
            },
             new Cleric(new HalfOrc(), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1))
            {
                Name = "мого",
                IsFriend = true,
                Level = Random.Next(1, 21),

            },
             new Fighter(new WoodElf(), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1))
            {
                Name = "Боба",
                Level = Random.Next(1, 21),
                IsFriend = true

            },
            new Cleric(new Goblin(), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1))
            {
                Name = "Ра",
                IsFriend = true,
                Level = Random.Next(1, 21)
            },
             new Cleric(new HalfOrc(), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1))
            {
                Name = "Яче",
                IsFriend = true,
                Level = Random.Next(1, 21),

            },new Fighter(new WoodElf(), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1))
            {
                Name = "Фрирен",
                Level = Random.Next(1, 21),
                IsFriend = true

            },
            new Cleric(new Goblin(),
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1), 
                Random.Next(8, 18 + 1))
            {
                Name = "Ирза",
                IsFriend = true,
                Level = Random.Next(1, 21)
            },
             new Cleric(new HalfOrc(), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1), 
                 Random.Next(8, 18 + 1))
            {
                Name = "Литвинова",
                IsFriend = true,
                Level = Random.Next(1, 21),

            },
        };
        public static ObservableCollection<Template> Enemies = new()
        {
            new Template(8, 14, 10, 10, 8, 8)
            {
                Name = "Goblin",
                Level = 0,
                IsFriend = false,

                ArmorClass = 15,
                HitPointDice = new Dice() {Type = 6, Count = 2},

            },
            new Template(30, 20, 50, 10 ,8, 8)
            {
                Name = "Dragon",
                Level = 0,
                IsFriend = false,

                ArmorClass = 15,
                HitPointDice = new Dice() {Type = 13, Count = 20},

            },
        };


    }
}

