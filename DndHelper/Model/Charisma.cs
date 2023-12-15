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
