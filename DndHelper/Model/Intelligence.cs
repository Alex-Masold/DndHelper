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

        private int value;
        private int modifier;

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

        public new int Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;

                    SavingThrows.Value = value;

                    Arcana.Value = value;
                    History.Value = value;
                    Investigation.Value = value;
                    Nature.Value = value;
                    Religion.Value = value;

                    OnPropertyChanged(nameof(Value));
                    OnPropertyChanged(nameof(Modifier)); // При изменении значения обновляем и модификатор
                }
            }
        }
        public int Modifier
        {
            get { return modifier = (Value-10)/2; }
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
