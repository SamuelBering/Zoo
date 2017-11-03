namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheRestOfPropertisToDBmodelClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CountriesOfOrigin", "Name", c => c.String());
            AddColumn("dbo.Environments", "Name", c => c.String());
            AddColumn("dbo.Spieces", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Spieces", "Name");
            DropColumn("dbo.Environments", "Name");
            DropColumn("dbo.CountriesOfOrigin", "Name");
        }
    }
}
