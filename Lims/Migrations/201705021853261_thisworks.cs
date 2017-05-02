namespace Lims.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thisworks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "DepartmentName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "DepartmentName");
        }
    }
}
