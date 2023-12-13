using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Model
{
    public class Dice : PropPropertyChanged
    {
        private int count;
        private int type;

        public int Count 
        { 
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            } 
        }
        public int Type 
        { 
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        

        public int Cast()
        {
            Random random = new Random();
            int result = 0;

            for (int i = 0; i < Count; i++)
            {
                // Генерируем случайное число от 1 до Type и добавляем Modifier
                int roll = random.Next(1, Type + 1);

                // Добавляем результат к общему суммарному значению
                result += roll;
            }

            return result;
        }

    }
}
