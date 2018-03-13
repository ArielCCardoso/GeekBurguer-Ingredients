using GeekBurger.Ingredients.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekBurger.Ingredients.Api.Data.Mappings
{
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredients");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.Id)
                .IsUnique(true);

            builder.Property(m => m.Id)
              .ValueGeneratedNever();

            builder.HasOne(m => m.Item)
                .WithMany(m => m.Ingredients)
                .HasForeignKey(m => m.ItemId);
        }
    }
}
