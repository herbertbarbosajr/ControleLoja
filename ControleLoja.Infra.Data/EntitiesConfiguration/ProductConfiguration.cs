using ControleLoja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLoja.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descrição).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Preço).HasPrecision(10, 2);

            builder.HasOne(e => e.Category).WithMany(e => e.Produtos)
                .HasForeignKey(e => e.CategoriaId);
        }
    }
}
