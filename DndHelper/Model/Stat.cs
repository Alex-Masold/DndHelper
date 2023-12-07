using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;

namespace DndHelper.Model
{
    public class Stat : PropPropertyChanged
    {
        private string name;
        private int value;
        private int modifier;
        private Skill savingThrows;
        public ObservableCollection<Skill> skills;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public int Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged(nameof(Value));
                    OnPropertyChanged(nameof(Modifier)); // При изменении значения обновляем и модификатор
                }
            }
        }
        public int Modifier
        {
            get { return modifier; }
            set
            {
                this.modifier = value;
                OnPropertyChanged(nameof(Modifier));
            }
        }
        public ObservableCollection<Skill> Skills
        {
            get => skills;
            set
            {
                if (skills != value)
                {
                    skills = value;
                    OnPropertyChanged(nameof(Skills));
                }
            }
        }
        public Skill SavingThrows
        {
            get => savingThrows;
            set
            {
                if (savingThrows != value)
                {
                    savingThrows = value;
                    OnPropertyChanged(nameof(SavingThrows));
                }
            }
        }
        public Stat(string name, int value =10)
        {
            Name = name;

            Value = value;
            Skills = DataContext.DataBase.Skills.GetValueOrDefault(name);
            StatInit(); 
        }
        public void StatInit()
        {
            foreach (Skill current in this.Skills)
            {
                current.Stat = this;
                current.Value = Value;
                current.InitModifier();
            }
            InitModifier();
        }
        public void InitModifier()
        {
            Modifier = (Value-10)/2;
        }
    }
}
