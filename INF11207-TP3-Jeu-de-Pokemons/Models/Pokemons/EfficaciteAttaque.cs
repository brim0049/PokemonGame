using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class EfficaciteAttaque
    {

        public int Id { get; set; }
        public double Effectiveness { get; set; }
        public OrigineType Attack { get; set; }
        public OrigineType Defend { get; set; }
        

        public static List<EfficaciteAttaque> GetEfficaciteAttaque()
        {
            List<EfficaciteAttaque> efficaciteAttaques;
            PokemonAppDbContext pokemonAppDbContext = new PokemonAppDbContext();
            efficaciteAttaques = pokemonAppDbContext.EfficaciteAttaques.ToList();
            return efficaciteAttaques;
        }
    }
}
