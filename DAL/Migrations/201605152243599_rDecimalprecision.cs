namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rDecimalprecision : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtoes", "Preco", c => c.Decimal(nullable: false, precision: 8, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
