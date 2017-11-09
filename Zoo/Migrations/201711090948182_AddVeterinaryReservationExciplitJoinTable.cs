namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVeterinaryReservationExciplitJoinTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VeterinaryReservations",
                c => new
                    {
                        VeterinaryId = c.Int(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VeterinaryId, t.AnimalId })
                .ForeignKey("dbo.Animals", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.Veterinaries", t => t.VeterinaryId, cascadeDelete: true)
                .Index(t => t.VeterinaryId)
                .Index(t => t.AnimalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VeterinaryReservations", "VeterinaryId", "dbo.Veterinaries");
            DropForeignKey("dbo.VeterinaryReservations", "AnimalId", "dbo.Animals");
            DropIndex("dbo.VeterinaryReservations", new[] { "AnimalId" });
            DropIndex("dbo.VeterinaryReservations", new[] { "VeterinaryId" });
            DropTable("dbo.VeterinaryReservations");
        }
    }
}
