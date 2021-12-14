namespace AutoVente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ville = c.String(maxLength: 100),
                        CodePostale = c.String(nullable: false, maxLength: 5),
                        Rue = c.String(nullable: false, maxLength: 255),
                        ComplementAdresse = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.utilisateur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Telephone = c.String(nullable: false, maxLength: 10),
                        IdAdress = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        Nom = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.adresses", t => t.IdAdress, cascadeDelete: true)
                .Index(t => t.IdAdress);
            
            CreateTable(
                "dbo.Vehicules",
                c => new
                    {
                        Immatriculation = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        DateMisEnCirculation = c.String(nullable: false),
                        Kilometrage = c.Long(nullable: false),
                        Etat = c.Int(nullable: false),
                        IdModel = c.Int(nullable: false),
                        IdCouleur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Immatriculation)
                .ForeignKey("dbo.couleurs", t => t.IdCouleur, cascadeDelete: true)
                .ForeignKey("dbo.models", t => t.IdModel, cascadeDelete: true)
                .Index(t => t.IdModel)
                .Index(t => t.IdCouleur);
            
            CreateTable(
                "dbo.couleurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeCouleur = c.String(nullable: false, maxLength: 15),
                        Nom = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(nullable: false, maxLength: 50),
                        Carburent = c.Int(nullable: false),
                        EmissionCo2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Annee = c.String(nullable: false, maxLength: 4),
                        PuissanceReel = c.Int(nullable: false),
                        NbPlaces = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BoiteDeVitesse = c.Int(nullable: false),
                        MarqueId = c.Int(nullable: false),
                        Nom = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.marques", t => t.MarqueId, cascadeDelete: true)
                .Index(t => t.MarqueId);
            
            CreateTable(
                "dbo.marques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Origine = c.Int(nullable: false),
                        Nom = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.hystoriqueAchatsVentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAchatVente = c.DateTime(nullable: false),
                        Prix = c.Int(nullable: false),
                        Etat = c.Int(nullable: false),
                        Immatriculation = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicules", t => t.Immatriculation)
                .Index(t => t.Immatriculation);
            
            CreateTable(
                "dbo.hystoriqueFrais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false, maxLength: 200),
                        Commentaire = c.String(nullable: false, maxLength: 1000),
                        Cout = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateFrai = c.DateTime(nullable: false),
                        Immatriculation = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicules", t => t.Immatriculation)
                .Index(t => t.Immatriculation);
            
            CreateTable(
                "dbo.images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        Numero = c.Int(nullable: false),
                        Immatriculation = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicules", t => t.Immatriculation)
                .Index(t => t.Immatriculation);
            
            CreateTable(
                "dbo.messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contenu = c.String(nullable: false, maxLength: 3000),
                        Titre = c.String(nullable: false, maxLength: 100),
                        EtatMessage = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IdUtilisateur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.utilisateur", t => t.IdUtilisateur, cascadeDelete: true)
                .Index(t => t.IdUtilisateur);
            
            CreateTable(
                "dbo.ModelCouleurs",
                c => new
                    {
                        Model_Id = c.Int(nullable: false),
                        Couleur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Model_Id, t.Couleur_Id })
                .ForeignKey("dbo.models", t => t.Model_Id, cascadeDelete: true)
                .ForeignKey("dbo.couleurs", t => t.Couleur_Id, cascadeDelete: true)
                .Index(t => t.Model_Id)
                .Index(t => t.Couleur_Id);
            
            CreateTable(
                "dbo.VehiculeUtilisateurs",
                c => new
                    {
                        Vehicule_Immatriculation = c.String(nullable: false, maxLength: 128),
                        Utilisateur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicule_Immatriculation, t.Utilisateur_Id })
                .ForeignKey("dbo.Vehicules", t => t.Vehicule_Immatriculation, cascadeDelete: true)
                .ForeignKey("dbo.utilisateur", t => t.Utilisateur_Id, cascadeDelete: true)
                .Index(t => t.Vehicule_Immatriculation)
                .Index(t => t.Utilisateur_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.messages", "IdUtilisateur", "dbo.utilisateur");
            DropForeignKey("dbo.VehiculeUtilisateurs", "Utilisateur_Id", "dbo.utilisateur");
            DropForeignKey("dbo.VehiculeUtilisateurs", "Vehicule_Immatriculation", "dbo.Vehicules");
            DropForeignKey("dbo.images", "Immatriculation", "dbo.Vehicules");
            DropForeignKey("dbo.Vehicules", "IdModel", "dbo.models");
            DropForeignKey("dbo.hystoriqueFrais", "Immatriculation", "dbo.Vehicules");
            DropForeignKey("dbo.hystoriqueAchatsVentes", "Immatriculation", "dbo.Vehicules");
            DropForeignKey("dbo.Vehicules", "IdCouleur", "dbo.couleurs");
            DropForeignKey("dbo.models", "MarqueId", "dbo.marques");
            DropForeignKey("dbo.ModelCouleurs", "Couleur_Id", "dbo.couleurs");
            DropForeignKey("dbo.ModelCouleurs", "Model_Id", "dbo.models");
            DropForeignKey("dbo.utilisateur", "IdAdress", "dbo.adresses");
            DropIndex("dbo.VehiculeUtilisateurs", new[] { "Utilisateur_Id" });
            DropIndex("dbo.VehiculeUtilisateurs", new[] { "Vehicule_Immatriculation" });
            DropIndex("dbo.ModelCouleurs", new[] { "Couleur_Id" });
            DropIndex("dbo.ModelCouleurs", new[] { "Model_Id" });
            DropIndex("dbo.messages", new[] { "IdUtilisateur" });
            DropIndex("dbo.images", new[] { "Immatriculation" });
            DropIndex("dbo.hystoriqueFrais", new[] { "Immatriculation" });
            DropIndex("dbo.hystoriqueAchatsVentes", new[] { "Immatriculation" });
            DropIndex("dbo.models", new[] { "MarqueId" });
            DropIndex("dbo.Vehicules", new[] { "IdCouleur" });
            DropIndex("dbo.Vehicules", new[] { "IdModel" });
            DropIndex("dbo.utilisateur", new[] { "IdAdress" });
            DropTable("dbo.VehiculeUtilisateurs");
            DropTable("dbo.ModelCouleurs");
            DropTable("dbo.messages");
            DropTable("dbo.images");
            DropTable("dbo.hystoriqueFrais");
            DropTable("dbo.hystoriqueAchatsVentes");
            DropTable("dbo.marques");
            DropTable("dbo.models");
            DropTable("dbo.couleurs");
            DropTable("dbo.Vehicules");
            DropTable("dbo.utilisateur");
            DropTable("dbo.adresses");
        }
    }
}
