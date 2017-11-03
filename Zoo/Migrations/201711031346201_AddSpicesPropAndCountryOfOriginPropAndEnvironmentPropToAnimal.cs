namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpicesPropAndCountryOfOriginPropAndEnvironmentPropToAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "CountryOfOrigin_CountryOfOriginId", c => c.Int());
            AddColumn("dbo.Animals", "Environment_EnvironmentId", c => c.Int());
            AddColumn("dbo.Animals", "Spieces_SpiecesId", c => c.Int());
            CreateIndex("dbo.Animals", "CountryOfOrigin_CountryOfOriginId");
            CreateIndex("dbo.Animals", "Environment_EnvironmentId");
            CreateIndex("dbo.Animals", "Spieces_SpiecesId");
            AddForeignKey("dbo.Animals", "CountryOfOrigin_CountryOfOriginId", "dbo.CountriesOfOrigin", "CountryOfOriginId");
            AddForeignKey("dbo.Animals", "Environment_EnvironmentId", "dbo.Environments", "EnvironmentId");
            AddForeignKey("dbo.Animals", "Spieces_SpiecesId", "dbo.Spieces", "SpiecesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "Spieces_SpiecesId", "dbo.Spieces");
            DropForeignKey("dbo.Animals", "Environment_EnvironmentId", "dbo.Environments");
            DropForeignKey("dbo.Animals", "CountryOfOrigin_CountryOfOriginId", "dbo.CountriesOfOrigin");
            DropIndex("dbo.Animals", new[] { "Spieces_SpiecesId" });
            DropIndex("dbo.Animals", new[] { "Environment_EnvironmentId" });
            DropIndex("dbo.Animals", new[] { "CountryOfOrigin_CountryOfOriginId" });
            DropColumn("dbo.Animals", "Spieces_SpiecesId");
            DropColumn("dbo.Animals", "Environment_EnvironmentId");
            DropColumn("dbo.Animals", "CountryOfOrigin_CountryOfOriginId");
        }
    }
}
