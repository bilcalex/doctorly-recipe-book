using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiClient.Models;

namespace RecipesHttpClient
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowRecipe(RecipeItem recipe)
        {
            Console.WriteLine(recipe.ToString());
        }

        static async Task<Uri> CreateRecipeAsync(RecipeItem recipe)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/recipes", recipe);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<RecipeItem> GetRecipeItemAsync(string path)
        {
            RecipeItem recipe = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                recipe = await response.Content.ReadAsAsync<RecipeItem>();
            }
            return recipe;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a list of ingredients
                var listOfIngredients = new List<Ingredient>()
                {
                    new Ingredient {
                        Name = "Beef Meat",
                        Quantity = 2,
                        UOM = "KG"
                    },
                    new Ingredient {
                        Name = "Carrots",
                        Quantity = 1,
                        UOM = "KG"
                    }
                };

                // Create a list of directions
                var listOfDirections = new List<Direction>()
                {
                    new Direction {
                        Name = "Cut the beef meat in tiny squares.",
                    },
                    new Direction {
                        Name = "Cut the carrots in tiny slices."
                    }
                };

                // Create a new recipe
                RecipeItem recipe = new RecipeItem
                {
                    Name = "Beef Soup",
                    Description = "A sour soup with a beef base.",
                    Ingredients = listOfIngredients,
                    Directions = listOfDirections
                };

                var url = await CreateRecipeAsync(recipe);
                Console.WriteLine($"Created at {url}");

                // Get the recipe
                recipe = await GetRecipeItemAsync(url.PathAndQuery);
                ShowRecipe(recipe);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
            }

            Console.ReadLine();
        }
    }
}