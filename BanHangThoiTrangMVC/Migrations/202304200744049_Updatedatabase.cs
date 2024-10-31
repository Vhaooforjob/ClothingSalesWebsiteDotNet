namespace BanHangThoiTrangMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Category", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Category", "CategoryId", c => c.Int(nullable: false));
        }
    }
}
