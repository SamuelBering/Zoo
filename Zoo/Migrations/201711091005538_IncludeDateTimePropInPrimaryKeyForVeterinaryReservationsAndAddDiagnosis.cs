namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeDateTimePropInPrimaryKeyForVeterinaryReservationsAndAddDiagnosis : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VeterinaryReservations");
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        DiagnosisId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DiagnosisId);
            
            AddColumn("dbo.VeterinaryReservations", "Diagnosis_DiagnosisId", c => c.Int());
            AlterColumn("dbo.VeterinaryReservations", "DateTime", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.VeterinaryReservations", new[] { "VeterinaryId", "AnimalId", "DateTime" });
            CreateIndex("dbo.VeterinaryReservations", "Diagnosis_DiagnosisId");
            AddForeignKey("dbo.VeterinaryReservations", "Diagnosis_DiagnosisId", "dbo.Diagnoses", "DiagnosisId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VeterinaryReservations", "Diagnosis_DiagnosisId", "dbo.Diagnoses");
            DropIndex("dbo.VeterinaryReservations", new[] { "Diagnosis_DiagnosisId" });
            DropPrimaryKey("dbo.VeterinaryReservations");
            AlterColumn("dbo.VeterinaryReservations", "DateTime", c => c.DateTime());
            DropColumn("dbo.VeterinaryReservations", "Diagnosis_DiagnosisId");
            DropTable("dbo.Diagnoses");
            AddPrimaryKey("dbo.VeterinaryReservations", new[] { "VeterinaryId", "AnimalId" });
        }
    }
}
