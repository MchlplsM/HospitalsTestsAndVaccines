namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NaSouPethanei : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "AspNetUser_Id" });
            AddColumn("dbo.Orders", "Product_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Products", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            CreateIndex("dbo.Orders", "Product_Id");
            CreateIndex("dbo.Orders", "User_Id");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "CustomerId");
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            DropColumn("dbo.Products", "NumberAvailable");
            DropColumn("dbo.Orders", "User_Id");
            DropColumn("dbo.Orders", "Product_Id");
            CreateIndex("dbo.Customers", "AspNetUser_Id");
            AddForeignKey("dbo.Customers", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
