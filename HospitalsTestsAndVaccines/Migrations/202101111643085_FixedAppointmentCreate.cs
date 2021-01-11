namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAppointmentCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "ProductId", c => c.String());
            AddColumn("dbo.Appointments", "Product_Id", c => c.Int());
            CreateIndex("dbo.Appointments", "Product_Id");
            AddForeignKey("dbo.Appointments", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Product_Id", "dbo.Products");
            DropIndex("dbo.Appointments", new[] { "Product_Id" });
            DropColumn("dbo.Appointments", "Product_Id");
            DropColumn("dbo.Appointments", "ProductId");
        }
    }
}
