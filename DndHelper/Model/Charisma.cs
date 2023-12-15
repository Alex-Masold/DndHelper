using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Charisma : Stat
    {
        private Skill deception;
        private Skill intimidation;
        private Skill performance;
        private Skill persuasion;

        private int value;
        private int modifier;

        public Skill Deception
        {
            get { return deception; }
            set
            {
                deception = value;
                OnPropertyChanged(nameof(Deception));
            }
        }
        public Skill Intimidation
        {
            get { return intimidation; }
            set
            {
                intimidation = value;
                OnPropertyChanged(nameof(Intimidation));
            }
        }
        public Skill Performance
        {
            get { return performance; }
            set
            {
                performance = value;
                OnPropertyChanged(nameof(Performance));
            }
        }
        public Skill Persuasion
        {
            get { return persuasion; }
            set
            {
                persuasion = value;
                OnPropertyChanged(nameof(Persuasion));
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

                    Deception.Value = value;
                    Intimidation.Value = value;
                    Performance.Value = value;
                    Persuasion.Value = value;

                    OnPropertyChanged(nameof(Value));
                    OnPropertyChanged(nameof(Modifier)); // При изменении значения обновляем и модификатор
                }
            }
        }
        public int Modifier
        {
            get { return modifier = (Value-10)/2; }
        }
        public Charisma()
        {
            Name = "Charisma";

            SavingThrows = new("Charisma", this);

            Deception = new("Deception", this);
            Intimidation = new("Intimidation", this);
            Performance = new("Performance", this);
            Persuasion = new("Persuasion", this);
        }
    }
}
