namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullAddOfDetailsToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Amka", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "HealthIssues", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "HealthIssues");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "Amka");
        }
    }
}
