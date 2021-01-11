namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Phone = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Address = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            AddColumn("dbo.Appointments", "DoctorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "ApplicationUserId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropColumn("dbo.Appointments", "DoctorId");
            DropTable("dbo.Doctors");
        }
    }
}
