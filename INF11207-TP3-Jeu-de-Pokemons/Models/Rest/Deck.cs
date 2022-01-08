using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP3_Jeu_de_Pokemons.Models.Rest
{
    public class Deck
    {
        public int DeckId { get; set; }
        public int? FirstPokemonId { get; set; }
        public int? SecondPokemonId { get; set; }
        public int? ThirdPokemonId { get; set; }
    }
}
