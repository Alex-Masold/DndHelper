using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace DndHelper.Model
{
    public class Skill : PropPropertyChanged
    {
        private string name;
        private bool proficient;
        private int modifier;
        private int value;
        private int masteryBonus;
        private Stat stat;
        private Dice dice;

        private RelayCommand skillCastCommand;
        public RelayCommand SkillCastCommand
        {
            get
            {
                return skillCastCommand ?? (skillCastCommand = new RelayCommand(obj => {
                    
                    // Создание объекта Popup
                    Popup messagePopup = new Popup();

                    messagePopup.StaysOpen = false;

                    // Текст сообщения
                    messagePopup.PlacementTarget = Application.Current.MainWindow;

                    // Создание объекта Border для стилизации внешнего вида Popup
                    Border popupBorder = new Border();
                    popupBorder.Background = Brushes.White; // Цвет фона
                    popupBorder.BorderBrush = Brushes.Black; // Цвет границы
                    popupBorder.BorderThickness = new Thickness(1); // Толщина границы

                    // Текст сообщения
                    TextBlock messageText = new TextBlock();
                    messageText.Text = Cast();
                    messageText.Padding = new Thickness(5, 10, 5, 10);

                    // Кнопка для закрытия Popup
                    Button closeButton = new Button();
                    closeButton.Content = "Закрыть";
                    closeButton.Click += (sender, e) => { messagePopup.IsOpen = false; };

                    // Добавление элементов в Border
                    popupBorder.Child = messageText;

                    // Установка Border в качестве содержимого Popup
                    messagePopup.Child = popupBorder;

                    messagePopup.Placement = PlacementMode.Custom;
                    // Установка пользовательского расположения
                    messagePopup.CustomPopupPlacementCallback = (popupSize, targetSize, offset) =>
                    {
                        // Расположение в правом нижнем углу
                        double x = targetSize.Width - popupSize.Width*1.5;
                        double y = targetSize.Height - popupSize.Height*3;

                        return new[] { new CustomPopupPlacement(new Point(x, y), PopupPrimaryAxis.None) };
                    };


                    messagePopup.IsOpen = true;


                    // Создайте таймер
                    DispatcherTimer timer = new DispatcherTimer();

                    // Установите интервал таймера в 10 секунд
                    timer.Interval = TimeSpan.FromSeconds(3);

                    // Обработчик события таймера
                    timer.Tick += (sender, e) =>
                    {
                        // Закрыть Popup после истечения времени
                        messagePopup.IsOpen = false;

                        // Остановить таймер
                        timer.Stop();
                    };

                    // Запустите таймер
                    timer.Start();
                }));
            }
        }

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
        public bool Proficient
        {
            get { return proficient; }
            set
            {
                if (proficient != value)
                {
                    proficient = value;
                    OnPropertyChanged(nameof(Modifier));
                    OnPropertyChanged(nameof(Proficient));
                }
            }
        }
        public int Modifier
        {
            get { if (Proficient == true) { return modifier = (Value-10)/2 + MasteryBonus; } else { return modifier = (Value-10)/2; } }
            set
            {
                if (this.modifier != value)
                {
                    this.modifier = value;
                    OnPropertyChanged(nameof(Modifier));
                    
                }
            }
        }
        public int Value
        {
            get { return value; }
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
        public Stat Stat
        {
            get { return stat; }
            set
            {
                stat = value;
                OnPropertyChanged(nameof(Stat));

                // Уведомляем об изменении MasteryBonus при изменении связанной Stat
                OnPropertyChanged(nameof(MasteryBonus));
            }
        }
        public Dice Dice
        {
            get { return dice; }
            set
            {
                dice = value;
                OnPropertyChanged(nameof(Dice));
                OnPropertyChanged(nameof(Dice.Count));
            }
        }
        public int MasteryBonus
        {
            get { return Stat?.MasteryBonus ?? 0; }
        }

        public Skill(string name, Stat stat)
        {
            Name = name;
            Stat = stat;
            Dice = new Dice() { Count = 1, Type = 20 };
        }
        public string Cast()
        {
            int cast = Dice.Cast();
            string result = $"Результат броска {cast + Modifier}: {cast} + {Modifier}";
            return result;
        }
    }
}
