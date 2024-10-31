namespace BanHangThoiTrangMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecreateday : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
