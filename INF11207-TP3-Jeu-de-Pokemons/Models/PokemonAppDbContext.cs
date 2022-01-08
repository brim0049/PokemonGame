using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using INF11207_TP3_Jeu_de_Pokemons.Enums;
using INF11207_TP3_Jeu_de_Pokemons.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    class PokemonAppDbContext:DbContext
    {
        public DbSet<Models.Pokemon> Pokemons { get; set; }
        public DbSet<Models.EfficaciteAttaque> EfficaciteAttaques { get; set; }

        //public DbSet<Models.Evolution> Evolutions { get; set; }
        //public DbSet<Models.Attaque> Attaques { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
MultiSubnetFailover=False;Database=PokemonDataBaseIIApplicationDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fichier Pokemoninfo.json

            List<Pokemon> jsonPokemon = JsonConvert.DeserializeObject<List<Pokemon>>(File.ReadAllText("Resources/Data/PokemonInfo.json"));
            modelBuilder.Entity<Pokemon>().Property(e => e.Evolution).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<Evolution>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        
            modelBuilder.Entity<Pokemon>().Property(e => e.Attacks).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<List<Attaque>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            modelBuilder.Entity<Pokemon>().Property(p => p.Types)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<OrigineType>>(v));

            modelBuilder.Entity<Pokemon>()
                 .HasData(jsonPokemon);

            modelBuilder.Entity<Pokemon>()
                    .HasKey(p => p.Id);

            modelBuilder.Entity<Attaque>(x =>
            {
                x.HasKey(a => a.AttaqueId);
                x.Property(a => a.AttaqueId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Attaque>()
                .Property(e => e.Type)
                .HasConversion(
           v => v.ToString(),
           v => (OrigineType)Enum.Parse(typeof(OrigineType), v));

            modelBuilder.Entity<Evolution>().HasNoKey();

            modelBuilder.Entity<JaugeXp>().HasNoKey();
            modelBuilder.Entity<JaugeVie>().HasNoKey();
            base.OnModelCreating(modelBuilder);

            // fichier EfficaciteAttaques.json
            List<EfficaciteAttaque> efficacitejson = JsonConvert.DeserializeObject<List<EfficaciteAttaque>>(File.ReadAllText("Resources/Data/AttacksEffectiveness.json"))
           .Select((x, index) => new EfficaciteAttaque
            {
                Id = index + 1,
                Attack = x.Attack,
                Defend = x.Defend,
                Effectiveness = x.Effectiveness
            }).ToList();

            modelBuilder.Entity<EfficaciteAttaque>()
                .Property(e => e.Attack)
                .HasConversion(
           v => v.ToString(),
           v => (OrigineType)Enum.Parse(typeof(OrigineType), v));

            modelBuilder.Entity<EfficaciteAttaque>()
                .Property(e => e.Defend)
                .HasConversion(
           v => v.ToString(),
           v => (OrigineType)Enum.Parse(typeof(OrigineType), v));


            modelBuilder.Entity<EfficaciteAttaque>()
                .HasData(efficacitejson);
            modelBuilder.Entity<EfficaciteAttaque>()
                    .HasKey(p => p.Id);
            modelBuilder.Entity<EfficaciteAttaque>().Property(e => e.Effectiveness).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<double>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

        }

    }
}
