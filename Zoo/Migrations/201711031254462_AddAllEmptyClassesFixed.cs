namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllEmptyClassesFixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.AnimalId);
            
            CreateTable(
                "dbo.CountriesOfOrigin",
                c => new
                    {
                        CountryOfOriginId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CountryOfOriginId);
            
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        EnvironmentId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.Spieces",
                c => new
                    {
                        SpiecesId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SpiecesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Spieces");
            DropTable("dbo.Environments");
            DropTable("dbo.CountriesOfOrigin");
            DropTable("dbo.Animals");
        }
    }
}
