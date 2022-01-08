using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP3_Jeu_de_Pokemons.Models.Rest
{
    public class Result
    {
        public int resultId { get; set; }

        public int InvitationId { get; set; }
        public Invitation Invitation { get; set; }

        public int PlayerWinnerId { get; set; }
        public Player PlayerWinner { get; set; }
    }
}
