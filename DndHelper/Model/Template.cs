using DndHelper.Model.Stats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace DndHelper.Model
{
    public class Template : PropPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string race;
        public string Race
        {
            get { return race; }
            set
            {
                race = value;
                OnPropertyChanged(nameof(Race));
            }
        }


        private bool bardicInspiration;
        public bool BardicInspiration
        {
            get { return bardicInspiration; }
            set
            {
                bardicInspiration = value;
                OnPropertyChanged(nameof(BardicInspiration));
            }
        }


        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged(nameof(Level));
                UpdateMasteryBonus();
            }
        }

        private int hitPoints;
        public int HitPoints
        {
            get { return hitPoints = HitPointDice.Cast(); }
        }

        private int armorClass;
        public int ArmorClass
        {
            get { return armorClass; }
            set
            {
                armorClass = value;
                OnPropertyChanged(nameof(ArmorClass));
            }
        }

        private int masteryBonus;
        public int MasteryBonus
        {
            get { return masteryBonus; }
            set
            {
                masteryBonus = value;
                OnPropertyChanged(nameof(MasteryBonus));

                OnPropertyChanged(nameof(Strength));
                OnPropertyChanged(nameof(Dexterity));
                OnPropertyChanged(nameof(Constitution));
                OnPropertyChanged(nameof(Intelligence));
                OnPropertyChanged(nameof(Wisdom));
                OnPropertyChanged(nameof(Charisma));
            }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }

        private int passivePerception;
        public int PassivePerception
        {
            get { return passivePerception + Wisdom.Modifier; }
            set
            {
                passivePerception = value;
                OnPropertyChanged(nameof(PassivePerception));
            }
        }

        private int initiative;
        public int Initiative
        {
            get { return initiative + Dexterity.Modifier; }
            set
            {
                initiative = value;
                OnPropertyChanged(nameof(InitiativeCats));
            }
        }

        private int initiativeCast;
        public int InitiativeCats
        {
            get { return initiativeCast + Initiative; }
            set
            {
                initiativeCast = value;
                OnPropertyChanged(nameof(InitiativeCats));
            }
        }

        private RelayCommand initiativeCatsCommand;
        public RelayCommand InitiativeCatsCommand
        {
            get
            {
                return initiativeCatsCommand ?? (initiativeCatsCommand = new RelayCommand(obj =>
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
                    InitiativeCats = D20.Cast();
                    messageText.Text = $"{Name}: Бросок инициативы - {InitiativeCats}";
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


        private Strength strength;
        private int strengthValue;
        public int StrengthValue
        {
            get { return strengthValue; }
            set
            {
                strengthValue = value;
                OnPropertyChanged(nameof(StrengthValue));
            }
        }
        public Strength Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                strength.Value = StrengthValue;
                strength.Character = this;
                OnPropertyChanged(nameof(Strength));
            }
        }

        private Dexterity dexterity;
        private int dexterityValue;
        public int DexterityValue
        {
            get { return dexterityValue; }
            set
            {
                dexterityValue = value;
                OnPropertyChanged(nameof(DexterityValue));
            }
        }
        public Dexterity Dexterity
        {
            get { return dexterity; }
            set
            {
                dexterity = value;
                dexterity.Value = DexterityValue;
                dexterity.Character = this;
                OnPropertyChanged(nameof(Dexterity));
            }
        }

        private Constitution constitution;
        private int constitutionValue;
        public int ConstitutionValue
        {
            get { return constitutionValue; }
            set
            {
                constitutionValue = value;
                OnPropertyChanged(nameof(ConstitutionValue));
            }
        }
        public Constitution Constitution
        {
            get { return constitution; }
            set
            {
                constitution = value;
                constitution.Value = ConstitutionValue;
                constitution.Character = this;
                OnPropertyChanged(nameof(Constitution));
            }
        }

        private Intelligence intelligence;
        private int intelligenceValue;
        public int IntelligenceValue
        {
            get { return intelligenceValue; }
            set
            {
                intelligenceValue = value;
                OnPropertyChanged(nameof(IntelligenceValue));
            }
        }
        public Intelligence Intelligence
        {
            get { return intelligence; }
            set
            {
                intelligence = value;
                intelligence.Value = IntelligenceValue;
                intelligence.Character = this;
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        private Wisdom wisdom;
        private int wisdomValue;
        public int WisdomValue
        {
            get { return wisdomValue; }
            set
            {
                wisdomValue = value;
                OnPropertyChanged(nameof(WisdomValue));
            }
        }
        public Wisdom Wisdom
        {
            get { return wisdom; }
            set
            {
                wisdom = value;
                wisdom.Value = WisdomValue;
                wisdom.Character = this;
                OnPropertyChanged(nameof(Wisdom));
            }
        }

        private Charisma charisma;
        private int charismaValue;
        public int CharismaValue
        {
            get { return charismaValue; }
            set
            {
                charismaValue = value;
                OnPropertyChanged(nameof(CharismaValue));
            }
        }
        public Charisma Charisma
        {
            get { return charisma; }
            set
            {
                charisma = value;
                charisma.Value = CharismaValue;
                charisma.Character = this;
                OnPropertyChanged(nameof(Charisma));
            }
        }


        private Dice hitPointDice;
        public Dice HitPointDice
        {
            get { return hitPointDice; }
            set
            {
                hitPointDice = value;
                OnPropertyChanged(nameof(HitPointDice));
            }
        }

        //private List<> attacks;
        private ObservableCollection<string> equipment;
        public ObservableCollection<string> Equipment
        {
            get { return equipment; }
            set
            {
                equipment = value;
                OnPropertyChanged(nameof(Equipment));
            }
        }

        private ObservableCollection<Trait> traits;
        public ObservableCollection<Trait> Traits
        {
            get { return traits; }
            set
            {
                traits = value;
                OnPropertyChanged(nameof(Traits));
            }
        }

        private Dice d20 = new Dice() { Count = 1, Type =20 };
        public Dice D20
        {
            get { return d20; }
        }

        public Template(
            int strengthValue = 10,
            int dexterityValue = 10,
            int constitutionValue = 10,
            int intelligenceValue = 10,
            int wisdomValue = 10,
            int charismaValue = 10)
        {
            StrengthValue = strengthValue;
            DexterityValue = dexterityValue;
            ConstitutionValue = constitutionValue;
            IntelligenceValue = intelligenceValue;
            WisdomValue = wisdomValue;
            CharismaValue = charismaValue;

            Strength = new Strength();
            Dexterity = new Dexterity();
            Constitution = new Constitution();
            Intelligence = new Intelligence();
            Wisdom = new Wisdom();
            Charisma = new Charisma();

            ArmorClass = 10 + Dexterity.Modifier;
            UpdateMasteryBonus();
            Speed = 30;
            PassivePerception = 10;
            Initiative = 0;

            //HitPointDice = null;
            BardicInspiration = false;

        }
        public void UpdateMasteryBonus()
        {
            if (Level <= 4)
            {
                MasteryBonus = 2;
            }
            else if (Level  <= 8)
            {
                MasteryBonus = 3;
            }
            else if (Level <= 12)
            {
                MasteryBonus = 4;
            }
            else if (Level <= 16)
            {
                MasteryBonus = 5;
            }
            else if (Level <= 20)
            {
                MasteryBonus = 6;
            }
        }
    }
}
