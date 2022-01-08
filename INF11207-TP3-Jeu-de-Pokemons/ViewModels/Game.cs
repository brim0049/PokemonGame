using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Models;
using INF11207_TP3_Jeu_de_Pokemons.Services;
using System.Collections.Generic;
using System.Windows;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels
{
    public class Game
    {
        private static readonly string _cheminVersSauvegarde = "Resources/Save/Sauvegarde.json";
        private static bool _sauvegardeChargee = false;

        private static List<Pokemon> _pokemonsBase;
        private static List<EfficaciteAttaque> _efficacites; 

        private static MainWindowViewModel _mainViewModel = new MainWindowViewModel();
        private static Dresseur _dresseur = new Dresseur(1);
        private static Recherche _recherche;

        public static string CheminVersSauvegarde
        {
            get { return _cheminVersSauvegarde; }
        }

        public static bool SauvegardeChargee
        {
            get { return _sauvegardeChargee; }
        }

        public static Emplacement Emplacement { get; set; }
        public static Attaque Attaque { get; set; }

        public static MainWindowViewModel MainWindow
        {
            get { return _mainViewModel; }
        }

        public static BaseViewModel VueActuelle
        {
            get { return _mainViewModel.VueActuelle; }
        }

        public static Dresseur Dresseur
        {
            get { return _dresseur; }
            set
            {
                _dresseur = value;
                _sauvegardeChargee = true;
            }
        }

        public static Recherche Recherche
        {
            get { return _recherche; }
        }

        public static Combat Combat { get; set; }
        public static EfficaciteAttaque efficaciteAttaque { get; set; }


        public static List<Pokemon> PokemonsDeBase
        {
            get { return _pokemonsBase; }
        }

        public static List<EfficaciteAttaque> Efficacites
        {
            get { return _efficacites; }
        }

        public static void Initialiser()
        {
            ChargerPokemonsBase();
            ChargerEfficacitesAttaques();
            _recherche = new Recherche();
            _recherche.Filtre = FiltreRecherche.Tous;
            Combat = new Combat(new Dresseur(1), new Dresseur(1), 0);
        }

        public static void Naviguer(string destination)
        {
            _mainViewModel.Navigation(destination);
        }

        public static void Sauvegarder()
        {
            if (Loader.Sauvegarder(Dresseur, CheminVersSauvegarde))
            {
                MessageBox.Show("Sauvegarde effectuée avec succès.", "Sauvegarde effectuée", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Une erreur s'est produite lors de la sauvegarde.", "Erreur", MessageBoxButton.OK);
            }
        }

        public static void ChargerPokemonsBase()
        {
            _pokemonsBase = new List<Pokemon>();
            _pokemonsBase = Pokemon.GetPokemon();
        }

        public static void ChargerEfficacitesAttaques()
        {
            _efficacites = new List<EfficaciteAttaque>();
            _efficacites= EfficaciteAttaque.GetEfficaciteAttaque();
        }

        public static double ChercherEfficacite(OrigineType agresseur, OrigineType defenseur)
        {
            
            return Efficacites.Find(e => e.Attack == agresseur && e.Defend == defenseur).Effectiveness;
        }
    }
}
