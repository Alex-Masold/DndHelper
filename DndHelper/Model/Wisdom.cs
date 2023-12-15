using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Wisdom : Stat
    {
        private Skill animalHandling;
        private Skill insight;
        private Skill medicine;
        private Skill perception;
        private Skill survival;

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
