using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model.Stats
{
    public class Strength : Stat
    {
        private Skill athletics;
        private int value;
        private int modifier;


        public Skill Athletics
        {
            get { return athletics; }
            set
            {
                athletics = value;
                OnPropertyChanged(nameof(Athletics));
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
                    Athletics.Value = value;

                    SavingThrows.Value = value;

                    OnPropertyChanged(nameof(Value));
                    OnPropertyChanged(nameof(Modifier)); // При изменении значения обновляем и модификатор
                }
            }
        }
        public int Modifier
        {
            get { return modifier = (Value - 10) / 2; }
        }

        public Strength()
        {
            Name = "Strength";

            SavingThrows = new("Strength", this);

            Athletics = new("Athletics", this);
        }
    }
}
