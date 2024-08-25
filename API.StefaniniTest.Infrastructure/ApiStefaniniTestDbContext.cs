using API.StefaniniTest.Domain.Entities;
using API.StefaniniTest.Infrastructure.Context.TypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace API.StefaniniTest.Infrastructure
{
    public class ApiStefaniniTestDbContext : DbContext
    {
        public ApiStefaniniTestDbContext(DbContextOptions<ApiStefaniniTestDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
