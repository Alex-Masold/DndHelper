using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model.Stats
{
    public class Wisdom : Stat
    {
        private Skill animalHandling;
        private Skill insight;
        private Skill medicine;
        private Skill perception;
        private Skill survival;

        private int value;
        private int modifier;

        public Skill AnimalHandling
        {
            get { return animalHandling; }
            set
            {
                animalHandling = value;
                OnPropertyChanged(nameof(AnimalHandling));
            }
        }
        public Skill Insight
        {
            get { return insight; }
            set
            {
                insight = value;
                OnPropertyChanged(nameof(Insight));
            }
        }
        public Skill Medicine
        {
            get { return medicine; }
            set
            {
                medicine = value;
                OnPropertyChanged(nameof(Medicine));
            }
        }
        public Skill Perception
        {
            get { return perception; }
            set
            {
                perception = value;
                OnPropertyChanged(nameof(Perception));
            }
        }
        public Skill Survival
        {
            get { return survival; }
            set
            {
                survival = value;
                OnPropertyChanged(nameof(Survival));
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

                    AnimalHandling.Value = value;
                    Insight.Value = value;
                    Medicine.Value = value;
                    Perception.Value = value;
                    Survival.Value = value;

                    OnPropertyChanged(nameof(Value));
                    OnPropertyChanged(nameof(Modifier)); // При изменении значения обновляем и модификатор
                }
            }
        }
        public int Modifier
        {
            get { return modifier = (Value - 10) / 2; }
        }

        public Wisdom()
        {
            Name = "Wisdom";

            SavingThrows = new("Wisdom", this);

            AnimalHandling = new("Animal Handling", this);
            Insight = new("Insight", this);
            Medicine = new("Medicine", this);
            Perception = new("Perception", this);
            Survival = new("Survival", this);
        }
    }
}
