using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP3_Jeu_de_Pokemons.Models.Rest
{
    public class Player
    {
        public Player()
        {
            Invitations = new List<Invitation>();
        }

        public int PlayerId { get; set; }
        public string Name { get; set; }

        public int? DeckId { get; set; }
        public Deck Deck { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
    }
}
