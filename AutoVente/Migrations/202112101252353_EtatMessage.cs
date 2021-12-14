namespace AutoVente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EtatMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.messages", "EtatMessage", c => c.Int(nullable: false));
            DropColumn("dbo.messages", "Ouvert");
        }
        
        public override void Down()
        {
            AddColumn("dbo.messages", "Ouvert", c => c.Boolean(nullable: false));
            DropColumn("dbo.messages", "EtatMessage");
        }
    }
}
