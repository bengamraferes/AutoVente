namespace AutoVente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrixVoiture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicules", "Prix", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicules", "Prix");
        }
    }
}
