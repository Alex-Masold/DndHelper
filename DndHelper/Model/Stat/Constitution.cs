using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model.Stats
{
    public class Constitution : Stat
    {
        private int value;
        private int modifier;

        public new int Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;

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
        public Constitution()
        {
            Name = "Constitution";

            SavingThrows = new("Constitution", this);
        }
    }
}
