using System.Collections.Generic;
using System.Text;

namespace ApiClient.Models
{
    
    public class RecipeItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }

        // Override ToString method for proper displaying the recipe properties.
        public override string ToString(){
            var result = new StringBuilder();

            result.Append("Name: " + this.Name + System.Environment.NewLine);
            result.Append("Description: " + this.Description + System.Environment.NewLine);
            result.Append("List of Ingredients: " + System.Environment.NewLine);

            foreach(Ingredient item in this.Ingredients){
                result.Append("- Ingredient: " + item.ToString() + ", ");
                result.Append("- Quantity: " + item.ToString() + ", ");
                result.Append("- UOM: " + item.ToString() + System.Environment.NewLine);
            }

            result.Append("List of Directions: " + System.Environment.NewLine);

            foreach(Direction item in this.Directions){
                result.Append("- Direction: " + item.ToString() + System.Environment.NewLine);
            }

            return result.ToString();
        }
    }
}