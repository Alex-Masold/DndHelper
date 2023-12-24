
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
using DndHelper.View;
using System.Windows.Controls.Primitives;

namespace DndHelper.ViewModel
{
    public class ApplicationViewModel : PropPropertyChanged
    {
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

        private string searchCharacterString;
        public string SearchCharacterString
        {
            get { return searchCharacterString; }
            set
            {
                searchCharacterString = value;
                OnPropertyChanged(nameof(SearchCharacterString));
                Search();
            }
        }

        private ObservableCollection<Character> filteredCharacters;
        public ObservableCollection<Character> FilteredCharacters
        {
            get { return filteredCharacters; }
            set
            {
                filteredCharacters = value;
                OnPropertyChanged(nameof(FilteredCharacters));
            }
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(SearchCharacterString))
            {
                FilteredCharacters = Characters;
            }
            else
            {
                FilteredCharacters = new ObservableCollection<Character>(
                    from character in Characters
                    where
                    character.Name.Contains(SearchCharacterString, StringComparison.OrdinalIgnoreCase)
                    orderby character.Name
                    select character
                    );
            }
        }
        
        public ObservableCollection<Character> Characters { get; set; }

        private RelayCommand addCharacterCommand;
        public RelayCommand AddCharacterCommand
        {
            get
            {
                return addCharacterCommand ??
                    (addCharacterCommand = new RelayCommand(obj =>
                    {
                        //Character character = new Character();
                        //Characters.Add(character);
                        //SelectedCharacter = character;
                        // Создайте экземпляр ViewModel для окна создания персонажа
                        CreateCharacterViewModel createCharacterViewModel = new CreateCharacterViewModel();

                        // Создайте окно и установите DataContext
                        CreateCharacterWindow createCharacterWindow = new CreateCharacterWindow();

                        // Установите текущее окно в качестве владельца
                        createCharacterWindow.Owner = Application.Current.MainWindow;

                        // Откройте окно в модальном режиме (ShowDialog)
                        bool? result = createCharacterWindow.ShowDialog();

                        // Если результат окна положительный (например, пользователь нажал "Создать"),
                        // вы можете обновить коллекцию персонажей, если это необходимо.
                        if (result == true)
                        {
                            Characters.Add(createCharacterViewModel.Character);
                            SelectedCharacter = createCharacterViewModel.Character;
                        }
                    }));
            }
        }


        private RelayCommand deleteCharacterCommand;
        public RelayCommand DeleteCharacterCommand
        {
            get
            {
                return deleteCharacterCommand ??
                    (deleteCharacterCommand = new RelayCommand(obj =>
                    {
                        Character character = new Character();
                        Characters.Remove(character);
                        SelectedCharacter = character;
                    }));
            }
        }
        

        public ApplicationViewModel()
        {
            Characters = new ObservableCollection<Character>(DataContext.DataBase.Characters);
            FilteredCharacters = Characters;

            SelectedCharacter = Characters.First();
        }
    }
}
