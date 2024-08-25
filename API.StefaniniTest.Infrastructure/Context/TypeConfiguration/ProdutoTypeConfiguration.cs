using API.StefaniniTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Infrastructure.Context.TypeConfiguration
{
    public class ProdutoTypeConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeProduto).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Valor).HasColumnType("decimal(10,2)").IsRequired();

            builder.HasMany(p => p.ItensPedidos)
                   .WithOne(i => i.Produtos)
                   .HasForeignKey(i => i.IdProduto);
        }
    }
}
