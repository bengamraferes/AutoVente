using AutoVente.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace AutoVente.DAO
{
    public class MyContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « MyContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « AutoVente.DAO.MyContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « MyContext » dans le fichier de configuration de l'application.
        public MyContext()
            : base("name=MyContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Model> Models { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Couleur> Couleurs { get; set; }
        public DbSet<Vehicule> Vehicule { get; set; }
        public DbSet<HystoriqueFrai> hystoriqueFrais { get; set; }
        public DbSet<HystoriqueAchatVente> HystoriqueAchatVentes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Message> Messages { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}