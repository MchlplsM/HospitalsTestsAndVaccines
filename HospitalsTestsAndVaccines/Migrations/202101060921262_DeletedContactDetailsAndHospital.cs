namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedContactDetailsAndHospital : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hospitals", "Product_Id", "dbo.Products");
            DropIndex("dbo.Hospitals", new[] { "Product_Id" });
            AddColumn("dbo.Customers", "AspNetUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "AspNetUser_Id");
            AddForeignKey("dbo.Customers", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "DateOfBirth");
            DropColumn("dbo.Customers", "Amka");
            DropColumn("dbo.Customers", "HealthIssues");
            DropTable("dbo.Hospitals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "HealthIssues", c => c.String());
            AddColumn("dbo.Customers", "Amka", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            DropForeignKey("dbo.Customers", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "AspNetUser_Id" });
            DropColumn("dbo.Customers", "AspNetUser_Id");
            CreateIndex("dbo.Hospitals", "Product_Id");
            AddForeignKey("dbo.Hospitals", "Product_Id", "dbo.Products", "Id");
        }
    }
}
