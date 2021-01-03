namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsInheritsFromProductsPerHospital1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "HospitalId", c => c.Int());
            AddColumn("dbo.Hospitals", "ProductName", c => c.String());
            AddColumn("dbo.Hospitals", "ProductCategory", c => c.Int());
            AddColumn("dbo.Hospitals", "Description", c => c.String());
            AddColumn("dbo.Hospitals", "Price", c => c.Double());
            AddColumn("dbo.Hospitals", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HospitalId = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                        ProductCategory = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Hospitals", "Discriminator");
            DropColumn("dbo.Hospitals", "Price");
            DropColumn("dbo.Hospitals", "Description");
            DropColumn("dbo.Hospitals", "ProductCategory");
            DropColumn("dbo.Hospitals", "ProductName");
            DropColumn("dbo.Hospitals", "HospitalId");
        }
    }
}
