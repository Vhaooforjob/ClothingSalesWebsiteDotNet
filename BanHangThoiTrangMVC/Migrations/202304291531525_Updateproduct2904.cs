namespace BanHangThoiTrangMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateproduct2904 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_ProductImage", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductImage", new[] { "Product_Id" });
            RenameColumn(table: "dbo.tb_ProductImage", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.tb_ProductImage", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_ProductImage", "ProductId");
            AddForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            DropColumn("dbo.tb_ProductImage", "PriductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductImage", "PriductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductId" });
            AlterColumn("dbo.tb_ProductImage", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.tb_ProductImage", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.tb_ProductImage", "Product_Id");
            AddForeignKey("dbo.tb_ProductImage", "Product_Id", "dbo.tb_Product", "Id");
        }
    }
}
