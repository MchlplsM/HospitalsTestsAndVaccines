namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        OrderStatus = c.Boolean(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Orders", "User_Id");
            CreateIndex("dbo.Orders", "Product_Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
