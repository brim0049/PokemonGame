using INF11207_TP3_Jeu_de_Pokemons.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace INF11207_TP3_Jeu_de_Pokemons.Enums
{
    [Flags]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum OrigineType
    {

        Normal = 0,
        Fire = 1,
        Water = 2,
        Electric = 3,
        Grass = 4,
        Ice = 5,
        Fighting = 6,
        Poison = 7,
        Ground = 8,
        Steel = 9,
        Flying = 10,
        Psychic = 11,
        Bug = 12,
        Rock = 13,
        Dark = 14,
        Ghost = 15,
        Dragon = 16,
        Fairy = 17
    }
}
