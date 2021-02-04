namespace AppDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ExpDetail", c => c.String());
            DropColumn("dbo.AspNetUsers", "Exp_Detail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Exp_Detail", c => c.String());
            DropColumn("dbo.AspNetUsers", "ExpDetail");
        }
    }
}
