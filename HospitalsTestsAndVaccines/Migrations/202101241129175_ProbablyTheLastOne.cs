namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProbablyTheLastOne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Detail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Detail", c => c.String());
        }
    }
}
