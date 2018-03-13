using GeekBurger.Ingredients.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekBurger.Ingredients.Api.Data.Mappings
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.Id)
                .IsUnique(true);

            builder.Property(m => m.Id)
              .ValueGeneratedNever();

            builder.HasMany(m => m.Ingredients)
                .WithOne(m => m.Item)
                .HasForeignKey(m => m.ItemId);
        }
    }
}
