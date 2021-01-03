namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeingKeysAtContactDetails : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "PostalCode");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "PostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
        }
    }
}
