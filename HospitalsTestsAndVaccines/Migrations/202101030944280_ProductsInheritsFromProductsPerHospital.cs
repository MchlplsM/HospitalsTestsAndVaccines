namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsInheritsFromProductsPerHospital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "ProductId");
        }
    }
}
