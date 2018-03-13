using GeekBurger.Ingredients.Api.Data.Mappings;
using GeekBurger.Ingredients.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Ingredients.Api.Data.Context
{
    public class GeekBurgerContext: DbContext
    {
        public GeekBurgerContext(DbContextOptions<GeekBurgerContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            modelBuilder.ApplyConfiguration(new IngredientMap());
        }
    }
}
