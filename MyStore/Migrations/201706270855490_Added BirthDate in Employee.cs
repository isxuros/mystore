namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthDateinEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "BirthDate");
        }
    }
}
