﻿using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class Pokemon : Personnage, ICloneable, ICombattant
    {
        private string description;
        private int atk;
        private int def;
        private int price;
        private int health;
        private Emplacement emplacement;
        private JaugeVie hpGauge;
        private Evolution evolution;
        private Guid idPokemonAchete;
        private string image;
        private bool achete;
        private bool equipe;

        private List<Attaque> attacks;

        public int Id { get; set; }
        public List<OrigineType> Types { get; set; }

        [NotMapped]
        public string PrintTypes
        {
            get
            {
                string types = "";
                for (int i = 0; i < Types.Count; i++)
                {
                    types += Types[i].ToString() + (i < Types.Count - 1 ? ", " : "");
                }
                return types;
            }
        }
        [NotMapped]
        public bool Evolue
        {
            get
            {
                return evolution != null && !string.IsNullOrEmpty(evolution.To);

            }
        }
        [NotMapped]
        public int EvolutionId { get; set; }
        public virtual Evolution Evolution
        {
            get { return evolution; }
            set
            {
                if (evolution != value)
                {
                    evolution = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ATK
        {
            get { return atk; }
            set
            {
                if (atk != value)
                {
                    atk = value;
                    OnPropertyChanged();
                }
            }
        }

        public int DEF
        {
            get { return def; }
            set
            {
                if (def != value)
                {
                    def = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged();
                }
            }
        }
        [NotMapped]
        public string PrintPrice
        {
            get { return $"{price}$"; }
        }

        public int Health
        {
            get { return health; }
            set
            {
                if (health != value)
                {
                    health = value;
                    hpGauge = new JaugeVie(health);
                    OnPropertyChanged();
                }
            }
        }
        [NotMapped]
        public JaugeVie HpGauge
        {
            get { return hpGauge; }
            set
            {
                if (hpGauge != value)
                {
                    hpGauge = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public List<Attaque> Attacks
        {
            get { return attacks; }
            set
            {
                if (attacks != value)
                {
                    attacks = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Achete
        {
            get { return achete; }
            set
            {
                if (achete != value)
                {
                    achete = value;
                    OnPropertyChanged();
                }
            }
        }
        [NotMapped]
        public bool Equipe
        {
            get { return equipe; }
            set
            {
                if (equipe != value)
                {
                    equipe = value;
                    OnPropertyChanged();
                }
            }
        }
        [NotMapped]
        public Emplacement Emplacement
        {
            get { return emplacement; }
            set
            {
                if (emplacement != value)
                {
                    if (value == Emplacement.Desequipe)
                    {
                        Equipe = false;
                    }
                    else
                    {
                        Equipe = true;
                    }
                    emplacement = value;
                    OnPropertyChanged();
                }
            }
        }
        [NotMapped]
        public Guid IdPokemonAchete 
        { 
            get { return idPokemonAchete; }
            set
            {
                if (idPokemonAchete != value)
                {
                    idPokemonAchete = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonConstructor]
        public Pokemon() : base("", 1, 100) 
        {
            //Types = new List<OrigineType>();
            //Attacks = new List<Attaque>();
        }
     
        public object Clone()
        {
            return MemberwiseClone();
        }

        public void Acheter()
        {
            Achete = true;
            if (idPokemonAchete.Equals(Guid.Empty))
            {
                idPokemonAchete = Guid.NewGuid();
            }
        }

        public bool EncoreValide()
        {
            return HpGauge.Value > 0;
        }

        public bool Attaquer(Pokemon adversaire, Attaque attaque)
        {
            double degats = attaque.CalculerDegats(adversaire) + ATK;

            return adversaire.RecevoirUneAttaque(degats); 
        }

        public bool RecevoirUneAttaque(double degats)
        {
            int degatsArrondis = (int)Math.Ceiling(degats) - DEF;
            HpGauge.PerdreDeLaVie(degatsArrondis);

            return HpGauge.Value == 0;
        }

        public void TerminerUnCombat(ResultatCombat resultats)
        {
            int niveauxEnPlus = XpGauge.AjouterExperience(resultats.Experience);
            Level += niveauxEnPlus;

            for (int i = 0; i < niveauxEnPlus; i++)
            {
                HpGauge.MaxValue++;
                ATK++;
            }

            HpGauge.Reinitialiser();
        }
     
        public static List<Pokemon> GetPokemon()
        {
            List<Pokemon> pokemons;
            PokemonAppDbContext pokemonAppDbContext = new PokemonAppDbContext();
            pokemons = pokemonAppDbContext.Pokemons.ToList();
            return pokemons;
        }
    }
}
