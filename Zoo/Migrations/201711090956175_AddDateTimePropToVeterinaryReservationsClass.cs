namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimePropToVeterinaryReservationsClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VeterinaryReservations", "DateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VeterinaryReservations", "DateTime");
        }
    }
}
