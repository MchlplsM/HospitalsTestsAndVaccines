namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calendar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "EndDate");
        }
    }
}
