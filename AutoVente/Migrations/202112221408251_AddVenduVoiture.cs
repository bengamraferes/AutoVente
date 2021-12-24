namespace AutoVente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVenduVoiture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicules", "Vendu", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicules", "Vendu");
        }
    }
}
