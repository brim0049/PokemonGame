using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.Services;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels.RelayCommands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class LancementCombatViewModel : BaseViewModel, INotifyPropertyChanged
    {
        /* REST API object */
        private RestApiQueries _restApiQueries;
        /* reference to the current window */

        /* different window components binding */

        private Models.Rest.Deck _deck;
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

        /* different window components binding */
        private ObservableCollection<Models.Invitation> _invitations;
        public ObservableCollection<Models.Invitation> Invitations
        {
            get
            {
                return _invitations;
            }
        }

        public Models.Invitation SelectedInvitation { get; set; }

        private Models.Invitation _addedInvitation;


        public int AddedIdInvitation
        {
            get
            {
                return _addedInvitation.PlayerReceiverId;
            }
            set
            {
                if (_addedInvitation.PlayerReceiverId != value)
                {
                    _addedInvitation.PlayerReceiverId = value;
                    OnPropertyChanged();
                }
            }
        }

        public float AddMoney
        {
            get
            {
                return _addedInvitation.Money;
            }
            set
            {
                if (_addedInvitation.Money != value)
                {
                    _addedInvitation.Money = value;
                    OnPropertyChanged();

                }
            }
        }
        public Invitation Invitation
        {
            get { return _invitation; }
            set { _invitation = value; }
        }

        public Invitation InvitationSelectionne
        {
            get { return _invitationSelectionnee; }
            set
            {
                _invitationSelectionnee = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Invitation> Resultats
        {
            get { return _resultats; }
            set
            {
                if (_resultats != value)
                {
                    _resultats = value;
                    OnPropertyChanged();
                }
            }
        }


        private Invitation _invitation;
        private Invitation _invitationSelectionnee;
        private ObservableCollection<Invitation> _resultats;
        ///* definition of the commands */
        public ICommand AddInvitationCommand { get; private set; }
        public ICommand SyncInvitationCommand { get; private set; }
        public ICommand AccepteCommand { get; private set; }
        public ICommand RefuseCommand { get; private set; }
        public ICommand CommandeLancer { get; set; }
        public ICommand CommandeTerminer { get; set; }

        /* constructor and initialization */

        public LancementCombatViewModel(WindowSize size) : base(size) 
        {

            _restApiQueries = new RestApiQueries();
            _invitations = new ObservableCollection<Models.Invitation>(_restApiQueries.GetInvitation("Invitations/Emitted/1"));
            _addedInvitation = new Models.Invitation();;
            AddInvitationCommand = new RelayCommand(
                o => true,
                o => AddInvitation()
            );

            SyncInvitationCommand = new RelayCommand(
                o => true,
                o => SyncInvitaiton()
            );
            AccepteCommand = new RelayCommand(
              o => true,
              o => Accepter()
          );

            RefuseCommand = new RelayCommand(
                o => true,
                o => Refuser()
            );
            CommandeTerminer = new RelayCommand(
                o => Invitation.IsValid,
                o => Terminer()
            );

            CommandeLancer = new RelayCommand(
                o => _invitationSelectionnee != null && Invitation.IsValid,
                o => LancerUnCombat()
            );
        }
        private void SyncInvitaiton()
        {
            _invitations.Clear();
            foreach (Models.Invitation task in _restApiQueries.GetInvitation("Invitations/Emitted/1"))
            {
                _invitations.Add(task);
            }
        }

        private void Accepter()
        {
            bool success = _restApiQueries.AccepteInvitation(SelectedInvitation, SelectedInvitation.PlayerReceiverId, SelectedInvitation.InvitationId, "Invitations/Accept");
            LancerUnCombat();
            Views.DeckWin deck = new Views.DeckWin(SelectedInvitation);
            deck.Show();
            _resultat = new Models.Rest.Result();
            PlayerWinnerId = SelectedInvitation.PlayerEmitterId;
            ResultId = SelectedInvitation.InvitationId;
            if (success)
                SyncInvitaiton();
            else
                MessageBox.Show("L'invitation n'a pas pu être acceptée !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Terminer()
        {
            bool success = _restApiQueries.AccepteInvitation(SelectedInvitation, SelectedInvitation.PlayerReceiverId, SelectedInvitation.InvitationId, "Invitations/Accept");
            _resultat = new Models.Rest.Result();
            PlayerWinnerId = SelectedInvitation.PlayerEmitterId;
            ResultId = SelectedInvitation.InvitationId;
            AddResult();
            if (success)
                SyncInvitaiton();
            else
                MessageBox.Show("L'invitation n'a pas pu être acceptée !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Refuser()
        {
            bool success = _restApiQueries.RefuseInvitation(SelectedInvitation, SelectedInvitation.PlayerReceiverId, SelectedInvitation.InvitationId, "Invitations/Refuse");
            if (success)
                SyncInvitaiton();
            else
                MessageBox.Show("L'invititaiton n'a pas pu être refusée !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AddInvitation()
        {
            bool success = _restApiQueries.AddInvitation(_addedInvitation, "Invitations/1");
            if (success)
                SyncInvitaiton();
            else
                MessageBox.Show("La tâche n'a pas pu être ajoutée !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void RechercherInvitations()
        {
            Invitation = new Invitation(Dresseur);
            Invitation.MiseCreateur = 100;

            List<Invitation> invitations = ChargerInvitations();
            invitations.AddRange(Dresseur.Invitations.FindAll(i => i.Statut == StatutType.Attente));

            Resultats = new ObservableCollection<Invitation>(invitations);
            InvitationSelectionne = Resultats[0];
        }
        public void LancerUnCombat()
        {
            Dresseur.ModifierArgent(-Invitation.MiseCreateur);

            int mise = Invitation.MiseCreateur + InvitationSelectionne.MiseCreateur;
            Dresseur adversaire = Resultats[0].Createur;
            adversaire.Depot.RechargerEmplacements();
            Game.Combat = new Combat(Dresseur, adversaire, mise);

            Game.Naviguer("combats");
        }

        private List<Invitation> ChargerInvitations()
        {
            List<Invitation> invitations = new List<Invitation>();
            if (!Loader.Charger(out invitations, "Resources/Data/InvitationsParDefaut.json"))
            {
                MessageBox.Show("Le fichier InvitationsParDefaut.json est manquant. Le jeu pourra donc rencontrer des comportements étranges.",
                    "Données manquantes", MessageBoxButton.OK);
            }
            return invitations;
        }
        /* definition of PropertyChanged */
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Models.Rest.Result _resultat;
        public static Combat game;


        public int ResultId
        {

            get
            {
                return _resultat.InvitationId;
            }
            set
            {
                _resultat.InvitationId = value;
                OnPropertyChanged();


            }
        }
        public int PlayerWinnerId
        {
            get
            {
                return _resultat.PlayerWinnerId;

            }
            set
            {
                //if (game.Result() == false)
                //{
                _resultat.PlayerWinnerId = value;

                //}
                //else
                //{
                //    _resultat.PlayerWinnerId = 1;
                //}
            }
            }


        public void AddResult()
        {
             
           
            bool success = _restApiQueries.AddResultat(_resultat, "Results");

            if (success)
                SyncInvitaiton();
            else
                MessageBox.Show("La tâche n'a pas pu être ajoutée !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
