using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p => p.Price).HasColumnType("decimal(18,4)");
            builder.Property(p => p.DiscountPercentage).HasColumnType("decimal(18,4)");
            builder.Property(p => p.Rating).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.Thumbnail).IsRequired();
            builder.HasMany(p => p.Images).WithOne(i => i.Product).HasForeignKey(i => i.ProductId);
            builder.HasOne(b => b.Brand).WithMany().HasForeignKey(p => p.BrandId);
            builder.HasOne(t => t.Type).WithMany().HasForeignKey(p => p.TypeId);
        }
    }
}
