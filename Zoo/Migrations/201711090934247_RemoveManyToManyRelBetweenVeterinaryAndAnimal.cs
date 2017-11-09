namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveManyToManyRelBetweenVeterinaryAndAnimal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VeterinaryAnimals", "Veterinary_VeterinaryId", "dbo.Veterinaries");
            DropForeignKey("dbo.VeterinaryAnimals", "Animal_AnimalId", "dbo.Animals");
            DropIndex("dbo.VeterinaryAnimals", new[] { "Veterinary_VeterinaryId" });
            DropIndex("dbo.VeterinaryAnimals", new[] { "Animal_AnimalId" });
            DropTable("dbo.VeterinaryAnimals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VeterinaryAnimals",
                c => new
                    {
                        Veterinary_VeterinaryId = c.Int(nullable: false),
                        Animal_AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Veterinary_VeterinaryId, t.Animal_AnimalId });
            
            CreateIndex("dbo.VeterinaryAnimals", "Animal_AnimalId");
            CreateIndex("dbo.VeterinaryAnimals", "Veterinary_VeterinaryId");
            AddForeignKey("dbo.VeterinaryAnimals", "Animal_AnimalId", "dbo.Animals", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.VeterinaryAnimals", "Veterinary_VeterinaryId", "dbo.Veterinaries", "VeterinaryId", cascadeDelete: true);
        }
    }
}
