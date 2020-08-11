namespace WebApiOAuth2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnHireDateConvertItToDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "HiringDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "HiringDate", c => c.DateTime(nullable: false));
        }
    }
}
