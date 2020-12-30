namespace HospitalsTestsAndVaccines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ContactDetails_Id", c => c.Int());
            CreateIndex("dbo.Customers", "ContactDetails_Id");
            AddForeignKey("dbo.Customers", "ContactDetails_Id", "dbo.ContactDetails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ContactDetails_Id", "dbo.ContactDetails");
            DropIndex("dbo.Customers", new[] { "ContactDetails_Id" });
            DropColumn("dbo.Customers", "ContactDetails_Id");
        }
    }
}
