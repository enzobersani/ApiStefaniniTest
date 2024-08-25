using API.StefaniniTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.StefaniniTest.Infrastructure.Context.TypeConfiguration
{
    public class ItemPedidoTypeConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItensPedido");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .UseIdentityColumn();

            builder.Property(i => i.IdPedido)
                .HasColumnName("IdPedido")
                .IsRequired();

            builder.Property(i => i.IdProduto)
                .HasColumnName("IdProduto")
                .IsRequired();

            builder.Property(i => i.Quantidade)
                .IsRequired();

            builder.HasOne(i => i.Pedidos)
                .WithMany(p => p.ItensPedidos)
                .HasForeignKey(i => i.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Produtos)
                .WithMany(p => p.ItensPedidos)
                .HasForeignKey(i => i.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
