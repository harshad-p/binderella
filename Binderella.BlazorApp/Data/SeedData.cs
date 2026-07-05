using RecipeBook.Models;

namespace RecipeBook.Data;

public static class SeedData
{
    public static void Initialize(RecipeContext db)
    {
        if (db.Recipes.Any())
        {
            return;
        }

        var recipe = new Recipe
        {
            Title = "Chicken Masala",
            ChefName = "Mom",
            ChefUrl = null,
            ClosingLine = "The Chicken Masala is ready!",
            DateAdded = DateTime.Now,
            Ingredients = new List<RecipeIngredient>
            {
                new() { Quantity = "500g", Name = "chicken, cut into pieces", SortOrder = 0 },
                new() { Quantity = "2", Name = "onions, finely chopped", SortOrder = 1 },
                new() { Quantity = "2 tbsp", Name = "ginger-garlic paste", SortOrder = 2 },
                new() { Quantity = "2", Name = "tomatoes, pureed", SortOrder = 3 },
                new() { Quantity = "1 tsp", Name = "turmeric powder", SortOrder = 4 },
                new() { Quantity = "2 tsp", Name = "garam masala", SortOrder = 5 },
                new() { Quantity = "to taste", Name = "salt", SortOrder = 6 },
                new() { Quantity = "2 tbsp", Name = "oil", SortOrder = 7 },
            },
            Steps = new List<RecipeStep>
            {
                new() { Description = "Heat oil in a pan and saute the onions until golden brown.", SortOrder = 0 },
                new() { Description = "Add ginger-garlic paste and cook until the raw smell disappears.", SortOrder = 1 },
                new() { Description = "Add tomato puree, turmeric, and salt. Cook until oil separates.", SortOrder = 2 },
                new() { Description = "Add the chicken pieces and mix well to coat with the masala.", SortOrder = 3 },
                new() { Description = "Cover and cook on low heat for 15-20 minutes, stirring occasionally.", SortOrder = 4 },
                new() { Description = "Sprinkle garam masala, mix, and simmer for another 5 minutes.", SortOrder = 5 },
            }
        };

        db.Recipes.Add(recipe);
        db.SaveChanges();
    }
}
