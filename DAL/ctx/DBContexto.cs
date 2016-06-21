using model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBContexto : DbContext
    {

        public DBContexto() : base("Ecommerce") { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<decimal>()
               .Configure(p => p.HasColumnType("Decimal"));

            modelBuilder.Properties<decimal>()
               .Configure(p => p.HasPrecision(8, 2));

            modelBuilder.Entity<Cliente>()
              .Property(c => c.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Cpf).HasMaxLength(11).IsRequired();

        }

    }
}
