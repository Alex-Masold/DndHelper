using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Intelligence : Stat
    {
        private Skill arcana;
        private Skill history;
        private Skill investigation;
        private Skill nature;
        private Skill religion;

        public Skill Arcana
        {
            get { return arcana; }
            set
            {
                arcana = value;
                OnPropertyChanged(nameof(Arcana));
            }
        }
        public Skill History
        {
            get { return history; }
            set
            {
                history = value;
                OnPropertyChanged(nameof(History));
            }
        }
        public Skill Investigation
        {
            get { return investigation; }
            set
            {
                investigation = value;
                OnPropertyChanged(nameof(Investigation));
            }
        }
        public Skill Nature
        {
            get { return nature; }
            set
            {
                nature = value;
                OnPropertyChanged(nameof(Nature));
            }
        }
        public Skill Religion
        {
            get { return religion; }
            set
            {
                religion = value;
                OnPropertyChanged(nameof(Religion));
            }
        }

        public Intelligence()
        {
            Name = "Intelligence";

            SavingThrows = new("Intelligence", this);

            Arcana = new("Arcana", this);
            History = new("History", this);
            Investigation = new("Investigation", this);
            Nature = new("Nature", this);
            Religion = new("Religion", this);
        }
    }
}
