namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToDateTime2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VeterinaryReservations");
            AlterColumn("dbo.VeterinaryReservations", "DateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddPrimaryKey("dbo.VeterinaryReservations", new[] { "VeterinaryId", "AnimalId", "DateTime" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VeterinaryReservations");
            AlterColumn("dbo.VeterinaryReservations", "DateTime", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.VeterinaryReservations", new[] { "VeterinaryId", "AnimalId", "DateTime" });
        }
    }
}
