namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVeterinaryClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Veterinaries",
                c => new
                    {
                        VeterinaryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VeterinaryId);
            
            CreateTable(
                "dbo.VeterinaryAnimals",
                c => new
                    {
                        Veterinary_VeterinaryId = c.Int(nullable: false),
                        Animal_AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Veterinary_VeterinaryId, t.Animal_AnimalId })
                .ForeignKey("dbo.Veterinaries", t => t.Veterinary_VeterinaryId, cascadeDelete: true)
                .ForeignKey("dbo.Animals", t => t.Animal_AnimalId, cascadeDelete: true)
                .Index(t => t.Veterinary_VeterinaryId)
                .Index(t => t.Animal_AnimalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VeterinaryAnimals", "Animal_AnimalId", "dbo.Animals");
            DropForeignKey("dbo.VeterinaryAnimals", "Veterinary_VeterinaryId", "dbo.Veterinaries");
            DropIndex("dbo.VeterinaryAnimals", new[] { "Animal_AnimalId" });
            DropIndex("dbo.VeterinaryAnimals", new[] { "Veterinary_VeterinaryId" });
            DropTable("dbo.VeterinaryAnimals");
            DropTable("dbo.Veterinaries");
        }
    }
}
