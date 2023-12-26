
using DndHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Security.Policy;
using DndHelper.Model.Stats;
using System.Security.Cryptography.Xml;

namespace DndHelper.ViewModel
{
    public class ApplicationViewModel : PropPropertyChanged
    {
        private Random Random = new();

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                selectedCharacter = value;
                OnPropertyChanged(nameof(selectedCharacter));
            }
        }

        private Template selectedInBattle;
        public Template SelectedInBattle
        {
            get { return selectedInBattle; }
            set
            {
                selectedInBattle = value;
                OnPropertyChanged(nameof(SelectedInBattle));
            }
        }
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Template> InBattle { get; set; }
        public static ObservableCollection<string> Log { get; set; }

        private Dice D20 = new Dice() { Count = 1, Type = 20 };

        private RelayCommand initiativeCatsCommand;
        public RelayCommand InitiativeCatsCommand
        {
            get
            {
                return initiativeCatsCommand ?? (initiativeCatsCommand = new RelayCommand(obj =>
                {
                    int Cast;
                    
                    Cast = D20.Cast();
                    SelectedCharacter.InitiativeCats = Cast;
                    Log.Add($"{SelectedCharacter.Name}: Бросок инициативы: Результат броска {SelectedCharacter.InitiativeCats}: {Cast} + {SelectedCharacter.Initiative}");
                    //messageText.Text = $"{SelectedCharacter.Name}: Бросок инициативы {Cast} + {SelectedCharacter.Initiative} - {SelectedCharacter.InitiativeCats}";
                    if (InBattle.FirstOrDefault(Character => Character.Name == SelectedCharacter.Name) == null)
                    {
                        InBattle.Add(SelectedCharacter);
                    }
                    var sortedCollection = new ObservableCollection<Template>(InBattle.OrderByDescending(character => character.InitiativeCats));
                    InBattle.Clear();
                    foreach (var Character in sortedCollection)
                    {
                        InBattle.Add(Character);
                    }
                }));
            }
        }

        private RelayCommand endTurnCommand;
        public RelayCommand EndTurnCommand
        {
            get
            {
                return endTurnCommand ?? (endTurnCommand = new RelayCommand(obj =>
                {
                    int Death = 10;
                    Template temp = InBattle.First();
                    InBattle.Remove(InBattle.First());
                    InBattle.Add(temp);

                    var IsDead = InBattle.FirstOrDefault(Character => Character.CurrentHitPoints == 0);
                    if (IsDead != null && IsDead == InBattle.First())
                    {
                        if (IsDead.IsFriend == false)
                        {
                            MessageBox.Show($"{IsDead.Name} мертв");
                            Log.Add($"{IsDead.Name} умер");
                            InBattle.Remove(IsDead);
                        }
                        else
                        {
                            if (D20.Cast() >= Death)
                            {
                                IsDead.DeathSaveTrue++;
                                Death++;
                                if (IsDead.DeathSaveTrue == 3)
                                {
                                    IsDead.CurrentHitPoints = 1;
                                    IsDead.DeathSaveTrue = 0;
                                }
                            }
                            else
                            {
                                IsDead.DeathSaveFalse++;
                                if (IsDead.DeathSaveFalse == 3)
                                {
                                    MessageBox.Show($"{IsDead.Name} умер");
                                    Log.Add($"{IsDead.Name} умер");
                                    InBattle.Remove(IsDead);
                                }
                            }
                        }
                    }
                    SelectedInBattle = InBattle.First();
                }));
            }
        }
        public ApplicationViewModel()
        {
            Characters = new ObservableCollection<Character>(DataContext.DataBase.Characters);

            InBattle = new ObservableCollection<Template>();

            for(int i = 0; i < Random.Next(1,5); i++)
            {
                DataContext.DataBase.Enemies[0].InitiativeCats = D20.Cast();
                InBattle.Add(DataContext.DataBase.Enemies[0]);
            }

            InBattle.Add(DataContext.DataBase.Enemies[1]);
            
            Log = new ObservableCollection<string>();

            SelectedCharacter = Characters.First();
        }
    }
}
