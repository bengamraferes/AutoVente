namespace AutoVente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelPriceInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.models", "Prix", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.models", "Prix", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
