using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Threading;
using System.Xml.Linq;

namespace DndHelper.Model.Stats
{
    public class Stat : PropPropertyChanged
    {
        private string name;

        private int value;
        private int modifier;

        private Skill savingThrows;

        private Dice dice;

        private Template character;

        private RelayCommand statCastCommand;
        public RelayCommand StatCastCommand
        {
            get
            {
                return statCastCommand ?? (statCastCommand = new RelayCommand(obj =>
                {

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
                        double x = targetSize.Width - popupSize.Width * 1.5;
                        double y = targetSize.Height - popupSize.Height * 3;

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
        public int MasteryBonus
        {
            get { return Character.MasteryBonus; }
        }
        public int Modifier
        {
            get { return modifier = (Value - 10) / 2; }
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
        public Template Character
        {
            get { return character; }
            set
            {
                character = value;
                OnPropertyChanged(nameof(Character));

                // Уведомляем об изменении MasteryBonus при изменении связанного Character
                OnPropertyChanged(nameof(MasteryBonus));
            }
        }

        public Stat()
        {
            Dice = new Dice() { Count = 1, Type = 20 };
        }

        public string Cast()
        {
            int cast = Dice.Cast();
            string result = $"{Name}: Результат броска {cast + Modifier}: {cast} + {Modifier}";
            return result;
        }
    }
}
