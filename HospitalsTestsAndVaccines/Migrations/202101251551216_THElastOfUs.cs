namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class THElastOfUs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "ApplicationUserId" });
            DropColumn("dbo.Products", "NumberAvailable");
            DropTable("dbo.Attendances");
            DropTable("dbo.Payments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "NumberAvailable", c => c.Byte(nullable: false));
            CreateIndex("dbo.Attendances", "ApplicationUserId");
            AddForeignKey("dbo.Attendances", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
