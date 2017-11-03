namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustNamesForChildParentAnimalsJoinTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AnimalAnimals", newName: "ChildParentAnimals");
            RenameColumn(table: "dbo.ChildParentAnimals", name: "Animal_AnimalId", newName: "ChildAnimalId");
            RenameColumn(table: "dbo.ChildParentAnimals", name: "Animal_AnimalId1", newName: "ParentAnimalId");
            RenameIndex(table: "dbo.ChildParentAnimals", name: "IX_Animal_AnimalId", newName: "IX_ChildAnimalId");
            RenameIndex(table: "dbo.ChildParentAnimals", name: "IX_Animal_AnimalId1", newName: "IX_ParentAnimalId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ChildParentAnimals", name: "IX_ParentAnimalId", newName: "IX_Animal_AnimalId1");
            RenameIndex(table: "dbo.ChildParentAnimals", name: "IX_ChildAnimalId", newName: "IX_Animal_AnimalId");
            RenameColumn(table: "dbo.ChildParentAnimals", name: "ParentAnimalId", newName: "Animal_AnimalId1");
            RenameColumn(table: "dbo.ChildParentAnimals", name: "ChildAnimalId", newName: "Animal_AnimalId");
            RenameTable(name: "dbo.ChildParentAnimals", newName: "AnimalAnimals");
        }
    }
}
