using System.Collections.Generic;

namespace RecipeApi.Models
{
    
    public class RecipeItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }
    }
}