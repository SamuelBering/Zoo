namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeightPropToAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Weight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "Weight");
        }
    }
}
