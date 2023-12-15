using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Constitution : Stat
    {
        public Constitution() 
        {
            Name = "Constitution";

            SavingThrows =  new("Constitution", this);
        }
    }
}
