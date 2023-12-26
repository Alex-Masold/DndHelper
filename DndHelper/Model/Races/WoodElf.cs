using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace DndHelper.Model.Races
{
    public class WoodElf : Elf
    {
        public WoodElf() : base()
        {
            Name = "Wood Elf";

            WisdomBonus = 1;
            Speed = 35;
        }
       
    }
}
