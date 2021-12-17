namespace AutoVente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAnneeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.models", "Annee", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.models", "Annee", c => c.String(nullable: false, maxLength: 4));
        }
    }
}
