using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }

        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Direction> Directions { get; set; }
    }
}