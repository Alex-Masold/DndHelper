using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Dice : PropPropertyChanged
    {
        private int count;
        private int type;
        private int modifier;

        public int Count { get; set; }
        public int Type { get; set; }
        public int Modifier { get; set; }

        public Dice(int count, int type, int modifier)
        {
            Count = count;
            Type = type;
            Modifier = modifier;
        }
    }
}
