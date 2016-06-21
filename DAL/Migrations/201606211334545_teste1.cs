namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemPedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.ItemPedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Cliente_Id" });
            RenameColumn(table: "dbo.ItemPedidoes", name: "Produto_Id", newName: "ProdutoId");
            RenameColumn(table: "dbo.Pedidoes", name: "Cliente_Id", newName: "ClienteId");
            AlterColumn("dbo.ItemPedidoes", "ProdutoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pedidoes", "ClienteId", c => c.Int(nullable: true));
            CreateIndex("dbo.ItemPedidoes", "ProdutoId");
            CreateIndex("dbo.Pedidoes", "ClienteId");
            AddForeignKey("dbo.ItemPedidoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ItemPedidoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            DropIndex("dbo.ItemPedidoes", new[] { "ProdutoId" });
            AlterColumn("dbo.Pedidoes", "ClienteId", c => c.Int());
            AlterColumn("dbo.ItemPedidoes", "ProdutoId", c => c.Int());
            RenameColumn(table: "dbo.Pedidoes", name: "ClienteId", newName: "Cliente_Id");
            RenameColumn(table: "dbo.ItemPedidoes", name: "ProdutoId", newName: "Produto_Id");
            CreateIndex("dbo.Pedidoes", "Cliente_Id");
            CreateIndex("dbo.ItemPedidoes", "Produto_Id");
            AddForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Clientes", "Id");
            AddForeignKey("dbo.ItemPedidoes", "Produto_Id", "dbo.Produtoes", "Id");
        }
    }
}
