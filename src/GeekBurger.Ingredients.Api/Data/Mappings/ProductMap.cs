using GeekBurger.Ingredients.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekBurger.Ingredients.Api.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.Id)
                .IsUnique(true);

            builder.Property(m => m.Id)
              .ValueGeneratedNever();

            builder.HasMany(m => m.Items)
                .WithOne(m => m.Product)
                .HasForeignKey(m => m.ProductId);
        }
    }
}
