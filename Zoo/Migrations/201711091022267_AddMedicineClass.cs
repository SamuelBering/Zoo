namespace Zoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedicineClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.MedicineDiagnosis",
                c => new
                    {
                        Medicine_MedicineId = c.Int(nullable: false),
                        Diagnosis_DiagnosisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Medicine_MedicineId, t.Diagnosis_DiagnosisId })
                .ForeignKey("dbo.Medicines", t => t.Medicine_MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.Diagnoses", t => t.Diagnosis_DiagnosisId, cascadeDelete: true)
                .Index(t => t.Medicine_MedicineId)
                .Index(t => t.Diagnosis_DiagnosisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineDiagnosis", "Diagnosis_DiagnosisId", "dbo.Diagnoses");
            DropForeignKey("dbo.MedicineDiagnosis", "Medicine_MedicineId", "dbo.Medicines");
            DropIndex("dbo.MedicineDiagnosis", new[] { "Diagnosis_DiagnosisId" });
            DropIndex("dbo.MedicineDiagnosis", new[] { "Medicine_MedicineId" });
            DropTable("dbo.MedicineDiagnosis");
            DropTable("dbo.Medicines");
        }
    }
}
