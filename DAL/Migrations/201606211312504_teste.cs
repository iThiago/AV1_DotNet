namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.Pedidoes", "Cliente_Id");
            AddForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Pedidoes", new[] { "Cliente_Id" });
            DropColumn("dbo.Pedidoes", "Cliente_Id");
        }
    }
}
