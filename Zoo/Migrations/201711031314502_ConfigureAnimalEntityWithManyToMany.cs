namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureAnimalEntityWithManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "Animal_AnimalId", "dbo.Animals");
            DropIndex("dbo.Animals", new[] { "Animal_AnimalId" });
            CreateTable(
                "dbo.AnimalAnimals",
                c => new
                    {
                        Animal_AnimalId = c.Int(nullable: false),
                        Animal_AnimalId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Animal_AnimalId, t.Animal_AnimalId1 })
                .ForeignKey("dbo.Animals", t => t.Animal_AnimalId)
                .ForeignKey("dbo.Animals", t => t.Animal_AnimalId1)
                .Index(t => t.Animal_AnimalId)
                .Index(t => t.Animal_AnimalId1);
            
            DropColumn("dbo.Animals", "Animal_AnimalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Animal_AnimalId", c => c.Int());
            DropForeignKey("dbo.AnimalAnimals", "Animal_AnimalId1", "dbo.Animals");
            DropForeignKey("dbo.AnimalAnimals", "Animal_AnimalId", "dbo.Animals");
            DropIndex("dbo.AnimalAnimals", new[] { "Animal_AnimalId1" });
            DropIndex("dbo.AnimalAnimals", new[] { "Animal_AnimalId" });
            DropTable("dbo.AnimalAnimals");
            CreateIndex("dbo.Animals", "Animal_AnimalId");
            AddForeignKey("dbo.Animals", "Animal_AnimalId", "dbo.Animals", "AnimalId");
        }
    }
}
