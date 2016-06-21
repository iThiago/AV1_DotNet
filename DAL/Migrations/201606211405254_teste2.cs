namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemPedidoes", "Pedido_Id", "dbo.Pedidoes");
            DropIndex("dbo.ItemPedidoes", new[] { "Pedido_Id" });
            RenameColumn(table: "dbo.ItemPedidoes", name: "Pedido_Id", newName: "PedidoId");
            AlterColumn("dbo.ItemPedidoes", "PedidoId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemPedidoes", "PedidoId");
            AddForeignKey("dbo.ItemPedidoes", "PedidoId", "dbo.Pedidoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedidoes", "PedidoId", "dbo.Pedidoes");
            DropIndex("dbo.ItemPedidoes", new[] { "PedidoId" });
            AlterColumn("dbo.ItemPedidoes", "PedidoId", c => c.Int());
            RenameColumn(table: "dbo.ItemPedidoes", name: "PedidoId", newName: "Pedido_Id");
            CreateIndex("dbo.ItemPedidoes", "Pedido_Id");
            AddForeignKey("dbo.ItemPedidoes", "Pedido_Id", "dbo.Pedidoes", "Id");
        }
    }
}
