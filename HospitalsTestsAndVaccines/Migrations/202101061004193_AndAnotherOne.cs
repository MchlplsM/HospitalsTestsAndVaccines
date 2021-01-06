namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AndAnotherOne : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "HospitalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "HospitalId", c => c.Int(nullable: false));
        }
    }
}
