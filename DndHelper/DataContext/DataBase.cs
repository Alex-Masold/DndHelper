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
        public static List<int> DefultValue = new() { 15, 14, 13, 12, 10, 8 };
        public static ObservableCollection<string> Classes = new()
        {
            "Bard",
            "Barbarian",
            "Fighter",
            "Wizard",
            "Druid",
            "Cleric",
            "Artificer",
            "Warlock",
            "Monk",
            "Paladin",
            "Rogue",
            "Ranger",
            "Sorcerer"
        };
        public static ObservableCollection<string> Races = new()
        {
            "Aarakocra",
            "Aasimar",
            "Autognome",
            "Astral elf",
            "Bugbear",
            "Verdan",
            "Simic hybrid",
            "Gith",
            "Giff",
            "Gnome",
            "Goblin",
            "Goliath",
            "Grung",
            "Dwarf",
            "Air Genasi",
            "Earth Genasi",
            "Fire Genasi",
            "Water Genasi",
            "Dragonborn",
            "Harengon",
            "Kalashtar",
            "Kender",
            "Kenku",
            "Centaur",
            "Kobold",
            "Warforged",
            "Leonin",
            "Locathah",
            "Loxodon",
            "Lizardfolk",
            "Minotaur",
            "Orc",
            "Plasmoid",
            "Half-orc",
            "Halfling",
            "Half-elf",
            "Satyr",
            "Owlin",
            "Tabaxi",
            "Tiefling (Asmodeus)",
            "Tiefling (Baalzebul)",
            "Tiefling (Dispater)",
            "Tiefling (Fierna)",
            "Tiefling (Glasya)",
            "Tiefling (Levistus)",
            "Tiefling (Mammon)",
            "Tiefling (Mephistopheles)",
            "Tiefling (Zariel)",
            "Tiefling (Mammon)",
            "Tiefling (Faerun)",
            "Tortle",
            "Thri-kreen",
            "Triton",
            "Firbolg",
            "Fairy",
            "Hadozee",
            "Hobgoblin",
            "Changeling",
            "Human",
            "Shifter (Beasthide)",
            "Shifter (Longtooth)",
            "Shifter (Wildhunt)",
            "Shifter (Swiftstride)",
            "High Elf",
            "Wood Elf",
            "Drow",
            "Sea Elf",
            "Shadar-kai",
            "Eladrin",
            "Yuan-ti"
        };

        public static ObservableCollection<Character> Characters = new()
        {
            new Character()
            {
                Name = "Джошув",
                Race = "Human",
                Level = 1,
                ClassCharacter = "Warrior",

            },
            new Character()
            {
                Name = "Мех",
                Race = "Auto-Gnome",
                Level = 1,
                ClassCharacter = "Artificer"
            },
             new Character()
            {
                Name = "Мого",
                Race = "Plasmoid",
                Level = 1,
                ClassCharacter = "Bard"
            },
        };
    }
}
