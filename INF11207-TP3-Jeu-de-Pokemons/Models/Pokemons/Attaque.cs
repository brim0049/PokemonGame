using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Attaque : Binding
    {
        public EfficaciteAttaque eff { get; set; }
        private string name;
        private double damage;
        private OrigineType type;
        [Key]
        public int AttaqueId { get; set; }
    public OrigineType Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Damage
        {
            get { return damage; }
            set
            {
                if (damage != value)
                {
                    damage = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Id { get; set; }
        public Pokemon Pokemon { get; set; }

        public double CalculerDegats(Pokemon adversaire)
        {
            double efficaciteTotale = 1;

            foreach (OrigineType typeAdversaire in adversaire.Types)
            {
                efficaciteTotale *= Game.ChercherEfficacite(type, typeAdversaire);
            }
            return damage * efficaciteTotale;
        }
    }
}
