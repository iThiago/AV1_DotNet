namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemPedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.ItemPedidoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.ItemPedidoes", new[] { "ProdutoId" });
            DropIndex("dbo.ItemPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            AlterColumn("dbo.ItemPedidoes", "ProdutoId", c => c.Int());
            AlterColumn("dbo.ItemPedidoes", "PedidoId", c => c.Int());
            AlterColumn("dbo.Pedidoes", "ClienteId", c => c.Int());
            CreateIndex("dbo.ItemPedidoes", "ProdutoId");
            CreateIndex("dbo.ItemPedidoes", "PedidoId");
            CreateIndex("dbo.Pedidoes", "ClienteId");
            AddForeignKey("dbo.ItemPedidoes", "PedidoId", "dbo.Pedidoes", "Id");
            AddForeignKey("dbo.ItemPedidoes", "ProdutoId", "dbo.Produtoes", "Id");
            AddForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ItemPedidoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.ItemPedidoes", "PedidoId", "dbo.Pedidoes");
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            DropIndex("dbo.ItemPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.ItemPedidoes", new[] { "ProdutoId" });
            AlterColumn("dbo.Pedidoes", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.ItemPedidoes", "PedidoId", c => c.Int(nullable: false));
            AlterColumn("dbo.ItemPedidoes", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pedidoes", "ClienteId");
            CreateIndex("dbo.ItemPedidoes", "PedidoId");
            CreateIndex("dbo.ItemPedidoes", "ProdutoId");
            AddForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemPedidoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemPedidoes", "PedidoId", "dbo.Pedidoes", "Id", cascadeDelete: true);
        }
    }
}
