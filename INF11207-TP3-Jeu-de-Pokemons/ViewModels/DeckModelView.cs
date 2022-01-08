using INF11207_TP3_Jeu_de_Pokemons.ViewModels.RelayCommands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    class DeckModelView: INotifyPropertyChanged
    {
        /* REST API object */
        private RestApiQueries _restApiQueries;
        /* reference to the current window */
        private Window _window;

        /* different window components binding */
        private Models.Invitation _invitation;
        private Models.Rest.Player _playersapi;


        private Models.Rest.Deck _deck;
        public string Name
        {
            get
            {
                return _playersapi.Name;
            }
        }
        public int Id
        {
            get
            {
                return _deck.DeckId;
            }
        }
        public int? First
        {
            get
            {
                return _deck.FirstPokemonId;
            }
        }
        public int? Second
        {
            get
            {
                return _deck.SecondPokemonId;
            }
        }
        public int? Third
        {
            get
            {
                return _deck.ThirdPokemonId;
            }
        }
        public DeckModelView(Window window, Models.Invitation player)
        {
            _invitation = player;
            _restApiQueries = new RestApiQueries();

            new Models.Rest.Player();
            _window = window;
            _playersapi = _restApiQueries.GetPlayer(_invitation.PlayerReceiverId, "Players");
            _deck = _restApiQueries.GetDeck(_playersapi.DeckId.Value, "Decks");
        }

        /* definition of the commands */




        /* definition of PropertyChanged */
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
