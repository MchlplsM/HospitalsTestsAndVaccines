namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicRemarks = c.String(),
                        Diagnosis = c.String(),
                        SecondDiagnosis = c.String(),
                        ThirdDiagnosis = c.String(),
                        Therapy = c.String(),
                        Date = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "ApplicationUserId" });
            DropTable("dbo.Attendances");
        }
    }
}
