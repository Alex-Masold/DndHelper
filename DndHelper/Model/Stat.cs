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

namespace DndHelper.Model
{
    public class Stat : PropPropertyChanged
    {
        private string name;
        
        private int value;
        private int modifier;

        private Skill savingThrows;
        
        private Dice dice;
        
        private event EventHandler ValueChanged;
        
        private Character character;

        private ObservableCollection<Skill> skills;

        private Dictionary<string, ObservableCollection<Skill>> SkillsDictionary = new()
        {
            { "Strength",
                new ObservableCollection<Skill> {
                new Skill("Athletics",          null)
            } },
            { "Dexterity",
                new ObservableCollection<Skill> {
                new Skill("Acrobatics",         null),
                new Skill("Sleight of Hand",    null),
                new Skill("Stealth",            null)
            } },
            { "Constitution", new ObservableCollection<Skill>() },
            { "Intelligence",
                new ObservableCollection<Skill> {
                new Skill("Arcana",             null),
                new Skill("History",            null),
                new Skill("Investigation",      null),
                new Skill("Nature",             null),
                new Skill("Religion",           null)
            } },
            { "Wisdom",
                new ObservableCollection<Skill> {
                new Skill("Animal Handling",    null),
                new Skill("Insight",            null),
                new Skill("Medicine",           null),
                new Skill("Perception",         null),
                new Skill("Survival",           null)
            } },
            { "Charisma",
                new ObservableCollection<Skill> {
                new Skill("Deception",          null),
                new Skill("Intimidation",       null),
                new Skill("Performance",        null),
                new Skill("Persuasion",         null)
            } }
        };

        private RelayCommand statCastCommand;
        public RelayCommand StatCastCommand
        {
            get
            {
                return statCastCommand ?? (statCastCommand = new RelayCommand(obj => {

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
                    ValueChanged?.Invoke(this, EventArgs.Empty); // Вызываем событие при изменении Value
                }
            }
        }
        public int MasteryBonus
        {
            get { return Character.MasteryBonus; }
        }
        public int Modifier
        {
            get { return modifier = (Value-10)/2; }
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
        public Character Character
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


        public Stat(string name, Character character, int value =10)
        {
            Name = name;
            Character = character;

            Value = value;
            Skills = new ObservableCollection<Skill>(SkillsDictionary.GetValueOrDefault(name));
            SavingThrows = new Skill(name, this) { Value = this.Value};
            Dice = new Dice() { Count = 1, Type = 20 };

            StatInit();

            ValueChanged += (sender, args) =>
            {
                foreach (Skill skill in Skills)
                {
                    skill.Value = Value;
                }
            };
        }
        public void StatInit()
        {
            foreach (Skill current in this.Skills)
            { 
                current.Stat = this;
                current.Value = Value;
            }
        }
        public string Cast()
        {
            int cast = Dice.Cast();
            string result = $"Результат броска {cast + Modifier}: {cast} + {Modifier}";
            return result;
        }
    }
}
